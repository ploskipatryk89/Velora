using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Entities;

namespace Velora.Infrastructure.Config
{
    public class BillConfiguration : BaseEntityConfiguration<Bill>
    {
        public override void Configure(EntityTypeBuilder<Bill> builder)
        {
            

            builder.Property(b => b.DueDate)
                .IsRequired();
        }
    }
}
