using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetEtMechant.Areas.Administration.Controllers;
using BetEtMechant.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BetEtMechant.Areas.Controllers
{
    public class DashboardController : BaseAdminController
    {
        public DashboardController(BetDbContext context) : base(context)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
