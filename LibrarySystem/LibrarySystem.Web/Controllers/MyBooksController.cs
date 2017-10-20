using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Web.Controllers
{
    public class MyBooksController : Controller
    {
        // GET: MyBooks
        public ActionResult Index()
        {
            return View();
        }
    }
}