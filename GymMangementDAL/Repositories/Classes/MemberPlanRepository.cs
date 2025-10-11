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
    internal class MemberPlanRepository : IMemberPlanRepository
    {

        private readonly GymMangementDbContext _dbContext;
        public MemberPlanRepository(GymMangementDbContext dbContext)
        {

            _dbContext = dbContext;
        }

        public int AddMemberPlan(MemberPlanModel memberPlan)
        {

            _dbContext.MemberPlans.Add(memberPlan);
            return _dbContext.SaveChanges();
        }

        public int DeleteMemberPlan(MemberPlanModel memberPlan)
        {

            _dbContext.MemberPlans.Remove(memberPlan);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<MemberPlanModel> GetAllMemberPlan()
        {

            return _dbContext.MemberPlans.ToList();
        }

        public MemberPlanModel? GetById(int id)
        {
            return _dbContext.MemberPlans.Find(id);
        }

        public int UpdateMemberPlan(MemberPlanModel memberPlan)
        {

            _dbContext.MemberPlans.Update(memberPlan);
             return _dbContext.SaveChanges();
        }
    }
}
