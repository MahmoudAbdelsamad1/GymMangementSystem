using GymMangementDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Interfaces
{
    public interface ITrainerRepository
    {

        IEnumerable<TrainerModel> GetAllTrainer();

        TrainerModel? GetById(int id);

        int DeleteTrainer(TrainerModel trainer);

        int AddTrainer(TrainerModel trainer);

        int UpdateTrainer(TrainerModel trainer);

    }
}
