using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIExample.Models;
using System.Data;
using System.Data.SqlClient;
using WebAPIExample.DataAccess;

namespace WebAPIExample.Controllers
{
    public class EmployeeController : ApiController
    {

        [HttpGet]
        [ActionName("GetallEmployees")]
        public List<Employee> GetEmployees()
        {
            DAEmployee objDAEmployee = new DAEmployee();
            List<Employee> lstemployees = new List<Employee>();
            lstemployees = objDAEmployee.GetAllEmployees();
            return lstemployees;
        }

        [HttpPost]
        public void AddEmployee([FromBody]Employee objemployee)
        {
            int Result = 0;
            DAEmployee objDAEmployee = new DAEmployee();
            Result = objDAEmployee.AddEmployee(objemployee);

        }


        [HttpPut]
        [ActionName("UpdateEmployee")]
        public void UpdateEmployee(Employee objemployee)
        {
            int Result = 0;
            DAEmployee objDAEmployee = new DAEmployee();
            Result = objDAEmployee.UpdateEmployee(objemployee);

        }


        [HttpDelete]
        [ActionName("DeleteEmployee")]
        public void DeleteEmployee(int ID)
        {
            int Result = 0;
            DAEmployee objDAEmployee = new DAEmployee();
            Employee objEmployee = new Employee();
            objEmployee.EmployeeID = ID;
            Result = objDAEmployee.DeleteEmployee(objEmployee);

        }
    }
}
