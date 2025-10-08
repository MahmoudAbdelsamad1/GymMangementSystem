using GymMangementDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Interfaces
{
    internal interface IMemberPlanRepository
    {
        IEnumerable<MemberPlanModel> GetAllMemberPlan();

        MemberPlanModel? GetById(int id);

        int DeleteMemberPlan(MemberPlanModel memberPlan);

        int AddMemberPlan(MemberPlanModel memberPlan);

        int UpdateMemberPlan(MemberPlanModel memberPlan);
    }
}

