using GymMangementDAL.Data.Contextes;
using GymMangementDAL.Models;
using GymMangementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Classes
{
    internal class PlanRepository : IPlaneRepository
    {

        private readonly GymMangementDbContext _dbContext;
        public PlanRepository(GymMangementDbContext dbContext)
        {

            _dbContext = dbContext;
        }

        public IEnumerable<Plan> GetAllPlans()
        {

            return _dbContext.Plans.ToList();
        }

        public Plan? GetById(int id)
        {

            return _dbContext.Plans.Find(id);
        }

        public int UpdatePlan(Plan plan)
        {
            _dbContext.Plans.Update(plan);
            return _dbContext.SaveChanges();
        }
    }
}
