using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost"

};
using var connection = connectionFactory.CreateConnection();
using var channel = connection.CreateModel();//multithreading

//Consumer may be up before Producer, so we should declare the queue.
//Declaring queues is an idempotent task.
string queueName = "LoadBalancing";
//create queue
channel.QueueDeclare(queueName, true, false, false, null);

//define event-based consumer
var consumer = new EventingBasicConsumer(channel);
consumer.Received += Consumer_Received;
channel.BasicConsume(queueName, false, consumer);//it doesn't send ack automatically.


Console.WriteLine("Press Enter To Exit.");
Console.ReadLine();

void Consumer_Received(object? sender, BasicDeliverEventArgs e)
{
    var body = e.Body;
    var message = System.Text.Encoding.UTF8.GetString(body.ToArray());    
    Console.WriteLine($"[-] Start Processing Message: {message}");
    Thread.Sleep(5000);
    Console.WriteLine("[-] Processing Message Finished.");

    channel.BasicAck(e.DeliveryTag, false);//we send ack here.
}