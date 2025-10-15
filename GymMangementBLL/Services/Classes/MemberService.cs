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
        private readonly IGenericRepository<MemberPlanModel> _memberPlanRepository;
        private readonly IGenericRepository<HealthRecordModel> _healthRecordRepository;

        public MemberService(IGenericRepository<MemberModel> memberRepository,
            IGenericRepository<MemberPlanModel> memberPlanRepository, IGenericRepository<HealthRecordModel> healthRecordRepository)
        {
            _memberRepository = memberRepository;
            _memberPlanRepository = memberPlanRepository;
             _healthRecordRepository = healthRecordRepository;
        }
        public bool CreateMember(CreateMemberViewModel member)
        {
            try
            {
                // firstly we must check if the phone and Email are unique

                if (IsEmailExist(member.Email) || IsPhoneExist(member.Phone)) return false;
               else{

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

                   return _memberRepository.Add(memberModel) > 0;
                }

            }
            catch (Exception ex) { 
            
            
                return false;

            }
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

        public MemberViewModel? GetMemberDetails(int id)
        {
            var member = _memberRepository.GetById(id);

            if(member is not null)
            {
                var memberDetails =  new MemberViewModel()
                {

                    Name = member.Name,
                    Phone = member.Phone,
                    Photo = member.Photo,
                    Email = member.Email,
                    Address = $"{member.Address.BuildingNum}- {member.Address.Street}-{member.Address.City}",
                    Gender = member.Gender.ToString(),
                    DateOfBirth = member.DateOfBirth.ToShortDateString()
                };

                // get active plan for mevember  

                var ActivePlan = _memberPlanRepository.GetAll(X=>X.Id == member.Id && X.Status == "Active").FirstOrDefault();

                if (ActivePlan is not null) { 
                
                    memberDetails.MemberSessionStartDate = ActivePlan.CreatedDate.ToLongDateString();
                    memberDetails.MemberSessionEndDate = ActivePlan.EndDate.ToLongDateString();
                    memberDetails.PlanName = ActivePlan.Plan.Name;
                }

                return memberDetails;

            }else return null;
        }

        public HealthRecordViewModel? GetMemberHealthDetails(int MemberId)
        {
           var healthRecord =   _healthRecordRepository.GetById(MemberId);

            if (healthRecord is not null) return new HealthRecordViewModel()
            {

                BloodType = healthRecord.BloodType,
                Height = healthRecord.Height,
                Note = healthRecord.Note,
                Weight = healthRecord.Weight,

            };
            else return null;
        }

        public UpdateMemberViewModel? GetMemberToUpdate(int MemberId)
        {

            var member = _memberRepository.GetById(MemberId);
            if (member is not null) return new UpdateMemberViewModel()
            {

                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone,
                BuildingNumber = member.Address.BuildingNum,
                Street = member.Address.Street,
                City = member.Address.City,
                Photo = member.Photo,



            };
            else return null;

        }

        public bool UpdateMember( int memberId , UpdateMemberViewModel updatedMember)
        {
            try
            {
                var member = _memberRepository.GetById(memberId);
                if(member is  null) return false;
                else
                {
                    if (IsEmailExist(updatedMember.Email) || IsPhoneExist(updatedMember.Phone)) return false;
                    else { 
                    
                        member.Name = updatedMember.Name;
                        member.Email = updatedMember.Email;
                        member.Phone = updatedMember.Phone;
                        member.Photo = updatedMember.Photo;
                        member.Address = new AddressModel()
                        {

                            BuildingNum = updatedMember.BuildingNumber,
                            City = updatedMember.City,
                            Street = updatedMember.Street,

                        };

                        return _memberRepository.Update(member) > 0;
                    
                    }


                }

            }
            catch (Exception ex) { 
            
                return false;
            }
        }


        #region Helper

        private bool IsEmailExist(string email)
        {
           return _memberRepository.GetAll(X=> X.Email == email).Any();


        }

        private bool IsPhoneExist(string phone)
        {
            return _memberRepository.GetAll(X => X.Phone == phone).Any();


        }

        #endregion
    }
}
