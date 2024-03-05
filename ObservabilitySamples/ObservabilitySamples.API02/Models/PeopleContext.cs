using Microsoft.EntityFrameworkCore;

namespace ObservabilitySamples.API02.Models
{
    public class PeopleContext:DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options)
        {
        }

        public  DbSet<Person> People { get; set; }

    }
}
