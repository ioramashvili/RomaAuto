using RomaAuto.Filters;
using RomaAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RomaAuto.Controllers
{
    [LoginFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = (MainUser)Session["user"];
            if ( user != null)
            {
                ViewBag.Message = user.Id + " " + user.Name + " " + user.LastName;
            }
            return View();
        }

        [AccessFilter]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}