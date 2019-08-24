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
        Employee Read(int id);

        bool Update(Employee employee);

        bool BonusUpdate(int employeeid, int bonus);

        bool BonusUpdate(Employee employee, int bonus);
    }
}
