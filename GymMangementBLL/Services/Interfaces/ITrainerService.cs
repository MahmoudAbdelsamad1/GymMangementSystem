using GymMangementBLL.ViewModels.TrainerViewModels;
using GymMangementDAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Services.Interfaces
{
    public  interface ITrainerService
    {

        IEnumerable<TrainerViewModel> GetAll();
        TrainerViewModel? GetByID(int trainerId);

        bool CreateTrainer (CreateTrainerViewModel trainer);

        DetailsOfTrainer? GetTrainerDetails(int trainerId);

        UpdateTrainerViewModel? GetTrainerToUpdate(int trainerId);

        bool UpdateTrainer(int TrainerId, UpdateTrainerViewModel updatedTrainer);

        bool DeleteTrainer (int trainerId);

    }
}
