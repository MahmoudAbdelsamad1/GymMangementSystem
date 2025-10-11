using GymMangementDAL.Data.Configurations;
using GymMangementDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Data.Contextes
{
    public class GymMangementDbContext : DbContext
    {
        public GymMangementDbContext(DbContextOptions<GymMangementDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=GymManagementSystem;Trusted_Connection=true;TrustServerCertificate=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public DbSet<MemberModel> Members { get; set; } // 

        public DbSet<HealthRecordModel> HealthRecords { get; set; }   // 
        public DbSet<TrainerModel> Trainers { get; set; }  // 

        public DbSet<Plan> Plans { get; set; } // 

        public DbSet<Category> Categories { get; set; } // 
        public DbSet<SessionModel> Sessions { get; set; } // 
        public DbSet<MemberPlanModel> MemberPlans { get; set; } // 
        public DbSet<MemberSessionModel> MemberSessions { get; set; }  // 

        // 8 DeSet but only 7 tables cz HealthRecords on Member table 

    }
}
