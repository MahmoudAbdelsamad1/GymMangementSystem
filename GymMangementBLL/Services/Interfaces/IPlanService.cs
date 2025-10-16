using GymMangementBLL.ViewModels.PlanViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Services.Interfaces
{
    public interface IPlanService
    {

        IEnumerable<PlanViewModel> GetAllPlans();
        PlanViewModel? GetById(int planId);

        UpdatePlanViewModel? GetPlanToUpdated(int planId);

        bool UpdatePlane(int planId, UpdatePlanViewModel updatedPlan);

        bool TogglePlanActiveStatus(int planId);

    }
}
