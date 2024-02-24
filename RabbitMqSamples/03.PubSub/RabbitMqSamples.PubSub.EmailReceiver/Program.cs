using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost"

};
using var connection = connectionFactory.CreateConnection();
using var channel = connection.CreateModel();//multithreading

string exchangeName = "MyMessageExchange";
channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout, false, false, null);

//the queue name doesn't matter
var queueName = channel.QueueDeclare().QueueName;
channel.QueueBind(queueName, exchangeName, "", null);

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
    Console.WriteLine($"[-] Start Sending Email: {message}");

}