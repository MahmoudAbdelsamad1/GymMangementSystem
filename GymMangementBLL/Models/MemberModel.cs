using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Models
{
    internal class MemberModel : GymUserModel
    {
        // jon date == Created date 

        public string? Photo { get; set; }

        #region Relations ship Member - healtRecored 

        public HealthRecordModel healthRecord { get; set; }

        #endregion

        #region Relation ship with Plan


        public ICollection<MemberPlanModel> MembersPlan { get; set; } = null!;


        #endregion

        #region Relation ship with Sessiom


        public ICollection<MemberSessionModel> MemberSessions { get; set; } = null!;


        #endregion
    }
}
