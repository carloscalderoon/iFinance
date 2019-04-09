using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iFinance.Models;

namespace iFinance.Controllers
{
    public class MonthlyIncomesController : Controller
    {
        //private DbModel db = new DbModel();
        IMockMonthlyIncomes db;

        //Constructors
        //Default Constructor
        public MonthlyIncomesController()
        {
            this.db = new IDataMonthlyIncomes();
        }

        public MonthlyIncomesController(IMockMonthlyIncomes mockDb)
        {
            this.db = mockDb;
        }

        // GET: MonthlyIncomes
        public ActionResult Index()
        {
            return View(db.MonthlyIncomes.ToList());
        }

        // GET: MonthlyIncomes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //MonthlyIncome monthlyIncome = db.MonthlyIncomes.Find(id);
            MonthlyIncome monthlyIncome = db.MonthlyIncomes.SingleOrDefault(c => c.IncomeID == id);
            if (monthlyIncome == null)
            {
                return HttpNotFound();
            }
            return View(monthlyIncome);
        }

        // GET: MonthlyIncomes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonthlyIncomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IncomeID,Origin,Amount,Date")] MonthlyIncome monthlyIncome)
        {
            if (ModelState.IsValid)
            {
                //db.MonthlyIncomes.Add(monthlyIncome);
                //db.SaveChanges();
                db.Save(monthlyIncome);
                return RedirectToAction("Index");
            }

            return View(monthlyIncome);
        }

        // GET: MonthlyIncomes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //MonthlyIncome monthlyIncome = db.MonthlyIncomes.Find(id);
            MonthlyIncome monthlyIncome = db.MonthlyIncomes.SingleOrDefault(c => c.IncomeID == id);
            if (monthlyIncome == null)
            {
                return HttpNotFound();
            }
            return View(monthlyIncome);
        }

        // POST: MonthlyIncomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IncomeID,Origin,Amount,Date")] MonthlyIncome monthlyIncome)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(monthlyIncome).State = EntityState.Modified;
                //db.SaveChanges();
                db.Save(monthlyIncome);
                return RedirectToAction("Index");
            }
            return View(monthlyIncome);
        }

        // GET: MonthlyIncomes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //MonthlyIncome monthlyIncome = db.MonthlyIncomes.Find(id);
            MonthlyIncome monthlyIncome = db.MonthlyIncomes.SingleOrDefault(c => c.IncomeID == id);
            if (monthlyIncome == null)
            {
                return HttpNotFound();
            }
            return View(monthlyIncome);
        }

        // POST: MonthlyIncomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //MonthlyIncome monthlyIncome = db.MonthlyIncomes.Find(id);
            MonthlyIncome monthlyIncome = db.MonthlyIncomes.SingleOrDefault(c => c.IncomeID == id);
            //db.MonthlyIncomes.Remove(monthlyIncome);
            //db.SaveChanges();
            db.Delete(monthlyIncome);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
