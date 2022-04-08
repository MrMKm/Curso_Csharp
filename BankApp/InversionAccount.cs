using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class InversionAccount : Account
    {
        public InversionAccount(string name, decimal initalSave, int minimunSave) 
            : base(name, initalSave, minimunSave) { }

        public string GetInversionReport()
        {
            Console.WriteLine(PrintHistory());

            decimal interest = Balance > 500 ? (Balance - 500) * 0.05m : 0;

            return $"Total inversion: ${Balance} \n" +
                $"Interest generated: ${interest}";
        }
    }
}
