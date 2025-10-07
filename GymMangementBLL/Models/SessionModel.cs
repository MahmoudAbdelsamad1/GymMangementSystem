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

    }
}
