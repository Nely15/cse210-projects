using System;
using System.Collections.Generic;

class Program

{
    static void Main(string[] args)

    {
        /*
        Exceeding Requirements:
        I added a scripture library using a List<Scripture>. 
        The program randomly picks a scripture from the list each time. 
        I added a hint mode to help users memorize the scripture better. 
        I also added a progress tracker to see how many words are hidden 
        and made it so that the already hidden words are not selected again. 
        To finish the program, I added a congratulatory message to encourage the user at the end of the activity.  
        */

        List<Scripture> scriptures = new List<Scripture>();

        scriptures.Add(

            new Scripture(

                new Reference("Matthew", 19, 26),
                "But Jesus beheld them, and said unto them, With men this is impossible; but with God all things are possible."

            )
        );

        scriptures.Add(

            new Scripture(

                new Reference("1 Nephi", 3, 7),
                "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."
            )
        );

        scriptures.Add(

            new Scripture(

                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."

            )
            
        );

        Random random = new Random();

        int randomNumber = random.Next(scriptures.Count);

        Scripture selectedScripture = scriptures[randomNumber];

        while (selectedScripture.AllWordsHidden() == false)

        {

            Console.Clear();

            Console.WriteLine(selectedScripture.GetDisplayText());

            Console.WriteLine();
            Console.WriteLine(selectedScripture.GetProgress());

            Console.WriteLine();
            Console.WriteLine("Press ENTER to continue");
            Console.WriteLine("Type 'hint' for hint");
            Console.WriteLine("Type 'quit' to quit");

            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")

            {
                break;

            }

            if (userInput.ToLower() == "hint")

            {

                selectedScripture.ShowHints();

            }

            else
            {

                selectedScripture.HideRandomWords(2);

            }

        }

        Console.Clear();

        Console.WriteLine(selectedScripture.GetDisplayText());

        Console.WriteLine();

        

            if (selectedScripture.AllWordsHidden())

            {

                Console.WriteLine("Congratulations! You finished memorizing the scripture!");

            }

        
        
        Console.WriteLine("Program ended");

    }

}


