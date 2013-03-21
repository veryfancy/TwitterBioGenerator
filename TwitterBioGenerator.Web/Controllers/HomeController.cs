using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterBioGenerator.Web;

namespace TwitterBioGenerator.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index", null, new Generator().GenerateBio());
        }
    }
}
