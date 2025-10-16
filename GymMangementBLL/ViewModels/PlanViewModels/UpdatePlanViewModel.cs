using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.ViewModels.PlanViewModels
{
    public class UpdatePlanViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(maximumLength:50,MinimumLength =5,ErrorMessage = "name must be between 5 and 50 char")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Description  is required")]
        [StringLength(maximumLength: 200, MinimumLength = 5, ErrorMessage = "name must be between 5 and 200 char")]
        public string Description  { get; set; } = null!;

        [Required(ErrorMessage = "DurationDays is required")]
        [Range(1,365,ErrorMessage ="Duration must be between 1 and 365")]
        public int DurationDays { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(120, 2000, ErrorMessage ="price must be between 120 and 2000")]
        public decimal Price { get; set; } 
    }
}
