using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost"

};
using var connection = connectionFactory.CreateConnection();
using var channel = connection.CreateModel();//multithreading
channel.ConfirmSelect();

string queueName = "LoadBalancing";
//create queue with durablility
channel.QueueDeclare(queueName, true, false, false, null);

Console.WriteLine("Type your message: ");
string message = Console.ReadLine() ?? "Default Message";

//persistent message
var messageProperty = channel.CreateBasicProperties();
messageProperty.Persistent = true;

for (int i = 0; i < 20; i++)
{
    var messageByts = System.Text.Encoding.UTF8.GetBytes(message+" "+ i);

    //In Default exchange, routing key equals queue name
    channel.BasicPublish(string.Empty, queueName,messageProperty, messageByts);
    
    if (channel.WaitForConfirms(TimeSpan.FromSeconds(5)))
        Console.WriteLine($"[*]Message number {i} received by RabbitMQ.");
    else Console.WriteLine($"[*] Message number {i} is not received by RabbitMQ !*!");

    Thread.Sleep(1000);
}


Console.WriteLine("[*]Your Message Sent[*]. Press any key to exit.");
Console.ReadKey();