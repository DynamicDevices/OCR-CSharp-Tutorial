# Lesson 7: Advanced Object-Oriented Programming

## 🎯 Learning Objectives (OCR A-Level Alignment)

This lesson covers **OCR Specification Section 2.1.1** - Advanced OOP Concepts:
- Inheritance and class hierarchies
- Polymorphism and method overriding
- Abstract classes and methods
- Interfaces and contracts
- Virtual methods and late binding
- Advanced OOP design patterns

## 📚 What You'll Learn

### Core Concepts
- **Inheritance**: Creating new classes based on existing ones
- **Polymorphism**: Objects taking multiple forms
- **Abstract Classes**: Partial implementations that cannot be instantiated
- **Interfaces**: Contracts defining what classes must implement
- **Method Overriding**: Child classes providing specific implementations
- **Virtual Methods**: Methods that can be overridden in derived classes

### OCR Assessment Objectives
- **AO1**: Demonstrate knowledge of advanced OOP principles
- **AO2**: Apply inheritance and polymorphism to solve complex problems
- **AO3**: Analyze the benefits of different OOP design approaches

## 🚀 Running the Code

```bash
cd Lesson07-OOP-Advanced
dotnet run
```

## 🔍 Key Programming Concepts

### 1. Inheritance
```csharp
// Base class
public class Vehicle
{
    protected string make;
    protected string model;
    
    public Vehicle(string make, string model)
    {
        this.make = make;
        this.model = model;
    }
    
    public virtual void Start()
    {
        Console.WriteLine($"{make} {model} started.");
    }
}

// Derived class
public class Car : Vehicle
{
    private int numberOfDoors;
    
    public Car(string make, string model, int doors) : base(make, model)
    {
        this.numberOfDoors = doors;
    }
    
    public override void Start()
    {
        Console.WriteLine($"{make} {model} car started smoothly.");
    }
}
```

### 2. Abstract Classes
```csharp
public abstract class Shape
{
    public abstract double GetArea();      // Must be implemented
    public abstract double GetPerimeter(); // Must be implemented
    
    public virtual void DisplayInfo()      // Can be overridden
    {
        Console.WriteLine($"This is a {GetType().Name}");
    }
}

public class Circle : Shape
{
    private double radius;
    
    public Circle(double radius) { this.radius = radius; }
    
    public override double GetArea()
    {
        return Math.PI * radius * radius;
    }
    
    public override double GetPerimeter()
    {
        return 2 * Math.PI * radius;
    }
}
```

### 3. Interfaces
```csharp
public interface IPlayable
{
    void Play();
    void Pause();
    void Stop();
    int GetDuration();
}

public class MusicTrack : IPlayable
{
    private string title;
    private int duration;
    
    public void Play() { Console.WriteLine($"Playing: {title}"); }
    public void Pause() { Console.WriteLine($"Paused: {title}"); }
    public void Stop() { Console.WriteLine($"Stopped: {title}"); }
    public int GetDuration() { return duration; }
}
```

### 4. Polymorphism
```csharp
List<Vehicle> vehicles = new List<Vehicle>
{
    new Car("Honda", "Civic", 4),
    new Motorcycle("Yamaha", "R1", false),
    new Truck("Ford", "F-150", 2.5)
};

foreach (Vehicle vehicle in vehicles)
{
    vehicle.Start(); // Calls appropriate Start method for each type
}
```

## 🏗️ OOP Design Principles

### Inheritance Hierarchy
```
Animal (abstract)
├── Lion
├── Elephant  
├── Penguin
└── Eagle

Employee (abstract)
├── FullTimeEmployee
├── PartTimeEmployee
└── ContractEmployee
```

### Interface Implementation
```
IPlayable
├── MusicTrack
├── VideoFile
└── Podcast
```

## 🎮 Interactive Features

The program includes several comprehensive examples:

1. **Vehicle Hierarchy**: Cars, motorcycles, and trucks with inheritance
2. **Shape Calculator**: Abstract classes with concrete implementations
3. **Media Player**: Interface-based design for different media types
4. **Employee Payroll**: Method overriding for different employee types
5. **Zoo Management**: Complete animal kingdom simulation

## 🔗 OCR Specification Links

### Component 2: Algorithms and Programming
- **2.1.1**: Thinking abstractly - abstraction and modeling
- **2.2.1**: Advanced programming techniques including inheritance
- **2.2.1**: Polymorphism and method overriding

## 💡 Study Tips for OCR Exams

### Common Exam Questions
1. **Inheritance Design**: "Create a class hierarchy for [scenario]"
2. **Method Overriding**: "Explain how method overriding works"
3. **Abstract vs Interface**: "When would you use an abstract class vs an interface?"
4. **Polymorphism**: "Demonstrate polymorphism with the given classes"

### Key Points to Remember
- **Inheritance**: "IS-A" relationship (Car IS-A Vehicle)
- **Composition**: "HAS-A" relationship (Car HAS-A Engine)
- **Abstract classes**: Can have both abstract and concrete methods
- **Interfaces**: Only method signatures, no implementation
- **Virtual methods**: Can be overridden but don't have to be
- **Abstract methods**: Must be overridden in derived classes

### Benefits of Advanced OOP
- **Code Reusability**: Inherit common functionality
- **Maintainability**: Changes in base class affect all derived classes
- **Extensibility**: Easy to add new types without changing existing code
- **Polymorphism**: Treat different objects uniformly
- **Abstraction**: Hide complex implementation details

## 🔄 Algorithm Implementations

### Method Overriding Pattern
```csharp
public abstract class Employee
{
    public abstract double CalculatePay(); // Each type calculates differently
}

public class FullTimeEmployee : Employee
{
    public override double CalculatePay()
    {
        return annualSalary / 12; // Monthly salary
    }
}

public class PartTimeEmployee : Employee  
{
    public override double CalculatePay()
    {
        return hourlyRate * hoursWorked; // Hourly calculation
    }
}
```

### Interface Implementation Pattern
```csharp
public interface IMovable
{
    void Move();
    double GetSpeed();
}

public class Animal : IMovable
{
    public virtual void Move() { /* default movement */ }
    public virtual double GetSpeed() { return 5.0; }
}

public class Lion : Animal
{
    public override void Move() { Console.WriteLine("Prowling..."); }
    public override double GetSpeed() { return 50.0; } // Lions are fast
}
```

## 🔄 Next Steps

After mastering this lesson:
1. **Practice**: Design complex class hierarchies for real-world scenarios
2. **Explore**: Learn about design patterns (Factory, Observer, Strategy)
3. **Apply**: Use advanced OOP in larger software projects
4. **Advance**: Move to Lesson 8 - Exception Handling and Validation

## 📖 Additional Resources

- [Microsoft C# Inheritance Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/inheritance)
- [Polymorphism in C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/polymorphism)
- [Abstract Classes vs Interfaces](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members)

---

**OCR A-Level Computer Science - Phase 2 Implementation**  
**Contact**: info@dynamicdevices.co.uk  
**License**: Creative Commons Attribution-NonCommercial 4.0 International
