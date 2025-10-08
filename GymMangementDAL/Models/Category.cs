using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Models
{
    internal class Category : BaseModel
    {
        public string Name { get; set; } = null!;

        #region Relation ship with Session

        public ICollection<SessionModel> Sessions { get; set; } = null!;

        #endregion


    }
}
