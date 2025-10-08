using GymMangementDAL.Data.Contextes;
using GymMangementDAL.Models;
using GymMangementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Classes
{
    internal class TrainerRepository : ITrainerRepository
    {
        private readonly GymMangementDbContext _dbContext;

        TrainerRepository(GymMangementDbContext dbContext) {

            _dbContext = dbContext;
        }

        public int AddTrainer(TrainerModel trainer)
        {
            _dbContext.Add(trainer);
            return _dbContext.SaveChanges();
            
        }

        public int DeleteTrainer(TrainerModel trainer)
        {
            _dbContext.Remove(trainer);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<TrainerModel> GetAllTrainer()
        {

            return _dbContext.Trainers.ToList();
        }

        public TrainerModel? GetById(int id)
        {

            return _dbContext.Trainers.Find(id);

        }

        public int UpdateTrainer(TrainerModel trainer)
        {
            _dbContext.Trainers.Update(trainer);
            return  _dbContext.SaveChanges();
        }
    }
}
