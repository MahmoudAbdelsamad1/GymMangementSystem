using GymMangementDAL.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Models
{
    public abstract class GymUserModel : BaseModel
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public Gender  Gender { get; set; }

        public AddressModel Address { get; set; } = null!;



    }


    // will create address model inside same class cz we do not use it outside this class 

    [Owned]
    public  class AddressModel
    {
        public int BuildingNum { get; set; }

        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;

    }
}
