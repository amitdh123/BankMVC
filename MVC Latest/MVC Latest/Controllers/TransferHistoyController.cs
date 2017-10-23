using MVC_Latest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Latest.Controllers
{
    public class TransferHistoyController : Controller
    {
        // GET: TransferHistoy

        [Authorize (Roles ="Customer")]
        public ActionResult TransferHistoryRetrieve()
        {
            TransferHistoryList history = new TransferHistoryList();
            string username = HttpContext.User.Identity.Name;
            IBusinessAccount iba = GenericFactory<BusinessLayer, IBusinessAccount>.CreateInstance();
            string checkingAccountNumber = iba.GetCheckingAccountNumber(username);
            history.transferHistoryList  = iba.GetTransferHistory(checkingAccountNumber);
            return View(history);
        }
    }
}