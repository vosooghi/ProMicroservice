using Ground.Extensions.Events.Outbox.Dal.EF;
using Ground.Infra.Data.Sql.Commands;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GroundTemplate.Infra.Data.Sql.Commands.Common
{
    public class DbContextNameCommandDbContext : BaseOutboxCommandDbContext
    {
        public DbContextNameCommandDbContext(DbContextOptions<DbContextNameCommandDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
