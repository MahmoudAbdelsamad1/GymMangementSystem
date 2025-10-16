using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.ViewModels.MemberViewModels
{
    public class UpdateMemberViewModel
    {
        public string Name { get; set; } = null!;

        public string? Photo { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "Email must ber between 5 and 100")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address ")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Phone Is Required")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid phone num")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$")]
        public string Phone { get; set; } = null!;
        [Required(ErrorMessage = "BuildingNumber Is Required")]
        [Range(1, 500)]
        public int BuildingNumber { get; set; }

        [Required(ErrorMessage = "Street Is Required")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "City Is Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Street must contain only litters ")]
        [MinLength(2)]
        public string City { get; set; } = null!;
    }
}
