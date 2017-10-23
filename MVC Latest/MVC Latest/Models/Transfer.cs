using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Latest.Models
{
    public class Transfer
    {
        public double chkBalance { get; set; }
        public double savBalance { get; set; }
        public double amtToTransfer { get; set; }
        public string status { get; set; }
    }
}