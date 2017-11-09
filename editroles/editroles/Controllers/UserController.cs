using System.Linq;
using System.Web.Mvc;
using editroles.UserModel;
using System.Web.Security;
using editroles.Model;

namespace editroles.Controllers
{


    public class UserController : Controller
    {
        UserEntity dbModel = new UserEntity();

        [HttpGet]
        public ActionResult Registration()
        {            
            return View(new RegistrationView());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegistrationView userModel)
        {
            
            if (ModelState.IsValid)
            {
                using (dbModel)
                {
                    if (dbModel.User.Any(x => x.Username == userModel.Username))
                    {
                        ViewBag.DuplicateMessage = "User already exists";
                        return View("Registration", new RegistrationView());
                    }
                    else
                    {
                        User user = new User();
                        user.Username = userModel.Username;
                        user.Password = userModel.Password;
                        user.Email = userModel.Email;
                        dbModel.User.Add(user);                        
                        dbModel.SaveChanges();
                        ViewBag.SuccessMessage = "You have registered as" + " " + userModel.Username;
                        return View("Registration", new RegistrationView());
                    }
                   
                    
                }
            }
            else
            {
                ModelState.Clear();
                return View("Registration", new RegistrationView());
            }          
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginView userModel, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                var data = dbModel.User.Where(x => x.Username == userModel.Username && x.Password == userModel.Password).FirstOrDefault();//lathos ean den epistrepsei tipota
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
                        return RedirectToAction("Contact", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Wrong User");
                    return View();
                }
            }
                                     
             else
             {
                 ModelState.Clear();
                 ModelState.AddModelError("", "Null credentials");
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