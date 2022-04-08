using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeControl
{
    public class Employee : User
    {
        public List<Activity> ActivitiesRegistered = new List<Activity>();

        public Employee() { }
        public Employee(string Name, DateTime EntryDate, string Password) : base(Name, EntryDate, Password) { }
        public Employee(string Name) : base(Name) { }

        public void RegisterHours(Activity hours)
        {
            ActivitiesRegistered.Add(hours);
        }

        public string PrintRegisteredActivities()
        {
            var sb = new StringBuilder();

            foreach (var activity in ActivitiesRegistered)
            {
                sb.AppendLine($"Hours: {activity.Hours}");
                sb.AppendLine($"Description: {activity.Description}");
                sb.AppendLine($"Date: {activity.Date.Date.ToShortDateString()} \n\n");
            }

            if (!ActivitiesRegistered.Any())
                Console.WriteLine("Activities not found");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();

            return sb.ToString();
        }
    }
}
