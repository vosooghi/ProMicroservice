using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySamples.Framework
{
    public class BaseDbContext:DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<OutBoxEventItem> OutBoxEventItems { get; set; }

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
            //DispatchEvents();

        }

        private void AddToOutBox()
        {
            var entities = ChangeTracker.Entries<AggregateRoot>()
                .Where(w => w.State == EntityState.Added || w.State == EntityState.Modified)
                .Select(w => w.Entity).ToList();
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
                        AggregateId = "1",
                        AggregateName = entity.GetType().Name,
                        AggregateTypeName = entity.GetType().FullName,
                        EventName = @event.GetType().Name,
                        EventTypeName = @event.GetType().FullName,
                        OutBoxEventItemID = entity.Id,
                        EventPayLoad = JsonConvert.SerializeObject(@event),
                        IsProcessed = false
                    });
                }
            }
        }

        //private void DispatchEvents()
        //{
        //    var dispatcher = this.GetService<IDomainEventDispatcher>();
        //    var entities = ChangeTracker.Entries<Entity>()
        //        .Where(w => w.State == EntityState.Added || w.State == EntityState.Modified)
        //        .Select(w => w.Entity);
        //    foreach (var entity in entities)
        //    {
        //        dispatcher.Dispatch(entity.Events);
        //        entity.ClearEvent();
        //    }

        //}

        /// <summary>
        /// //we need to load whole graph of the aggregate
        /// </summary>
        /// <param name="clrEntityType">Entity type name</param>
        /// <returns></returns>
        public IEnumerable<string> GetIncludePaths(Type clrEntityType)
        {
            var entityType = Model.FindEntityType(clrEntityType);
            var includedNavigations = new HashSet<INavigation>();
            var stack = new Stack<IEnumerator<INavigation>>();
            while (true)
            {
                var entityNavigations = new List<INavigation>();
                foreach (var navigation in entityType.GetNavigations())
                {
                    if (includedNavigations.Add(navigation))
                        entityNavigations.Add(navigation);
                }
                if (entityNavigations.Count == 0)
                {
                    if (stack.Count > 0)
                        yield return string.Join(".", stack.Reverse().Select(e => e.Current.Name));
                }
                else
                {
                    foreach (var navigation in entityNavigations)
                    {
                        var inverseNavigation = navigation.Inverse;
                        if (inverseNavigation != null)
                            includedNavigations.Add(inverseNavigation);
                    }
                    stack.Push(entityNavigations.GetEnumerator());
                }
                while (stack.Count > 0 && !stack.Peek().MoveNext())
                    stack.Pop();
                if (stack.Count == 0) break;
                entityType = stack.Peek().Current.TargetEntityType;
            }
        }
}
