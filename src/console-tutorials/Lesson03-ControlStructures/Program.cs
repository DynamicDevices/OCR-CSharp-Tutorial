using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Control Structures Demo ===\n");

        // Example 1: If/Else Statements
        Console.WriteLine("--- Age Verification ---");
        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());

        if (age >= 18)
        {
            Console.WriteLine("You are an adult!");
        }
        else if (age >= 13)
        {
            Console.WriteLine("You are a teenager!");
        }
        else
        {
            Console.WriteLine("You are a child!");
        }
        Console.WriteLine();

        // Example 2: Grade Calculator
        Console.WriteLine("--- Grade Calculator ---");
        Console.Write("Enter your test score (0-100): ");
        int score = int.Parse(Console.ReadLine());

        if (score >= 90)
        {
            Console.WriteLine("Excellent! Grade: A");
        }
        else if (score >= 80)
        {
            Console.WriteLine("Good job! Grade: B");
        }
        else if (score >= 70)
        {
            Console.WriteLine("Not bad! Grade: C");
        }
        else if (score >= 60)
        {
            Console.WriteLine("You passed. Grade: D");
        }
        else
        {
            Console.WriteLine("You need to study more. Grade: F");
        }
        Console.WriteLine();

        // Example 3: For Loop
        Console.WriteLine("--- Countdown with For Loop ---");
        for (int i = 5; i >= 1; i--)
        {
            Console.WriteLine($"Countdown: {i}");
            System.Threading.Thread.Sleep(500); // Wait half a second
        }
        Console.WriteLine("🚀 Blast off!");
        Console.WriteLine();

        // Example 4: While Loop - Simple Guessing Game
        Console.WriteLine("--- Number Guessing Game ---");
        Random random = new Random();
        int secretNumber = random.Next(1, 6); // Random number 1-5
        int guess = 0;
        int attempts = 0;

        Console.WriteLine("I'm thinking of a number between 1 and 5!");
        
        while (guess != secretNumber)
        {
            Console.Write("Enter your guess: ");
            guess = int.Parse(Console.ReadLine());
            attempts++;

            if (guess == secretNumber)
            {
                Console.WriteLine($"🎉 Correct! You got it in {attempts} attempts!");
            }
            else if (guess < secretNumber)
            {
                Console.WriteLine("Too low! Try again.");
            }
            else
            {
                Console.WriteLine("Too high! Try again.");
            }
        }
        Console.WriteLine();

        // Example 5: Switch Statement
        Console.WriteLine("--- Day of the Week ---");
        Console.Write("Enter a day number (1-7): ");
        int dayNumber = int.Parse(Console.ReadLine());

        switch (dayNumber)
        {
            case 1:
                Console.WriteLine("Monday - Start of the work week!");
                break;
            case 2:
                Console.WriteLine("Tuesday - Getting into the groove!");
                break;
            case 3:
                Console.WriteLine("Wednesday - Hump day!");
                break;
            case 4:
                Console.WriteLine("Thursday - Almost there!");
                break;
            case 5:
                Console.WriteLine("Friday - TGIF!");
                break;
            case 6:
                Console.WriteLine("Saturday - Weekend fun!");
                break;
            case 7:
                Console.WriteLine("Sunday - Rest day!");
                break;
            default:
                Console.WriteLine("That's not a valid day number (1-7)!");
                break;
        }
        Console.WriteLine();

        // Example 6: Logical Operators
        Console.WriteLine("--- Movie Theater Check ---");
        Console.Write("Enter your age: ");
        int movieAge = int.Parse(Console.ReadLine());
        Console.Write("Do you have a student ID? (yes/no): ");
        string hasStudentId = Console.ReadLine().ToLower();

        bool isStudent = hasStudentId == "yes";

        if (movieAge >= 18 || (movieAge >= 13 && isStudent))
        {
            Console.WriteLine("You can watch PG-13 movies!");
        }
        else
        {
            Console.WriteLine("You can only watch G-rated movies.");
        }

        if (movieAge >= 65 || isStudent)
        {
            Console.WriteLine("You qualify for a discount!");
        }

        Console.WriteLine("\n=== Try modifying the code to experiment! ===");
    }
}