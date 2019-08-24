using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallCenter.Business.UnitOfWork;
using CallCenter.Data;

namespace CallCenter.Business.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public bool BonusUpdate(Employee employee, int bonus)
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
            return BonusUpdate(employeeUpdating, bonus);
        }

        public Employee Read(int id)
        {
            return Worker.Connection.Employee.Find(id);
        }

        public bool Update(Employee employee)
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
