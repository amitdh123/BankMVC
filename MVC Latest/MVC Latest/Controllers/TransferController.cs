using MVC_Latest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Latest.Controllers
{
    public class TransferController : Controller
    {
        // GET: Transfer
        [Authorize(Roles ="Customer")]
        public ActionResult CheckingtoSaving()
        {
            Transfer chkToSav = new Transfer();
            string username = HttpContext.User.Identity.Name;
            IBusinessAccount iba = GenericFactory<BusinessLayer, IBusinessAccount>.CreateInstance();
            string chkAcctNum = iba.GetCheckingAccountNumber(username);
            chkToSav.chkBalance = iba.GetCheckingBalance(chkAcctNum);
            chkToSav.savBalance = iba.GetSavingBalance(chkAcctNum + "1");
            chkToSav.amtToTransfer = 0;
            chkToSav.status = "";
            return View(chkToSav);
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public ActionResult CheckingtoSaving(Transfer chkToSav)
        {
            string username = HttpContext.User.Identity.Name;
            IBusinessAccount iba = GenericFactory<BusinessLayer, IBusinessAccount>.CreateInstance();
            string chkAcctNum = iba.GetCheckingAccountNumber(username);

            bool res = iba.TransferFromChkgToSavViaSP(chkAcctNum, chkAcctNum + "1", chkToSav.amtToTransfer);
            if (res == true)
            {
                chkToSav.chkBalance = iba.GetCheckingBalance(chkAcctNum);
                chkToSav.savBalance = iba.GetSavingBalance(chkAcctNum + "1");
                chkToSav.status = "Amount transferred Successfully!";
            }
            else
            {
                chkToSav.status = "Amount transfer is not successful..";
            }
            return View(chkToSav);
        }


        //Transfer Logic for Saving to Checking

        [Authorize(Roles = "Customer")]
        public ActionResult SavingtoChecking()
        {
            Transfer chkToSav = new Transfer();
            string username = HttpContext.User.Identity.Name;
            IBusinessAccount iba = GenericFactory<BusinessLayer, IBusinessAccount>.CreateInstance();
            string chkAcctNum = iba.GetCheckingAccountNumber(username);
            chkToSav.chkBalance = iba.GetCheckingBalance(chkAcctNum);
            chkToSav.savBalance = iba.GetSavingBalance(chkAcctNum + "1");
            chkToSav.amtToTransfer = 0;
            chkToSav.status = "";
            return View(chkToSav);
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public ActionResult SavingtoChecking(Transfer savToChk)
        {
            string username = HttpContext.User.Identity.Name;
            IBusinessAccount iba = GenericFactory<BusinessLayer, IBusinessAccount>.CreateInstance();
            string chkAcctNum = iba.GetCheckingAccountNumber(username);

            bool res = iba.TransferSavToChk(chkAcctNum + "1" , chkAcctNum, savToChk.amtToTransfer);
            if (res == true)
            {
                savToChk.chkBalance = iba.GetCheckingBalance(chkAcctNum);
                savToChk.savBalance = iba.GetSavingBalance(chkAcctNum + "1");
                savToChk.status = "Amount transferred Successfully!";
            }
            else
            {
                savToChk.status = "Amount transfer is not successful..";
            }
            return View(savToChk);
        }
    }
}