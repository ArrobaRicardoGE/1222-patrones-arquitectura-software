using System;

namespace ComputerSale
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonalComputer pc = new PersonalComputer();
            string ans;

            RefreshScreen();
            WriteTitle("Step 1: Pick central unit");
            Console.WriteLine("Currently, we only have one type of central unit. Continue? (Y/N)");
            ans = Console.ReadLine();
            if (ans == "N") return;
            pc.AddComponent("Central Unit");
            Console.WriteLine("Central Unit added!");
            System.Threading.Thread.Sleep(2000);
            while(true)
            {
                RefreshScreen();
                WriteTitle("Step 2: Configure peripherals");
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add input peripheral");
                Console.WriteLine("2. Add output peripheral");
                Console.WriteLine("3. Add other peripherals / components");
                Console.WriteLine("4. Remove Component");
                Console.WriteLine("5. Checkout");
                ans = Console.ReadLine();

                if (ans == "1")
                {
                    RefreshScreen();
                    WriteTitle("Select input peripheral");
                    string type = HandleOptions(pc.Inputs); 
                    if(type == "")
                    {
                        Console.WriteLine("Peripheral not on list");
                        System.Threading.Thread.Sleep(2000);
                        continue; 
                    }
                    pc.AddInput(type);
                    Console.WriteLine(type + " added!");
                    System.Threading.Thread.Sleep(2000);
                }
                else if (ans == "2")
                {
                    RefreshScreen();
                    WriteTitle("Select output peripheral");
                    string type = HandleOptions(pc.Outputs);
                    if (type == "")
                    {
                        Console.WriteLine("Peripheral not on list");
                        System.Threading.Thread.Sleep(2000);
                        continue; 
                    }
                    pc.AddOutput(type);
                    Console.WriteLine(type + " added!");
                    System.Threading.Thread.Sleep(2000);
                }
                else if (ans == "3")
                {
                    RefreshScreen();
                    WriteTitle("Select other peripherals / components");
                    string type = HandleOptions(pc.Components);
                    if (type == "")
                    {
                        Console.WriteLine("Peripheral not on list");
                        System.Threading.Thread.Sleep(2000);
                        continue;
                    }
                    pc.AddComponent(type);
                    Console.WriteLine(type + " added!");
                    System.Threading.Thread.Sleep(2000);
                }
                else if (ans == "4")
                {
                    RefreshScreen();
                    WriteTitle("Select component to remove");
                    Console.WriteLine(pc.DescribeComponents(true /* idx */)); 
                    ans = Console.ReadLine();
                    try
                    {
                        pc.RemoveComponent(int.Parse(ans) - 1);
                    }
                    catch
                    {
                        Console.WriteLine("Invalid option: " + ans + ". Try again.");
                        System.Threading.Thread.Sleep(2000);
                        continue;
                    }
                    Console.WriteLine("Product #" + ans + " removed!");
                    System.Threading.Thread.Sleep(2000);
                }
                else if (ans == "5")
                {
                    RefreshScreen(); 
                    if (!pc.ValidateComponentCount())
                    {
                        WriteTitle("Error!");
                        Console.WriteLine("You didn't select enough peripherals.\nYou must add at least one output peripheral and one input peripheral.");
                        System.Threading.Thread.Sleep(4000);
                        continue; 
                    }
                    break; 
                }

            }
            RefreshScreen();
            WriteTitle("Summary");
            Console.WriteLine(pc.DescribeComponents());
            Console.WriteLine();
            Console.WriteLine(string.Format("TOTAL: {0:c}", pc.GetFinalPrice())); 
            
        }

        static void RefreshScreen()
        {
            Console.Clear();
            Console.WriteLine("PERSONAL COMPUTER STORE");
            Console.WriteLine();
        }

        static void WriteTitle(string title)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine(title);
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }

        static string HandleOptions(Creator creator)
        {
            for (int i = 0; i < creator.AvailableTypes.Length; i++)
                Console.WriteLine(string.Format("{0}. {1}", i + 1, creator.AvailableTypes[i]));
            string ans = Console.ReadLine();
            int val = int.Parse(ans) - 1;
            if (val < 0 || val >= creator.AvailableTypes.Length)
            {
                return ""; 

            }
            return creator.AvailableTypes[val];
        }
    }
}
