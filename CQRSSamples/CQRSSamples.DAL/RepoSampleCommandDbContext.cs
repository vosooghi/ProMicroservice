using CQRSSamples.Domain.Categories.Entities;
using CQRSSamples.Domain.Products.Entities;
using CQRSSamples.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSSamples.Command.DAL
{
    public class RepoSampleCommandDbContext : BaseCommandDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public RepoSampleCommandDbContext(DbContextOptions<RepoSampleCommandDbContext> options) : base(options)
        {

        }
    }
}
