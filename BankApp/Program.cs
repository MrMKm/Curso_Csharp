using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var inversionAccout = new InversionAccount("Ricardo Orozco", 200, 50);

            inversionAccout.Deposit(100, DateTime.Now, "Saving");
            inversionAccout.Deposit(100, DateTime.Now, "Saving");
            inversionAccout.Deposit(200, DateTime.Now, "Saving");

            Console.WriteLine(inversionAccout.GetInversionReport());
        }
    }
}
