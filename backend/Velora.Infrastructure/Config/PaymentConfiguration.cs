using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Entities;

namespace Velora.Infrastructure.Config
{
    public class PaymentConfiguration : BaseEntityConfiguration<Payment>
    {
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            base.Configure(builder);

            builder.UseTphMappingStrategy();

            builder.HasDiscriminator<string>("PaymentType")
            .HasValue<Bill>("Bill")
            .HasValue<RecurringBill>("RecurringBill")
            .HasValue<Loan>("Loan");

            builder.Property(p => p.PaymentName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .HasMaxLength(100);

            builder.Property(p => p.PaymentAccountNumber)
                .HasMaxLength(50);

            builder.Property(p => p.Amount)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.BankAccount)
                .WithMany()
                .HasForeignKey(p => p.BankAccountId)
                .OnDelete(DeleteBehavior.SetNull);
            
        }
    }
}
