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
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (string.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            EmployeeDto employeeDto = Worker.EmployeeRepository.Read(model.UserName, model.Password);
            if (employeeDto != null && !string.IsNullOrEmpty(employeeDto.Email))
            {
                FormsAuthentication.SetAuthCookie(employeeDto.Email, true);
                CallCenter.Helper.AccountInformations.SignedIn.Id = employeeDto.Id;
                CallCenter.Helper.AccountInformations.SignedIn.FullName = string.Format("{0} {1}", employeeDto.Name, employeeDto.LastName);
                CallCenter.Helper.AccountInformations.SignedIn.Email = employeeDto.Email;

                return RedirectToAction("Index", "Home");
            }
            else
                ModelState.AddModelError("loginerror", "Hatalı eposta ve/veya şifre");

            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}