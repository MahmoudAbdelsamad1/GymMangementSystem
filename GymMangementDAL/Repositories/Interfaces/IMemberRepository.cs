using GymMangementDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        IEnumerable<MemberModel> GetAllMembers();

        MemberModel? GetById(int id);

        int DeleteMember(MemberModel member);

        int AddMember(MemberModel member);

        int UpdateMember(MemberModel member);
    }
}
