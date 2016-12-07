using CsvHelper;
using DemoApplication.Core.Interface;
using DemoApplication.Domain.Entities;
using DemoApplication.Domain.Entities.EmployeeIncome;
using DemoApplication.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Services.Service
{
    public class IncomeCalculationService: IIncomeCalculationService
    {       
        private readonly IIncomeCalculationRepository _incomeCalculationRepository;

        public IncomeCalculationService(IIncomeCalculationRepository incomeCalculationRepository)
        {
            _incomeCalculationRepository = incomeCalculationRepository;
        }

        public IEnumerable<EmployeeIncome> CalculateTotalIncomeInYear(string filePath)
        {            
            try
            {
                var csv = new CsvReader(new StreamReader(filePath));

                IEnumerable<EmployeeIncomeCsvFormat> EmployeeIncomeData = csv.GetRecords<EmployeeIncomeCsvFormat>().ToList();

                if(EmployeeIncomeData == null || EmployeeIncomeData.Count()==0)
                    throw new ArgumentNullException("route", "Input file cannot be null or empty");

                var pivotQuery = from y in
                                    (from y in EmployeeIncomeData
                                     group y by y.Year into g                                     
                                     select new
                                     {
                                         Year = g.Key,                                
                                         January = g.Where(x => (int)x.Month == 1).Sum(x => x.Income),
                                         February = g.Where(x => (int)x.Month == 2).Sum(x => x.Income),
                                         March = g.Where(x => (int)x.Month == 3).Sum(x => x.Income),
                                         April = g.Where(x => (int)x.Month == 4).Sum(x => x.Income),
                                         May = g.Where(x => (int)x.Month == 5).Sum(x => x.Income),
                                         June = g.Where(x => (int)x.Month == 6).Sum(x => x.Income),
                                         July = g.Where(x => (int)x.Month == 7).Sum(x => x.Income),
                                         August = g.Where(x => (int)x.Month == 8).Sum(x => x.Income),
                                         September = g.Where(x => (int)x.Month == 9).Sum(x => x.Income),
                                         October = g.Where(x => (int)x.Month == 10).Sum(x => x.Income),
                                         November = g.Where(x => (int)x.Month == 11).Sum(x => x.Income),
                                         December = g.Where(x => (int)x.Month == 12).Sum(x => x.Income)
                                     }).ToList()
                                     select new EmployeeIncome
                                     {
                                         Year = y.Year,
                                         January = y.January,
                                         February = y.February,
                                         March = y.March,
                                         April = y.April,
                                         May = y.May,
                                         June = y.June,
                                         July = y.July,
                                         August = y.August,
                                         September = y.September,
                                         October = y.October,
                                         November = y.November,
                                         December = y.December
                                     };

                return pivotQuery.ToList();                
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                throw ex;
            }
        }

        public IEnumerable<EmployeeIncomeAverage> CalculateAverageIncomePerYear(string filePath)
        {
            try
            {
                var csv = new CsvReader(new StreamReader(filePath));

                IEnumerable<EmployeeIncomeCsvFormat> EmployeeIncomeData = csv.GetRecords<EmployeeIncomeCsvFormat>().ToList();

                var pivotQuery = from y in
                                     (from y in EmployeeIncomeData
                                      group y by y.Year into g
                                      select new
                                      {
                                          Year = g.Key,
                                          AverageIncome = g.Average(x => x.Income)
                                      }).ToList()
                                 select new EmployeeIncomeAverage
                                 {
                                     Year = y.Year,
                                     AverageIncome = y.AverageIncome
                                 };

                return pivotQuery;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message + ex.InnerException != null ? ex.InnerException.Message : "");
                throw ex;
            }
        }        
    }
}
