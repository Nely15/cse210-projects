using System;

class Program
{
    static void Main()
    {
        LogActivity.Load();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. View Statistics");
            Console.WriteLine("5. Quit");
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

                Console.Clear();

                Console.WriteLine("Activity Statistics");
                Console.WriteLine();

                Console.WriteLine($"Breathing: {LogActivity.BreathingCount} times");
                Console.WriteLine($"Minutes: {LogActivity.BreathingSeconds / 60.0:F1}");
                Console.WriteLine();

                Console.WriteLine($"Reflection: {LogActivity.ReflectionCount} times");
                Console.WriteLine($"Minutes: {LogActivity.ReflectionSeconds / 60.0:F1}");
                Console.WriteLine();

                Console.WriteLine($"Listing: {LogActivity.ListingCount} times");
                Console.WriteLine($"Minutes: {LogActivity.ListingSeconds / 60.0:F1}");
                Console.WriteLine();

                Console.WriteLine("Press Enter...");
                Console.WriteLine();

                Console.ReadLine();

            }

            else if (choice == "5")
            {

                break;

            }


            else
            {

                Console.WriteLine("Invalid option.");
                Thread.Sleep(1500);
            }

            LogActivity.Save();

        }

    }

}
/*
        Exceeding Requirements:
        I added an activity log that tracks how many times each activity 
        is completed and the total time spent on each activity. The statistics
        are saved and loaded from a file so they persist between program sessions.
        I also modified the Reflection and Listing activities so prompts are not 
        repeated until all available prompts have been used.
*/  