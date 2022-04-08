using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class GiftCardAccount : Account
    {
        public GiftCardAccount(string name, decimal initalBalance) : base(name, initalBalance) { }

        public string PrintHistory()
        {
            string result = "";

            foreach(var transaction in TransactionsList)
                result += transaction.PrettyToString();

            return result;
        }
    }
}
