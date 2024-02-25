using Microsoft.EntityFrameworkCore;

namespace RabbitMqSamples.RPC.Server.Models
{
    public class CustomerDbContext:DbContext
    {
        public  DbSet<Customer>  Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;initial catalog=CustomerDb;user id=sa;password=P@ssw0rd;encrypt=false");
        }
    }
}
