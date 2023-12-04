﻿using ApplicationArchitectureSample.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationArchitectureSample.Infra.Data.SqlServer
{
    public class AppArchContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=AppArchDB;User Id=sa;Password=P@ssw0rd;Encrypt=False");
        }
    }
}

