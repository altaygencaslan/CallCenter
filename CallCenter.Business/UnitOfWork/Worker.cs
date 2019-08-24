using CallCenter.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.Business.UnitOfWork
{
    public class Worker
    {
        private static CallCenterDbContext _connection;
        public static CallCenterDbContext Connection
        {
            get
            {
                if (_connection == null)
                    _connection = new CallCenterDbContext();

                return _connection;
            }
        }

        private static TicketRepository _ticketRepository;
        public static TicketRepository TicketRepository
        {
            get
            {
                if (_ticketRepository == null)
                    _ticketRepository = new TicketRepository();

                return _ticketRepository;
            }
        }

        private static EmployeeRepository _employeeRepository;
        public static EmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository();

                return _employeeRepository;
            }
        }

        public static int SaveChanges()
        {
            return Connection.SaveChanges();
        }
    }
}
