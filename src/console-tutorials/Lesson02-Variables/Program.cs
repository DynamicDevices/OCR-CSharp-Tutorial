using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Welcome to Variables! ===\n");

        // Different types of variables
        int age = 15;
        double height = 5.8;
        string name = "Alex";
        char grade = 'A';
        bool likesCode = true;

        // Displaying variables
        Console.WriteLine("--- Student Information ---");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Age: " + age);
        Console.WriteLine("Height: " + height + " feet");
        Console.WriteLine("Grade: " + grade);
        Console.WriteLine("Likes coding: " + likesCode);
        Console.WriteLine();

        // String interpolation (a cleaner way to combine text and variables)
        Console.WriteLine($"Hi {name}! You are {age} years old and {height} feet tall.");
        Console.WriteLine();

        // Math with variables
        Console.WriteLine("--- Math Examples ---");
        int num1 = 15;
        int num2 = 4;
        
        Console.WriteLine($"First number: {num1}");
        Console.WriteLine($"Second number: {num2}");
        Console.WriteLine($"Addition: {num1} + {num2} = {num1 + num2}");
        Console.WriteLine($"Subtraction: {num1} - {num2} = {num1 - num2}");
        Console.WriteLine($"Multiplication: {num1} * {num2} = {num1 * num2}");
        Console.WriteLine($"Division: {num1} / {num2} = {num1 / num2}");
        Console.WriteLine($"Remainder: {num1} % {num2} = {num1 % num2}");
        Console.WriteLine();

        // Getting input from the user
        Console.WriteLine("--- Interactive Section ---");
        Console.Write("What's your favorite color? ");
        string favoriteColor = Console.ReadLine();
        
        Console.Write("What's your lucky number? ");
        string numberInput = Console.ReadLine();
        int luckyNumber = int.Parse(numberInput); // Convert text to number
        
        Console.WriteLine($"\nAwesome! Your favorite color is {favoriteColor}");
        Console.WriteLine($"and your lucky number is {luckyNumber}!");
        Console.WriteLine($"Your lucky number times 2 is {luckyNumber * 2}!");

        // Challenge: Try modifying the variables above and see what happens!
        // Try creating your own variables and displaying them
    }
}