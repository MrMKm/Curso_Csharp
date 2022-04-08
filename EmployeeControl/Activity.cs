using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeControl
{
    public class Activity
    {
        public int Hours { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Activity() { }

        public Activity(int Hours) : this(Hours, "N/A") { }

        public Activity(int Hours, string Description)
        {
            this.Hours = Hours;
            this.Description = Description;
            this.Date = DateTime.Now;
        }

        public Activity(int Hours, string Description, DateTime date)
        {
            this.Hours = Hours;
            this.Description = Description;
            this.Date = date;
        }
    }
}
