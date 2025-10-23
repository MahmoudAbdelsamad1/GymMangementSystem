using AutoMapper.Execution;
using GymMangementBLL.Services.Interfaces;
using GymMangementBLL.ViewModels.AnalyticsViewModels;
using GymMangementDAL.Models;
using GymMangementDAL.Repositories.Interfaces;
using GymMangementDAL.UnitOfWork.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Services.Classes
{
    public class AnalyticsServices : IAnalyticsServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnalyticsServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public GetAnalyticsViewModel GetAnalyticsData()
        {
            var sessions = _unitOfWork.SessionRepository.GetAll();


            var date = new GetAnalyticsViewModel()
            {

                TotalMembers = _unitOfWork.GetRepository<MemberModel>().GetAll().Count(),
                Trainers = _unitOfWork.GetRepository<TrainerModel>().GetAll().Count(),
                ActiveMembers = _unitOfWork.GetRepository<MemberPlanModel>().GetAll(X => X.Status == "Active").Count(),
                OngoingSessions = sessions.Count(X => X.StartAt <= DateTime.Now &&  X.EndAt > DateTime.Now),   
                CompletedSessions = sessions.Count(X=> X.EndAt < DateTime.Now),
                UpcomingSessions = sessions.Count(X => X.StartAt > DateTime.Now),
            };
            return date;
        }
    }
}
