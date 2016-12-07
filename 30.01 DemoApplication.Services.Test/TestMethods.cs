using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;
using DemoApplication.Domain.Entities.EmployeeIncome;
using System.Collections.Generic;
using DemoApplication.Services.Service;
using DemoApplication.Core.Interface;
using DemoApplication.Web.Models.ViewModel;

namespace DemoApplication.Services.Test
{
    [TestClass]
    public class TestMethods
    {
        Mock<IIncomeCalculationRepository> _mockincomeCalculationRepository;
        IncomeCalculationService _incomeCalculationService;

        [TestInitialize]
        public void Setup()
        {
            _mockincomeCalculationRepository = new Mock<IIncomeCalculationRepository>();
            _incomeCalculationService = new IncomeCalculationService(_mockincomeCalculationRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "File path cannot be null or empty")]
        public void EmptyFileName_TestMethod()
        {
            string filePath = "";
            EmployeeIncomeVm employeeIncomeVm = new EmployeeIncomeVm(filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "File path does not exist")]
        public void IncorrectFileName_TestMethod()
        {
            string filePath = ("E:\\souce code\\DemoApplication\\DemoApplication.Web\\Content\\IncorrectFile.csv");
            EmployeeIncomeVm employeeIncomeVm = new EmployeeIncomeVm(filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Input file cannot be null or empty")]
        public void CalculateTotalIncomeInYear_NullFile_TestMethod()
        {
            string filePath = ("E:\\souce code\\DemoApplication\\DemoApplication.Web\\Content\\SampleData_TestProject.csv"); // physical location of file
            IEnumerable<EmployeeIncome> employeeIncome = _incomeCalculationService.CalculateTotalIncomeInYear(filePath);
        }

        [TestMethod]        
        public void CalculateTotalIncomeInYear_TestMethod()
        {
            string filePath = ("E:\\souce code\\DemoApplication\\DemoApplication.Web\\Content\\SampleData.csv"); // physical location of file
            var employeeIncome = _incomeCalculationService.CalculateTotalIncomeInYear(filePath);

            decimal actualJanuaryTotalSum = employeeIncome.Where(x => x.Year == "2016").FirstOrDefault().January;
            decimal expectedJanuaryTotalSum = 410;

            Assert.AreEqual(expectedJanuaryTotalSum, actualJanuaryTotalSum);                       
        }
        
    }
}
