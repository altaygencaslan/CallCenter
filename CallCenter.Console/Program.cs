using CallCenter.Business.DTO;
using CallCenter.Business.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker.EmployeeRepository.Create(new EmployeeDto
            {
                Id = 1,
                Name = "Altay",
                LastName = "Gençaslan",
                Email = "a@g.com",
                Bonus= 0,
                Password = "123456"
            });

            Worker.EmployeeRepository.Create(new EmployeeDto
            {
                Id = 2,
                Name = "Nergiz",
                LastName = "Gençaslan",
                Email = "n@g.com",
                Bonus = 0,
                Password = "654321"
            });

            Worker.EmployeeRepository.Create(new EmployeeDto
            {
                Id = 3,
                Name = "Ahmet Deniz",
                LastName = "Gençaslan",
                Email = "ad@g.com",
                Bonus = 0,
                Password = "192837"
            });

            EmployeeDto employee = Worker.EmployeeRepository.Read(2);
            System.Console.WriteLine(employee.Name);

            System.Console.ReadKey();
        }
    }
}
