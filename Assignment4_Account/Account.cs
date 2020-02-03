using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_Account
{
    public abstract class Account
    {


        public readonly List<Person> users = new List<Person>();
        public readonly List<Transaction> transactions = new List<Transaction>();
        private static int LAST_NUMBER = 100_000;
        public string Number { get; protected set; }
        public double Balance { get; protected set; }
        public double LowestBalance { get; protected set; }

        public Account(string type, double balance)
        {
            Number = type + LAST_NUMBER.ToString();
            LAST_NUMBER++;
            Balance = balance;
            LowestBalance = balance;
        }

        public virtual void Deposit(double balance, Person person)
        {
            this.Balance = this.Balance + balance;
            this.LowestBalance = this.Balance;
            var transaction = new Transaction(Number, balance, person, DateTime.Now);
            transactions.Add(transaction);
        }

        public void AddUser(Person person)
        {
            users.Add(person);

        }

        public bool IsUser(string name)
        {
            foreach (var user in users)
            {
                if (user.Name == name)
                    return true;
            }

            return false;
        }

        public abstract void PrepareMonthlyStatement();

        public override string ToString()
        {
            string result = "Account number: " + Number + ". Users: ";
            foreach (var user in users)
            {
                result += user.Name + ", ";
            }

            result += ". Balance: " + Balance + ". Transactions: ";
            foreach (var trans in transactions)
            {
                result += trans.Time.ToShortTimeString() + ", ";
            }

            return result;
        }
    }
}
