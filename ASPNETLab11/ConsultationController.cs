using ASPNETLab10.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETLab10
{
    public class ConsultationController : Controller
    {
        public IActionResult Index()
        {

            return View("./Views/Register.cshtml");

        }

        [HttpPost]
        public IActionResult Reg(ConsultationModel consultationModel)

        {
            if (consultationModel.Date.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("Date", "Incorrect date");

            }

            if (consultationModel.Date.DayOfWeek == DayOfWeek.Saturday || consultationModel.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                ModelState.AddModelError("Date", "Consultation can't be on weekends");
            }


            if (consultationModel.Date.DayOfWeek == DayOfWeek.Monday && consultationModel.Product == "Basics")
            {

                ModelState.AddModelError("Date", "Consultation of basics can't be on Monday");
            }

            if (ModelState.IsValid)
            {
                TempData["Message"] = "Consultation successfully created!";
                ViewBag.Message = TempData["Message"];
                return View("./Views/Register.cshtml");
            }

            return View("./Views/Register.cshtml", consultationModel);

        }
    }
}