using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Entities;

namespace Velora.Infrastructure.Config
{
    public class BankAccountConfiguration : BaseEntityConfiguration<BankAccount>
    {
        public override void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            base.Configure(builder);

            builder.ToTable("BankAccounts");

            builder.Property(b => b.BankName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.BankAccountNumber)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasIndex(b => b.BankAccountNumber)
                .IsUnique();

            builder.Property(b => b.Balance)
                .HasPrecision(18, 2);

          


            builder.HasOne(b => b.User)
                .WithMany(u => u.BankAccounts)
                .HasForeignKey(b => b.UserId);

          ;
        }
    }
}
