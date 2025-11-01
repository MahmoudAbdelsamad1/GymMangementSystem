using GymMangementBLL.Services;
using GymMangementBLL.Services.Classes;
using GymMangementBLL.Services.Interfaces;
using GymMangementDAL.Data.Contextes;
using GymMangementDAL.Data.GymDbContextSeed;
using GymMangementDAL.Repositories.Classes;
using GymMangementDAL.Repositories.Interfaces;
using GymMangementDAL.UnitOfWork.Classes;
using Microsoft.EntityFrameworkCore;

namespace GymMangementPL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Ask CLR to create ob from GymMangementDbContext

            builder.Services.AddDbContext<GymMangementDbContext>(options =>
            {

                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));


            });

            //builder.Services.AddScoped(typeof(IGenericRepository<> ), typeof(GenericRepository<>) );

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<ISessionRepository, SessionRepository>();

            builder.Services.AddAutoMapper(X => X.AddProfile(new MappingProfiles()));

            builder.Services.AddScoped<IAnalyticsServices, AnalyticsServices>();

            builder.Services.AddScoped<IMemberService, MemberService>();

            builder.Services.AddScoped<ITrainerService, TrainerService>();

            //builder.Services.AddAutoMapper(typeof(MappingProfiles));


            var app = builder.Build();

            #region Migarate Database - Data seeding 

            var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<GymMangementDbContext>();
            var pendingMigrations = dbContext.Database.GetPendingMigrations();
            if (!pendingMigrations?.Any() ?? false)
                dbContext.Database.Migrate();

            GymDbContextSeeding.SeedData(dbContext);
            #endregion


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();

           
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id:int?}")
                .WithStaticAssets();

        

            app.Run();
        }
    }
}
