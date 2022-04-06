using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReminderChallenge
{
    class User
    {
        public static DateTime remindDate { get; set; }
        public static DateTime actualDate { get; set; }
        public static string eventName { get; set; }
        public static int remaindDays { get; set; }
    }

    class Program
    {
        static async Task<bool> DateValidator(string date)
        {
            Regex regex = new Regex(@"^[\d]{2}/[\d]{2}/[\d]{4}$");
            return regex.IsMatch(date);
        }

        static async Task Reminder()
        {
            while(User.actualDate.Date <= User.remindDate.Date)
            {
                Console.Clear();

                if (User.remindDate.Date == User.actualDate.Date)
                {
                    Console.WriteLine(User.eventName + " it's today!!!");
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    break;
                }

                if ((User.remindDate - User.actualDate).TotalDays <= User.remaindDays)
                {
                    Console.WriteLine("Only remains " 
                        + (int)((User.remindDate - User.actualDate).TotalDays) + " days");
                    User.actualDate = User.actualDate.Date.AddDays(1);
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }

                else
                {
                    Console.WriteLine(User.actualDate.ToString("d"));
                    User.actualDate = User.actualDate.Date.AddDays(1);
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            }
        }

        static async Task Main(string[] args)
        {
            bool validDates = false;
            string dateInput = "";

            Console.WriteLine("Event's name:");
            User.eventName = Console.ReadLine();
            if(String.IsNullOrEmpty(User.eventName))
            {
                Console.WriteLine("Invalid event's name... try again");
                await Task.Delay(TimeSpan.FromSeconds(2));
                return;
            }

            while (!validDates)
            {
                Console.Clear();
                Console.WriteLine("Event's date:\nFormat(dd/mm/yyyy)");
                dateInput = Console.ReadLine();
                if (await DateValidator(dateInput))
                {
                    try
                    {
                        User.remindDate = DateTime.ParseExact(dateInput, "d", null);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("\nInvalid date, try again...");
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        continue;
                    }
                }

                else
                {
                    Console.WriteLine("\nInvalid date, try again...");
                    await Task.Delay(TimeSpan.FromSeconds(2));
                    continue;
                }

                Console.WriteLine();

                Console.WriteLine("Actual date:\nFormat(dd/mm/yyyy)");
                dateInput = Console.ReadLine();
                if (await DateValidator(dateInput))
                {
                    try
                    {
                        User.actualDate = DateTime.ParseExact(dateInput, "d", null);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\nInvalid date, try again...");
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        continue;
                    }
                }

                else
                {
                    Console.WriteLine("\nInvalid date, try again...");
                    await Task.Delay(TimeSpan.FromSeconds(2));
                    continue;
                }

                if(User.remindDate.Date > User.actualDate.Date)
                    validDates = true;

                else
                {
                    Console.WriteLine("\nInvalid dates, try again...");
                    await Task.Delay(TimeSpan.FromSeconds(2));
                    continue;
                }

            }

            Console.WriteLine();
            Console.WriteLine("Days to remind you:");
            try
            {
                Int32.TryParse(Console.ReadLine(), out int remindDays);
                User.remaindDays = remindDays;
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid format to remind days");
            }

            await Reminder();
        }
    }
}
