using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Transaction(decimal amount, DateTime date, string description)
        {
            this.Amount = amount;
            this.Date = date;
            this.Description = description;
        }

        public string PrettyToString()
        {
            return
                $"Date: {Date.ToShortDateString()} \n" +
                $"Amount: ${Amount.ToString()} \n" +
                $"Description: {Description} \n\n";
        }
    }
}
