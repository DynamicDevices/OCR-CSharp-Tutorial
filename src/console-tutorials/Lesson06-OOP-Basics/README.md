# Lesson 6: Object-Oriented Programming Basics

## 🎯 Learning Objectives (OCR A-Level Alignment)

This lesson covers **OCR Specification Section 2.2.1** - Object-Oriented Programming:
- Classes and objects fundamentals
- Encapsulation and data hiding
- Properties and methods
- Constructors and static members
- Method overloading
- Real-world OOP applications

## 📚 What You'll Learn

### Core Concepts
- **Classes**: Blueprints for creating objects
- **Objects**: Instances of classes with their own data
- **Encapsulation**: Hiding internal data and providing controlled access
- **Properties**: Getter/setter methods for accessing private fields
- **Static Members**: Class-level data and methods
- **Method Overloading**: Multiple methods with the same name but different parameters

### OCR Assessment Objectives
- **AO1**: Demonstrate knowledge of OOP principles and terminology
- **AO2**: Apply OOP concepts to solve programming problems
- **AO3**: Analyze the benefits of object-oriented design

## 🚀 Running the Code

```bash
cd Lesson06-OOP-Basics
dotnet run
```

## 🔍 Key Programming Concepts

### 1. Class Definition
```csharp
public class Student
{
    // Private fields (encapsulation)
    private string name;
    private int age;
    
    // Constructor
    public Student(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    
    // Properties
    public string Name 
    { 
        get { return name; } 
        set { name = value; } 
    }
    
    // Methods
    public void DisplayInfo()
    {
        Console.WriteLine($"Student: {name}, Age: {age}");
    }
}
```

### 2. Object Creation and Usage
```csharp
Student student1 = new Student("Alice", 16);
student1.DisplayInfo();
Console.WriteLine(student1.Name); // Using property
```

### 3. Static Members
```csharp
public class Student
{
    public static int TotalStudents = 0; // Class-level variable
    
    public Student(string name, int age)
    {
        // Constructor code
        TotalStudents++; // Increment for each new student
    }
    
    public static int GetTotalStudents() // Class-level method
    {
        return TotalStudents;
    }
}
```

## 🎮 Interactive Features

The program includes several hands-on exercises:

1. **Student Management**: Create and manage student objects with grades
2. **Bank Account System**: Demonstrate encapsulation with account operations
3. **Car Class**: Show properties and state management
4. **Calculator**: Demonstrate method overloading
5. **Library Management**: Complete application using multiple classes

## 🔗 OCR Specification Links

### Component 2: Algorithms and Programming
- **2.2.1**: Programming techniques including object-oriented programming
- **2.1.1**: Thinking abstractly - using classes to model real-world entities

## 💡 Study Tips for OCR Exams

### Common Exam Questions
1. **Class Design**: "Design a class to represent a [real-world entity]"
2. **Encapsulation**: "Explain why private fields and public properties are used"
3. **Object Creation**: "Write code to create and use objects of the given class"
4. **Static vs Instance**: "Explain the difference between static and instance members"

### Key Points to Remember
- **Classes** are templates; **objects** are instances
- **Private fields** hide data; **public properties** provide controlled access
- **Constructors** initialize objects when they're created
- **Static members** belong to the class, not individual objects
- **Method overloading** allows multiple methods with the same name
- **Encapsulation** improves code security and maintainability

### Real-World Applications
- **Student Management Systems**: Track student information and grades
- **Banking Applications**: Manage accounts with secure operations
- **Game Development**: Characters, items, and game objects
- **E-commerce**: Products, customers, and shopping carts
- **Library Systems**: Books, members, and borrowing records

## 🔄 Next Steps

After mastering this lesson:
1. **Practice**: Create your own classes for different real-world entities
2. **Explore**: Learn about inheritance and polymorphism (Lesson 7)
3. **Apply**: Use OOP in larger programming projects
4. **Advance**: Study design patterns and advanced OOP concepts

## 📖 Additional Resources

- [Microsoft C# Classes Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/)
- [OCR A-Level Computer Science Specification](https://www.ocr.org.uk/qualifications/as-and-a-level/computer-science-h046-h446-from-2015/)
- [Object-Oriented Programming Principles](https://www.freecodecamp.org/news/object-oriented-programming-concepts-21bb035f7260/)

---

**OCR A-Level Computer Science - Phase 2 Implementation**  
**Contact**: info@dynamicdevices.co.uk  
**License**: Creative Commons Attribution-NonCommercial 4.0 International
