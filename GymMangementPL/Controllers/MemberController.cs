using GymMangementBLL.Services.Classes;
using GymMangementBLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymMangementPL.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public ActionResult Index()
        {
            var members = _memberService.GetAll();
            return View(members);
        }

        public ActionResult MemberDetails(int id)
        {
            if(id <= 0) return RedirectToAction(nameof(Index));

            var details = _memberService.GetMemberDetails(id);
            if(details is null) return RedirectToAction(nameof(Index));

            Console.WriteLine($" $$$$$&&&%%%%%%%%4 {details.Phone} ///////// {details.PlanName}");

            return View(details);
        }

    }
}
