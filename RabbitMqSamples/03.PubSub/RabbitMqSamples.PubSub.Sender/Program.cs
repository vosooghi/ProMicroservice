using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost"

};
using var connection = connectionFactory.CreateConnection();
using var channel = connection.CreateModel();//multithreading
channel.ConfirmSelect();

string exchangeName = "MyMessageExchange";

channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout, false, false, null);

Console.WriteLine("Type your message: ");
string message = Console.ReadLine() ?? "Default Message";

//persistent message
var messageProperty = channel.CreateBasicProperties();
messageProperty.Persistent = true;


var messageByts = System.Text.Encoding.UTF8.GetBytes(message);


channel.BasicPublish(exchangeName,"", messageProperty, messageByts);


Console.WriteLine("[*]Your Message Sent[*]. Press any key to exit.");
Console.ReadKey();