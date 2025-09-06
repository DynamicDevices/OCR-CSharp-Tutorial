using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("⚠️ Exception Handling and Validation - OCR A-Level");
        Console.WriteLine("==================================================\n");

        // Example 1: Basic Try-Catch
        Console.WriteLine("--- Example 1: Basic Exception Handling ---");
        DivisionExample();
        Console.WriteLine();

        // Example 2: Multiple Exception Types
        Console.WriteLine("--- Example 2: Multiple Exception Types ---");
        ArrayAccessExample();
        Console.WriteLine();

        // Example 3: Finally Block
        Console.WriteLine("--- Example 3: Finally Block ---");
        FileOperationExample();
        Console.WriteLine();

        // Example 4: Custom Exceptions
        Console.WriteLine("--- Example 4: Custom Exceptions ---");
        BankAccountExample();
        Console.WriteLine();

        // Example 5: Input Validation
        Console.WriteLine("--- Example 5: Input Validation ---");
        InputValidationExample();
        Console.WriteLine();

        Console.WriteLine("🎯 Key Exception Handling Concepts:");
        Console.WriteLine("• Try-catch blocks handle runtime errors gracefully");
        Console.WriteLine("• Finally blocks always execute, even after exceptions");
        Console.WriteLine("• Custom exceptions provide specific error information");
        Console.WriteLine("• Input validation prevents many exceptions");
        Console.WriteLine("• Proper error handling improves user experience");
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void DivisionExample()
    {
        try
        {
            Console.Write("Enter first number: ");
            int num1 = int.Parse(Console.ReadLine() ?? "0");
            
            Console.Write("Enter second number: ");
            int num2 = int.Parse(Console.ReadLine() ?? "0");
            
            int result = num1 / num2;
            Console.WriteLine($"Result: {num1} / {num2} = {result}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Cannot divide by zero!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter valid numbers!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    static void ArrayAccessExample()
    {
        int[] numbers = { 10, 20, 30, 40, 50 };
        
        try
        {
            Console.Write("Enter array index (0-4): ");
            int index = int.Parse(Console.ReadLine() ?? "0");
            
            Console.WriteLine($"Value at index {index}: {numbers[index]}");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Error: Index is outside array bounds!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter a valid number!");
        }
    }

    static void FileOperationExample()
    {
        string fileName = "test.txt";
        StreamWriter? writer = null;
        
        try
        {
            writer = new StreamWriter(fileName);
            writer.WriteLine("Testing file operations");
            Console.WriteLine($"Successfully wrote to {fileName}");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: No permission to write file!");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
        finally
        {
            // This always executes
            writer?.Close();
            Console.WriteLine("File operation completed (finally block executed)");
        }
    }

    static void BankAccountExample()
    {
        try
        {
            SafeBankAccount account = new SafeBankAccount("John Doe", 1000);
            
            Console.WriteLine($"Initial balance: ${account.Balance}");
            
            account.Withdraw(500);  // Valid
            account.Withdraw(600);  // Should throw InsufficientFundsException
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine($"Banking error: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Invalid argument: {ex.Message}");
        }
    }

    static void InputValidationExample()
    {
        int age = GetValidAge();
        string email = GetValidEmail();
        
        Console.WriteLine($"Valid input received - Age: {age}, Email: {email}");
    }

    static int GetValidAge()
    {
        while (true)
        {
            try
            {
                Console.Write("Enter your age (1-120): ");
                int age = int.Parse(Console.ReadLine() ?? "0");
                
                if (age < 1 || age > 120)
                {
                    throw new ArgumentOutOfRangeException("Age must be between 1 and 120");
                }
                
                return age;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static string GetValidEmail()
    {
        while (true)
        {
            Console.Write("Enter your email: ");
            string? email = Console.ReadLine();
            
            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Email cannot be empty.");
                continue;
            }
            
            if (!email.Contains("@") || !email.Contains("."))
            {
                Console.WriteLine("Please enter a valid email address.");
                continue;
            }
            
            return email;
        }
    }
}

// Custom Exception Class
public class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message) { }
    
    public InsufficientFundsException(string message, Exception innerException) 
        : base(message, innerException) { }
}

// Safe Bank Account with Exception Handling
public class SafeBankAccount
{
    private string accountHolder;
    private double balance;
    
    public SafeBankAccount(string accountHolder, double initialBalance)
    {
        if (string.IsNullOrEmpty(accountHolder))
            throw new ArgumentException("Account holder name cannot be empty");
            
        if (initialBalance < 0)
            throw new ArgumentException("Initial balance cannot be negative");
            
        this.accountHolder = accountHolder;
        this.balance = initialBalance;
    }
    
    public string AccountHolder => accountHolder;
    public double Balance => balance;
    
    public void Deposit(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive");
            
        balance += amount;
        Console.WriteLine($"Deposited ${amount:F2}. New balance: ${balance:F2}");
    }
    
    public void Withdraw(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive");
            
        if (amount > balance)
            throw new InsufficientFundsException($"Cannot withdraw ${amount:F2}. Available balance: ${balance:F2}");
            
        balance -= amount;
        Console.WriteLine($"Withdrew ${amount:F2}. New balance: ${balance:F2}");
    }
}
