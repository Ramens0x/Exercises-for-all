using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitShop_J1_L_P0023.Models
{
    public class Fruit
    {
        public int FruitId { get; set; }
        public string FruitName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Origin { get; set; }

        public Fruit(int id, string name, int price, int quantity, string origin)
        {
            this.FruitId = id;
            this.FruitName = name;
            this.Price = price;
            this.Quantity = quantity;
            this.Origin = origin;
        }

        public int GetAmount()
        {
            return Price * Quantity;
        }
    }
}
