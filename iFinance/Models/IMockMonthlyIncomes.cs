using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFinance.Models
{
    public interface IMockMonthlyIncomes
    {
        IQueryable<MonthlyIncome> MonthlyIncomes { get; }
        MonthlyIncome Save(MonthlyIncome monthlyIncome);
        void Delete(MonthlyIncome monthlyIncome);
        void Dispose();
    }
}
