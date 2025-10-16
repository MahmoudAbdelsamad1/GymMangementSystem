using GymMangementBLL.Services.Interfaces;
using GymMangementBLL.ViewModels.TrainerViewModels;
using GymMangementDAL.Models;
using GymMangementDAL.Models.Enums;
using GymMangementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Services.Classes
{
    public class TrainerService : ITrainerService
    {
        private readonly IUnitOfWork _trainerRepository;

        public TrainerService(IUnitOfWork trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }
        public bool CreateTrainer(CreateTrainerViewModel trainer)
        {
            var repo = _trainerRepository.GetRepository<TrainerModel>();
            // phone amd emila not duplicated 
            // Specialties already validated on ViewModel

            if (IsEmailAndPhoneUnique(trainer.Email,trainer.Phone)) return false;

             repo.Add(new TrainerModel {
                 Email = trainer.Email, 
                 Phone = trainer.Phone,
                 Name = trainer.Phone,
                 Address = new AddressModel
                 {
                     BuildingNum = trainer.BuildingNumber,
                     City = trainer.City,
                     Street = trainer.Street
                 },
                 CreatedDate = DateTime.Now,
                 DateOfBirth = trainer.DateOfBirth,
                 Gender = trainer.Gender,
                 Specialties = trainer.Specialization,
                 
                 TrainerSessions = [] /// Pls note


             });

            return _trainerRepository.SaveChanges() > 0;
        }

        public bool DeleteTrainer(int trainerId)
        {
            var trainer = _trainerRepository.GetRepository<TrainerModel>().GetById(trainerId);
            if (trainer is null) return false;
            var sessions  = trainer.TrainerSessions;
            foreach (var item in sessions)
            {
                if (item.StartAt > DateTime.Now) return false;
            }

            _trainerRepository.GetRepository<TrainerModel>().Delete(trainer);
            return _trainerRepository.SaveChanges() > 0;
        }

        public IEnumerable<TrainerViewModel> GetAll()
        {
            var trainers = _trainerRepository.GetRepository<TrainerModel>().GetAll();

            if (trainers is null) return [];
            return trainers.Select(X => new TrainerViewModel()
            {
                Email = X.Email,
                Name = X.Name,
                Phone = X.Phone,
                Specialization = X.Specialties.ToString()

            });
        }

        public TrainerViewModel? GetByID(int trainerId)
        {
           var trainer = _trainerRepository.GetRepository<TrainerModel>().GetById(trainerId);
            if(trainer is null) return null;

            return new TrainerViewModel { 
            
            
                Name = trainer.Name,
                Phone = trainer.Phone,
                Email = trainer.Email,
                Specialization= trainer.Specialties.ToString()  
                
            
            };
           
        }

        public DetailsOfTrainer? GetTrainerDetails(int trainerId)
        {
           var trainer =  _trainerRepository.GetRepository<TrainerModel>().GetById(trainerId);
            if(trainer is null) return null;

            return new DetailsOfTrainer { 
            
                Name = trainer.Name,
                Email = trainer.Email,
                Phone = trainer.Phone,
                Date = trainer.DateOfBirth,
                Address = $"{trainer.Address.BuildingNum}.{trainer.Address.Street}.{trainer.Address.City}",
                Specializations  = trainer.Specialties.ToString()
 

            };
        }

        public UpdateTrainerViewModel? GetTrainerToUpdate(int trainerId)
        {
            var trainer = _trainerRepository.GetRepository<TrainerModel>().GetById(trainerId);
            if (trainer is null) return null;

            return new UpdateTrainerViewModel
            {

                Name = trainer.Name,
                Email = trainer.Email,
                Phone = trainer.Phone,
                Address = trainer.Address,
                Specialization = trainer.Specialties

            };
        }

        public bool UpdateTrainer(int TrainerId, UpdateTrainerViewModel updatedTrainer)
        {
            if (IsEmailAndPhoneUnique(updatedTrainer.Email, updatedTrainer.Phone)) return false;

            _trainerRepository.GetRepository<TrainerModel>().Update(new TrainerModel { 
            
            
                Email = updatedTrainer.Email,
                Phone = updatedTrainer.Phone,
                Name = updatedTrainer.Name,
                Address = new AddressModel { BuildingNum  = updatedTrainer.Address.BuildingNum ,
                    City = updatedTrainer.Address.City , Street = updatedTrainer.Address.Street , },
                UpdatedDate = DateTime.Now,
                Specialties = updatedTrainer.Specialization,           
            });

            return _trainerRepository.SaveChanges() > 0;

        }

        #region Hellper

        bool IsEmailAndPhoneUnique(string email, string phone)
        {
             return _trainerRepository.GetRepository<TrainerModel>().
                                             GetAll(X => X.Email == email || X.Phone == phone).Any();

        }


        #endregion
    }
}
