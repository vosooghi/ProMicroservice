using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;
using RepositorySamples.Domain.Categories.Entities;
using RepositorySamples.Domain.Products.Entities;
using RepositorySamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySamples.DAL
{
    public class RepoSampleDbContext : BaseDbContext
    {
        public  DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public RepoSampleDbContext(DbContextOptions<RepoSampleDbContext> options) : base(options)
        {

        }
    }
}
