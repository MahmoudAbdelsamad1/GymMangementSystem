using GymMangementBLL.ViewModels.MemberViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Services.Interfaces
{
    public interface IMemberService
    {

        public IEnumerable<MemberViewModel> GetAll { get; set; }
    }
}
