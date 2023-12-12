using DomainEventSamples.Core;
using Microsoft.EntityFrameworkCore;

namespace DomainEventSamples.Infra.DAL
{
    public class SampleContext:DbContext
    {
        public DbSet<Person> People { get; set; }
        public SampleContext(DbContextOptions<SampleContext> options) : base(options) { }
    }
}