using DemoApplication.Core.Interface;
using DemoApplication.Domain.Entities.EmployeeIncome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Core.Repository
{
    public class EfIncomeCalculationRepository : IIncomeCalculationRepository
    {
        public EmployeeIncomeCsvFormat CalculateTotalIncomeInYear()
        {
            EmployeeIncomeCsvFormat e = new EmployeeIncomeCsvFormat();
            e.Year = "2016";
            

            return e;
        }
    }
}
