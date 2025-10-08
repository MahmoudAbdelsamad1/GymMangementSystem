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
    internal class HealthRecoredConfig : IEntityTypeConfiguration<HealthRecordModel>
    {
        public void Configure(EntityTypeBuilder<HealthRecordModel> builder)
        {
            builder.ToTable("Members").HasKey(X => X.Id);

            builder.HasOne<MemberModel>().WithOne(X => X.healthRecord).HasForeignKey<HealthRecordModel>(X => X.Id);
        }
    }
}
