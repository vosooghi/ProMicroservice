using RabbitMQ.Client;
var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost"

};
using var connection = connectionFactory.CreateConnection();
using var channel = connection.CreateModel();//multithreading
channel.ConfirmSelect();

string exchangeName = "MailBoxTopicExchange";

channel.ExchangeDeclare(exchangeName, ExchangeType.Topic, false, false, null);

Console.WriteLine("Type your message: ");
string message = Console.ReadLine() ?? "Default Message";
Console.WriteLine("Which network do you want to send your message with? type [sms] or [email]: ");


string routKey = $"message.{Console.ReadLine()}";

//persistent message
var messageProperty = channel.CreateBasicProperties();
messageProperty.Persistent = true;


var messageByts = System.Text.Encoding.UTF8.GetBytes(message);


channel.BasicPublish(exchangeName, routKey, messageProperty, messageByts);


Console.WriteLine("[*]Your Message Sent[*]. Press any key to exit.");
Console.ReadKey();