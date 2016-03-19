using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OptionsWebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() {
            // Redirect if the user is already logged in
            if (User.IsInRole("Admin")) {
                return RedirectToAction("Index", "Choices", new { });
            } else if (User.IsInRole("Student")) {
                return RedirectToAction("Create", "Choices", new { });
            }

            return View();
        }
    }
}