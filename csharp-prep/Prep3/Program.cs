using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;
        Random random = new Random();

        while (playAgain)
        {
            // Generate a new magic number for each game when user plays
            int magicNumber = random.Next(1, 101);
            // initial the total number of guesses
            int numberOfGuesses = 0;
        

            Console.WriteLine("I've picked a new magic number between 1 and 100. Try to guess it!");

            int userGuess;
            do
            {
                Console.Write("What is your guess? ");
                userGuess = int.Parse(Console.ReadLine());
                numberOfGuesses++;  // Increasa number of guesses after each input

                if (userGuess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (userGuess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it in " + numberOfGuesses + " guesses!");
                    break; // Exit the loop after user guesses correctly
                }

            } while (userGuess != magicNumber);

            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainInput = Console.ReadLine();

            if (playAgainInput.ToLower() != "yes")
            {
                playAgain = false;  // Set play again to false if user says no
                Console.WriteLine("Thank you for playing with me!");
            }
        }
    }
}