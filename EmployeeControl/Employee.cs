using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeControl
{
    public class Employee : User
    {
        public List<Tuple<int, string>> HoursRegistred = new List<Tuple<int, string>>();

        public Employee() { }
        public Employee(string Name, DateTime EntryDate, string Password) : base(Name, EntryDate, Password) { }
        public Employee(string Name) : base(Name) { }

        public void RegisterHours(Tuple<int, string> hours)
        {
            HoursRegistred.Add(hours);
        }
    }
}
