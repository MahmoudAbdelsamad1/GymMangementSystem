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
    internal class MemberRepository : IMemberRepository
    {
        private readonly GymMangementDbContext _dbContext;
        public MemberRepository(GymMangementDbContext dbContext) {

            _dbContext = dbContext;
        }
        public int AddMember(MemberModel member)
        {
            _dbContext.Members.Add(member);
            return _dbContext.SaveChanges();
        }

        public int DeleteMember(MemberModel member)
        {
            _dbContext.Members.Remove(member);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<MemberModel> GetAllMembers()
        {
            return _dbContext.Members.ToList();
        }

        public MemberModel? GetById(int id)
        {
            return _dbContext.Members.Find(id);
        }

        public int UpdateMember(MemberModel member)
        {
            _dbContext.Members.Update(member);
            return _dbContext.SaveChanges();
        }
    }
}
