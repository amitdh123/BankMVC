using MVC_Latest.Models;
using MVC_Latest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Latest.Controllers
{
    [HandleError]
    public class AuthenticationController : Controller
    {

        public IMyAuthenticationService MyAuthService { get; set; }
        // public IMyMembershipService MyMembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (MyAuthService == null) { MyAuthService = new MyAuthenticationService(); }

            base.Initialize(requestContext);
        }

        // GET: Authentication
        public ActionResult Index()
        {
            AuthenticationData data = new AuthenticationData();      
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(AuthenticationData data , string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (MyAuthService.SignIn(data.username, data.password, false))
                {
                    if (!String.IsNullOrEmpty(returnUrl))
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
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(data);
        }

        public ActionResult LogOff()
        {
            MyAuthService.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}