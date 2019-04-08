using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iFinance.Models;

namespace iFinance.Controllers
{
    public class HomeController : Controller
    {
        //Connection to DB

            private DbModel db = new DbModel();



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

        public ActionResult MonthlyExpenses()
        {

            var expenses = db.MonthlyExpenses.ToList();

            

            return View(expenses);
        }

        public ActionResult MonthlyIncomes()
        {
            return View();
        }

        public ActionResult ViewCharge( string ChargeName)
        {
            ViewBag.ChargeName = ChargeName;
            return View();
        }
    }
}