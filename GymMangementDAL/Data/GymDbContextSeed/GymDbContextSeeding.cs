using GymMangementDAL.Data.Contextes;
using GymMangementDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GymMangementDAL.Data.GymDbContextSeed
{
    public static class GymDbContextSeeding
    {

        public static bool SeedData(GymMangementDbContext dbContext)
        {
            try {

                var HasPlans = dbContext.Plans.Any();
                var HasCategories = dbContext.Categories.Any();

                if (HasPlans && HasCategories) return false;

                if (!HasPlans)
                {

                    var plans = LoadDataFromJsonFiles<Plan>("plans.json");
                    if (plans.Any())
                    {
                        dbContext.Plans.AddRange(plans);
                    }
                }

                if (!HasCategories)
                {

                    var categories = LoadDataFromJsonFiles<Category>("categories.json");
                    if (categories.Any())
                    {
                        dbContext.Categories.AddRange(categories);
                    }
                }


                return dbContext.SaveChanges() > 0;
            }
            catch (Exception ex) {

                Console.WriteLine( "Failed seeding date: " + ex);
            
                return false;
            }
        }

        private static List<T> LoadDataFromJsonFiles<T>(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", fileName);

            if (!File.Exists(filePath)) throw new FileNotFoundException() ;

            var data = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<List<T>>(data, options) ?? new List<T>();
          
        }

    }
}
