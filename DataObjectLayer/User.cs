using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer
{
    public class User
    {
        public int EmployeeId { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

    }
}
