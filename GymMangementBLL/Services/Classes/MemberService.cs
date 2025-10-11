using GymMangementBLL.Services.Interfaces;
using GymMangementBLL.ViewModels.MemberViewModels;
using GymMangementDAL.Models;
using GymMangementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Services.Classes
{
    public class MemberService : IMemberService


    {
        private readonly IGenericRepository<MemberModel> _memberRepository;

        public MemberService(IGenericRepository<MemberModel> memberRepository)
        {
            _memberRepository = memberRepository;
        }


        public IEnumerable<MemberViewModel> GetAll()
        {

            var memberModels = _memberRepository.GetAll();

            if (memberModels is null || !memberModels.Any())
            {

                return Enumerable.Empty<MemberViewModel>();


            }
            else
            {

                var memberViewModels = memberModels.Select(X => new MemberViewModel

                {
                    Id = X.Id,
                    Name = X.Name,
                    Phone = X.Phone,
                    Photo = X.Photo,
                    Email = X.Email,
                    Gender = X.Gender.ToString(),


                });


                return memberViewModels;

            }


        }
    }
}
