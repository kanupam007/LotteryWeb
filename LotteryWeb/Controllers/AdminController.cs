using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LotteryWeb.Controllers
{
    public class AdminController : Controller
    {
        // GET: Default
        [Route("Admin-Personal-Info")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("Admin-My-Tickets")]
        public ActionResult MyTickets()
        {
            return View();
        }
        [Route("Admin-Transactions")]
        public ActionResult Transactions()
        {
            return View();
        }
        [Route("Admin-Users")]
        public ActionResult Users()
        {
            return View();
        }
    }
}