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

        public IEnumerable<MemberViewModel> GetAll();

        public bool CreateMember(CreateMemberViewModel member);


        MemberViewModel? GetMemberDetails(int id);

        HealthRecordViewModel? GetMemberHealthDetails(int MemberId);

        UpdateMemberViewModel? GetMemberToUpdate(int MemberId);

        bool UpdateMember( int memberId , UpdateMemberViewModel updatedMember);

    }
}
