using DemoApplication.Domain.Entities.EmployeeIncome;
using DemoApplication.Services.Interface;
using DemoApplication.Web.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DemoApplication.Web.Controllers
{
    public class EmployeeIncomeController : ApiController
    {
        private readonly IIncomeCalculationService _incomeCalculationService;

        public EmployeeIncomeController(IIncomeCalculationService incomeCalculationService)
        {
            _incomeCalculationService = incomeCalculationService;
        }

        // GET api/<controller>        
        public EmployeeIncomeVm Get()       
        {           
            string filePath = HttpContext.Current.Server.MapPath("~/Content/SampleData.csv");
            //string filePath = "";
            EmployeeIncomeVmBuilder model = new EmployeeIncomeVmBuilder(_incomeCalculationService);

            return model.BuildEmployeeIncomeVm(filePath);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}