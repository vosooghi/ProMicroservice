using EventStore.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventSourcingSample.Framework
{
    public class EsEventStore : IEventStore
    {
        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            NullValueHandling = NullValueHandling.Ignore
        };
        private readonly EventStoreClient _eventStoreClient;
        public EsEventStore()
        {
            const string connectionString = "esdb://admin:changeit@localhost:2113?tls=false&tlsVerifyCert=false&keepAliveTimeout=10000&keepAliveInterval=10000";

            var settings = EventStoreClientSettings.Create(connectionString);

            _eventStoreClient = new EventStoreClient(settings);
        }
        public IReadOnlyList<IDomainEvent> GetAll(string aggregateTypeName, long id)
        {
            var result = _eventStoreClient.ReadStreamAsync(Direction.Forwards, GetStreamId(aggregateTypeName, id), StreamPosition.Start);

            var events = result.ToListAsync().Result;
            var domainEvents = events.Select(c => GetDomainEvent(c.Event.Data.ToArray())).ToList();
            return domainEvents;
        }

        private IDomainEvent GetDomainEvent(byte[] data)
        {            
            string json = System.Text.Encoding.UTF8.GetString(data);
            var obj = JsonConvert.DeserializeObject(json, _serializerSettings);
            return obj as IDomainEvent;
        }

        public void Save(string aggregateTypeName, long id, int currentVersion, IReadOnlyList<IDomainEvent> events)
        {
            IEnumerable<EventData> eventData = events.Select(c => new EventData(Uuid.NewUuid(), c.GetType().Name,
                GetSerializedEventData(c)));
            _eventStoreClient.AppendToStreamAsync(GetStreamId(aggregateTypeName, id), StreamState.Any,
                eventData).Wait();
        }

        private ReadOnlyMemory<byte> GetSerializedEventData(IDomainEvent c)
        {
            var jsonEvent = JsonConvert.SerializeObject(c, _serializerSettings);
            var byteArray = System.Text.Encoding.UTF8.GetBytes(jsonEvent);
            return byteArray;
        }

        private string GetStreamId(string aggregateTypeName, long id)
        {
            return $"{aggregateTypeName}-{id}";
        }
    }
}
