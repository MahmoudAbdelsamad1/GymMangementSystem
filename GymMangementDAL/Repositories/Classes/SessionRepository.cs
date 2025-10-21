using GymMangementDAL.Data.Contextes;
using GymMangementDAL.Models;
using GymMangementDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Classes
{
    public class SessionRepository : GenericRepository<SessionModel>, ISessionRepository
    {
        private readonly GymMangementDbContext _dbContext;

        public SessionRepository(GymMangementDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }
        public IEnumerable<SessionModel> GetAllSessionsWithTrainerAndCategories()
        {
            return _dbContext.Sessions.Include(session => session.SessionCategory).Include(session => session.SessionTrainer).ToList();
        }

        public int GetAvailableSlots(int sessionId)
        {
            return _dbContext.MemberSessions.Count(S => S.SessionId == sessionId);
        }
    }
}
