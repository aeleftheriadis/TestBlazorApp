using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBlazorApp.Infastructure.Libs
{
    public class BankAccount
    {
        private readonly string _customerName;
        private decimal _balance;
        public BankAccount(string customerName, decimal balance)
        {
            _customerName = customerName;
            _balance = balance;
        }

        public string CustomerName
        {
            get { return _customerName; }
        }

        public decimal Balance
        {
            get { return _balance; }
        }

        public void Debit(decimal amount)
        {
            if(amount > _balance)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            if(amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            _balance -= amount;
        }

        public void Credit(decimal amount)
        {
            if(amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            _balance += amount;
        }
    }
}
