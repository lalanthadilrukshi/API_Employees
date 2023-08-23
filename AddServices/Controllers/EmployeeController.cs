using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddServices.Models;
namespace AddServices.Controllers
{
    //[EnableCors("*", "*", "*")]//any origin, anyheader, any method
    //  [EnableCors(origins: "http://myclient.azurewebsites.net", headers: "*", methods: "*", SupportsCredentials = true)]
   // [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]




   // [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
       // [Route("GetAll")]
        // [HttpGet, Route("GetAll")]

        // public async Task<string> Message()
        [Route("api/Employee/GetAll")]
        public List<Employee> GetAll()
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee{Id=101,Name="Abhinav",Location="Bangalore",Salary=12345},

                new Employee{Id=102,Name="Abhishek",Location="Chennai",Salary=23456},

                new Employee{Id=103,Name="Akshay",Location="Bangalore",Salary=34567},

                new Employee{Id=104,Name="Akash",Location="Chennai",Salary=45678},

                new Employee{Id=105,Name="Anil",Location="Bangalore",Salary=56789}
            };
            return empList;
        }



    }
}
