using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_Account
{
    public class Transaction
    {
        public string AccountNumber { get; }
        public double Amount { get; }
        public Person Originator { get; }
        public DateTime Time { get; }

        public Transaction(string accountNumber, double amount, Person person, DateTime time)
        {
            AccountNumber = accountNumber;
            //ToDo
            Amount = amount;
            Originator = person;
            Time = time;
        }

        public override string ToString()
        {
            string action = (Amount > 0) ? action = "Deposite" : action = "Withdraw";
            return $"Account number: {AccountNumber}, Person: {Originator.Name}, {action} Amount: {Amount.ToString()}, Time: {Time.ToShortTimeString()}";
        }


    }
}
