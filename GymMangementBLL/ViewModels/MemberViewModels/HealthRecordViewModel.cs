using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.ViewModels.MemberViewModels
{
    public class HealthRecordViewModel 
    {
        [Required(ErrorMessage = "Height is Required ")]
        [Range(45,240)]
        public int Height { get; set; }

        [Required(ErrorMessage = "Weight is Required ")]
        [Range(20, 500)]

        public int Weight { get; set; }

        [Required(ErrorMessage = "BloodType is Required ")]
        [StringLength(maximumLength:3 , ErrorMessage ="BloodTyb must not increased by 3")]
        public string BloodType { get; set; } = null!;

        public string? Note { get; set; }
    }
}
