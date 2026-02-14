using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServicePractice
{
    class ShopDb
    {
        private CustomerDb _customerDb;
        private Dictionary<int, Shop> _shop;
        private static int productId = 1;
        private Dictionary<Shop, int> _cart = new Dictionary<Shop, int>();


        public ShopDb(CustomerDb customerDb)
        {
            _customerDb = customerDb;
            InitializeShop();
        }

        private void InitializeShop()
        {
            _shop = new Dictionary<int, Shop>()
            {
                [1] = new Shop("Fanta Classic 500ml", 3.5m, true, 120, productId++),
                [2] = new Shop("Monster Energy Mega Original 553ml", 4m, true, 130, productId++),
                [3] = new Shop("Chupa Chups Mini Bites Sour 120g", 3m, true, 50, productId++),
                [4] = new Shop("Red Band Swedish Fish 100g", 1.5m, true, 60, productId++),
                [5] = new Shop("Pringles Hot Ones Los Calientes Barbacoa 156g", 6m, true, 40, productId++),
                [6] = new Shop("Nerds Gummy Clusters Cherry Lemonade Blitz 85g", 5m, true, 55, productId++),
                [7] = new Shop("Herr's Carolina Reaper Curls 28.4g", 1.5m, true, 47, productId++),
                [8] = new Shop("Herr's Jalapeno Poppers Flavoured Cheese Curls 28,4g", 1.5m, true, 51, productId++),
                [9] = new Shop("Sour Patch Kids Blue Raspberry 130g", 3.2m, true, 68, productId++),
                [10] = new Shop("Bounty Crispy Rolls 5-Pack 117g", 4.5m, true, 77, productId++),
                [11] = new Shop("Njie ProPud Hallongrotta Proteinbar 55g", 3.0m, true, 56, productId++)
            };
        }

        public void Shop()
        {
            Customer customer = _customerDb.GetLoggedInCustomer();

            if (customer == null)
            {
                Console.WriteLine("You need to login first. Type !login to login.");
                return;
            }

            Console.WriteLine($"User login info: {customer.Name} | {customer.Balance} | {customer.Id}");

            DisplayShop();

            int productId = 0;
            int amount = 0;

            string? userInput = "";

            while (true)
            {
                Console.WriteLine("Enter the product ID you want to buy.");
                userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out productId))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                Shop product = _shop.Values.FirstOrDefault(x => x.ProductId == productId);

                Console.WriteLine("Enter amount of the product you want to buy");
                userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out amount))
                {
                    Console.WriteLine("Invalid input.");
                    return;
                }

                Console.WriteLine($"Do you want to add {product.Name} of {amount} to cart? Type y/n");
                userInput = Console.ReadLine();
                if (userInput == "y")
                {
                    Cart(customer, product, amount);
                    break;
                }
                else
                {
                    return;
                }
            }
        }

        private void Cart(Customer customer, Shop product, int amount)
        {
            bool hasSameProduct = _cart.ContainsKey(product);

            if (hasSameProduct)
            {
                Console.WriteLine("Same product has already been added.");
                _cart[product] += amount;
                Console.WriteLine($"Product amount has been increased by {amount}");
            }
            else
            {
                _cart.Add(product, amount);
            }

            Console.WriteLine("If you want to checkout type \"y\" or type nothing/anything to continue");
            string? userInput = Console.ReadLine();
            if (userInput == "y")
            {
                Checkout(customer);
            }
        }

        private void Checkout(Customer customer)
        {
            decimal totalAmount = 0;

            foreach (var item in _cart)
            {
                totalAmount += item.Value * item.Key.Price;
            }

            Console.WriteLine("\nYour cart:\n");

            DisplayCart();

            Console.WriteLine($"\nTotal price: {totalAmount}$");

            Console.WriteLine("Type debit or creditCard to make payment");
            string? userAnswer = Console.ReadLine();

            PaymentService.IPaymentService paymentMethod = null;

            if (userAnswer == "debit")
            {
                paymentMethod = new PaymentService.DebitCard();
            }
            else if (userAnswer == "creditCard")
            {
                paymentMethod = new PaymentService.CreditCard();
            }
            else
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            var pay = new PaymentService.Pay(paymentMethod);
            bool paymentSuccess = pay.Payment(customer, totalAmount);

            if (!paymentSuccess)
            {
                return;
            }

            foreach (var item in _cart)
            {
                int beforeStock = item.Key.StockAmount;
                item.Key.StockAmount -= item.Value;
                int afterStock = item.Key.StockAmount;

                Console.WriteLine(
                    $" Product name: {item.Key.Name} |" +
                    $" Reduced by: {item.Value} |" +
                    $" Stock before {beforeStock} | " +
                    $" Stock After: {afterStock}");
            }

            _cart.Clear();
        }

        private void DisplayCart()
        {
            foreach (var (key, value) in _cart)
            {
                Console.WriteLine($"Product: {key.Name} | Amount: {value}");
            }
        }

        public void DisplayShop()
        {
            foreach (var item in _shop.Values)
            {
                Console.WriteLine($"Name: {item.Name} | " +
                    $"Price: {item.Price} | " +
                    $"In Stock: {item.InStock} | " +
                    $"Stock Amount: {item.StockAmount} | " +
                    $"Product ID: {item.ProductId}");
            }
        }
    }
}
