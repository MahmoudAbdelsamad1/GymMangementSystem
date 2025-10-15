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

        public bool CreateMember(CreateMemberViewModel member)
        {
            // firstly we must check if the phone and Email are unique
            bool IsMemberCreated = false;
            bool IsEmailUnique = _memberRepository.GetAll(X => X.Email == member.Email).Any();
            bool IsPhoneUnique = _memberRepository.GetAll(X => X.Phone == member.Phone).Any();

            if (IsEmailUnique && IsPhoneUnique)
            {

                MemberModel memberModel = new MemberModel()
                {
                    Name = member.Name,
                    Address = new AddressModel()
                    {
                        BuildingNum = member.BuildingNumber,
                        City = member.City,
                        Street = member.Street,
                    },
                    Email = member.Email,
                    CreatedDate = DateTime.Now,
                    DateOfBirth = member.DateOfBirth,
                    Gender = member.Gender,
                    healthRecord = new HealthRecordModel()
                    {
                        BloodType = member.HealthRecord.BloodType,
                        Height = member.HealthRecord.Height,
                        Note = member.HealthRecord.Note,
                        Weight = member.HealthRecord.Weight
                    },
                    Phone = member.Phone,


                };

                IsMemberCreated = _memberRepository.Add(memberModel) > 0;
            }

            return IsMemberCreated;

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
