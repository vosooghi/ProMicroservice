
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Collections.Concurrent;
using BasicInfo.Infra.Data.Sql.Commands.Common;
using Microsoft.EntityFrameworkCore;

namespace BasicInfo.Endpoints.WebApi.BackgroundTasks
{
    public class EventPublisher : BackgroundService
    {
        #region Props
        private readonly IConnection _connection;
        private readonly IModel _model;
        private readonly string exchangeName = "NewsCmsExchange";
        //it can be parameterizied
        private readonly string requestRouteKeyPattern = "NewsCmsExchange.BasicInfo.Event.{0}";
        private readonly BasicInfoCommandDbContext _dbContext;
        #endregion

        public EventPublisher(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            _dbContext = scope.ServiceProvider.GetRequiredService<BasicInfoCommandDbContext>();

            var facotry = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            _connection = facotry.CreateConnection();
            _model = _connection.CreateModel();
            _model.ExchangeDeclare(exchangeName, ExchangeType.Topic, false, false, null);
            
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var events =await _dbContext.OutBoxEventItems.Where(w => w.IsProcessed == false).Take(100).ToListAsync();
                if(events.Any())
                {
                    foreach (var @event in events)
                    {
                        var finalRouteKey = string.Format(requestRouteKeyPattern, @event.EventName);
                        var messageBody = System.Text.Encoding.UTF8.GetBytes(@event.EventPayload);
                        _model.BasicPublish(exchangeName, finalRouteKey, null,messageBody);
                        @event.IsProcessed = true;
                    }
                    _dbContext.SaveChanges();
                    _dbContext.ChangeTracker.Clear();
                }
                await Task.Delay(2000);
            }            
        }
    }
}
