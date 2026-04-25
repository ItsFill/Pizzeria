using System;

namespace Pizzaria
{
    class Program
    {
        public enum PizzaCode
        {
            Margherita = 101,
            Pepperoni = 102,
            FourCheeses = 103,
            Hawaiian = 104,
            Carbonara = 105
        }

        public enum DrinkCode
        {
            Cola = 201,
            Pepsi = 202,
            OrangeJuice = 203,
            AppleJuice = 204,
            MineralWater = 205
        }

        public enum MainMenuOption
        {
            ShowPizzaMenu = 1,
            ShowDrinkMenu = 2,
            MakeOrder = 3,
            ViewOrder = 4,
            Exit = 0
        }

        public class Manager
        {
            public void ShowPizzaCode()
            {
                foreach (PizzaCode code in Enum.GetValues(typeof(PizzaCode)))
                {
                    Console.WriteLine($"{(int)code} {code}");
                }

                Console.WriteLine("\nInput product's code: ");
            }
            
            public void ShowDrinkCode()
            {
                foreach (DrinkCode code in Enum.GetValues(typeof(DrinkCode)))
                {
                    Console.WriteLine($"{(int)code} {code}");
                }

                Console.WriteLine("\nInput product's code: ");
            }
            
            public void ShowMainMenu()
            {
                foreach (MainMenuOption code in Enum.GetValues(typeof(MainMenuOption)))
                {
                    Console.WriteLine($"{(int)code} {code}");
                }

                Console.WriteLine("\nInput action's code: ");
            }

            static void Main(string[] args)
            {
                Manager manager = new Manager();
                bool isRunning = true;
                List<string> orders = new List<string>();

                
                while (isRunning)
                {
                    
                    manager.ShowMainMenu();
                    string input = Console.ReadLine();
                    Console.WriteLine("\n");

                    switch (input)
                    {
                        case "1":
                            manager.ShowPizzaCode();
                            break;
                        case "2":
                            manager.ShowDrinkCode();
                            break;
                        case "3":
                            Console.WriteLine("\n");
                            Console.WriteLine("Please make a order:");
                            Console.WriteLine("\n");

                            input = Console.ReadLine();

                            List<string> inputs = input.Split(' ').ToList();

                            foreach (string order in inputs)
                            {

                                if (int.TryParse(order, out int numericCode))
                                {
                                    bool isPizza = Enum.IsDefined(typeof(PizzaCode), numericCode);
                                    bool isDrink = Enum.IsDefined(typeof(DrinkCode), numericCode);

                                    if (isPizza || isDrink)
                                    {
                                        orders.Add(order);
                                        Console.WriteLine($"Product {numericCode} was added to the order.!");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Code {numericCode} was not found in the order.!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("It is not a valid order.");
                                }
                            }

                            break;
                        case "4":
                            Console.WriteLine("Your order:");
                            if (orders.Count == 0) 
                                Console.WriteLine("Empty...");
                            else 
                                Console.WriteLine(string.Join(", ", orders));
                            break;
                        case "0":
                            isRunning = false;
                            break;
                    }
                }
            }
        }
    }
};

