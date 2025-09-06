using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("🏗️ Object-Oriented Programming Basics - OCR A-Level");
        Console.WriteLine("===================================================\n");

        // Example 1: Creating and Using Objects
        Console.WriteLine("--- Example 1: Creating Objects ---");
        
        // Create student objects
        Student student1 = new Student("Alice Johnson", 16, "CS001");
        Student student2 = new Student("Bob Smith", 17, "CS002");
        
        // Display student information
        student1.DisplayInfo();
        student2.DisplayInfo();
        
        // Add grades
        student1.AddGrade(95);
        student1.AddGrade(87);
        student1.AddGrade(92);
        
        student2.AddGrade(88);
        student2.AddGrade(91);
        
        Console.WriteLine($"\n{student1.Name}'s average: {student1.GetAverage():F2}%");
        Console.WriteLine($"{student2.Name}'s average: {student2.GetAverage():F2}%");
        Console.WriteLine();

        // Example 2: Bank Account Class
        Console.WriteLine("--- Example 2: Bank Account System ---");
        
        BankAccount account1 = new BankAccount("Alice Johnson", 1001, 1000.00);
        BankAccount account2 = new BankAccount("Bob Smith", 1002, 500.00);
        
        Console.WriteLine("Initial account states:");
        account1.DisplayAccountInfo();
        account2.DisplayAccountInfo();
        
        // Perform transactions
        Console.WriteLine("\nPerforming transactions:");
        account1.Deposit(250.00);
        account1.Withdraw(100.00);
        account2.Deposit(75.00);
        account2.Withdraw(600.00); // This should fail
        
        Console.WriteLine("\nFinal account states:");
        account1.DisplayAccountInfo();
        account2.DisplayAccountInfo();
        Console.WriteLine();

        // Example 3: Car Class with Properties
        Console.WriteLine("--- Example 3: Car Class with Properties ---");
        
        Car car1 = new Car("Toyota", "Camry", 2022, "Blue");
        Car car2 = new Car("Honda", "Civic", 2021, "Red");
        
        Console.WriteLine("Car Information:");
        car1.DisplayCarInfo();
        car2.DisplayCarInfo();
        
        // Start engines and drive
        car1.StartEngine();
        car1.Drive(50);
        car1.Drive(25);
        car1.StopEngine();
        
        Console.WriteLine($"\n{car1.Make} {car1.Model} total mileage: {car1.Mileage} miles");
        Console.WriteLine();

        // Example 4: Static Members
        Console.WriteLine("--- Example 4: Static Members ---");
        
        Console.WriteLine($"Total students created: {Student.TotalStudents}");
        Console.WriteLine($"Total bank accounts: {BankAccount.TotalAccounts}");
        Console.WriteLine($"Next account number: {BankAccount.GetNextAccountNumber()}");
        
        // Create more objects to see static counters increase
        Student student3 = new Student("Charlie Brown", 16, "CS003");
        BankAccount account3 = new BankAccount("Charlie Brown", BankAccount.GetNextAccountNumber(), 750.00);
        
        Console.WriteLine($"After creating more objects:");
        Console.WriteLine($"Total students: {Student.TotalStudents}");
        Console.WriteLine($"Total accounts: {BankAccount.TotalAccounts}");
        Console.WriteLine();

        // Example 5: Method Overloading
        Console.WriteLine("--- Example 5: Method Overloading ---");
        
        Calculator calc = new Calculator();
        
        Console.WriteLine("Calculator demonstrations:");
        Console.WriteLine($"Add(5, 3) = {calc.Add(5, 3)}");
        Console.WriteLine($"Add(5.5, 3.2) = {calc.Add(5.5, 3.2)}");
        Console.WriteLine($"Add(1, 2, 3) = {calc.Add(1, 2, 3)}");
        Console.WriteLine($"Add(\"Hello\", \"World\") = {calc.Add("Hello", "World")}");
        Console.WriteLine();

        // Interactive Exercise: Library Management System
        Console.WriteLine("--- Interactive Exercise: Library Management ---");
        LibraryManagementDemo();

        Console.WriteLine("\n🎯 Key OOP Concepts Learned:");
        Console.WriteLine("• Classes define the blueprint for objects");
        Console.WriteLine("• Objects are instances of classes");
        Console.WriteLine("• Encapsulation hides internal data and provides controlled access");
        Console.WriteLine("• Properties provide getter/setter access to private fields");
        Console.WriteLine("• Static members belong to the class, not individual objects");
        Console.WriteLine("• Method overloading allows multiple methods with the same name");
        Console.WriteLine("• Constructors initialize objects when they're created");
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void LibraryManagementDemo()
    {
        Library library = new Library("Central Library");
        
        // Add some books
        library.AddBook(new Book("The C# Programming Language", "Anders Hejlsberg", "978-0321741769"));
        library.AddBook(new Book("Clean Code", "Robert Martin", "978-0132350884"));
        library.AddBook(new Book("Design Patterns", "Gang of Four", "978-0201633612"));
        
        bool running = true;
        
        while (running)
        {
            Console.WriteLine($"\n📚 {library.Name} Management System");
            Console.WriteLine("1. List all books");
            Console.WriteLine("2. Add new book");
            Console.WriteLine("3. Search for book");
            Console.WriteLine("4. Borrow book");
            Console.WriteLine("5. Return book");
            Console.WriteLine("6. Library statistics");
            Console.WriteLine("7. Exit");
            Console.Write("Choose option (1-7): ");
            
            string? choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    library.ListAllBooks();
                    break;
                    
                case "2":
                    Console.Write("Enter book title: ");
                    string? title = Console.ReadLine();
                    Console.Write("Enter author: ");
                    string? author = Console.ReadLine();
                    Console.Write("Enter ISBN: ");
                    string? isbn = Console.ReadLine();
                    
                    if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(author) && !string.IsNullOrEmpty(isbn))
                    {
                        library.AddBook(new Book(title, author, isbn));
                        Console.WriteLine("Book added successfully!");
                    }
                    break;
                    
                case "3":
                    Console.Write("Enter search term (title or author): ");
                    string? searchTerm = Console.ReadLine();
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        library.SearchBooks(searchTerm);
                    }
                    break;
                    
                case "4":
                    Console.Write("Enter book title to borrow: ");
                    string? borrowTitle = Console.ReadLine();
                    if (!string.IsNullOrEmpty(borrowTitle))
                    {
                        library.BorrowBook(borrowTitle);
                    }
                    break;
                    
                case "5":
                    Console.Write("Enter book title to return: ");
                    string? returnTitle = Console.ReadLine();
                    if (!string.IsNullOrEmpty(returnTitle))
                    {
                        library.ReturnBook(returnTitle);
                    }
                    break;
                    
                case "6":
                    library.ShowStatistics();
                    break;
                    
                case "7":
                    running = false;
                    break;
                    
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}

// Student class demonstrating basic OOP concepts
public class Student
{
    // Static field - belongs to the class, not individual objects
    public static int TotalStudents = 0;
    
    // Private fields (encapsulation)
    private string name;
    private int age;
    private string studentId;
    private List<int> grades;
    
    // Constructor
    public Student(string name, int age, string studentId)
    {
        this.name = name;
        this.age = age;
        this.studentId = studentId;
        this.grades = new List<int>();
        TotalStudents++; // Increment static counter
    }
    
    // Properties (controlled access to private fields)
    public string Name 
    { 
        get { return name; } 
        set { name = value; } 
    }
    
    public int Age 
    { 
        get { return age; } 
        set { if (value >= 0) age = value; } 
    }
    
    public string StudentId 
    { 
        get { return studentId; } 
    }
    
    // Methods
    public void AddGrade(int grade)
    {
        if (grade >= 0 && grade <= 100)
        {
            grades.Add(grade);
            Console.WriteLine($"Added grade {grade} for {name}");
        }
        else
        {
            Console.WriteLine("Invalid grade. Must be between 0 and 100.");
        }
    }
    
    public double GetAverage()
    {
        if (grades.Count == 0) return 0;
        
        int sum = 0;
        foreach (int grade in grades)
        {
            sum += grade;
        }
        return (double)sum / grades.Count;
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine($"Student: {name}, Age: {age}, ID: {studentId}, Grades: {grades.Count}");
    }
}

// BankAccount class demonstrating encapsulation and validation
public class BankAccount
{
    public static int TotalAccounts = 0;
    private static int nextAccountNumber = 1001;
    
    private string accountHolder;
    private int accountNumber;
    private double balance;
    
    public BankAccount(string accountHolder, int accountNumber, double initialBalance)
    {
        this.accountHolder = accountHolder;
        this.accountNumber = accountNumber;
        this.balance = initialBalance >= 0 ? initialBalance : 0;
        TotalAccounts++;
    }
    
    // Properties
    public string AccountHolder { get { return accountHolder; } }
    public int AccountNumber { get { return accountNumber; } }
    public double Balance { get { return balance; } }
    
    // Static method
    public static int GetNextAccountNumber()
    {
        return nextAccountNumber++;
    }
    
    // Methods with validation
    public bool Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Deposited ${amount:F2}. New balance: ${balance:F2}");
            return true;
        }
        Console.WriteLine("Deposit amount must be positive.");
        return false;
    }
    
    public bool Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Withdrew ${amount:F2}. New balance: ${balance:F2}");
            return true;
        }
        else if (amount > balance)
        {
            Console.WriteLine($"Insufficient funds. Current balance: ${balance:F2}");
        }
        else
        {
            Console.WriteLine("Withdrawal amount must be positive.");
        }
        return false;
    }
    
    public void DisplayAccountInfo()
    {
        Console.WriteLine($"Account: {accountNumber}, Holder: {accountHolder}, Balance: ${balance:F2}");
    }
}

// Car class demonstrating properties and state management
public class Car
{
    private string make;
    private string model;
    private int year;
    private string color;
    private bool isRunning;
    private int mileage;
    
    public Car(string make, string model, int year, string color)
    {
        this.make = make;
        this.model = model;
        this.year = year;
        this.color = color;
        this.isRunning = false;
        this.mileage = 0;
    }
    
    // Properties
    public string Make { get { return make; } }
    public string Model { get { return model; } }
    public int Year { get { return year; } }
    public string Color { get { return color; } set { color = value; } }
    public bool IsRunning { get { return isRunning; } }
    public int Mileage { get { return mileage; } }
    
    // Methods
    public void StartEngine()
    {
        if (!isRunning)
        {
            isRunning = true;
            Console.WriteLine($"{make} {model} engine started!");
        }
        else
        {
            Console.WriteLine($"{make} {model} is already running.");
        }
    }
    
    public void StopEngine()
    {
        if (isRunning)
        {
            isRunning = false;
            Console.WriteLine($"{make} {model} engine stopped.");
        }
        else
        {
            Console.WriteLine($"{make} {model} is already stopped.");
        }
    }
    
    public void Drive(int miles)
    {
        if (isRunning && miles > 0)
        {
            mileage += miles;
            Console.WriteLine($"Drove {miles} miles. Total mileage: {mileage}");
        }
        else if (!isRunning)
        {
            Console.WriteLine("Cannot drive. Engine is not running.");
        }
        else
        {
            Console.WriteLine("Invalid distance.");
        }
    }
    
    public void DisplayCarInfo()
    {
        Console.WriteLine($"{year} {make} {model} ({color}) - Mileage: {mileage} miles");
    }
}

// Calculator class demonstrating method overloading
public class Calculator
{
    // Method overloading - same name, different parameters
    public int Add(int a, int b)
    {
        return a + b;
    }
    
    public double Add(double a, double b)
    {
        return a + b;
    }
    
    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
    
    public string Add(string a, string b)
    {
        return a + " " + b;
    }
}

// Book class for library system
public class Book
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public bool IsAvailable { get; private set; }
    
    public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        IsAvailable = true;
    }
    
    public void Borrow()
    {
        IsAvailable = false;
    }
    
    public void Return()
    {
        IsAvailable = true;
    }
    
    public void DisplayInfo()
    {
        string status = IsAvailable ? "Available" : "Borrowed";
        Console.WriteLine($"  \"{Title}\" by {Author} - {status}");
    }
}

// Library class managing collection of books
public class Library
{
    public string Name { get; private set; }
    private List<Book> books;
    
    public Library(string name)
    {
        Name = name;
        books = new List<Book>();
    }
    
    public void AddBook(Book book)
    {
        books.Add(book);
    }
    
    public void ListAllBooks()
    {
        Console.WriteLine($"\n📚 All Books in {Name}:");
        if (books.Count == 0)
        {
            Console.WriteLine("  No books in library.");
            return;
        }
        
        for (int i = 0; i < books.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            books[i].DisplayInfo();
        }
    }
    
    public void SearchBooks(string searchTerm)
    {
        Console.WriteLine($"\n🔍 Search results for \"{searchTerm}\":");
        bool found = false;
        
        foreach (Book book in books)
        {
            if (book.Title.ToLower().Contains(searchTerm.ToLower()) || 
                book.Author.ToLower().Contains(searchTerm.ToLower()))
            {
                book.DisplayInfo();
                found = true;
            }
        }
        
        if (!found)
        {
            Console.WriteLine("  No books found matching your search.");
        }
    }
    
    public void BorrowBook(string title)
    {
        foreach (Book book in books)
        {
            if (book.Title.ToLower() == title.ToLower())
            {
                if (book.IsAvailable)
                {
                    book.Borrow();
                    Console.WriteLine($"You borrowed \"{book.Title}\"");
                }
                else
                {
                    Console.WriteLine($"\"{book.Title}\" is already borrowed.");
                }
                return;
            }
        }
        Console.WriteLine($"Book \"{title}\" not found.");
    }
    
    public void ReturnBook(string title)
    {
        foreach (Book book in books)
        {
            if (book.Title.ToLower() == title.ToLower())
            {
                if (!book.IsAvailable)
                {
                    book.Return();
                    Console.WriteLine($"You returned \"{book.Title}\"");
                }
                else
                {
                    Console.WriteLine($"\"{book.Title}\" was not borrowed.");
                }
                return;
            }
        }
        Console.WriteLine($"Book \"{title}\" not found.");
    }
    
    public void ShowStatistics()
    {
        int totalBooks = books.Count;
        int availableBooks = 0;
        int borrowedBooks = 0;
        
        foreach (Book book in books)
        {
            if (book.IsAvailable)
                availableBooks++;
            else
                borrowedBooks++;
        }
        
        Console.WriteLine($"\n📊 {Name} Statistics:");
        Console.WriteLine($"  Total books: {totalBooks}");
        Console.WriteLine($"  Available: {availableBooks}");
        Console.WriteLine($"  Borrowed: {borrowedBooks}");
    }
}
