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
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<RecurringBill> RecurringBills { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<ScheduledPayment> ScheduledPayments { get; set; }
       
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
            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
        }
       
    }
}
