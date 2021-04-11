using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using VehicleShowRoomManager.IdentityConfig;
using VehicleShowRoomManager.Models;

namespace VehicleShowRoomManager.Controllers
{
    public class AccountController : Controller
    {
  
        private static ShowRoomDataContext _db;
        public AccountController()
        {
    
            _db = new ShowRoomDataContext();
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            AppUser user = userManager.Find(login.UserName, login.Password);
            if (user != null)
            {
                var ident = userManager.CreateIdentity(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
                //use the instance that has been created. 
                authManager.SignIn(
                    new AuthenticationProperties { IsPersistent = login.RememberMe }, ident);
                return Redirect(Url.Action("Index", "ShowRoom"));
            }
          
            ModelState.AddModelError("", "Invalid username or password");
            return View(login);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Register(RegisterViewModel model, List<string> Covers)
        {

            if (!ModelState.IsValid)
            {
                return View();

            }
            //to do Avartar
            var user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email
                
            };
           

            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var createUserResult = await userManager.CreateAsync(user, model.Password);
            var authManager = HttpContext.GetOwinContext().Authentication;
            if (!createUserResult.Succeeded)
            {
                var errorMsg = new StringBuilder();
                foreach(var err in createUserResult.Errors)
                {
                    errorMsg.Append(err);
                    errorMsg.Append(", ");
                }
         
                ModelState.AddModelError("", errorMsg.ToString());
           
                return View();
            }
            //login user
            var ident = userManager.CreateIdentity(user,
                      DefaultAuthenticationTypes.ApplicationCookie);
            //use the instance that has been created. 
            authManager.SignIn(
                new AuthenticationProperties { IsPersistent = false }, ident);
            return Redirect(Url.Action("Index", "ShowRoom"));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }
    }
}