using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetEtMechant.Class;
using BetEtMechant.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BetEtMechant.Controllers
{
    public class BaseController : Controller
    {
        protected readonly BetDbContext _context;

        public BaseController(BetDbContext context)
        {
            _context = context;
        }

        protected void DisplayMessage(string message, TypeMessage typeMessage)
        {

            TempData["Message"] = JsonConvert.SerializeObject(new Flash(message, typeMessage));
        }
    }
}
