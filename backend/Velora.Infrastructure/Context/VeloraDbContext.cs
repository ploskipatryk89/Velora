using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Entities;
using Velora.Infrastructure.Config;

namespace Velora.Infrastructure.Context
{
    public class VeloraDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public VeloraDbContext(DbContextOptions options) : base(options)
        {
        }

        protected VeloraDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("velora");

            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
       
    }
}
