using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Account
    {
        public string Owner { get; set; }
        public string Number { get; set; }
        public decimal Balance { 
            get{
                decimal balance = 0;
                foreach(var transaction in TransactionsList)
                {
                    balance += transaction.Amount;
                }

                return balance;
            }
        }

        private readonly int _minimumBalance;
        private static int _accountNumberSeed = 1234567890;

        protected List<Transaction> TransactionsList = new List<Transaction>();

        public Account() { }

        public Account(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

        public Account(string name, decimal initialBalance, int minimumBalance)
        {
            if(initialBalance < minimumBalance)
                throw new InvalidOperationException("Initial Balance can't be lower than minimum allowed");

            this.Owner = name;
            this._minimumBalance = minimumBalance;

            this.Number = _accountNumberSeed.ToString();
            _accountNumberSeed++;

            if (initialBalance > 0)
                Deposit(initialBalance, DateTime.Now, "Initial balance");
        }

        public void Deposit(decimal amount, DateTime date, string description)
        {
            if (amount <= 0)
                Console.WriteLine("Deposit must be higher than 0");

            var deposit = new Transaction(amount, date, description);
            this.TransactionsList.Add(deposit);
        }

        public void WithDrawal(decimal amount, DateTime date, string description)
        {
            if (amount <= 0)
                Console.WriteLine("Withdrawal must be higher than 0");

            var transaction = CheckLimit((this.Balance - amount) < _minimumBalance);
            var withdrawal = new Transaction(-amount, date, description);
            this.TransactionsList.Add(withdrawal);

            if(transaction != null)
                this.TransactionsList.Add(transaction);
        }

        protected virtual Transaction CheckLimit(bool isOverCharge)
        {
            if (isOverCharge)
                throw new InvalidOperationException("Insufficient funds");

            else
                return default;
        }

        protected string PrintHistory()
        {
            string result = "";

            foreach (var transaction in TransactionsList)
                result += transaction.PrettyToString();

            return result;
        }
    }
}
