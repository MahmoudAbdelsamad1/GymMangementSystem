using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Models
{
    internal abstract class BaseModel
    {

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        #region Relation ship with plan

        public ICollection<> MyProperty { get; set; }

        #endregion
    }
}
