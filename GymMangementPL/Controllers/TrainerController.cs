using GymMangementBLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;

namespace GymMangementPL.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
           _trainerService = trainerService;
        }
        public ActionResult Index()
        {
            var trainers = _trainerService.GetAll();
                return View(trainers);
        }
    }
}
