using BasicInfo.Core.Domain.Categoris.Entities;
using BasicInfo.Core.Domain.Keywords.Entities;
using BasicInfo.Core.Domain.Keywords.ValueObjects;
using Ground.Extensions.Events.Outbox.Dal.EF;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BasicInfo.Infra.Data.Sql.Commands.Common
{
    public class BasicInfoCommandDbContext : BaseOutboxCommandDbContext
    {
        public  DbSet<Keyword> Keywords { get; set; }
        public  DbSet<Category> Categories { get; set; }

        public BasicInfoCommandDbContext(DbContextOptions<BasicInfoCommandDbContext> options) : base(options)
        {
        }


        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<TinyString>().HaveConversion<TinyStringValueConversion>();
            base.ConfigureConventions(configurationBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//==GetType().Assembly
            base.OnModelCreating(builder);
        }
    }
}
