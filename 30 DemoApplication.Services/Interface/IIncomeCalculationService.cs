using DemoApplication.Domain.Entities.EmployeeIncome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Services.Interface
{
    public interface IIncomeCalculationService
    {
        IEnumerable<EmployeeIncome> CalculateTotalIncomeInYear(string filename);
        IEnumerable<EmployeeIncomeAverage> CalculateAverageIncomePerYear(string filePath);
    }
}
