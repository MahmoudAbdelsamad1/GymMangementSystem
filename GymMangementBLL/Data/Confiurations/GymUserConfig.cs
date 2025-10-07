using GymMangementBLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Data.Confiurations
{
    internal class GymUserConfig<T> : IEntityTypeConfiguration<T> where T : GymUserModel
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {

            builder.Property(p => p.Name).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(p => p.Email).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(p => p.Phone).HasColumnType("varchar").HasMaxLength(11);


            builder.ToTable("Email", tableBuilder =>
            {
                tableBuilder.HasCheckConstraint("GymUserEmailCheck", "Email LIKE '%@%.%'");

            });

            builder.ToTable("Phone", tableBuilder =>
            {
                tableBuilder.HasCheckConstraint("GymUserPhoneCheck", "Phone LIKE '01%' and Phone not like '%[^0-9]%'");

            });
            
            builder.HasIndex(p => p.Email).IsUnique();
            builder.HasIndex(p => p.Phone).IsUnique();

            builder.OwnsOne(A => A.Address, builder =>
            {

                builder.Property(C => C.City).HasColumnName("City").HasColumnType("varchar").HasMaxLength(30);

                builder.Property(S => S.Street).HasColumnName("Street").HasColumnType("varchar").HasMaxLength(30);

                builder.Property(B => B.BuildingNum).HasColumnName("BuildingNum");
            });
        }
    }
}
