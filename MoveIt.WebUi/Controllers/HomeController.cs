using MoveIt.Contracts.Repositories;
using MoveIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoveIt.WebUi.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<ApplicationUser> _users;

        public HomeController(IRepository<ApplicationUser> users)
        {
            this._users = users;
        }

        public ActionResult Index()
        {
            return View();
        }

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