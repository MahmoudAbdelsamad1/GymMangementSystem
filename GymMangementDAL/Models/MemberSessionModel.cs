using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Models
{
    public class MemberSessionModel : BaseModel
    {
        // BookingDate == createdAT

        public bool IsAttended { get; set; }
        public int MemberId { get; set; }  // 
        public MemberModel Member { get; set; } = null!;  // 

        public int SessionId { get; set; }  // 

        public SessionModel Session { get; set; } = null!; // 
    }
}
