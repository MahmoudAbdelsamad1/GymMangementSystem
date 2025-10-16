using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.ViewModels.TrainerViewModels
{
    public class DetailsOfTrainer
    {

        public string Name { get; set; } = null!;
        public string Specializations { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateOnly Date { get; set; }
        public string Address { get; set; } = null!;


    }
}
