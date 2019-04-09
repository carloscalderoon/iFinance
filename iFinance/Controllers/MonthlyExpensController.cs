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

    public class MonthlyExpensController : Controller
    {
        private DbModel db = new DbModel();

        // GET: MonthlyExpens
        public ActionResult Index()
        {
            return View(db.MonthlyExpenses.ToList());
        }

        // GET: MonthlyExpens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyExpens monthlyExpens = db.MonthlyExpenses.Find(id);
            if (monthlyExpens == null)
            {
                return HttpNotFound();
            }
            return View(monthlyExpens);
        }

        // GET: MonthlyExpens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonthlyExpens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionID,Name,Amount,Date")] MonthlyExpens monthlyExpens)
        {
            if (ModelState.IsValid)
            {
                db.MonthlyExpenses.Add(monthlyExpens);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monthlyExpens);
        }

        // GET: MonthlyExpens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyExpens monthlyExpens = db.MonthlyExpenses.Find(id);
            if (monthlyExpens == null)
            {
                return HttpNotFound();
            }
            return View(monthlyExpens);
        }

        // POST: MonthlyExpens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactionID,Name,Amount,Date")] MonthlyExpens monthlyExpens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monthlyExpens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monthlyExpens);
        }

        // GET: MonthlyExpens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyExpens monthlyExpens = db.MonthlyExpenses.Find(id);
            if (monthlyExpens == null)
            {
                return HttpNotFound();
            }
            return View(monthlyExpens);
        }

        // POST: MonthlyExpens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonthlyExpens monthlyExpens = db.MonthlyExpenses.Find(id);
            db.MonthlyExpenses.Remove(monthlyExpens);
            db.SaveChanges();
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
