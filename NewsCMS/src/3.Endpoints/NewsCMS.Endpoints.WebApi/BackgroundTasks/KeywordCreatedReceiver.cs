
using Ground.Core.Domain.Events;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Data.SqlClient;

namespace NewsCMS.Endpoints.WebApi.BackgroundTasks
{
    public class KeywordCreatedReceiver : BackgroundService
    {
        #region Props
        private readonly IConnection _connection;
        private readonly IModel _model;
        private readonly string _exchangeName = "NewsCmsExchange";
        private readonly string _routingKey = "NewsCmsExchange.BasicInfo.Event.KeywordCreated";
        private string _queueName ;
        private int _messageCount;
        private EventingBasicConsumer _consumer;

        private readonly SqlConnection _sqlConnection = new SqlConnection("server=.;initial catalog = NewsCMSDb; user id=sa;password=P@ssw0rd;encrypt=false");
        #endregion

        public KeywordCreatedReceiver()
        {            
            var facotry = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            _connection = facotry.CreateConnection();
            _model = _connection.CreateModel();
            _model.ExchangeDeclare(_exchangeName, ExchangeType.Topic, false, false, null);
            _queueName = _model.QueueDeclare().QueueName;
            _model.QueueBind(_queueName, _exchangeName, _routingKey, null);
            _consumer = new EventingBasicConsumer(_model);
            _consumer.Received += consumer_Received;
            _model.BasicConsume(_queueName, true, _consumer);
            
            Console.WriteLine("Start Receiving Events...");
            _sqlConnection.Open();

        }

        private void consumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            string message = System.Text.Encoding.UTF8.GetString(e.Body.ToArray());
            var keywordEvent = JsonConvert.DeserializeObject<KeywordCreatedDto>(message);
            
            string command = $"INSERT INTO [dbo].[Keyword] ([KeywordBusinessId],[KeywordTitle])VALUES('{keywordEvent.BusinessId}',N'{keywordEvent.Title}')";
            SqlCommand sqlCommand = new SqlCommand(command, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
            
            _messageCount++;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine($"Message Count at {DateTime.Now} is {_messageCount}");                
                await Task.Delay(10000);
            }
        }
    }

    public class KeywordCreatedDto
    {
        public Guid BusinessId { get; set; }
        public string Title { get; set; }
    }
}
