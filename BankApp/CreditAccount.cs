using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class CreditAccount : Account
    {
        public decimal Fee { get; } = 0.07m;

        private decimal OverCharge
        {
            get {
                decimal balance = 0;
                foreach (var transaction in TransactionsList)
                {
                    balance += transaction.Amount;
                }

                if (balance < 0)
                    return balance;

                return 0;
            }
        }

        public CreditAccount(string name, decimal creditLimit) 
            : base(name, creditLimit) { }

        public decimal GetInterest()
        {
            if(OverCharge < 0)
            {
                return OverCharge * Fee;
            }

            return 0;
        }

        public string GetCreditReport()
        {
            Console.WriteLine(PrintHistory());

            decimal availableCredit = Balance > 0 ? Balance : 0;
            decimal interest = Math.Abs(GetInterest());

            return $"Available credit: ${availableCredit} \n" +
                $"Interest generated: ${interest}";
        }

        protected override Transaction CheckLimit(bool isOverCharge)
            => isOverCharge ? new Transaction(-500, DateTime.Now, "Over Charge") : default;
    }
}
