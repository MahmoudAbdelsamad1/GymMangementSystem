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
    internal class MemberConfig : GymUserConfig<MemberModel>, IEntityTypeConfiguration<MemberModel>
    {
        public new void Configure(EntityTypeBuilder<MemberModel> builder)
        {
            builder.Property(p => p.CreatedDate).HasColumnName("JoinDate").HasDefaultValueSql("GETDATE()");
           // builder.Ignore(X=>X.CreatedDate);

            base.Configure(builder);
        }
    }
}
