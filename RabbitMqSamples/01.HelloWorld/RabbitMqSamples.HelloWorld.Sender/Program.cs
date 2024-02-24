using RabbitMQ.Client;
var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost"

};
using var connection = connectionFactory.CreateConnection();
using var channel = connection.CreateModel();//multithreading

string queueName = "HelloWorld";
//create queue
channel.QueueDeclare(queueName, false, false, false, null);

Console.WriteLine("Type your message: ");
string message = Console.ReadLine() ?? "Default Message";
var messageByts = System.Text.Encoding.UTF8.GetBytes(message.ToCharArray());

//In Default exchange, routing key equals queue name
channel.BasicPublish(string.Empty, queueName, null, messageByts);

Console.WriteLine("[*]Your Message Sent[*]. Press any key to exit.");
Console.ReadKey();