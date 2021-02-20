using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        { 
        }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Parts> Parts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
