using System;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine();
        Console.WriteLine("Reminder: Take a moment to reflect and write in your journal today!");

        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine();
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display ");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Display by Mood");
            Console.WriteLine("6. Quit");
            Console.WriteLine();
            Console.Write("Choose an option: ");

            int.TryParse(Console.ReadLine(), out choice);

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine();
                Console.WriteLine(prompt);
                Console.Write("> ");

                string response = Console.ReadLine();

                Console.WriteLine("How are you feeling today? (happy, sad, stressed, calm, excited, other)");
                string mood = Console.ReadLine();

                DateTime currentTime = DateTime.Now;
                string dateText = currentTime.ToShortDateString();

                Entry newEntry = new Entry();

                newEntry._date = dateText;
                newEntry._promptText = prompt;
                newEntry._entryText = response;
                newEntry._mood = mood;


                theJournal.AddEntry(newEntry);
            }

            else if (choice == 2)
            {

                theJournal.DisplayAll();
            }

            else if (choice == 3)
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();

                theJournal.SaveToFile(filename);
            }

            else if (choice == 4)
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();

                theJournal.LoadFromFile(filename);
            }

            else if (choice == 5)
            {
                Console.WriteLine("Enter mood to filter (happy, sad, calm, etc.): ");
                string mood = Console.ReadLine();

                theJournal.DisplayByMood(mood);

            }

            else if (choice == 6)
            {
                Console.WriteLine("Goodbye!");

            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

    }
}

/*
Things I added to exceeds requirements:
I added a mood system so each entry stores how the user felt. 
I also added a mood filter option so users can display entries by mood.  
Lastly I added a reminder message at the start of the program to encourage journaling.
*/
