using CRYBZ_CCSB.Services;
using CRYBZ_CCSB.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRYBZ_CCSB.Controllers
{
    public class ContractController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
