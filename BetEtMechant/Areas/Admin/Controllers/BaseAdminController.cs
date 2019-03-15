using BetEtMechant.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetEtMechant.Areas.Administration.Controllers
{
    [Area("admin")]
    [Authorize]
    public abstract class BaseAdminController : Controller
    {
        protected readonly BetDbContext _context;
        public BaseAdminController(BetDbContext context)
        {
            _context = context;
        }

        protected void DisplayMessage(string message, string type)
        {
            dynamic data = new { message, type };
            TempData["Flash"] = data;
        }

    }
}
