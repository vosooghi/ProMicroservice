using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqSamples.RPC.Server.Models;

var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost"

};
using var connection = connectionFactory.CreateConnection();
using var channel = connection.CreateModel();//multithreading

CustomerRepository _customerRepository = new CustomerRepository();

string exchangeName = "RpcSampleExchange";
channel.ExchangeDeclare(exchangeName, ExchangeType.Topic, false, false, null);

//the queue name doesn't matter
var queueName = channel.QueueDeclare().QueueName;
channel.QueueBind(queueName, exchangeName, "rpc.get.customer.request", null);

//define event-based consumer
var consumer = new EventingBasicConsumer(channel);
consumer.Received += Consumer_Received;
channel.BasicConsume(queueName, true, consumer);//it doesn't send ack automatically.


Console.WriteLine("Press Enter To Exit.");
Console.ReadLine();

void Consumer_Received(object? sender, BasicDeliverEventArgs e)
{
    var body = e.Body;
    var message = System.Text.Encoding.UTF8.GetString(body.ToArray());

    int customerId = int.Parse(message);
    Customer customer = _customerRepository.GetById(customerId);
    var customerByteArray = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(customer));

    var requestProperties = e.BasicProperties;
    var correlationId = requestProperties.CorrelationId;
    var routingKey = requestProperties.ReplyTo;

    var responseProperty = channel.CreateBasicProperties();
    responseProperty.CorrelationId = correlationId;

    channel.BasicPublish(exchangeName, routingKey, responseProperty, customerByteArray);
    Thread.Sleep(5000);
    Console.WriteLine($"[-] Start Sending SMS: {message}");

}