using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Transaction
    {
        public decimal Balance { get => MoneyGiven - TotalPurchasePrice; set { } } // amount in pennies 

        public string ChangeGiven { get; set; }

        public decimal MoneyGiven { get; set; } // in pennies

        public decimal TotalPurchasePrice { get; set; } // in pennies

        public Transaction()
        {
        }

        public void MakeChange()
        {
            string change = "";
            int quarters = 0;
            int nickels = 0;
            int dimes = 0;
            int remainder = 0;

            quarters = (int)Balance / 25;
            remainder = (int)Balance % 25;
            dimes = remainder / 10;
            remainder = remainder % 10;
            nickels = remainder / 5;

            if (quarters > 0)
            {
                change += quarters + " quarters. ";
            }
            
            if (dimes > 0)
            {
                change += dimes + " dimes. ";
            }

            if (nickels > 0)
            {
                change += nickels + " nickels. ";
            }

            ChangeGiven = change;
        }

        public void FinishTransaction()
        {
            MakeChange();
            Balance = 0;
        }
    }
}