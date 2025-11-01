using AutoMapper.Execution;
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
        private readonly IUnitOfWork _unitOfWork;
    

        public MemberService( IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
          
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

                   _unitOfWork.GetRepository<MemberModel>().Add(memberModel) ;

                    return _unitOfWork.SaveChanges() > 0 ;
                }

            }
            catch (Exception ex) { 
            
            
                return false;

            }
        }

        public bool DeleteMember(int MemberId)
        {

            var member = _unitOfWork.GetRepository<MemberModel>().GetById(MemberId);

            if (member is null) return false;
            // must check there is no active sessions 
            // member.MemberSessions.Select(X=> X.Session.StartAt > DateTime.Now).Any();
            var  BokedSessionsIds = _unitOfWork.GetRepository<MemberSessionModel>().GetAll(X => X.Id == member.Id).Select(X=>X.Id);  

            var hasActiveSessions = _unitOfWork.GetRepository<SessionModel>().GetAll(X=> BokedSessionsIds.Contains(X.Id) && X.StartAt > DateTime.Now ).Any();

            if (hasActiveSessions) return false;
            // must delete any plans related wih this member before delete member (avid exeption for relation between them)
            var memberPlans = _unitOfWork.GetRepository<MemberSessionModel>().GetAll(X=>X.Id == MemberId && X.Session.StartAt > DateTime.Now);
            try
            {
                if (memberPlans.Any())
                {
                    foreach (var item in memberPlans)
                    {
                        _unitOfWork.GetRepository<MemberSessionModel>().Delete(item);
                    }

                }

                 _unitOfWork.GetRepository<MemberModel>().Delete(member)  ;
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception ex) {


                return false;
            
            }
          


        }

        public IEnumerable<MemberViewModel> GetAll()
        {


            var memberModels = _unitOfWork.GetRepository<MemberModel>().GetAll();

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

        public GetMemberDetails? GetMemberDetails(int id)
        {
            var member = _unitOfWork.GetRepository<MemberModel>().GetById(id);

            if(member is not null)
            {
               
                var memberDetails =  new GetMemberDetails()
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

                var ActivePlan = _unitOfWork.GetRepository<MemberPlanModel>().GetAll(X=>X.MemberId == member.Id && X.Status == "Active").FirstOrDefault();
                var teste = _unitOfWork.GetRepository<MemberPlanModel>().GetAll();
         
                if (ActivePlan is not null) {
                    

                    memberDetails.MemberSessionStartDate = ActivePlan.CreatedDate.ToLongDateString();
                    memberDetails.MemberSessionEndDate = ActivePlan.EndDate.ToLongDateString();
                    var plane = _unitOfWork.GetRepository<Plan>().GetById(ActivePlan.PlanId);
                    if(plane is not null) 
                    memberDetails.PlanName = plane.Name;
                }

                return memberDetails;

            }else return null;
        }

        public HealthRecordViewModel? GetMemberHealthDetails(int MemberId)
        {
           var healthRecord = _unitOfWork.GetRepository<HealthRecordModel>().GetById(MemberId);

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

            var member = _unitOfWork.GetRepository<MemberModel>().GetById(MemberId);
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
                var member = _unitOfWork.GetRepository<MemberModel>().GetById(memberId);
                if (member is null) return false;
                else
                {
                    var isEmailExist = _unitOfWork.GetRepository<MemberModel>().GetAll(X => X.Email == member.Email && X.Id != member.Id).Any();
                    var isPhoneExisted = _unitOfWork.GetRepository<MemberModel>().GetAll(X => X.Phone == member.Phone && X.Id != member.Id).Any();

                    if (isEmailExist || isPhoneExisted) return false;
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

                        _unitOfWork.GetRepository<MemberModel>().Update(member) ;

                        return _unitOfWork.SaveChanges() > 0;

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
           return _unitOfWork.GetRepository<MemberModel>().GetAll(X=> X.Email == email).Any();


        }

        private bool IsPhoneExist(string phone)
        {
            return _unitOfWork.GetRepository<MemberModel>().GetAll(X => X.Phone == phone).Any();


        }

        #endregion
    }
}
