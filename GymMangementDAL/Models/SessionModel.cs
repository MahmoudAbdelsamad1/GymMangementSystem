using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Models
{
    internal class SessionModel : BaseModel
    {
        public string Description { get; set; } = null!;

        public int Capacity { get; set; }

        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }

        public int CategoryId { get; set; }
        public int TrainerId { get; set; }

        #region Relation ship with category 

        public Category Category { get; set; } = null!;
        #endregion

        #region Relation ship with Trainer 

        public TrainerModel SessionTrainer { get; set; } = null!;
        #endregion

        #region Relation ship with Member 

        public ICollection<MemberSessionModel> SessionMembers { get; set; } = null!;
        #endregion
    }
}
