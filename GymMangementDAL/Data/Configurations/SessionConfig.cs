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
    internal class SessionConfig : IEntityTypeConfiguration<SessionModel>
    {
        public void Configure(EntityTypeBuilder<SessionModel> builder)
        {


            builder.ToTable(tb =>
            {

                tb.HasCheckConstraint("SessionCapacityCheck", " Capacity Between 1 to 25 ");
                tb.HasCheckConstraint("SessionEndDateCheck", "StartAt > EndAt");

            });

            builder.HasOne(X => X.SessionCategory).WithMany(X=> X.Sessions).HasForeignKey(X=>X.CategoryId);  // 

            builder.HasOne(X => X.SessionTrainer).WithMany(X => X.TrainerSessions).HasForeignKey(X => X.TrainerId);

        }
    }
}
