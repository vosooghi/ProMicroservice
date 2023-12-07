using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjects.EfSamples
{
    public class PersonContext:DbContext
    {
        public DbSet<Person> People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;initial catalog=PersonDb;user id = sa;password=P@ssw0rd;encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().OwnsOne(w => w.FirstName);
            modelBuilder.Entity<Person>().Property<LastName>(w => w.LastName).HasConversion(w=>w.Value,w=>new LastName(w));
            //if we have multi-value ValueObject, we have to use jsone serializer
        }
    }
}
