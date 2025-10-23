using System.Diagnostics;
using GymMangementBLL.Services.Interfaces;
using GymMangementDAL.Models;
using GymMangementPL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymMangementPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnalyticsServices _analyticsData;

        public HomeController(IAnalyticsServices analyticsData)
        {
            _analyticsData = analyticsData;
        }



        public ViewResult Index()
        {
            var data  = _analyticsData.GetAnalyticsData();
           
            return View(data);
        }


 
    }
}
