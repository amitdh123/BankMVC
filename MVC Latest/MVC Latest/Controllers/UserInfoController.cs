using MVC_Latest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Latest.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserInfo
        public ActionResult Register()
        {
            UserInfo ui = new UserInfo();
            return View(ui);
        }

        [HttpPost]
        public ActionResult Register(UserInfo ui)
        {
            bool res = false;
            string username = ui.username;
            string password = ui.password;
            string chkAcctNum = ui.checkingAccountNumber;

            UserInfo dataRetrieve = new UserInfo();
            Repository _dataauth = new Repository();
            res = _dataauth.RegisterUser(username, password, chkAcctNum);

            if(res == true)
            {
                dataRetrieve.status = "You have sucessfully registered";
                dataRetrieve.username = " ";
                dataRetrieve.password = "";
                dataRetrieve.checkingAccountNumber = "";

            }
            else
            {
                dataRetrieve.status = "Could not register";

            }
            return View(dataRetrieve);
        }

        /*[Authorize(Roles = "Customer")]
        public ActionResult UpdatePassword()
        {
            UserInfo ui = new UserInfo();
            return View(ui);
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public ActionResult UpdatePassword(UserInfo ui)
        {
            return View(ui);
        }*/
    }
}