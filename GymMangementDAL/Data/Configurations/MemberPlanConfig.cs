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
    internal class MemberPlanConfig : IEntityTypeConfiguration<MemberPlanModel>
    {
        public void Configure(EntityTypeBuilder<MemberPlanModel> builder)
        {

            builder.Property(X => X.CreatedDate).HasColumnName("StartDate").HasDefaultValueSql("GETDATE()");

            builder.HasKey(X=> new{ X.MemberId , X.PlanId }); // composite key
            builder.Ignore(X => X.Id); // ignore this key 

        }
    }
}
