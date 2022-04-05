using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterChallenge
{
    class Company
    {
        public int ID { get; set; }
        public string CompanyName { get; set; } 
        public string CompanyAdmin { get; set; }
        public DateTime Antiquity { get; set; }
        public bool Active { get; set; } = false;

        public static bool GetByID(Company company)
        {
            var validID = Int32.TryParse(User.Input, out int id);

            if (validID)
                return company.ID.Equals(id);
            else
                return false;
        }

        public static bool GetByCompanyName(Company company)
        {
            return company.CompanyName.Contains(User.Input);
        }

        public static bool GetByAdminName(Company company)
        {
            return company.CompanyAdmin.Contains(User.Input);
        }

        public static bool GetActiveCompanies(Company company)
        {
            return company.Active;
        }

        public static bool GetByAntiquity(Company company)
        {
            var startRange = User.startDate.Split('/').ToList();
            DateTime startDate = new DateTime(Int32.Parse(startRange[0]), Int32.Parse(startRange[1]), 1);

            var endRange = User.endDate.Split('/').ToList();
            DateTime endDate = new DateTime(Int32.Parse(endRange[0]), Int32.Parse(endRange[1]), 30);

            return company.Antiquity.Date >= startDate && company.Antiquity.Date <= endDate;
        }

        public static string PrintCompany(Company company)
        {
            string companyToString =
                "\n" + company.ID.ToString() +
                "\n" + company.CompanyName +
                "\n" + company.CompanyAdmin +
                "\n" + company.Antiquity.ToString() +
                "\n" + company.Active.ToString() + "\n";

            return companyToString;
        }
    }

    class User
    {
        public static string Input { get; set; }
        public static string startDate { get; set; }
        public static string endDate { get; set; }
    }

    class Program
    {
        static void Searcher(int opc, List<Company> companies)
        {
            switch (opc)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("ID: ");
                    User.Input = Console.ReadLine();

                    Predicate<Company> predicateByID = new Predicate<Company>(Company.GetByID);

                    List<Company> results = companies.FindAll(predicateByID);

                    if (results.Any())
                    {
                        foreach (var item in results)
                            Console.WriteLine(Company.PrintCompany(item));
                    }

                    else
                        Console.WriteLine("Companies don't found");
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Company Name: ");
                    User.Input = Console.ReadLine();

                    Predicate<Company> predicateByCompanyName = new Predicate<Company>(Company.GetByCompanyName);

                    results = companies.FindAll(predicateByCompanyName);

                    if (results.Any())
                    {
                        foreach (var item in results)
                            Console.WriteLine(Company.PrintCompany(item));
                    }

                    else
                        Console.WriteLine("Companies don't found");
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("Company Admin Name: ");
                    User.Input = Console.ReadLine();

                    Predicate<Company> predicateByAdminName = new Predicate<Company>(Company.GetByAdminName);

                    results = companies.FindAll(predicateByAdminName);

                    if (results.Any())
                    {
                        foreach (var item in results)
                            Console.WriteLine(Company.PrintCompany(item));
                    }

                    else
                        Console.WriteLine("Companies don't found");
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("Start Date (Format: yyyy/mm): ");
                    User.startDate = Console.ReadLine();
                    Console.WriteLine("End Date (Format: yyyy/mm): ");
                    User.endDate = Console.ReadLine();

                    DateSearcher(companies);

                    break;

                case 5:
                    Console.Clear();

                    Predicate<Company> predicateByActives = new Predicate<Company>(Company.GetActiveCompanies);

                    results = companies.FindAll(predicateByActives);

                    if (results.Any())
                    {
                        foreach (var item in results)
                            Console.WriteLine(Company.PrintCompany(item));
                    }

                    else
                        Console.WriteLine("Companies don't found");

                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option");
                    break;
            }

            static void DateSearcher(List<Company> companies)
            {
                Predicate<Company> predicateByDate = new Predicate<Company>(Company.GetByAntiquity);

                List<Company> results = companies.FindAll(predicateByDate);

                if (results.Any())
                {
                    foreach (var item in results)
                        Console.WriteLine(Company.PrintCompany(item));
                }

                else
                    Console.WriteLine("Companies don't found");
            }


        }

        static void Main(string[] args)
        {
            List<Company> companies = new List<Company>()
            {
                new Company()
                {ID = 1, CompanyName = "Company 1", CompanyAdmin = "Ricardo", Antiquity = new DateTime(1998, 12, 17)},
                new Company()
                {ID = 2, CompanyName = "Company 2", CompanyAdmin = "Jair", Antiquity = new DateTime(1997, 12, 17)},
                new Company()
                {ID = 3, CompanyName = "Company 3", CompanyAdmin = "Orozco", Antiquity = new DateTime(1996, 12, 17)},
                new Company()
                {ID = 4, CompanyName = "Company 4", CompanyAdmin = "Alvarez", Antiquity = new DateTime(1995, 12, 17)},
                new Company()
                {ID = 5, CompanyName = "Company 5", CompanyAdmin = "Ricardo", Antiquity = new DateTime(1994, 12, 17)},
                new Company()
                {ID = 6, CompanyName = "Company 6", CompanyAdmin = "Jair", Antiquity = new DateTime(1993, 12, 17)},
                new Company()
                {ID = 7, CompanyName = "Company 7", CompanyAdmin = "Orozco", Antiquity = new DateTime(1992, 12, 17)},
                new Company()
                {ID = 8, CompanyName = "Company 8", CompanyAdmin = "Alvarez", Antiquity = new DateTime(1991, 12, 17)},
                new Company()
                {ID = 9, CompanyName = "Company 9", CompanyAdmin = "Ricardo", Antiquity = new DateTime(1990, 12, 17)},
                new Company()
                {ID = 10, CompanyName = "Company 10", CompanyAdmin = "Jair", Antiquity = new DateTime(1999, 12, 17)},
                new Company()
                {ID = 11, CompanyName = "Company 11", CompanyAdmin = "Orozco", Antiquity = new DateTime(1998, 12, 17)},
                new Company()
                {ID = 12, CompanyName = "Company 12", CompanyAdmin = "Alvarez", Antiquity = new DateTime(1997, 12, 17)},
                new Company()
                {ID = 13, CompanyName = "Company 13", CompanyAdmin = "Ricardo", Antiquity = new DateTime(1996, 12, 17)},
                new Company()                     
                {ID = 14, CompanyName = "Company 14", CompanyAdmin = "Jair", Antiquity = new DateTime(1995, 12, 17)},
                new Company()
                {ID = 15, CompanyName = "Company 15", CompanyAdmin = "Orozco", Antiquity = new DateTime(1994, 12, 17)},
                new Company()
                {ID = 16, CompanyName = "Company 16", CompanyAdmin = "Alvarez", Antiquity = new DateTime(1993, 12, 17)},
                new Company()
                {ID = 17, CompanyName = "Company 17", CompanyAdmin = "Ricardo", Antiquity = new DateTime(1992, 12, 17)},
                new Company()
                {ID = 18, CompanyName = "Company 18", CompanyAdmin = "Jair", Antiquity = new DateTime(1991, 12, 17)},
                new Company()
                {ID = 19, CompanyName = "Company 19", CompanyAdmin = "Orozco", Antiquity = new DateTime(1990, 12, 17)},
                new Company()
                {ID = 20, CompanyName = "Company 20", CompanyAdmin = "Alvarez", Antiquity = new DateTime(2000, 12, 17)},
            };

            Console.Write("Choose an searching option:\n" +
                "1. ID\n" +
                "2. Company Name\n" +
                "3. Admin Name\n" +
                "4. Antiquity\n" +
                "5. Active companies\n\n" +
                "Type your option: ");

            int opc = Convert.ToInt32(Console.ReadLine());
            Searcher(opc, companies);
        }
    }
}
