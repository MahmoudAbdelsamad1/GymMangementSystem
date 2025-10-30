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
            if(id <= 0)  {

                TempData["ErrorMessage"] = " Id can not be 0 or negative number";
              return  RedirectToAction(nameof(Index));

            }

            var details = _memberService.GetMemberDetails(id);
            if(details is null)
            {
                TempData["ErrorMessage"] = "Member not found ";
               return RedirectToAction(nameof(Index));
            }


            return View(details);
        }

    }
}
