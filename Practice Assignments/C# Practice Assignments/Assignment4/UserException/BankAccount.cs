using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserException
{

    class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }

    class BankAccount
    {
        private int _accountNumber;
        private double _balance;

        public BankAccount(int accountNumber, double balance)
        {
            _accountNumber = accountNumber;
            _balance = balance;
        }

        public void FundTransfer(double amount)
        {
            if(amount<=_balance)
            {
                _balance = _balance-amount;
                Console.WriteLine("Transfer successfull! Balance: "+_balance);
            }
            else
            {
                throw new InsufficientBalanceException($"Entered Amount is Greater than Account Balance.Please Enter Amount Lesser than {_balance}");
            }
        }
    }
}
