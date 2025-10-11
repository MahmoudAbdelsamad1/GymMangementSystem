using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Models
{
    public class MemberPlanModel : BaseModel
    {
        // StartDate == CreatedDate


        public DateTime EndDate  { get; set; }
        public int MemberId { get; set; }  // 
        public int PlanId { get; set; }  // 
        public MemberModel Member { get; set; } = null!;  // 
        public Plan Plan { get; set; } = null!;  // 

        public string  Status { get {


                if (EndDate >= DateTime.Now)
                    return "Expired";
                else return "Active";
            } }

    }
}
