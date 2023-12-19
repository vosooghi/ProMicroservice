﻿using Microsoft.EntityFrameworkCore;

namespace RepositorySamples.Framework
{
    public class EfRepository<TAggregate, TDbContext> : IRepository<TAggregate>
        where TAggregate : AggregateRoot
        where TDbContext : BaseDbContext
    {
        protected readonly TDbContext _dbContext;
        public EfRepository(TDbContext context)
        {
            _dbContext = context;
        }
        public TAggregate Get(long id)
        {
            //we need to load whole graph of the aggregate
            var includePath = _dbContext.GetIncludePaths(typeof(TAggregate));
            IQueryable<TAggregate> query = _dbContext.Set<TAggregate>().AsQueryable();
            foreach (var item in includePath)
            {
                query = query.Include(item);
            }
            return query.Where(c => c.Id == id).First();
            
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
