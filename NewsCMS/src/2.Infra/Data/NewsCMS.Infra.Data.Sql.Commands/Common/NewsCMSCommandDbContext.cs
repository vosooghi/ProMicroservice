using Ground.Extensions.Events.Outbox.Dal.EF;
using Ground.Infra.Data.Sql.Commands;
using Microsoft.EntityFrameworkCore;
using NewsCMS.Core.Domain.News.Entities;
using System.Reflection;

namespace NewsCMS.Infra.Data.Sql.Commands.Common
{
    public class NewsCMSCommandDbContext : BaseOutboxCommandDbContext
    {
        public DbSet<Core.Domain.News.Entities.News> News { get; set; }
        public NewsCMSCommandDbContext(DbContextOptions<NewsCMSCommandDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
