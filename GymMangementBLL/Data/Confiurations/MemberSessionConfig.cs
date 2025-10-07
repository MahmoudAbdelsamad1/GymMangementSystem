using GymMangementBLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Data.Confiurations
{
    internal class MemberSessionConfig : IEntityTypeConfiguration<MemberSessionModel>
    {
        public void Configure(EntityTypeBuilder<MemberSessionModel> builder)
        {
            builder.Property(X => X.CreatedDate).HasColumnName("BookingDate").HasDefaultValueSql("GETDATE()");
            builder.HasKey(X => new { X.MemberId, X.SessionId });
            builder.Ignore(X => X.Id);
        }
    }
}
