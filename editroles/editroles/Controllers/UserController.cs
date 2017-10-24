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
        public ActionResult Registration()
        {
            User userModel = new User();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Registration(User userModel)
        {
            using (Database1Entities dbModel = new Database1Entities())
            {
                if (dbModel.User.Any(x => x.Username == userModel.Username))
                {
                    ViewBag.DuplicateMessage = "User already exists";
                    return View("Registration", new User());
                }
                dbModel.User.Add(userModel);
                dbModel.SaveChanges();
            }

            ModelState.Clear();
            ViewBag.SuccessMessage = "You have registered as" + " " + userModel.Username;
            return View("Registration", new User());
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User userModel, string returnUrl)
        {
           try
            {
                Database1Entities dbModel = new Database1Entities();

                var data = dbModel.User.Where(x => x.Username == userModel.Username && x.Password == userModel.Password).First();
                if (data != null)
                {
                    FormsAuthentication.SetAuthCookie(data.Username, false);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && returnUrl.StartsWith("//") && returnUrl.StartsWith("/\\"))
                    {
                        ViewBag.SuccessMessage = "You have registered as" + " " + userModel.Username;
                        return Redirect(returnUrl);                    
                    }

                    else
                    {
                        ViewBag.SuccessMessage = "You have registered as" + " " + userModel.Username;
                        return RedirectToAction("About", "Home");                        
                    }
                }
                return View();

            }
            
            catch
            {
                ModelState.Clear();
                ModelState.AddModelError("", "Invalid credentials");
                
                return View();
            }
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }
    }
}