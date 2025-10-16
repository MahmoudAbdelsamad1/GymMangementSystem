using GymMangementDAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.ViewModels.TrainerViewModels
{
    public class CreateTrainerViewModel
    {
        [Required(ErrorMessage ="Name is required ")]
        [StringLength(maximumLength:50,MinimumLength =5,ErrorMessage ="Name must be between 5 and 50")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = " Invalid name ")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email is required ")]
        [RegularExpression(@"^[A-Za-z0-9._%+\-]+@[A-Za-z0-9.\-]+\.[A-Za-z]{2,}$", ErrorMessage = " Invalid Email ")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Invalid email ")]
        [EmailAddress]

        public string Email { get; set; } = null!;


        [Required(ErrorMessage = "Phone is required ")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid phone ")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "DateOfBirth is required ")]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required ")]
        public Gender Gender { get; set; } = null!;

        [Required(ErrorMessage = "BuildingNumber is required ")]
        [Range(1,500,ErrorMessage ="Invalid Build Number")]
        public int BuildingNumber { get; set; }

        [Required(ErrorMessage = "Street is required ")]
        [StringLength(maximumLength:50,MinimumLength =5)]
        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "City is required ")]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = " Invalid City name")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Specialization is required ")]
        [StringLength(maximumLength: 35, MinimumLength = 5)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = " Invalid Specialization name")]
        public Specialties Specialization { get; set; } 
     
    }
}
