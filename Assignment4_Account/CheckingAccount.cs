﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_Account
{
    public class CheckingAccount : Account, ITransaction
    {
        private static double COST_PER_TRANSACTION = 0.05;
        private static double INTEREST_RATE = 0.005;
        private const int MONTH = 12;
        private bool hasOverdraft;

        public CheckingAccount(double balance = 0, bool hasOverdraft = false) : base("CK-", balance)
        {
            this.hasOverdraft = hasOverdraft;
        }

        public override void Deposit(double amount, Person person)
        {
            base.Deposit(amount, person);
        }

        public void Withdraw(double amount, Person person)
        {
            if (!base.IsUser(person.Name))
            {
                throw new AccountException(AccountException.ExceptionEnum.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            }

            if (!person.IsAuthenticated)
            {
                throw new AccountException(AccountException.ExceptionEnum.USER_NOT_LOGGED_IN);
            }

            if (base.Balance < amount)
            {
                throw new AccountException(AccountException.ExceptionEnum.NO_OVERDRAFT);
            }

            Deposit(amount, person);
        }

        public override void PrepareMonthlyStatement()
        {
            var serviceFee = base.transactions.Count * COST_PER_TRANSACTION;
            var interest = base.Balance * (INTEREST_RATE / MONTH);
            this.Balance += this.Balance + interest - serviceFee;
            this.transactions.Clear();
        }
    }
}
