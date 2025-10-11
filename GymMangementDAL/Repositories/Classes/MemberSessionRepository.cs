using GymMangementDAL.Data.Contextes;
using GymMangementDAL.Models;
using GymMangementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Classes
{
    internal class MemberSessionRepository : IMemberSessionRepository
    {

        private readonly GymMangementDbContext _dbContext;
        public MemberSessionRepository(GymMangementDbContext dbContext)
        {

            _dbContext = dbContext;
        }


        public int AddMemberSession(MemberSessionModel memberSession)
        {

            _dbContext.MemberSessions.Add(memberSession);
             return _dbContext.SaveChanges();
        }

        public int DeleteMemberSession(MemberSessionModel memberSession)
        {

            _dbContext.MemberSessions.Remove(memberSession);
            return _dbContext.SaveChanges();

        }

        public IEnumerable<MemberSessionModel> GetAllMemberSession()
        {

            return _dbContext.MemberSessions.ToList() ;
        }

        public MemberSessionModel? GetById(int id)
        {
            return _dbContext.MemberSessions.Find(id);
        }

        public int UpdateMemberSession(MemberSessionModel memberSession)
        {

            _dbContext.MemberSessions.Update(memberSession);
            return _dbContext.SaveChanges();
        }
    }
}
