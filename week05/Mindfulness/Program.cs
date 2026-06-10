using System;

class Program
{
    static void Main()
    {

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine("Select an option: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {

                BreathingActivity a = new BreathingActivity();
                a.Run();

            }

            else if (choice == "2")
            {

                ReflectionActivity a = new ReflectionActivity();
                a.Run();

            }

            else if (choice == "3")
            {

                ListingActivity a = new ListingActivity();
                a.Run();

            }

            else if (choice == "4")
            {

                break;

            }

            else
            {

                Console.WriteLine("Invalid option.");
                Thread.Sleep(1500);
            }

        }

    }
    
}