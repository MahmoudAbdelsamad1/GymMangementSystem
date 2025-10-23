using AutoMapper;
using GymManagementSystemBLL.ViewModels.SessionViewModels;
using GymMangementBLL.Services.Interfaces;
using GymMangementBLL.ViewModels.SessionsViewModels;
using GymMangementDAL.Models;
using GymMangementDAL.Repositories.Classes;
using GymMangementDAL.Repositories.Interfaces;
using GymMangementDAL.UnitOfWork.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Services.Classes
{
    public class SessionServices : ISessionServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _autoMapper;

        public SessionServices(IUnitOfWork unitOfWork, IMapper autoMapper)
        {
            _unitOfWork = unitOfWork;
            _autoMapper = autoMapper;
        }

        public bool CreateSession(CreateSessionViewModel createdSession)
        {
            try
            {

                // trainer exist 
                // category exist 
                // time valid 

                if (!IsTrainerExist(createdSession.TrainerId) ||
                    !IsCategoryExist(createdSession.CategoryId) ||
                    !IsTimeValid(createdSession.StartDate, createdSession.EndDate)) return false;

                // is capacity in valid rangne 

                if (createdSession.Capacity > 25 || createdSession.Capacity < 0) return false;

                var sessionModel = _autoMapper.Map<CreateSessionViewModel, SessionModel>(createdSession);
                _unitOfWork.SessionRepository.Add(sessionModel);
                return _unitOfWork.SaveChanges() > 0;

            }
            catch (Exception ex)
            {

                Console.WriteLine("failed to add session " + ex);
                return false;
            }
        }

        public IEnumerable<SessionViewModel> GetAllSessionsWithTrainerAndCategories()
        {
            var sessions = _unitOfWork.SessionRepository.GetAllSessionsWithTrainerAndCategories();
            if (sessions is null || !sessions.Any()) return [];


            var mappedSessions = _autoMapper.Map<IEnumerable<SessionModel>, IEnumerable<SessionViewModel>>(sessions);

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
            if (session is null) return null;

            var mappedSession = _autoMapper.Map<SessionModel, SessionViewModel>(session);
            mappedSession.AvailableSlots = mappedSession.Capacity - _unitOfWork.SessionRepository.GetCountOfBookedSlots(mappedSession.Id);

            return mappedSession;
        }


        public UpdateSessionViewModel? GetSessionToUpdate(int sessionId)
        {
            var session = _unitOfWork.SessionRepository.GetSessionWithTrainerAndCategory(sessionId);
            if (session is null) return null;

            return _autoMapper.Map<SessionModel,UpdateSessionViewModel>(session);
        }

        public bool UpdateSession(int sessionId, UpdateSessionViewModel updatedSession)
        {
            try {
                // valid date 
                var sessionModel = _unitOfWork.SessionRepository.GetSessionWithTrainerAndCategory(sessionId);

                if (sessionModel is null) return false;
                if (!IsTimeValid(sessionModel.StartAt, sessionModel.EndAt)) return false;
               if (_unitOfWork.GetRepository<TrainerModel>().GetById(updatedSession.TrainerId) is null) return false;

               // is session running || Ended || has active booking
                if (!IsSessionAvailableToUpdated(sessionModel)) return false;


                var mappedSession = _autoMapper.Map<UpdateSessionViewModel, SessionModel>(updatedSession);
                mappedSession.UpdatedDate = DateTime.Now;
                _unitOfWork.SessionRepository.Update(mappedSession);

                return _unitOfWork.SaveChanges() > 0;

            } catch (Exception ex) {

                Console.WriteLine("failed to add session : " + ex);
                return false;
            }
        }


        public bool DeleteSession(int sessionId)
        {
            var session = _unitOfWork.SessionRepository.GetSessionWithTrainerAndCategory(sessionId);
            if (session is null) return false;

            if(!IsSessionAvailableToDelete(session)) return false;

            _unitOfWork.SessionRepository.Delete(session);

            return _unitOfWork.SaveChanges() > 0;
        }




        #region Helper

        bool IsSessionAvailableToUpdated(SessionModel session) {

            if (session.StartAt < DateTime.Now) return false;

            if (session.EndAt > DateTime.Now) return false;

            bool IsSessionHasActiveBooking = _unitOfWork.SessionRepository.GetCountOfBookedSlots(session.Id) > 0;

            if(IsSessionHasActiveBooking) return false;


            return true;

        
        }

        bool IsSessionAvailableToDelete(SessionModel session)
        {
            // session on future 
            if (session.StartAt > DateTime.Now) return false;

            if (session.StartAt < DateTime.Now && session.EndAt > DateTime.Now) return false;

            bool IsSessionHasActiveBooking = _unitOfWork.SessionRepository.GetCountOfBookedSlots(session.Id) > 0;

            if (IsSessionHasActiveBooking) return false;


            return true;


        }

        private bool IsTrainerExist(int TrainerId)
        {


            return _unitOfWork.GetRepository<TrainerModel>().GetById(TrainerId) is not null;

        }

        private  bool IsCategoryExist(int CategoryId)
        {


            return _unitOfWork.GetRepository<Category>().GetById(CategoryId) is not null;

        }


        private  bool IsTimeValid(DateTime StartDate, DateTime EndDate)
        {


            return StartDate < EndDate;

        }

    

        #endregion
    }
}
