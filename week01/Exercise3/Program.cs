using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        while (playAgain == "yes")
        {
            Random randomGenerator = new();
            int magicNumber = randomGenerator.Next(1, 101);


            int guess = -1;
            int guessCount = 0;

            while (guess != magicNumber)
            {
                Console.WriteLine("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                guessCount++;

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }

                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }

                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.WriteLine($"You guessed the number in {guessCount} guesses.");

            Console.Write("Do you want to play again? ");
            playAgain = Console.ReadLine();

        }

        Console.WriteLine("Thank you for playing! See you soon!");
    }
}