using GymMangementBLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Data.Confiurations
{<
    internal class TrainerConfig : GymUserConfig<TrainerModel>, IEntityTypeConfiguration<TrainerModel>
    {
        public new void Configure(EntityTypeBuilder<TrainerModel> builder)
        {

            builder.Property(p => p.CreatedDate).HasColumnName("HireDate").HasDefaultValueSql("GETDATE()");

            base.Configure(builder);
        }
    }
}
