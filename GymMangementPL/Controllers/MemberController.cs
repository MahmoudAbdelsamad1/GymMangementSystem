using GymMangementBLL.Services.Classes;
using GymMangementBLL.Services.Interfaces;
using GymMangementBLL.ViewModels.MemberViewModels;
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


        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateMember(CreateMemberViewModel createdMember)
        {


            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("DataInvalid", "Check data and missing fields");
                return View(nameof(Create), createdMember);

            }
           bool result =  _memberService.CreateMember(createdMember);
            if (!result)
            {

                TempData["FailedMessage"] = "Failed to create member check mail or phone duplicated";

            }
            else
            {
                TempData["SuccessMessage"] = "Member Created Successfully";
            }

            return RedirectToAction(nameof(Index));


        }


        public ActionResult HealthRecordData(int id)
        {

           HealthRecordViewModel details  =  _memberService.GetMemberHealthDetails(id);

            if (details is null) {

                TempData["ErrorMessage"] = "No Derails for this member ";
               return  RedirectToAction(nameof(Index));
            }

            return View(details);



        }

    }
}
 