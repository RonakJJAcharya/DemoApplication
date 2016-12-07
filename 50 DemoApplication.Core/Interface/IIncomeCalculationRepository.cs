using DemoApplication.Domain.Entities.EmployeeIncome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Core.Interface
{
    public interface IIncomeCalculationRepository
    {
        EmployeeIncomeCsvFormat CalculateTotalIncomeInYear();
    }
}
