using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("📚 Collections and Advanced Data Structures - OCR A-Level");
        Console.WriteLine("========================================================\n");

        Console.WriteLine("🏛️ Why Collections Were Invented:");
        Console.WriteLine("In the early days of programming (1950s-60s), arrays had fixed sizes.");
        Console.WriteLine("If you needed more space, tough luck! You had to rewrite your program.");
        Console.WriteLine("Collections were invented to solve this - they can grow and shrink!");
        Console.WriteLine("Different collections solve different problems that programmers face.\n");

        // Example 1: List<T> - Dynamic Arrays
        Console.WriteLine("--- Example 1: List<T> (Dynamic Arrays) ---");
        Console.WriteLine("Problem: Arrays have fixed size. What if we don't know how many items we'll have?");
        Console.WriteLine("Solution: List<T> - invented in the 1970s, it's an array that can resize itself!\n");
        
        List<string> students = new List<string>();
        
        // Adding elements
        students.Add("Alice");
        students.Add("Bob");
        students.Add("Charlie");
        
        // Adding multiple elements
        students.AddRange(new string[] { "Diana", "Eve" });
        
        Console.WriteLine($"Number of students: {students.Count}");
        Console.WriteLine("Students:");
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {students[i]}");
        }
        
        // Inserting at specific position
        students.Insert(1, "Zoe");
        Console.WriteLine($"\nAfter inserting Zoe at position 1:");
        foreach (string student in students)
        {
            Console.Write($"{student} ");
        }
        Console.WriteLine("\n");

        // Example 2: Stack<T> - Last In, First Out (LIFO)
        Console.WriteLine("--- Example 2: Stack<T> (LIFO) ---");
        Console.WriteLine("🥞 Real-World Origin: Think of a stack of plates in a cafeteria!");
        Console.WriteLine("You can only add/remove plates from the top. Last plate in, first out.");
        Console.WriteLine("Invented in 1946 for computer memory management - still used today!");
        Console.WriteLine("Perfect for: Undo operations, browser back button, function calls.\n");
        
        Stack<string> browserHistory = new Stack<string>();
        
        // Push pages onto the stack
        browserHistory.Push("google.com");
        browserHistory.Push("github.com");
        browserHistory.Push("stackoverflow.com");
        browserHistory.Push("docs.microsoft.com");
        
        Console.WriteLine("Browser history (most recent first):");
        Console.WriteLine($"Current page: {browserHistory.Peek()}");
        Console.WriteLine($"Pages in history: {browserHistory.Count}");
        
        // Simulate back button
        Console.WriteLine("\nSimulating back button clicks:");
        while (browserHistory.Count > 0)
        {
            string currentPage = browserHistory.Pop();
            Console.WriteLine($"Going back from: {currentPage}");
            
            if (browserHistory.Count > 0)
            {
                Console.WriteLine($"Now on: {browserHistory.Peek()}");
            }
            else
            {
                Console.WriteLine("No more pages in history");
            }
        }
        Console.WriteLine();

        // Example 3: Queue<T> - First In, First Out (FIFO)
        Console.WriteLine("--- Example 3: Queue<T> (FIFO) ---");
        Console.WriteLine("🚶‍♀️ Real-World Origin: Like a queue (line) at a shop!");
        Console.WriteLine("First person in line gets served first. Fair and orderly.");
        Console.WriteLine("Invented in 1959 for job scheduling in early computers.");
        Console.WriteLine("Perfect for: Print queues, task scheduling, breadth-first search.\n");
        
        Queue<string> printQueue = new Queue<string>();
        
        // Enqueue print jobs
        printQueue.Enqueue("Document1.pdf");
        printQueue.Enqueue("Photo.jpg");
        printQueue.Enqueue("Report.docx");
        printQueue.Enqueue("Presentation.pptx");
        
        Console.WriteLine("Print queue:");
        Console.WriteLine($"Jobs in queue: {printQueue.Count}");
        Console.WriteLine($"Next job: {printQueue.Peek()}");
        
        // Process print jobs
        Console.WriteLine("\nProcessing print jobs:");
        while (printQueue.Count > 0)
        {
            string job = printQueue.Dequeue();
            Console.WriteLine($"Printing: {job}");
            
            if (printQueue.Count > 0)
            {
                Console.WriteLine($"Next in queue: {printQueue.Peek()}");
            }
        }
        Console.WriteLine("All jobs completed!\n");

        // Example 4: Dictionary<TKey, TValue> - Key-Value Pairs
        Console.WriteLine("--- Example 4: Dictionary<TKey, TValue> ---");
        Console.WriteLine("📖 Real-World Origin: Like a real dictionary or phone book!");
        Console.WriteLine("You look up a word (key) to find its meaning (value).");
        Console.WriteLine("Invented in 1953 using 'hash tables' - super fast lookups!");
        Console.WriteLine("Perfect for: Databases, caches, lookup tables, word counts.\n");
        
        Dictionary<string, int> studentGrades = new Dictionary<string, int>();
        
        // Adding key-value pairs
        studentGrades.Add("Alice", 95);
        studentGrades.Add("Bob", 87);
        studentGrades.Add("Charlie", 92);
        studentGrades["Diana"] = 88; // Alternative syntax
        studentGrades["Eve"] = 91;
        
        Console.WriteLine("Student Grades:");
        foreach (KeyValuePair<string, int> student in studentGrades)
        {
            Console.WriteLine($"  {student.Key}: {student.Value}%");
        }
        
        // Checking if key exists
        Console.Write("\nEnter student name to look up: ");
        string? searchName = Console.ReadLine();
        
        if (!string.IsNullOrEmpty(searchName))
        {
            if (studentGrades.ContainsKey(searchName))
            {
                Console.WriteLine($"{searchName}'s grade: {studentGrades[searchName]}%");
            }
            else
            {
                Console.WriteLine($"{searchName} not found in the grade book.");
            }
        }
        Console.WriteLine();

        // Example 5: HashSet<T> - Unique Elements
        Console.WriteLine("--- Example 5: HashSet<T> (Unique Elements) ---");
        Console.WriteLine("🔍 Mathematical Origin: Based on 'set theory' from mathematics!");
        Console.WriteLine("A set can only contain unique items - no duplicates allowed.");
        Console.WriteLine("Invented in 1960s, uses hash tables for super-fast duplicate detection.");
        Console.WriteLine("Perfect for: Removing duplicates, membership testing, unique collections.\n");
        
        HashSet<string> uniqueWords = new HashSet<string>();
        
        string[] text = { "the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog", "the" };
        
        Console.WriteLine($"Original text: {string.Join(" ", text)}");
        
        foreach (string word in text)
        {
            uniqueWords.Add(word); // Duplicates are automatically ignored
        }
        
        Console.WriteLine($"Unique words: {string.Join(", ", uniqueWords)}");
        Console.WriteLine($"Total words: {text.Length}, Unique words: {uniqueWords.Count}");
        Console.WriteLine();

        // Example 6: Custom Stack Implementation
        Console.WriteLine("--- Example 6: Custom Stack Implementation ---");
        Console.WriteLine("🛠️ Learning by Building: Understanding how things work inside!");
        Console.WriteLine("In the 1960s, programmers had to build their own data structures.");
        Console.WriteLine("Today C# provides them built-in, but understanding the internals");
        Console.WriteLine("helps you become a better programmer and ace your OCR exams!\n");
        
        CustomStack<int> numberStack = new CustomStack<int>();
        
        // Push numbers
        for (int i = 1; i <= 5; i++)
        {
            numberStack.Push(i * 10);
            Console.WriteLine($"Pushed: {i * 10}, Stack size: {numberStack.Size}");
        }
        
        Console.WriteLine($"\nTop element: {numberStack.Peek()}");
        
        // Pop all elements
        Console.WriteLine("\nPopping all elements:");
        while (!numberStack.IsEmpty())
        {
            int value = numberStack.Pop();
            Console.WriteLine($"Popped: {value}, Remaining: {numberStack.Size}");
        }
        Console.WriteLine();

        // Example 7: Custom Queue Implementation
        Console.WriteLine("--- Example 7: Custom Queue Implementation ---");
        
        CustomQueue<string> messageQueue = new CustomQueue<string>();
        
        // Enqueue messages
        string[] messages = { "Hello", "World", "From", "C#", "Queue" };
        foreach (string message in messages)
        {
            messageQueue.Enqueue(message);
            Console.WriteLine($"Enqueued: {message}, Queue size: {messageQueue.Size}");
        }
        
        Console.WriteLine($"\nFront element: {messageQueue.Peek()}");
        
        // Dequeue all messages
        Console.WriteLine("\nDequeuing all messages:");
        while (!messageQueue.IsEmpty())
        {
            string message = messageQueue.Dequeue();
            Console.WriteLine($"Dequeued: {message}, Remaining: {messageQueue.Size}");
        }
        Console.WriteLine();

        // Interactive Exercise: Student Management System
        Console.WriteLine("--- Interactive Exercise: Student Management System ---");
        StudentManagementSystem();

        Console.WriteLine("\n🎯 Key Learning Points:");
        Console.WriteLine("• List<T> provides dynamic arrays with automatic resizing");
        Console.WriteLine("• Stack<T> follows LIFO principle - useful for undo operations");
        Console.WriteLine("• Queue<T> follows FIFO principle - useful for task scheduling");
        Console.WriteLine("• Dictionary<TKey, TValue> provides fast key-based lookups");
        Console.WriteLine("• HashSet<T> automatically maintains unique elements");
        Console.WriteLine("• Understanding when to use each data structure is crucial");
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void StudentManagementSystem()
    {
        Dictionary<int, string> students = new Dictionary<int, string>();
        Queue<string> waitingList = new Queue<string>();
        Stack<string> recentActions = new Stack<string>();
        
        bool running = true;
        
        while (running)
        {
            Console.WriteLine("\n📚 Student Management System");
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Remove student");
            Console.WriteLine("3. Find student");
            Console.WriteLine("4. List all students");
            Console.WriteLine("5. Add to waiting list");
            Console.WriteLine("6. Process waiting list");
            Console.WriteLine("7. Undo last action");
            Console.WriteLine("8. Exit");
            Console.Write("Choose option (1-8): ");
            
            string? choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    Console.Write("Enter student ID: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.Write("Enter student name: ");
                        string? name = Console.ReadLine();
                        if (!string.IsNullOrEmpty(name))
                        {
                            students[id] = name;
                            recentActions.Push($"Added student: {name} (ID: {id})");
                            Console.WriteLine($"Added {name} with ID {id}");
                        }
                    }
                    break;
                    
                case "2":
                    Console.Write("Enter student ID to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int removeId))
                    {
                        if (students.ContainsKey(removeId))
                        {
                            string removedName = students[removeId];
                            students.Remove(removeId);
                            recentActions.Push($"Removed student: {removedName} (ID: {removeId})");
                            Console.WriteLine($"Removed {removedName}");
                        }
                        else
                        {
                            Console.WriteLine("Student not found");
                        }
                    }
                    break;
                    
                case "3":
                    Console.Write("Enter student ID to find: ");
                    if (int.TryParse(Console.ReadLine(), out int findId))
                    {
                        if (students.ContainsKey(findId))
                        {
                            Console.WriteLine($"Found: {students[findId]} (ID: {findId})");
                        }
                        else
                        {
                            Console.WriteLine("Student not found");
                        }
                    }
                    break;
                    
                case "4":
                    Console.WriteLine($"\nAll Students ({students.Count}):");
                    foreach (var student in students)
                    {
                        Console.WriteLine($"  ID: {student.Key}, Name: {student.Value}");
                    }
                    break;
                    
                case "5":
                    Console.Write("Enter name for waiting list: ");
                    string? waitingName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(waitingName))
                    {
                        waitingList.Enqueue(waitingName);
                        Console.WriteLine($"Added {waitingName} to waiting list");
                    }
                    break;
                    
                case "6":
                    if (waitingList.Count > 0)
                    {
                        string nextStudent = waitingList.Dequeue();
                        Console.WriteLine($"Processing: {nextStudent}");
                        Console.WriteLine($"Remaining in waiting list: {waitingList.Count}");
                    }
                    else
                    {
                        Console.WriteLine("Waiting list is empty");
                    }
                    break;
                    
                case "7":
                    if (recentActions.Count > 0)
                    {
                        string lastAction = recentActions.Pop();
                        Console.WriteLine($"Undoing: {lastAction}");
                    }
                    else
                    {
                        Console.WriteLine("No actions to undo");
                    }
                    break;
                    
                case "8":
                    running = false;
                    break;
                    
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}

// Custom Stack Implementation for Educational Purposes
public class CustomStack<T>
{
    private List<T> items;
    
    public CustomStack()
    {
        items = new List<T>();
    }
    
    public void Push(T item)
    {
        items.Add(item);
    }
    
    public T Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty");
            
        T item = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);
        return item;
    }
    
    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty");
            
        return items[items.Count - 1];
    }
    
    public bool IsEmpty()
    {
        return items.Count == 0;
    }
    
    public int Size => items.Count;
}

// Custom Queue Implementation for Educational Purposes
public class CustomQueue<T>
{
    private List<T> items;
    
    public CustomQueue()
    {
        items = new List<T>();
    }
    
    public void Enqueue(T item)
    {
        items.Add(item);
    }
    
    public T Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");
            
        T item = items[0];
        items.RemoveAt(0);
        return item;
    }
    
    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");
            
        return items[0];
    }
    
    public bool IsEmpty()
    {
        return items.Count == 0;
    }
    
    public int Size => items.Count;
}
