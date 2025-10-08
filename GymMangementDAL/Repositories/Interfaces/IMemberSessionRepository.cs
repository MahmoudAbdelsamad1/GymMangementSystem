using GymMangementDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Interfaces
{
    public interface IMemberSessionRepository
    {
        IEnumerable<MemberSessionModel> GetAllMemberSession();

        MemberSessionModel? GetById(int id);

        int DeleteMemberSession(MemberSessionModel memberSession);

        int AddMemberSession(MemberSessionModel memberSession);

        int UpdateMemberSession(MemberSessionModel memberSession);
    }
}
