using CallCenter.Business.DTO;
using CallCenter.Business.UnitOfWork;
using CallCenter.Presentation.Models;
using CallCenter.Presentation.Models.Login;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CallCenter.Presentation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public AccessToken accessToken
        {
            get
            {
                AccessToken token = (AccessToken)TempData["AccessToken"];
                if (token != null && token.access_date > DateTime.Now)
                    return token;
                else
                    accessToken = GetToken().Result;

                return accessToken;
            }

            set
            {
                value.access_date = DateTime.Now.AddSeconds(value.expires_in);
                TempData["AccessToken"] = value;
            }
        }
        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<TicketDto> ticketList = Worker.TicketRepository.ReadAll();
            foreach (TicketDto item in ticketList)
            {
                item.TicketOwnerFullName = GetCustomerFullName(accessToken.access_token, item.TicketOwnerId).Result;
            }
            return View(ticketList);
        }

        public ActionResult Detail(int id)
        {
            TicketDto ticket = Worker.TicketRepository.Read(id);
            ticket.TicketOwnerFullName = GetCustomerFullName(accessToken.access_token, ticket.TicketOwnerId).Result;
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
            return RedirectToAction("Detail", new { id = id });
        }

        private async Task<AccessToken> GetToken()
        {
            using (var client = new HttpClient())
            {
                EmployeeDto employeeDto = Worker.EmployeeRepository.Read(HttpContext.User.Identity.Name);

                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("username", employeeDto.Email));
                postData.Add(new KeyValuePair<string, string>("password", employeeDto.Password));
                postData.Add(new KeyValuePair<string, string>("grant_type", "password"));

                HttpContent content = new FormUrlEncodedContent(postData);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                var responseResult = client.PostAsync("http://localhost:52632/token", content).Result;

                return JsonConvert.DeserializeObject<AccessToken>(responseResult.Content.ReadAsStringAsync().Result);
            }
        }

        private async Task<string> GetCustomerFullName(string token, int customerid)
        {
            string fullname = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52632/");
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage responseMessage = client.GetAsync("api/Customers/" + customerid).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    var customerResultStr = responseMessage.Content.ReadAsStringAsync().Result;
                    if (!string.IsNullOrEmpty(customerResultStr))
                    {
                        EmployeeDto resultCustomer = JsonConvert.DeserializeObject<EmployeeDto>(customerResultStr);
                        if (resultCustomer != null && resultCustomer.Id > 0 &&
                            !string.IsNullOrEmpty(resultCustomer.Name) &&
                            !string.IsNullOrEmpty(resultCustomer.LastName))
                            fullname = string.Format("{0} {1}", resultCustomer.Name, resultCustomer.LastName);
                    }
                }
            }

            return fullname;
        }
    }
}