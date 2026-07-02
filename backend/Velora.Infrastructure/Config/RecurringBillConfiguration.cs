using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Entities;

namespace Velora.Infrastructure.Config
{
    public class RecurringBillConfiguration : BaseEntityConfiguration<RecurringBill>
    {
        public override void Configure(EntityTypeBuilder<RecurringBill> builder)
        {
            

            builder.Property(r => r.Frequency)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(r => r.StartDate)
                .IsRequired();

            builder.Property(r => r.EndDate)
                .IsRequired();

        }
    }
}
