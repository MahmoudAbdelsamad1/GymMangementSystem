using GymMangementDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Interfaces
{
    public interface IHealthRecordRepository
    {
        IEnumerable<HealthRecordModel> GetAllHealthRecordes();

        HealthRecordModel? GetById(int id);

        int DeleteHealthRecord(HealthRecordModel healthRecord);

        int AddHealthRecord(HealthRecordModel healthRecord);

        int UpdateHealthRecord(HealthRecordModel healthRecord);
    }
}
