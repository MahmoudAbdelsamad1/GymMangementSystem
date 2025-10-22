using GymMangementBLL.ViewModels.SessionsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Services.Interfaces
{
    public interface ISessionServices 
    {

        IEnumerable<SessionViewModel> GetAllSessionsWithTrainerAndCategories();

        int GetCountOfBookedSlots(int sessionId);

        SessionViewModel? GetSessionWithTrainerAndCategories(int sessionId);


    }
}
