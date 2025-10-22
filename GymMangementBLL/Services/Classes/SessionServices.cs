using GymMangementBLL.Services.Interfaces;
using GymMangementBLL.ViewModels.SessionsViewModels;
using GymMangementDAL.Models;
using GymMangementDAL.Repositories.Classes;
using GymMangementDAL.UnitOfWork.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Services.Classes
{
    internal class SessionServices : ISessionServices
    {
        private readonly UnitOfWork _unitOfWork;

        public SessionServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<SessionViewModel> GetAllSessionsWithTrainerAndCategories()
        {
             var sessions = _unitOfWork.SessionRepository.GetAllSessionsWithTrainerAndCategories();
            if (sessions is null || !sessions.Any()) return [];

            var sessionViewModels = sessions.Select(session => new SessionViewModel
            {
                Id = session.Id,
                EndDate = session.EndAt,
                StartDate = session.StartAt,
                Capacity = session.Capacity,
                Description = session.Description,
                TrainerName = session.SessionTrainer.Name,
                CategoryName = session.SessionCategory.Name,
                AvailableSlots = session.Capacity - _unitOfWork.SessionRepository.GetCountOfBookedSlots(session.Id)

            });
            
            return sessionViewModels;
        }

        public int GetCountOfBookedSlots(int sessionId)
        {
           return _unitOfWork.SessionRepository.GetCountOfBookedSlots(sessionId);
        }
    }
}
