using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeControl
{
    class Users
    {
        public static List<Employee> employeeList = new List<Employee>() 
        {
            new Employee("Ricardo", new DateTime(2022, 04, 10), "password"),
            new Employee("Jair", new DateTime(2022, 04, 10), "password"),
            new Employee("Orozco", new DateTime(2022, 04, 10), "password"),
            new Employee("Alvarez", new DateTime(2022, 04, 10), "password"),
        };
        public static List<Supervisor> supervisorList = new List<Supervisor>()
        {
            new Supervisor("Carlos", new DateTime(2022, 04, 10), "password")
        };

        public static Employee employee = new Employee();
        public static Supervisor supervisor = new Supervisor();

        public static DateTime actualDate { get; set; }
    }

    class Program
    {
        static async Task<bool> CheckDate(DateTime date, DateTime actualDate)
        {
            return date.Date == actualDate.Date;
        }

        static async Task<bool> CheckCredentials(int ID, string password, int type)
        {
            if(type == 1)
            {
                foreach(var employee in Users.employeeList)
                {
                    if (employee.ID.Equals(ID) && employee.Password.Equals(password))
                    {
                        Users.employee = employee;
                        return true;
                    }
                }

                return false;
            }

            else
            {
                foreach (var supervisor in Users.supervisorList)
                {
                    if (supervisor.ID.Equals(ID) && supervisor.Password.Equals(password))
                    {
                        Users.supervisor = supervisor;
                        return true;
                    }
                }

                return false;
            }
        }

        static async Task EmployeeMenu()
        {
            int hours = 0;
            string description = "";
            bool exit = false;

            do
            {
                Console.Clear();

                if (await CheckDate(Users.employee.EntryDate, Users.actualDate))
                    Console.WriteLine($"Congratulations {Users.employee.Name} for being another year with us!!! :) \n\n");

                Console.WriteLine($"Welcome! {Users.employee.Name} \n\n" +
                    $"1. Register hours \n" +
                    $"2. See hours validates \n" +
                    $"3. Send hours to validate \n" +
                    $"4. Sign out \n\n" +
                    $"Choose an option:");

                int opc = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (opc)
                {
                    case 1:
                        Console.WriteLine("Hours: ");
                        hours = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Description: ");
                        description = Console.ReadLine();

                        Users.employee.RegisterHours(Tuple.Create(hours, description));
                        break;

                    case 2:
                        Console.WriteLine(Users.employee.PrintHours());
                        Console.ReadLine();
                        break;

                    case 3:
                        Console.WriteLine("Hours sended to Supervisor");
                        break;

                    case 4:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Option, try again...");
                        break;
                }
            } while (!exit);
        }

        static async Task SupervisorMenu()
        {
            bool exit = false;
            do
            {
                Console.Clear();

                if (await CheckDate(Users.supervisor.EntryDate, Users.actualDate))
                    Console.WriteLine($"Congratulations {Users.employee.Name} for being another year with us!!! :) \n\n");

                Console.WriteLine($"Welcome! {Users.employee.Name} \n\n" +
                    $"1. Validate employee hours \n" +
                    $"2. Add new employee \n" +
                    $"3. Edit an employee \n" +
                    $"4. Delete an employee" +
                    $"5. Sign out \n\n" +
                    $"Choose an option:");

                int opc = Convert.ToInt32(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        Console.WriteLine("Employee ID: ");
                        Users.employee = Users.supervisor.GetEmployeeByID(Convert.ToInt32(Console.ReadLine()));

                        Console.Clear();
                        Console.WriteLine(Users.employee.PrintHours());
                        Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Validate hours?");

                        if (Console.ReadLine() == "yes")
                        {
                            Users.supervisor.ValidateHours(Users.employee.HoursRegistred, Users.employee.ID);
                            Console.WriteLine("Hours validated");
                            Console.WriteLine("\n\n");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Employee ID: ");
                        Users.employee = Users.supervisor.GetEmployeeByID(Convert.ToInt32(Console.ReadLine()));

                        Users.supervisor.AddEmployee(Users.employee);
                        Console.WriteLine("Employee added");
                        Console.WriteLine("\n\n");

                        break;

                    case 3:
                        string newName = "";
                        DateTime newDate = new DateTime();

                        Console.WriteLine("Employee ID: ");
                        Users.employee = Users.supervisor.GetEmployeeByID(Convert.ToInt32(Console.ReadLine()));

                        Console.Clear();

                        Console.WriteLine("New name: ");
                        newName = Console.ReadLine();
                        Console.WriteLine("New entry date:\nFormat(dd/mm/yyyy)");
                        newDate = DateTime.ParseExact(Console.ReadLine(), "d", null);

                        Users.supervisor.EditEmployee(newName, newDate, Users.employee.ID);
                        Console.WriteLine("Employee updated");
                        Console.WriteLine("\n\n");

                        break;

                    case 4:
                        Console.WriteLine("Employee ID: ");
                        Users.employee = Users.supervisor.GetEmployeeByID(Convert.ToInt32(Console.ReadLine()));

                        Console.Clear();

                        Users.supervisor.DeleteEmployee(Users.employee.ID);
                        Console.WriteLine("Employee deleted");
                        Console.WriteLine("\n\n");

                        break;

                    case 5:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Option, try again...");
                        break;
                }
            } while (!exit);
        }

        static async Task Menu()
        {
            Console.Clear();
            Console.WriteLine("Actual date:\nFormat(dd/mm/yyyy)");
            Users.actualDate = DateTime.ParseExact(Console.ReadLine(), "d", null);

            Console.Clear();
            Console.WriteLine("\t\tLog in\n\n" +
                "Employee: 1 \nSupervisor: 2 \nExit: 3 \n\nChoose an option:");

            int opc = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            int ID = 0;
            string password = "";

            switch(opc)
            {
                case 1:
                    Console.WriteLine("Employee ID: ");
                    ID = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Password: ");
                    password = Console.ReadLine();

                    if (await CheckCredentials(ID, password, opc))
                        await EmployeeMenu();
                    break;

                case 2:
                    Console.WriteLine("Supervisor ID: ");
                    ID = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Password: ");
                    password = Console.ReadLine();

                    if (await CheckCredentials(ID, password, opc))
                        await SupervisorMenu();
                    break;

                default:
                    Console.WriteLine("Invalid Option, try again...");
                    break;
            }
        }

        static async Task Main(string[] args)
        {
            while(true)
            {
                await (Menu());
            }
        }
    }
}
