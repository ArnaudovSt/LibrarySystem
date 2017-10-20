using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibrarySystem.Common;

namespace LibrarySystem.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class CrudController : Controller
    {
        // GET: Admin/Crud
        public ActionResult Index()
        {
            return View();
        }
    }
}