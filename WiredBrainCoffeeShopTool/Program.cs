using System;
using System.Linq;
using WiredBrainCoffee.DataAccess;

namespace WiredBrainCoffeeShopTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wired Brain Coffee Shop");
            Console.WriteLine("Write 'help' to display available coffee shop commands, "+
                "Write 'quit' to exit applicationj");

            var coffeeShopDataProvider = new CoffeeShopDataProvider();

            while (true)
            {
                var line = Console.ReadLine();
                var coffeeShops = coffeeShopDataProvider.LoadCoffeeShops();

                if (string.Equals("quit", line, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                if (string.Equals("help", line, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("> Available coffee shop commands");
                    foreach(var coffeeShop in coffeeShops)
                    {
                        Console.WriteLine($"> " + coffeeShop.Location);
                    }
                }
                else
                {
                    var foundCoffeeShops = coffeeShops.Where(x => x.Location.StartsWith(line, StringComparison.OrdinalIgnoreCase)).ToList();

                    if(foundCoffeeShops.Count == 0)
                    {
                        Console.WriteLine($"> Command '{line}' not found");
                    }
                    else if (foundCoffeeShops.Count == 1)
                    {
                        var coffeeShop = foundCoffeeShops.Single();
                        Console.WriteLine($"> Location : {coffeeShop.Location}");
                        Console.WriteLine($"> Stock (Beans) : {coffeeShop.BeansInStockInKg} KG");
                    }
                    else
                    {
                        Console.WriteLine("> Multiple coffee shop commands found");
                        foreach (var coffeeType in foundCoffeeShops)
                        {
                            Console.WriteLine($"> {coffeeType.Location} ");
                        }
                    }
                }
            }
        }
    }
}
