using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServicePractice
{
    class Shop
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public int StockAmount { get; set; }
        public int ProductId { get; set; }

        public Shop(string name, decimal price, bool inStock, int stockAmount, int productId)
        {
            Name = name;
            Price = price;
            InStock = inStock;
            StockAmount = stockAmount;
            ProductId = productId;
        }
    }
}
