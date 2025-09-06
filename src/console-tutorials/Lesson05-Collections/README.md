# Lesson 5: Collections and Advanced Data Structures

## 🎯 Learning Objectives (OCR A-Level Alignment)

This lesson covers **OCR Specification Section 1.4.2** - Advanced Data Structures:
- Generic collections (List<T>, Dictionary<TKey,TValue>)
- Stack and Queue data structures (LIFO and FIFO)
- HashSet for unique element storage
- Custom data structure implementation
- Choosing appropriate data structures for problems

## 📚 What You'll Learn

### Core Concepts
- **List<T>**: Dynamic arrays that can grow and shrink
- **Stack<T>**: Last In, First Out (LIFO) data structure
- **Queue<T>**: First In, First Out (FIFO) data structure  
- **Dictionary<TKey,TValue>**: Key-value pair storage with fast lookups
- **HashSet<T>**: Collection of unique elements
- **Custom Implementations**: Building your own stack and queue classes

### OCR Assessment Objectives
- **AO1**: Demonstrate knowledge of different data structure types and their properties
- **AO2**: Apply appropriate data structures to solve computational problems
- **AO3**: Analyze the efficiency and suitability of different data structures

## 🚀 Running the Code

```bash
cd Lesson05-Collections
dotnet run
```

## 🔍 Key Programming Concepts

### 1. List<T> - Dynamic Arrays
```csharp
List<string> students = new List<string>();
students.Add("Alice");           // Add single element
students.AddRange(new[] {"Bob", "Charlie"}); // Add multiple
students.Insert(1, "Zoe");       // Insert at position
students.Remove("Bob");          // Remove by value
students.RemoveAt(0);           // Remove by index
```

### 2. Stack<T> - LIFO Operations
```csharp
Stack<string> history = new Stack<string>();
history.Push("Page1");          // Add to top
history.Push("Page2");          // Add to top
string current = history.Peek(); // Look at top (don't remove)
string last = history.Pop();     // Remove from top
```

### 3. Queue<T> - FIFO Operations
```csharp
Queue<string> jobs = new Queue<string>();
jobs.Enqueue("Job1");           // Add to back
jobs.Enqueue("Job2");           // Add to back
string next = jobs.Peek();       // Look at front (don't remove)
string first = jobs.Dequeue();   // Remove from front
```

### 4. Dictionary<TKey,TValue> - Key-Value Storage
```csharp
Dictionary<string, int> grades = new Dictionary<string, int>();
grades.Add("Alice", 95);        // Add key-value pair
grades["Bob"] = 87;             // Alternative syntax
int aliceGrade = grades["Alice"]; // Access by key
bool hasCharlie = grades.ContainsKey("Charlie"); // Check existence
```

## 📊 Data Structure Comparison (OCR Requirement)

| Data Structure | Access Time | Insert Time | Delete Time | Use Case |
|----------------|-------------|-------------|-------------|----------|
| **Array** | O(1) | O(n) | O(n) | Fixed-size collections |
| **List<T>** | O(1) | O(1)* | O(n) | Dynamic collections |
| **Stack<T>** | O(1) top | O(1) | O(1) | Undo operations, parsing |
| **Queue<T>** | O(1) front | O(1) | O(1) | Task scheduling, BFS |
| **Dictionary<T,K>** | O(1)* | O(1)* | O(1)* | Fast key-based lookup |
| **HashSet<T>** | O(1)* | O(1)* | O(1)* | Unique element storage |

*Average case - may degrade to O(n) in worst case

## 🎮 Interactive Features

The program includes several hands-on exercises:

1. **Collection Basics**: Work with List<T>, Stack<T>, and Queue<T>
2. **Dictionary Operations**: Store and retrieve key-value pairs
3. **HashSet Uniqueness**: Automatically handle duplicate removal
4. **Custom Implementations**: See how stacks and queues work internally
5. **Student Management System**: Complete application using multiple data structures

## 🔗 OCR Specification Links

### Component 1: Computer Systems
- **1.4.2**: Data structures including stacks, queues, and hash tables
- **1.4.2**: Abstract data types and their implementations

### Component 2: Algorithms and Programming
- **2.2.1**: Use of data structures in problem solving
- **2.3.1**: Algorithm efficiency with different data structures

## 💡 Study Tips for OCR Exams

### Common Exam Questions
1. **Data Structure Selection**: "Choose the most appropriate data structure for..."
2. **Stack Operations**: "Trace through these stack operations: Push(5), Push(3), Pop(), Push(7)..."
3. **Queue Operations**: "Show the state of the queue after these operations..."
4. **Implementation**: "Write pseudocode for a stack using an array"

### Key Points to Remember
- **Stack**: LIFO - like a stack of plates, add/remove from top only
- **Queue**: FIFO - like a queue at a shop, join at back, leave from front
- **Dictionary**: Fast O(1) average lookup time using hash tables
- **List<T>**: Automatically resizes, but may need to copy all elements
- **HashSet<T>**: No duplicates allowed, unordered collection

### Real-World Applications
- **Stack**: Browser back button, undo functionality, expression evaluation
- **Queue**: Print job scheduling, breadth-first search, task processing
- **Dictionary**: Database indexing, caching, symbol tables
- **List**: Dynamic arrays, shopping carts, search results
- **HashSet**: Removing duplicates, membership testing, set operations

## 🔄 Algorithm Implementations

### Custom Stack Class
```csharp
public class CustomStack<T>
{
    private List<T> items = new List<T>();
    
    public void Push(T item) => items.Add(item);
    
    public T Pop()
    {
        if (IsEmpty()) throw new InvalidOperationException("Stack is empty");
        T item = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);
        return item;
    }
    
    public T Peek() => IsEmpty() ? 
        throw new InvalidOperationException("Stack is empty") : 
        items[items.Count - 1];
    
    public bool IsEmpty() => items.Count == 0;
}
```

### Custom Queue Class
```csharp
public class CustomQueue<T>
{
    private List<T> items = new List<T>();
    
    public void Enqueue(T item) => items.Add(item);
    
    public T Dequeue()
    {
        if (IsEmpty()) throw new InvalidOperationException("Queue is empty");
        T item = items[0];
        items.RemoveAt(0);
        return item;
    }
    
    public T Peek() => IsEmpty() ? 
        throw new InvalidOperationException("Queue is empty") : 
        items[0];
    
    public bool IsEmpty() => items.Count == 0;
}
```

## 🔄 Next Steps

After mastering this lesson:
1. **Practice**: Implement other data structures (binary trees, linked lists)
2. **Apply**: Use collections in real programming projects
3. **Optimize**: Learn about time and space complexity analysis
4. **Advance**: Move to Lesson 6 - Object-Oriented Programming Basics

## 📖 Additional Resources

- [Microsoft C# Collections Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections)
- [Data Structures Visualization](https://www.cs.usfca.edu/~galles/visualization/Algorithms.html)
- [OCR A-Level Computer Science Specification](https://www.ocr.org.uk/qualifications/as-and-a-level/computer-science-h046-h446-from-2015/)

---

**OCR A-Level Computer Science - Phase 2 Implementation**  
**Contact**: info@dynamicdevices.co.uk  
**License**: Creative Commons Attribution-NonCommercial 4.0 International
