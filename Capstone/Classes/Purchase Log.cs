using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Capstone.Classes
{
    // Creates a class called PurchaseLog
    public class PurchaseLog
    {
        // Giving the class a property called Path
        public string Path { get; }

        // A constructor called PurchaseLog, which sets the string path with the property Path
        public PurchaseLog (string path)
        {
            Path = path;
        }

        // A method printing the Log line by line
        public void PrintLog(string line)
        {
            try
            {
                // invoking the StreamWriter to write to outside path
                using (StreamWriter sw = new StreamWriter(Path, true))
                {
                    // writes the line to the log, which is located at an outside path
                    sw.WriteLine(line);
                }
            }
            catch (IOException)
            {
                // Telling user if the file could not be created.
                Console.WriteLine("File could not be created.");
            }
        }
        // The method created to print the deposits to the log, using dollars and balance
        public string PrintFeedMoney(int dollars, decimal balance)
        {
            // Prints FeedMoney date, transaction type, amount of transaction, remaining balance
            return ($"{DateTime.Now} \t FEED MONEY \t {dollars.ToString("C")}\t {balance.ToString("C")}");  
        }
        // The method to print purchases to the log, using item name, price, and balance
        public string PrintPurchase (string itemName, decimal price, decimal balance)
        {
            // Prints purchase date, item name, amount of transaction, remaining balance
            return ($"{DateTime.Now} \t {itemName} \t {price.ToString("C")}\t {balance.ToString("C")}");

        }
        // The method created to print the change return to the log, using and balance
        public string PrintChange (decimal balance)
        {
            // Prints date, transaction type, amount of transaction, remaining balance
            return ($"{DateTime.Now} \t GIVE CHANGE \t {balance.ToString("C")}\t {0.00.ToString("C")}");

        }
    }
    
}
