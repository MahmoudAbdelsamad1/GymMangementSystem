using AutoMapper;
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
        private readonly IMapper _autoMapper;

        public SessionServices(UnitOfWork unitOfWork, IMapper autoMapper)
        {
            _unitOfWork = unitOfWork;
            _autoMapper = autoMapper;
        }
        public IEnumerable<SessionViewModel> GetAllSessionsWithTrainerAndCategories()
        {
             var sessions = _unitOfWork.SessionRepository.GetAllSessionsWithTrainerAndCategories();
            if (sessions is null || !sessions.Any()) return [];

            //var sessionViewModels = sessions.Select(session => new SessionViewModel
            //{
            //    Id = session.Id,
            //    EndDate = session.EndAt,
            //    StartDate = session.StartAt,
            //    Capacity = session.Capacity,
            //    Description = session.Description,
            //    TrainerName = session.SessionTrainer.Name,
            //    CategoryName = session.SessionCategory.Name,
            //    AvailableSlots = session.Capacity - _unitOfWork.SessionRepository.GetCountOfBookedSlots(session.Id)

            //});

           var  mappedSessions = _autoMapper.Map<IEnumerable<SessionModel>, IEnumerable<SessionViewModel>>(sessions);

            foreach (var session in mappedSessions)
            {
                session.AvailableSlots = session.Capacity - _unitOfWork.SessionRepository.GetCountOfBookedSlots(session.Id);    
            }


            return mappedSessions;
        }

        public int GetCountOfBookedSlots(int sessionId)
        {
           return _unitOfWork.SessionRepository.GetCountOfBookedSlots(sessionId);
        }

        public SessionViewModel? GetSessionWithTrainerAndCategories(int sessionId)
        {
            var session = _unitOfWork.SessionRepository.GetSessionWithTrainerAndCategory(sessionId);
            if(session is null) return null;

           var  mappedSession = _autoMapper.Map<SessionModel, SessionViewModel>(session);
            mappedSession.AvailableSlots = mappedSession.Capacity - _unitOfWork.SessionRepository.GetCountOfBookedSlots(sessionId);

            return mappedSession;
        }
    }
}
