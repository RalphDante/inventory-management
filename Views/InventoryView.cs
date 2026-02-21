using System;
using InventoryApp.Services;

namespace InventoryApp.Views
{
    public class InventoryView
    {
        private InventoryService _service;

        public InventoryView()
        {
            _service = new InventoryService();
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n===== Inventory Management =====");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. Reset Inventory");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewInventory();
                        break;
                    case "2":
                        UpdateStock();
                        break;
                    case "3":
                        ResetInventory();
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("Exiting program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void ViewInventory()
        {
            Console.WriteLine("\n--- Current Inventory ---");
            Console.WriteLine($"{"#",-5} {"Product",-15} {"Stock",10}");
            Console.WriteLine(new string('-', 32));

            for (int i = 0; i < _service.GetProductCount(); i++)
            {
                Console.WriteLine($"{i + 1,-5} {_service.GetProductName(i),-15} {_service.GetStock(i),10}");
            }
        }

        private void UpdateStock()
        {
            ViewInventory();
            Console.Write("\nEnter product number to update: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int index) && index >= 1 && index <= _service.GetProductCount())
            {
                Console.Write($"Enter new stock for {_service.GetProductName(index - 1)}: ");
                string newStock = Console.ReadLine();

                if (int.TryParse(newStock, out _))
                {
                    _service.UpdateStock(index - 1, newStock);
                    Console.WriteLine("Stock updated successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid stock value. Must be a number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid product number.");
            }
        }

        private void ResetInventory()
        {
            _service.ResetInventory();
            Console.WriteLine("Inventory has been reset to initial values.");
        }
    }
}
