using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Latest.Models
{
    public class UserInfo
    {
        public string username { get; set; }
        public string password { get; set; }
        public string checkingAccountNumber { get; set; }
        public string newpassword { get; set; }
        public string status { get; set; }
    }
}