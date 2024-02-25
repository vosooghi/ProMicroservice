using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Concurrent;
using System.Reflection.Emit;
using System.Threading.Channels;

namespace RabbitMqSamples.RPC.AsyncClient.Models
{
    public class CustomerCaller
    {
        private readonly IConnection _connection;
        private readonly IModel _model;
        private readonly EventingBasicConsumer _consumer;
        private readonly BlockingCollection<Customer> _customers = new BlockingCollection<Customer>();
        private readonly IBasicProperties _basicProperties;
        private readonly string replyTo = "rpc.get.customer.async.client";
        private readonly string exchangeName = "RpcSampleExchange";
        private readonly string requestRouteKey = "rpc.get.customer.request";
        //async
        private readonly Action<Customer> _action;
        public CustomerCaller(Action<Customer> customerAction)
        {
            _action = customerAction;

            var facotry = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            _connection = facotry.CreateConnection();
            _model = _connection.CreateModel();
            string queueName = _model.QueueDeclare().QueueName;


            _model.ExchangeDeclare(exchangeName, ExchangeType.Topic, false, false, null);

            _model.QueueBind(queueName, exchangeName, replyTo, null);

            _consumer = new EventingBasicConsumer(_model);
            _consumer.Received += _consumer_Received;
            _model.BasicConsume(queueName, true, _consumer);
        }

        private void _consumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            var customerByte = e.Body.ToArray();
            var customerString = System.Text.Encoding.UTF8.GetString(customerByte);
            var customer = JsonConvert.DeserializeObject<Customer>(customerString);

            //async
            _action(customer);
        }

        public void Get(int id)
        {
            var message = System.Text.Encoding.UTF8.GetBytes(id.ToString());
            var props = _model.CreateBasicProperties();
            props.CorrelationId = id.ToString();
            props.ReplyTo = replyTo;

            _model.BasicPublish(exchangeName, requestRouteKey, props, message);

            Console.WriteLine($"the request for customer {id} sent");
        }

        public void CloseConnection()
        {
            _connection.Close();
        }
    }
}
