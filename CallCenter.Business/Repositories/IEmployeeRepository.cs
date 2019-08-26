using CallCenter.Business.DTO;
using CallCenter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.Business.Repositories
{
    public interface IEmployeeRepository
    {
        bool Create(EmployeeDto employee);

        EmployeeDto Read(int id);

        EmployeeDto Read(string email);

        bool Update(EmployeeDto employee);

        bool BonusUpdate(int employeeid, int bonus);

        bool BonusUpdate(EmployeeDto employee, int bonus);

        EmployeeDto Read(string userName, string password);
    }
}
