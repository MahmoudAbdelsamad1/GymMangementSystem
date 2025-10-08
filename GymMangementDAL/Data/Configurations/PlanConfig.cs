using GymMangementDAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Data.Configurations
{
    internal class PlanConfig : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {

            builder.Property(p => p.Name).HasColumnType("varchar").HasMaxLength(50);

            builder.Property(p => p.Description).HasColumnType("varchar").HasMaxLength(100);

            builder.Property(p => p.Price).HasPrecision(10,2);

            builder.ToTable("DurationDays", tb =>
            {

                tb.HasCheckConstraint("PlanDurationDaysCheck", " DurationDays Between 1 and 365 ");

            });
        }
    }
}
