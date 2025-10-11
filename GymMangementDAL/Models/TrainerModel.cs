using GymMangementDAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Models
{
    public class TrainerModel : GymUserModel
    {
        public Specialties Specialties { get; set; }

        // HireDate == created at 

        #region Relations ship with session

        public ICollection<SessionModel> TrainerSessions { get; set; } = null!;  //

        #endregion
    }
}
