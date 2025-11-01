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

                TempData["ErrorMessage"] = "Failed to create member check mail or phone duplicated";

            }
            else
            {
                TempData["SuccessMessage"] = "Member Created Successfully";
            }

            return RedirectToAction(nameof(Index));


        }


        public ActionResult HealthRecordData(int id)
        {
            if (id <= 0) {
                TempData["ErrorMessage"] = "Id can not be zer or negative num ";
                return RedirectToAction(nameof(Index));
            }

           HealthRecordViewModel details  =  _memberService.GetMemberHealthDetails(id);

            if (details is null) {

                TempData["ErrorMessage"] = "Member details no found";
               return  RedirectToAction(nameof(Index));
            }

            return View(details);



        }


        
        public ActionResult MemberEdit(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Id can not be zer or negative num ";
                return RedirectToAction(nameof(Index));
            }

            var memberToUpdate = _memberService.GetMemberToUpdate(id);
            if (memberToUpdate is  null) {

                TempData["ErrorMessage"] = "Member no found ";
                return RedirectToAction(nameof(Index));

            }

            return View(memberToUpdate);
        }

        [HttpPost]
        public ActionResult MemberEdit([FromRoute] int id, UpdateMemberViewModel updatedMember)
        {
            if (!ModelState.IsValid)
            {

                ModelState.AddModelError("DataInvalid", "Check data and missing fields");

                return View(updatedMember);

            }

            var result = _memberService.UpdateMember(id, updatedMember);

            if (!result)
            {
                TempData["FailedMessage"] = "Failed to update member check mail or phone duplicated";

            }
            else {

                TempData["SuccessMessage"] = "Member Updated Successfully";

            }

            return RedirectToAction(nameof(Index));
        }


        public ActionResult Delete(int id) {

          var result =   _memberService.GetMemberDetails(id);

            if (result is null) {

                TempData["ErrorMessage"] = "Member not found ";

                RedirectToAction(nameof(Index));

            }
            ViewBag.MemberId = id;
            return View();
        }

        [HttpPost]
        public ActionResult DeleteConfirmed([FromForm] int id) {


            if (id <= 0) {

                TempData["ErrorMessage"] = "Id can not be  ozeror negative num";
            }

          var result =   _memberService.DeleteMember(id);

            if (!result)
            {

                TempData["ErrorMessage"] = "Failed to delete this member";

            }
            else {

                TempData["SuccessMessage"] = "Member Deleted Successfully";

            }

           return RedirectToAction(nameof(Index));

        }
    }
}
 