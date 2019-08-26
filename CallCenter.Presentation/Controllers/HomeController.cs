using CallCenter.Business.DTO;
using CallCenter.Business.UnitOfWork;
using CallCenter.Presentation.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CallCenter.Presentation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<TicketDto> ticketList = Worker.TicketRepository.ReadAll();
            return View(ticketList);
        }

        public ActionResult Detail(int id)
        {
            TicketDto ticket = Worker.TicketRepository.Read(id);
            return View(ticket);
        }

        public ActionResult Assign(int id)
        {
            EmployeeDto employeeDto = Worker.EmployeeRepository.Read(HttpContext.User.Identity.Name);
            if (employeeDto != null)
            {
                TicketDto ticketDto = Worker.TicketRepository.Read(id);
                ticketDto.ResponsedUserId = employeeDto.Id;
                
                Worker.TicketRepository.AssignToMe(ticketDto);

                return RedirectToAction("Index");
            }
            return RedirectToAction("Detail",new { id = id });
        }
    }
}