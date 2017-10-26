using editroles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace editroles.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "Administrator, Member")]
        public ActionResult Index()
        {           
            using (Database1Entities db = new Database1Entities())
            {
                var L2EQuery = db.User.ToList();
                // var L2EQuery = db.User.Where(s => s.Role == "Member").ToList();
                return View(L2EQuery);
            }           
        }

        [HttpPost]
        public ActionResult EditIndex()
        {
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public ActionResult EditIndex2()
        {
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}