using CallCenter.Business.Repositories;
using CallCenter.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;

namespace CallCenter.Business.UnitOfWork
{
    public class Worker
    {
        private static UnityContainer _container;
        public static UnityContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = new UnityContainer();
                    _container.AddNewExtension<Interception>();

                    _container.RegisterType<IEmployeeRepository, EmployeeRepository>(new Interceptor<InterfaceInterceptor>(),
                                                                            new InterceptionBehavior<LoggingAspect>());
                    _container.RegisterType<ITicketRepository, TicketRepository>(new Interceptor<InterfaceInterceptor>(),
                                                                                new InterceptionBehavior<LoggingAspect>());
                }

                return _container;
            }
        }

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

        public static ITicketRepository TicketRepository
        {
            get
            {
                return Container.Resolve<ITicketRepository>();
            }
        }
        
        public static IEmployeeRepository EmployeeRepository
        {
            get
            {
                return Container.Resolve<IEmployeeRepository>();
            }
        }

        public static int SaveChanges()
        {
            return Connection.SaveChanges();
        }
    }
}
