using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Entities;

namespace Velora.Infrastructure.Config
{
    public class LoanConfiguration : BaseEntityConfiguration<Loan>
    {
        public override void Configure(EntityTypeBuilder<Loan> builder)
        {
            

            builder.Property(l => l.Status)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(l => l.PrincipalAmount)
                .HasPrecision(18, 2);

            builder.Property(l => l.RemainingBalance)
                .HasPrecision(18, 2);

            builder.Property(l => l.PaymentStartDate)
                .IsRequired();

            builder.Property(l => l.PaymentEndDate)
                .IsRequired();


            builder.Property(l => l.InterestRate)
                .HasPrecision(5, 2);
                
           

        }
    }
}
