using BetEtMechant.Controllers;
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
    public abstract class BaseAdminController : BaseController
    {
        protected BaseAdminController(BetDbContext context) : base(context)
        {
        }
    }
}
