using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.Business.DTO
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    var plainTextBytes = Encoding.UTF8.GetBytes(value);
                    _password = Convert.ToBase64String(plainTextBytes);
                }
            }
        }

        public int Bonus { get; set; }
    }
}
