using GymMangementDAL.Models;
using GymMangementDAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.ViewModels.MemberViewModels
{
    public class GetMemberDetails
    {
        [Required(ErrorMessage ="Name is required ")]
        [StringLength(maximumLength: 50, MinimumLength =2,ErrorMessage ="name must be between 2 amd 50")]
        [RegularExpression(@"^[a-zA-Z\s]+$",ErrorMessage ="Name is invalid")]

        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Photo is required ")]


        public string Photo { get; set; } = null!;

        [Required(ErrorMessage = "Plane Name is required ")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "name must be between 2 amd 50")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Plane is invalid")]
        public string PlanName { get; set; } = null!;

        [Required(ErrorMessage = "Email is required ")]
        [EmailAddress(ErrorMessage = " Invalid Email Address")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Phone is required ")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$",ErrorMessage ="invalid phone num")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="invalid number")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Gender is required ")]

        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Date of birhth is required ")]
        [DataType(DataType.Date,ErrorMessage ="invalid date of birth")]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Member Session Start Date is required ")]

        public string MemberSessionStartDate { get; set; } = null!;

        [Required(ErrorMessage = "Member Session End Date is required ")]
        [DataType(DataType.DateTime, ErrorMessage = "invalid end date  ")]

        public string MemberSessionEndDate { get; set; } = null!;

        [Required(ErrorMessage = "Address is required ")]

        public string Address { get; set; } = null!;
    }
}
