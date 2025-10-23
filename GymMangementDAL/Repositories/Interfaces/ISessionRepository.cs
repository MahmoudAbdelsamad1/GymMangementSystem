using GymMangementDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Interfaces
{
    public interface ISessionRepository: IGenericRepository<SessionModel>
    {

        IEnumerable<SessionModel> GetAllSessionsWithTrainerAndCategories();

        int GetCountOfBookedSlots(int sessionId);

        SessionModel? GetSessionWithTrainerAndCategory(int sessionId);


    }
}
