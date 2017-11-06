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
            return View(new Registration());
        }

        [HttpPost]
        public ActionResult Registration(Registration userModel)
        {
            if (ModelState.IsValid)
            {
                using (dbModel)
                {
                    if (dbModel.User.Any(x => x.Username == userModel.Username))
                    {
                        ViewBag.DuplicateMessage = "User already exists";
                        return View("Registration", new Registration());
                    }
                    else
                    {
                       // dbModel.User.Add(userModel);
                        dbModel.SaveChanges();
                    }
                   
                    
                }
            }            
            ModelState.Clear();
            ViewBag.SuccessMessage = "You have registered as" + " " + userModel.Username;
            return View("Registration", new Registration());
            
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login userModel, string returnUrl)
        {
            if(ModelState.IsValid)
            {
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
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
                                     
             else
             {
                 ModelState.Clear();
                 ModelState.AddModelError("", "Invalid credentials");

                 return View();
             }

            return View();
           
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }
    }
}