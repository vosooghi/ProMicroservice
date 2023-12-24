﻿namespace CQRSSamples.Framework
{
    public abstract class BaseEfUnitOfWork<TDbContext> : IUnitOfWork
        where TDbContext : BaseCommandDbContext
    {
        private readonly TDbContext _dbContext;

        public BaseEfUnitOfWork(TDbContext context)
        {
            _dbContext = context;
        }
        public void BeginTransaction()
        {
            _dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _dbContext.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _dbContext.Database.RollbackTransaction();
        }
    }
}
