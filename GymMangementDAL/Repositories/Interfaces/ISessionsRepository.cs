using GymMangementDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Interfaces
{
    public interface ISessionsRepository
    {

        IEnumerable<SessionModel> GetAllSessions();

        SessionModel? GetById(int id);

        int DeleteSession (SessionModel session);

        int AddSession(SessionModel session);

        int UpdateSession(SessionModel session);
    }
}
