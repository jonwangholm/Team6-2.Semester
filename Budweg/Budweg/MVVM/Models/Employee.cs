using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budweg.MVVM.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsHR { get; set; }

        public Employee(string name, string email, bool isHr)
        {
            Name = name;
            Email = email;
            IsHR = isHr;
        }
    }
}
