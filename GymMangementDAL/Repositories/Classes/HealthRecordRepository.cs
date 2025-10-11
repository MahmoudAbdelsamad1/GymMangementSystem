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
    internal class HealthRecordRepository : IHealthRecordRepository
    {
        private readonly GymMangementDbContext _dbContext;

        public HealthRecordRepository(GymMangementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddHealthRecord(HealthRecordModel healthRecord)
        {
            _dbContext.HealthRecords.Add(healthRecord);
            return _dbContext.SaveChanges();
        }

        public int DeleteHealthRecord(HealthRecordModel healthRecord)
        {

            _dbContext.HealthRecords.Remove(healthRecord);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<HealthRecordModel> GetAllHealthRecordes()
        {

            return _dbContext.HealthRecords.ToList();
        }

        public HealthRecordModel? GetById(int id)
        {
            return _dbContext.HealthRecords.Find(id);
        }

        public int UpdateHealthRecord(HealthRecordModel healthRecord)
        {

            _dbContext.HealthRecords.Update(healthRecord);
            return _dbContext.SaveChanges();
        }
    }
}
