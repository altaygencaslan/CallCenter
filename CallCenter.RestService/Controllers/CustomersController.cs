using CallCenter.Business.DTO;
using CallCenter.Business.UnitOfWork;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CallCenter.RestService.Controllers
{
    public class CustomersController : ApiController
    {
        [Authorize]
        public IHttpActionResult Get(int id)
        {
            EmployeeDto employee = Worker.EmployeeRepository.Read(id);

            //throw new Exception("ExceptionHandler testi");

            if (employee == null)
                return NotFound();
            else
                return Ok(employee);
        }
    }
}
