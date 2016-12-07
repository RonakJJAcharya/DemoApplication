using DemoApplication.Domain.Entities.EmployeeIncome;
using DemoApplication.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DemoApplication.Web.Models.ViewModel
{
    public class EmployeeIncomeVmBuilder 
    {
        private readonly IIncomeCalculationService _incomeCalculationService;

        public EmployeeIncomeVmBuilder(IIncomeCalculationService incomeCalculationService)
        {
            _incomeCalculationService = incomeCalculationService;
        }

        public EmployeeIncomeVm BuildEmployeeIncomeVm(string filePath)
        {            
            var income = new EmployeeIncomeVm(filePath)
            {   
                TotalIncome = _incomeCalculationService.CalculateTotalIncomeInYear(filePath),
                AverageIncome = _incomeCalculationService.CalculateAverageIncomePerYear(filePath),
            };
            return income;
        }
    }
}