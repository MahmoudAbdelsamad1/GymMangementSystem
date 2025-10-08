using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Models
{

    [Table("Plan")]
    public class Plan : BaseModel 
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int DurationDays { get; set; }

        public decimal Price { get; set; }

        public bool IsActive  { get; set; }

        #region Relation ship with member 

        public ICollection<MemberPlanModel> PlansMember { get; set; } = null!;  //


        #endregion
    }
}
