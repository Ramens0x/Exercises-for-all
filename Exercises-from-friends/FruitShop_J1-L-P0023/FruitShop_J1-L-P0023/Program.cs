using System;
using FruitShop_J1_L_P0023.Business;

namespace FruitShop_J1_L_P0023
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopManager manager = new ShopManager();

            while (true)
            {
                Console.WriteLine("\n========== FRUIT SHOP SYSTEM ==========");
                Console.WriteLine("1. Create Fruit");
                Console.WriteLine("2. View Orders");
                Console.WriteLine("3. Shopping (for buyer)");
                Console.WriteLine("4. Exit");
                Console.Write("Please choose: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        manager.CreateFruit(); // Gọi hàm từ file ShopManager
                        break;
                    case "2":
                        manager.ViewOrders();
                        break;
                    case "3":
                        manager.Shopping();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}
