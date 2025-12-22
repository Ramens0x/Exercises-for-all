using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitShop_J1_L_P0023.Models;

namespace FruitShop_J1_L_P0023.Business
{
    public class ShopManager
    {
        private ArrayList listFruit = new ArrayList();
        private Hashtable orders = new Hashtable();

        public void CreateFruit()
        {
            while (true)
            {
                Console.WriteLine("\n --- Create Fruit ---");
                Console.Write("Enter Fruit ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Fruit Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Price: ");
                int price = int.Parse(Console.ReadLine());
                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                Console.Write("Enter Origin: ");
                string origin = Console.ReadLine();

                Fruit newFruit = new Fruit(id, name, price, quantity, origin);
                listFruit.Add(newFruit);

                Console.WriteLine("Fruit created successfully!");
                Console.Write("Do you want to continue (Y/N)? ");
                if (Console.ReadLine().ToUpper() == "N")
                {
                    break;
                }
            }
        }

        public void ViewOrders()
        {
            Console.WriteLine("\n --- View Orders ---");
            if (orders.Count == 0)
            {
                Console.WriteLine("No orders yet.");
                return;
            }
            foreach (string customerName in orders.Keys)
            {
                Console.WriteLine($"Customer: {customerName}");
                Console.WriteLine("Product      | Quantity | Price | Amount");

                ArrayList customerCart = (ArrayList)orders[customerName];
                int total = 0;
                foreach (Fruit f in customerCart)
                {
                    Console.WriteLine($"{f.FruitName,-12} | {f.Quantity,-8} | {f.Price,-5}$ | {f.GetAmount()}$");
                    total += f.GetAmount();
                }
                Console.WriteLine($"Total: {total}$");
                Console.WriteLine("----------------------------------------");
            }    
        }

        public void Shopping()
        {
            if (listFruit.Count == 0)
            {
                Console.WriteLine("No fruit available!");
                return;
            }

            ArrayList currentOrder = new ArrayList();

            while (true)
            {
                Console.WriteLine("\nList of Fruit:");
                Console.WriteLine("| ++ Item ++ | ++ Fruit Name ++ | ++ Origin ++ | ++ Price ++ |");

                int itemIndex = 1;
                foreach (Fruit f in listFruit)
                {
                    Console.WriteLine($"| {itemIndex,-10} | {f.FruitName,-14} | {f.Origin,-10} | {f.Price,-6}$ |");
                    itemIndex++;
                }

                Console.Write("Select Item: ");
                int selectedIndex = int.Parse(Console.ReadLine());
                Fruit selectedFruit = (Fruit)listFruit[selectedIndex - 1];

                Console.WriteLine($"You selected: {selectedFruit.FruitName}");
                Console.Write("Please input quantity: ");
                int quantityBuying = int.Parse(Console.ReadLine());

                Fruit boughtItem = new Fruit(selectedFruit.FruitId, selectedFruit.FruitName, selectedFruit.Price, quantityBuying, selectedFruit.Origin);
                currentOrder.Add(boughtItem);

                Console.Write("Do you want to order now (Y/N)? ");
                if (Console.ReadLine().ToUpper() == "Y") break;
            }

            Console.WriteLine("\nProduct      | Quantity | Price | Amount");
            int totalOrder = 0;
            foreach (Fruit f in currentOrder)
            {
                Console.WriteLine($"{f.FruitName,-12} | {f.Quantity,-8} | {f.Price,-5}$ | {f.GetAmount()}$");
                totalOrder += f.GetAmount();
            }
            Console.WriteLine($"Total: {totalOrder}$");

            Console.Write("Input your name: ");
            string customerName = Console.ReadLine();
            orders.Add(customerName, currentOrder);
            Console.WriteLine("Order saved!");
        }
    }
}
