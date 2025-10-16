using GymMangementBLL.Services.Interfaces;
using GymMangementBLL.ViewModels.PlanViewModels;
using GymMangementDAL.Models;
using GymMangementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Services.Classes
{
    public class PlanService : IPlanService
    {
        private readonly IUnitOfWork _planRepository;

        public PlanService(IUnitOfWork planRepository)
        {
            _planRepository = planRepository;
        }
        public IEnumerable<PlanViewModel> GetAllPlans()
        {
            PlanViewModel[]  planViewModelsList = [];
           var PlanModelsList = _planRepository.GetRepository<Plan>().GetAll();
            if (PlanModelsList.Any() && planViewModelsList is not null) {

                foreach (var item in PlanModelsList)
                {
                    planViewModelsList.Append(new PlanViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        IsActive = item.IsActive,
                        DurationDays = item.DurationDays,
                        price = item.Price


                    });
                }

            }
            return planViewModelsList;
        }

        public PlanViewModel? GetById(int planId)
        {
           var planModel = _planRepository.GetRepository<Plan>().GetById(planId);
            if(planModel is null )return null;

            return new PlanViewModel() { 
            
                Name = planModel.Name,
                Description = planModel.Description,
                IsActive = planModel.IsActive,
                DurationDays = planModel.DurationDays,
                price = planModel.Price
            
            };
        }

        public UpdatePlanViewModel? GetPlanToUpdated(int planId)
        {
            var planModel = _planRepository.GetRepository<Plan>().GetById(planId);
            if (planModel is null || planModel.IsActive == false) return null;

            return new UpdatePlanViewModel()
            {

                Name = planModel.Name,
                Description = planModel.Description,
                DurationDays = planModel.DurationDays,
                Price = planModel.Price
                
            };
        }

        public bool TogglePlanActiveStatus(int planId)
        {
            var repo = _planRepository.GetRepository<Plan>();
           var plan = repo.GetById(planId);

            if(plan is null || HasActiveMemberShips(planId)) return false;
            plan.IsActive = !plan.IsActive;
            plan.UpdatedDate = DateTime.Now;


            try
            {
                repo.Update(plan);
                return _planRepository.SaveChanges() > 0 ;

            }
            catch (Exception ex)
            {


                return false;

            }

        }

        public bool UpdatePlane(int planId, UpdatePlanViewModel updatedPlan)
        {
            var planModel = _planRepository.GetRepository<Plan>().GetById(planId);
            if(planModel is null) return false;


            if(HasActiveMemberShips(planId)) return false;

            try {
            planModel.Name = updatedPlan.Name;
                planModel.Description = updatedPlan.Description;
                planModel.Price  = updatedPlan.Price;
                planModel.DurationDays = updatedPlan.DurationDays;
                planModel.UpdatedDate = DateTime.Now;
                _planRepository.GetRepository<Plan>().Update(planModel) ;
                return _planRepository.SaveChanges() > 0;

            }
            catch(Exception ex) {
            
            
                return false;

            }

        }

        #region Hellper


        bool HasActiveMemberShips(int planId)
        {

            return _planRepository.GetRepository<MemberPlanModel>().GetAll(X => X.Id == planId && X.Status == "Active").Any();

        }

        #endregion
    }
}
