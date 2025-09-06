using System;

class Program
{
    static void Main(string[] args)
    {
        // Welcome message
        Console.WriteLine("🎮 Welcome to the Number Guessing Game! 🎮");
        Console.WriteLine("==========================================");
        Console.WriteLine();

        // Get player's name
        Console.Write("What's your name? ");
        string playerName = Console.ReadLine();
        Console.WriteLine($"Hello, {playerName}! Let's play!");
        Console.WriteLine();

        // Game settings
        bool playAgain = true;
        int gamesWon = 0;
        int totalGames = 0;

        while (playAgain)
        {
            totalGames++;
            Console.WriteLine($"🎯 Game #{totalGames}");
            Console.WriteLine("I'm thinking of a number between 1 and 100...");
            
            // Generate random number
            Random random = new Random();
            int secretNumber = random.Next(1, 101);
            int guess = 0;
            int attempts = 0;
            int maxAttempts = 7;

            // Game loop
            while (guess != secretNumber && attempts < maxAttempts)
            {
                Console.WriteLine($"You have {maxAttempts - attempts} attempts left.");
                Console.Write("Enter your guess: ");
                
                // Input validation
                string input = Console.ReadLine();
                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Please enter a valid number!");
                    continue;
                }

                attempts++;

                if (guess == secretNumber)
                {
                    Console.WriteLine($"🎉 Congratulations, {playerName}! You got it!");
                    Console.WriteLine($"The number was {secretNumber}!");
                    Console.WriteLine($"You won in {attempts} attempts!");
                    gamesWon++;
                    
                    // Bonus messages based on performance
                    if (attempts == 1)
                    {
                        Console.WriteLine("🏆 INCREDIBLE! You got it in one try!");
                    }
                    else if (attempts <= 3)
                    {
                        Console.WriteLine("⭐ Excellent guessing skills!");
                    }
                    else if (attempts <= 5)
                    {
                        Console.WriteLine("👍 Good job!");
                    }
                }
                else if (guess < secretNumber)
                {
                    Console.WriteLine("📈 Too low! Try a higher number.");
                    
                    // Give hints
                    if (secretNumber - guess > 20)
                    {
                        Console.WriteLine("💡 Hint: You're way too low!");
                    }
                }
                else
                {
                    Console.WriteLine("📉 Too high! Try a lower number.");
                    
                    // Give hints
                    if (guess - secretNumber > 20)
                    {
                        Console.WriteLine("💡 Hint: You're way too high!");
                    }
                }
                Console.WriteLine();
            }

            // Check if player ran out of attempts
            if (guess != secretNumber)
            {
                Console.WriteLine($"😔 Sorry, {playerName}! You ran out of attempts.");
                Console.WriteLine($"The number was {secretNumber}.");
                Console.WriteLine("Better luck next time!");
            }

            Console.WriteLine();
            
            // Show statistics
            Console.WriteLine("📊 Your Statistics:");
            Console.WriteLine($"Games played: {totalGames}");
            Console.WriteLine($"Games won: {gamesWon}");
            
            if (totalGames > 0)
            {
                double winRate = (double)gamesWon / totalGames * 100;
                Console.WriteLine($"Win rate: {winRate:F1}%");
            }
            Console.WriteLine();

            // Ask if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainInput = Console.ReadLine().ToLower();
            
            if (playAgainInput == "yes" || playAgainInput == "y")
            {
                playAgain = true;
                Console.WriteLine("\n" + new string('=', 40));
            }
            else
            {
                playAgain = false;
            }
        }

        // Final goodbye message
        Console.WriteLine($"\nThanks for playing, {playerName}! 👋");
        Console.WriteLine("Hope you had fun learning C#!");
        
        if (gamesWon > 0)
        {
            Console.WriteLine($"You won {gamesWon} out of {totalGames} games!");
        }
        
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}