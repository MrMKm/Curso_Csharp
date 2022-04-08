using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeControl
{
    public class Supervisor : User
    {
        public static List<Employee> EmployeeList = new List<Employee>();

        public Supervisor() { }
        public Supervisor(string Name, DateTime EntryDate, string Password) : base(Name, EntryDate, Password) { }
        public Supervisor(string Name) : base(Name) { }

        public void ValidateHours(List<Tuple<int, string>> employeeHours, int employeeID)
        {
            var employee = EmployeeList.Find(e => e.ID.Equals(employeeID));

            if(employee != null)
            {
                foreach(var hours in employeeHours)
                {
                    employee.Hours.Add(hours);
                }

                employee.HoursRegistred.Clear();
            }
        }

        public Employee GetEmployeeByID(int employeeID)
        {
            var employee = EmployeeList.Find(e => e.ID.Equals(employeeID));

            return employee;
        }

        public void AddEmployeeToTeam(Employee employee)
        {
            EmployeeList.Add(employee);
        }

        public Employee AddEmployeeToSystem(string name)
        {
            Employee employee = new Employee(name);
            return employee;
        }

        public void EditEmployee(string employeeName, DateTime entryDate, int employeeID)
        {
            foreach(var e in EmployeeList)
            {
                if(e.ID.Equals(employeeID))
                {
                    e.Name = employeeName;
                    e.EntryDate = entryDate;

                    break;
                }
            }
        }

        public void DeleteEmployee(int employeeID)
        {
            var employee = EmployeeList.Find(e => e.ID.Equals(employeeID));

            EmployeeList.Remove(employee);
        }
    }
}
