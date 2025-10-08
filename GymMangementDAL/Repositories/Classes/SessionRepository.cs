using GymMangementDAL.Data.Contextes;
using GymMangementDAL.Models;
using GymMangementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace GymMangementDAL.Repositories.Classes
{
    internal class SessionRepository : ISessionsRepository
    {
        private readonly GymMangementDbContext _dbContext;
        public SessionRepository(GymMangementDbContext dbContext)
        {

            _dbContext = dbContext;
        }


        public int AddSession(SessionModel session)
        {
            _dbContext.Sessions.Add(session);
            return _dbContext.SaveChanges();
        }

        public int DeleteSession(SessionModel session)
        {

            _dbContext.Sessions.Remove(session);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<SessionModel> GetAllSessions()
        {

            return _dbContext.Sessions.ToList();
        }

        public SessionModel? GetById(int id)
        {

            return _dbContext.Sessions.Find(id);
        }

        public int UpdateSession(SessionModel session)
        {

            _dbContext.Sessions.Update(session);      
                return _dbContext.SaveChanges();


        }
    }
}
