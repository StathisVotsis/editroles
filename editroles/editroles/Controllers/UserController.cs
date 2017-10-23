using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using editroles.Models;
using System.Web.Security;

namespace editroles.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User userModel, string returnUrl)
        {
            DbtestEntities dbModel = new DbtestEntities();
            
            var data = dbModel.User.Where(x => x.Username == userModel.Username && x.Password == userModel.Password).First();
            if (data != null)
            {
                FormsAuthentication.SetAuthCookie(data.Username, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && returnUrl.StartsWith("//") && returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }

                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            else
            {
                ModelState.AddModelError("", "Invalid credentials");
                return View();
            }
        }
    }
}