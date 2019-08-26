using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallCenter.Business.DTO;
using CallCenter.Business.UnitOfWork;
using CallCenter.Data;

namespace CallCenter.Business.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public bool BonusUpdate(EmployeeDto employee, int bonus)
        {
            Employee employeeUpdating = Worker.Connection.Employee.Find(employee.Id);
            if (employeeUpdating != null)
            {
                employeeUpdating.Bonus += bonus;
                return Worker.SaveChanges() > 0;
            }

            return false;
        }

        public bool BonusUpdate(int employeeid, int bonus)
        {
            Employee employeeUpdating = Worker.Connection.Employee.Find(employeeid);
            if (employeeUpdating != null)
            {
                employeeUpdating.Bonus += bonus;
                return Worker.SaveChanges() > 0;
            }

            return false;
        }

        public bool Create(EmployeeDto employee)
        {
            Employee newEmployee = new Employee
            {
                Id = employee.Id,
                Name = employee.Name,
                LastName = employee.LastName,
                Email = employee.Email,
                Password = employee.Password,
                Bonus = employee.Bonus
            };

            Worker.Connection.Employee.Add(newEmployee);
            return Worker.SaveChanges() > 0;
        }

        public EmployeeDto Read(int id)
        {
            Employee employee = Worker.Connection.Employee.Find(id);
            if (employee != null)
            {
                EmployeeDto employeeDto = new EmployeeDto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Bonus = employee.Bonus
                };

                return employeeDto;
            }

            return null;
        }

        public EmployeeDto Read(string userName, string password)
        {
            EmployeeDto employeeLogin = new EmployeeDto { Email = userName, Password = password };
            Employee employee = Worker.Connection.Employee.Where(w => w.Email.Equals(employeeLogin.Email) &&
                                                                      w.Password.Equals(employeeLogin.Password))
                                                          .FirstOrDefault();
            if (employee != null)
            {
                EmployeeDto employeeDto = new EmployeeDto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Bonus = employee.Bonus
                };

                return employeeDto;
            }

            return null;
        }

        public EmployeeDto Read(string email)
        {
            Employee employee = Worker.Connection.Employee.Where(w => w.Email.Equals(email)).FirstOrDefault();
            if (employee != null)
            {
                EmployeeDto employeeDto = new EmployeeDto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Bonus = employee.Bonus
                };

                return employeeDto;
            }

            return null;
        }

        public bool Update(EmployeeDto employee)
        {
            Employee employeeUpdating = Worker.Connection.Employee.Find(employee.Id);
            employeeUpdating.Email = employee.Email;
            employeeUpdating.Name = employee.Name;
            employeeUpdating.LastName = employee.LastName;
            employeeUpdating.Bonus += employee.Bonus;

            return Worker.SaveChanges() > 0;
        }
    }
}
