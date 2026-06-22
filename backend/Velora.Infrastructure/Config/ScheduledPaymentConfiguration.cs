
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Entities;

namespace Velora.Infrastructure.Config
{
    public class ScheduledPaymentConfiguration : BaseEntityConfiguration<ScheduledPayment>
    {
        public override void Configure(EntityTypeBuilder<ScheduledPayment> builder)
        {
            base.Configure(builder);

            builder.Property(s => s.DueDate)
                .IsRequired();

            builder.Property(s => s.Amount)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(s => s.Status)
                .IsRequired()
                .HasConversion<string>();

            builder.HasOne(b => b.Payment)
                .WithMany(b => b.ScheduledPayments)
                .HasForeignKey(s => s.PaymentId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
