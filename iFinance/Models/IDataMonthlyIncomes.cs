using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iFinance.Models
{
    public class IDataMonthlyIncomes : IMockMonthlyIncomes
    {

        //DB Connection
        private DbModel db = new DbModel();

        public IQueryable<MonthlyIncome> MonthlyIncomes { get { return db.MonthlyIncomes; } }

        public void Delete(MonthlyIncome monthlyIncome)
        {
            db.MonthlyIncomes.Remove(monthlyIncome);
            db.SaveChanges();
        }

        public MonthlyIncome Save(MonthlyIncome monthlyIncome)
        {
            if (monthlyIncome.IncomeID == 0)
            {
                db.MonthlyIncomes.Add(monthlyIncome);
            } else
            {
                db.Entry(monthlyIncome).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return monthlyIncome;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}