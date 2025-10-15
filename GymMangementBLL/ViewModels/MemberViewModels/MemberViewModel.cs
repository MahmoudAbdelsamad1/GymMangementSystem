using GymMangementDAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.ViewModels.MemberViewModels
{
    public class MemberViewModel
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public string? Photo { get; set; } 
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Gender { get; set; } = null!;
     
        public string? PlanName { get; set; } = null!;

        public string? DateOfBirth { get; set; } 
        public string? MemberSessionStartDate { get; set; } 

        public string? MemberSessionEndDate { get; set; } 

        public string? Address { get; set; }



    }
}
