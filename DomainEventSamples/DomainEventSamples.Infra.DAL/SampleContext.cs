using DomainEventSamples.Core;
using DomainEventSamples.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace DomainEventSamples.Infra.DAL
{
    public class SampleContext:DbContext
    {
        
        public SampleContext(DbContextOptions<SampleContext> options) : base(options) { }
        public DbSet<Person> People { get; set; }
        public  DbSet<OutBoxEventItem> OutBoxEventItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        //Type 4 Dispatcher
        #region Type 4 dispatcher
        public override int SaveChanges()
        {
            HandleBeforSaveChange();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            HandleBeforSaveChange();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            HandleBeforSaveChange();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            HandleBeforSaveChange();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        private void HandleBeforSaveChange()
        {
            // it should executed befor DispatchEvents, as the events cleared by DispatchEvents.
            AddToOutBox();
            DispatchEvents();
            
        }

        private void AddToOutBox()
        {
            var entities = ChangeTracker.Entries<Entity>()
                .Where(w => w.State == EntityState.Added || w.State == EntityState.Modified)
                .Select(w => w.Entity);
            var dateTime = DateTime.Now;
            foreach (var entity in entities)
            {
                foreach (var @event in entity.Events)
                {
                    OutBoxEventItems.Add(new OutBoxEventItem
                    {
                        EventId = Guid.NewGuid(),
                        AccuredByUserID = "1",
                        AccuredOn = dateTime,
                        AggregateId="1",
                        AggregateName=entity.GetType().FullName,
                        EventName = @event.GetType().FullName,
                        EventTypeName = @event.GetType().FullName,
                        EventPayLoad = JsonConvert.SerializeObject(@event),
                        IsProcessed = true
                    });                    
                }
            }
        }

        private void DispatchEvents()
        {
            var dispatcher = this.GetService<IDomainEventDispatcher>();
            var entities = ChangeTracker.Entries<Entity>()
                .Where(w=>w.State == EntityState.Added || w.State== EntityState.Modified)
                .Select(w=>w.Entity);
            foreach (var entity in entities)
            {
                dispatcher.Dispatch(entity.Events);
                entity.ClearEvent();
            }
            
        }
        #endregion
    }
}