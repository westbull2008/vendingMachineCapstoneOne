using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    // Creating a new class called Menu
    public class Menu
    {
        // Creating vm from VendingMachine class, using file vendingmachine.csv
        VendingMachine vm = new VendingMachine("vendingmachine.csv");
        
        // Creating log from PurchaseLog class, using file Log.txt
        PurchaseLog log = new PurchaseLog("Log.txt");

        // A method called header, showing the first line when program is opened
        private void PrintHeader()
        {
            // The first line shown to user
            Console.WriteLine("Welcome to our lovely vending machine!!");
            Console.WriteLine();

        }
        // A method which will display the menu
        public void Display()
        {
            // Calls the PrintHeader method showing the first line
            PrintHeader();
            
            while (true)
            {
                // Writes Main Menu heading and separating line
                Console.WriteLine("MAIN MENU");
                Console.WriteLine();

                // Gives options of displaying items or making a purchase
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase a Delicious Treat");

                // Lets user enter whether they want option 1 or 2 in menu
                string input = Console.ReadLine();

                // If input 1 is entered
                if (input == "1")
                {
                    // Display the items using DisplayItems method in this class
                    Console.WriteLine();
                    DisplayItems();
                    Console.WriteLine();
                }
                // If input 2 is entered
                else if (input == "2")
                {
                    // Set Purchase method into action and then break
                    Console.WriteLine();
                    Purchase();
                    break;
                }

            }
        }
        // The method for making a purchase
        public void Purchase()
        {
            while (true)
            {
                // Displays submenu showing options to deposit, purchase, and finish, and balance
                Console.WriteLine();
                Console.WriteLine("PURCHASE MENU");
                Console.WriteLine();
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine($"Current Balance: {vm.Trans.BalanceInDollars.ToString("C")}");
                string input = Console.ReadLine();
                Console.WriteLine();

                // If choosing to deposit
                if (input == "1")
                {
                    while (true)
                    {
                        Console.WriteLine();
                        // Tells customer what denomination to deposit
                        Console.WriteLine("Please insert a bill (we accept $1, $2, $5, or $10)");
                        
                        // Customer enters deposit amount
                        string deposit = Console.ReadLine();
                        
                        // If deposit is valid via IsWholeDollar method in this class
                        if (IsWholeDollar(deposit))
                        {
                            // Converts deposit into an integer into vm using FeedMoney
                            vm.FeedMoney(int.Parse(deposit));
                        
                            // Displays balance to user
                            Console.WriteLine(vm.Trans.BalanceInDollars.ToString("C"));
                            Console.WriteLine();

                            // Asks customer if they want to deposit more
                            Console.Write("Do you wish to deposit any more? (Y/N)");
                            input = Console.ReadLine();

                            // Sends customer back to deposit question if answer Y or y
                            if (input != "Y" && input != "y")
                            {
                                break;
                            }
                        }

                    }
                }
                //If they enter purchase option
                else if (input == "2")
                {
                    while (true)
                    {
                        Console.WriteLine();

                        // Displays valid list of items to customer
                        DisplayItems();
                        Console.WriteLine();

                        // Asks user to select a purchase, or q to go back
                        Console.Write("Please select your purchase, or press (Q) to go back: ");
                        input = Console.ReadLine();

                        // If they select Q or q, break and return to purchase menu
                        Console.WriteLine();
                        if (input == "Q" || input == "q")
                        {
                            break;
                        }
                        // If customer selects an invalid location, tells them that.
                        if (!IsLocationValid(input))
                        {
                            Console.WriteLine("Your location is invalid.");
                            Console.WriteLine();
                        }
                        // If item is out of stock, informs customer.
                        else if (!IsInStock(input))
                        {
                            Console.WriteLine("The item is out of stock.");
                            Console.WriteLine();
                        }
                        // If customer has insufficient funds, tells them that
                        else if (!HasEnoughMoney(input))
                        {
                            Console.WriteLine($"You don't have enough money. Your balance is { vm.Trans.BalanceInDollars.ToString("C")}.");
                            Console.WriteLine();
                        }
                        // Allows customer to make a purchase from vm if input is correct
                        else
                        {
                            vm.PurchaseItem(input);
                            break;
                        }
                    }
                }
                // If 3 chosen for Finish Transaction
                else if (input == "3")
                {
                    Console.WriteLine();

                    // Tells customer how much change they will receive
                    Console.WriteLine($"Your change is {vm.Trans.BalanceInDollars.ToString("C")}");

                    // Invokes Finish Transaction method from Transaction
                    vm.Trans.FinishTransaction();

                    // Writes line from ChangeGiven in Transaction regarding quarters, etc
                    Console.WriteLine(vm.Trans.ChangeGiven);

                    // Consumes the items using the method below, then breaks
                    ConsumeItems();
                    break;
                }
            }
        }

        // Boolean assessing if customer has enough money for set purchase
        private bool HasEnoughMoney(string location)
        {
            // Set to false if the cost is greater than the balance
            if (vm.Slots[location].Items[0].Price > vm.Trans.BalanceInDollars)
            {
                return false;
            }
            // otherwise true, they have enough money
            return true;
        }

        // Assesses if item is in stock at the location
        private bool IsInStock(string location)
        {
            // Returns false if number of items in stock is 0
            if (vm.Slots[location].AmountOfItems == 0)
            {
                return false;
            }
            // Otherwise true, item is in stock
            return true;

        }
        // Method to display items
        public void DisplayItems()
        {
            // For each slot location
            foreach (string location in locations)
            {
                // Prints GetItemInfo line from method in Vending Machine at each location
                Console.WriteLine(vm.GetItemInfo(location));
            }
        }
        // Method to ensure customer is depositing a whole dollar, using deposit parameter
        public bool IsWholeDollar(string deposit)
        {
            // If customer enters number other than 1, 2, 5, or 10
            if (deposit != "1" && deposit != "2" && deposit != "5" && deposit != "10")
            {
                // Is Whole Dollar is false
                return false;
            }
            // Otherwise deposit is valid
            return true;
        }
        // Method to ensure slot location entered is valid
        public bool IsLocationValid(string location)
        {
            if (!locations.Contains(location))
            {
                return false;
            }
            return true;
        }
        // Method to consume items; delays printout before printing line from Item subclasses 
        public void ConsumeItems()
        {
            foreach (Item item in vm.PurchasedItems)
            {
                System.Threading.Thread.Sleep(750);
                Console.WriteLine(item.Consume());
            }
        }
        // Confirming valid string locations
        static string[] locations =
        {
            "A1", "A2", "A3", "A4",
            "B1", "B2", "B3", "B4",
            "C1", "C2", "C3", "C4",
            "D1", "D2", "D3", "D4"
        };

    }
}
