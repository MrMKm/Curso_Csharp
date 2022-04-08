using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeControl
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime EntryDate { get; set; }

        public List<Activity> Hours = new List<Activity>();

        private static int _IDSeed = 1;

        public User() { }

        public User(string Name) : this(Name, DateTime.Now, Name) { }

        public User(string Name, DateTime EntryDate, string Password)
        {
            this.ID = _IDSeed;
            this.Name = Name;
            this.Password = Password;
            this.EntryDate = EntryDate;

            _IDSeed++;
        }

        public string PrintActivities()
        {
            var sb = new StringBuilder();

            foreach (var activity in Hours)
            {
                sb.AppendLine($"Hours: {activity.Hours}");
                sb.AppendLine($"Description: {activity.Description}");
                sb.AppendLine($"Date: {activity.Date.Date.ToShortDateString()} \n\n");
            }

            if (!Hours.Any())
                Console.WriteLine("Activities not found");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();

            return sb.ToString();
        }
    }
}
