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

        public List<Tuple<int, string>> Hours = new List<Tuple<int, string>>();

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

        public string PrintHours()
        {
            var sb = new StringBuilder();

            foreach(var h in Hours)
            {
                sb.AppendLine($"Hours: {h.Item1}");
                sb.AppendLine($"Description: {h.Item2} \n\n");
            }

            return sb.ToString();
        }
    }
}
