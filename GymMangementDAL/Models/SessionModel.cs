using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Models
{
    public class SessionModel : BaseModel
    {
        public string Description { get; set; } = null!;

        public int Capacity { get; set; }

        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }


        #region Relation ship with category 
        public int CategoryId { get; set; }

        public Category SessionCategory { get; set; } = null!; // 
        #endregion

        #region Relation ship with Trainer 

        public int TrainerId { get; set; } // 

        public TrainerModel SessionTrainer { get; set; } = null!; //
        #endregion

        #region Relation ship with Member 

        public ICollection<MemberSessionModel> SessionMembers { get; set; } = null!;  // 
        #endregion
    }
}
