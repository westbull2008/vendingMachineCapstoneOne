using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Transaction
    {
        // Creates a new Purchase Log called log, creating Log.txt
        PurchaseLog log = new PurchaseLog("Log.txt");

        // A property of the transaction called Balance, set as Money Given - Total Purchase Price
        public decimal Balance { get => MoneyGiven - TotalPurchasePrice; set { } } // amount in pennies

        // A property which converts the Balance (in pennies) to dollars.
        public decimal BalanceInDollars { get => Balance / 100; }

        // A property of the transaction/machine called ChangeGiven, reflecting change handed back.
        public string ChangeGiven { get; set; }

        // A property which deposits money into the account.
        public decimal MoneyGiven { get; set; } // in pennies

        // A property which gets the total purchase price in the transaction
        public decimal TotalPurchasePrice { get; set; } // in pennies

        // An open default constructor with no parameters.
        public Transaction()
        {
        }

        
        //A method setting out how to create change
        public void MakeChange()
        {
            // Creating an empty string called change
            string change = "";
            // Creating an integer called quarters, value set at 0
            int quarters = 0;
            // Creating an integer called dimes, value set at 0
            int dimes = 0;
            // Creating an integer called nickels, value set at 0
            int nickels = 0;
            // Creating an integer called remainder, where remainder after division is stored.
            int remainder = 0;

            // Calculating quarters returned as the whole value of Balance / 25
            quarters = (int)Balance / 25;
            // Calculating the remainder after division 
            remainder = (int)Balance % 25;
            // Calculating dimes returned from remainder after quarters removed
            dimes = remainder / 10;
            // Calculating the remainder after division 
            remainder = remainder % 10;
            // Calculating nickels returned from remainder after dimes removed
            nickels = remainder / 5;

            // Loop printing out to user how many quarters returned provided it's more than zero 
            if (quarters > 0)
            {
                change += quarters + " quarters. ";
            }

            // Loop printing out to user how many dimes returned provided it's more than zero 
            if (dimes > 0)
            {
                change += dimes + " dimes. ";
            }

            // Loop printing out to user how many nickels returned provided it's more than zero 
            if (nickels > 0)
            {
                change += nickels + " nickels. ";
            }

            // Setting the value of ChangeGiven method to change
            ChangeGiven = change;
            log.PrintLog(log.PrintChange(BalanceInDollars));// Change log
        }

        // Method to finish transaction
        public void FinishTransaction()
        {
            // Telling program to make change
            MakeChange();
            // Setting balance to zero after change handed out
            Balance = 0;
        }
    }
}