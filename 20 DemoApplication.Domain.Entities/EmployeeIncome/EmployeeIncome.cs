using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvHelper.Configuration;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace DemoApplication.Domain.Entities.EmployeeIncome
{
    public class EmployeeIncomeVm
    {
        public IEnumerable<EmployeeIncome> TotalIncome { get; set; }
        public IEnumerable<EmployeeIncomeAverage> AverageIncome { get; set; }

        #region constructor
        public EmployeeIncomeVm(string filePath)
        {
            try
            {
                if (String.IsNullOrEmpty(filePath))
                {
                    //Logger class usage for displaying error in error log using 'Elmah'
                    Logger.Log("File path cannot be null or empty");
                    throw new ArgumentNullException("filePath", "File path cannot be null or empty");
                }
                else if (!File.Exists(filePath))
                {
                    Logger.Log("File path does not exist");
                    throw new ArgumentException("File path does not exist");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
    public class EmployeeIncome
    {
        public string Year { get; set; }
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March {get; set;}
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }                
    }
    public class EmployeeIncomeAverage
    {
        public string Year { get; set; }
        public decimal AverageIncome { get; set; }
    }
    public class EmployeeIncomeCsvFormat
    {        
        public string Year { get; set; }        
        public enum MonthEnum
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6, 
            July = 7,
            Auguest = 8,
            Septempber = 9,
            October = 10, 
            November = 11,
            December = 12
        }
        public MonthEnum Month { get; set; }
        public decimal Income { get; set; }     
    }

    // Class to map .csv file columns with class or model EmployeeIncomeCsvFormat 
    public sealed class EmployeeIncomeCsvFormatClassMap : CsvClassMap<EmployeeIncomeCsvFormat>
    {
        public EmployeeIncomeCsvFormatClassMap()
        {
            Map( m => m.Year ).Index( 0 );
            Map( m => m.Month ).Index( 1 );
            Map( m => m.Income ).Index( 2 );
        }
    }    
}
