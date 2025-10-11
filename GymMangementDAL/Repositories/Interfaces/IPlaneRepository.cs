using GymMangementDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Interfaces
{
    public interface IPlaneRepository
    {
        IEnumerable<Plan> GetAllPlans();

        Plan? GetById(int id);

        int DeletePlan(Plan plan);

        int AddPlan(Plan plan);

        int UpdatePlan(Plan plan);
    }
}

