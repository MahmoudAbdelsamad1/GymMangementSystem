using GymMangementBLL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Models
{
    internal class TrainerModel : GymUserModel
    {
        public Specialties Specialties { get; set; }

        // HireDate == created at 
    }
}
