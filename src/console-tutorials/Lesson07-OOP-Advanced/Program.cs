using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("🏛️ Advanced Object-Oriented Programming - OCR A-Level");
        Console.WriteLine("=====================================================\n");

        // Example 1: Inheritance
        Console.WriteLine("--- Example 1: Inheritance ---");
        InheritanceExample();
        Console.WriteLine();

        // Example 2: Polymorphism
        Console.WriteLine("--- Example 2: Polymorphism ---");
        PolymorphismExample();
        Console.WriteLine();

        // Example 3: Abstract Classes
        Console.WriteLine("--- Example 3: Abstract Classes ---");
        AbstractClassExample();
        Console.WriteLine();

        // Example 4: Interfaces
        Console.WriteLine("--- Example 4: Interfaces ---");
        InterfaceExample();
        Console.WriteLine();

        // Example 5: Method Overriding
        Console.WriteLine("--- Example 5: Method Overriding ---");
        MethodOverridingExample();
        Console.WriteLine();

        // Interactive Exercise: Animal Kingdom Simulation
        Console.WriteLine("--- Interactive Exercise: Animal Kingdom ---");
        AnimalKingdomDemo();

        Console.WriteLine("\n🎯 Advanced OOP Concepts Learned:");
        Console.WriteLine("• Inheritance allows classes to inherit from other classes");
        Console.WriteLine("• Polymorphism enables objects to take multiple forms");
        Console.WriteLine("• Abstract classes provide partial implementations");
        Console.WriteLine("• Interfaces define contracts that classes must implement");
        Console.WriteLine("• Method overriding allows child classes to provide specific implementations");
        Console.WriteLine("• Virtual methods can be overridden in derived classes");
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void InheritanceExample()
    {
        // Create different types of vehicles
        Car car = new Car("Toyota", "Camry", 4);
        Motorcycle motorcycle = new Motorcycle("Harley", "Davidson", true);
        Truck truck = new Truck("Ford", "F-150", 2.5);

        Console.WriteLine("Vehicle Information:");
        car.DisplayInfo();
        motorcycle.DisplayInfo();
        truck.DisplayInfo();

        Console.WriteLine("\nStarting engines:");
        car.Start();
        motorcycle.Start();
        truck.Start();
    }

    static void PolymorphismExample()
    {
        // Polymorphism - treating different objects the same way
        List<Vehicle> vehicles = new List<Vehicle>
        {
            new Car("Honda", "Civic", 4),
            new Motorcycle("Yamaha", "R1", false),
            new Truck("Chevy", "Silverado", 3.0)
        };

        Console.WriteLine("Polymorphic vehicle operations:");
        foreach (Vehicle vehicle in vehicles)
        {
            vehicle.Start(); // Calls the appropriate Start method for each type
            vehicle.DisplayInfo();
            Console.WriteLine($"Fuel efficiency: {vehicle.GetFuelEfficiency()} MPG");
            Console.WriteLine();
        }
    }

    static void AbstractClassExample()
    {
        List<Shape> shapes = new List<Shape>
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Triangle(3, 4, 5)
        };

        Console.WriteLine("Shape calculations:");
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetType().Name}:");
            Console.WriteLine($"  Area: {shape.GetArea():F2}");
            Console.WriteLine($"  Perimeter: {shape.GetPerimeter():F2}");
            shape.DisplayInfo();
            Console.WriteLine();
        }
    }

    static void InterfaceExample()
    {
        List<IPlayable> playableItems = new List<IPlayable>
        {
            new MusicTrack("Bohemian Rhapsody", "Queen", 355),
            new VideoFile("The Matrix", "Action", 8160),
            new Podcast("Tech Talk", "John Doe", 2700)
        };

        Console.WriteLine("Media player simulation:");
        foreach (IPlayable item in playableItems)
        {
            item.Play();
            Console.WriteLine($"Duration: {item.GetDuration()} seconds");
            item.Pause();
            item.Stop();
            Console.WriteLine();
        }
    }

    static void MethodOverridingExample()
    {
        Employee[] employees = {
            new FullTimeEmployee("Alice Johnson", 50000),
            new PartTimeEmployee("Bob Smith", 20, 160),
            new ContractEmployee("Charlie Brown", 75, 40)
        };

        Console.WriteLine("Employee payroll:");
        foreach (Employee employee in employees)
        {
            Console.WriteLine($"{employee.Name}: ${employee.CalculatePay():F2}");
            employee.DisplayEmployeeInfo();
            Console.WriteLine();
        }
    }

    static void AnimalKingdomDemo()
    {
        Zoo zoo = new Zoo("Safari Park");
        
        // Add different animals
        zoo.AddAnimal(new Lion("Simba", 5));
        zoo.AddAnimal(new Elephant("Dumbo", 12));
        zoo.AddAnimal(new Penguin("Pingu", 3));
        zoo.AddAnimal(new Eagle("Freedom", 7));

        bool running = true;
        
        while (running)
        {
            Console.WriteLine($"\n🦁 {zoo.Name} Management System");
            Console.WriteLine("1. List all animals");
            Console.WriteLine("2. Feed all animals");
            Console.WriteLine("3. Animal sounds");
            Console.WriteLine("4. Animal movements");
            Console.WriteLine("5. Zoo statistics");
            Console.WriteLine("6. Exit");
            Console.Write("Choose option (1-6): ");
            
            string? choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    zoo.ListAllAnimals();
                    break;
                case "2":
                    zoo.FeedAllAnimals();
                    break;
                case "3":
                    zoo.AllAnimalSounds();
                    break;
                case "4":
                    zoo.AllAnimalMovements();
                    break;
                case "5":
                    zoo.ShowStatistics();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}

// Base Vehicle class
public class Vehicle
{
    protected string make;
    protected string model;
    protected bool isRunning;

    public Vehicle(string make, string model)
    {
        this.make = make;
        this.model = model;
        this.isRunning = false;
    }

    public string Make => make;
    public string Model => model;
    public bool IsRunning => isRunning;

    public virtual void Start()
    {
        isRunning = true;
        Console.WriteLine($"{make} {model} started.");
    }

    public virtual void Stop()
    {
        isRunning = false;
        Console.WriteLine($"{make} {model} stopped.");
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Vehicle: {make} {model}");
    }

    public virtual double GetFuelEfficiency()
    {
        return 25.0; // Default MPG
    }
}

// Derived Car class
public class Car : Vehicle
{
    private int numberOfDoors;

    public Car(string make, string model, int numberOfDoors) : base(make, model)
    {
        this.numberOfDoors = numberOfDoors;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Car: {make} {model} ({numberOfDoors} doors)");
    }

    public override double GetFuelEfficiency()
    {
        return 30.0; // Cars are more fuel efficient
    }
}

// Derived Motorcycle class
public class Motorcycle : Vehicle
{
    private bool hasSidecar;

    public Motorcycle(string make, string model, bool hasSidecar) : base(make, model)
    {
        this.hasSidecar = hasSidecar;
    }

    public override void Start()
    {
        isRunning = true;
        Console.WriteLine($"{make} {model} motorcycle roared to life!");
    }

    public override void DisplayInfo()
    {
        string sidecarInfo = hasSidecar ? "with sidecar" : "without sidecar";
        Console.WriteLine($"Motorcycle: {make} {model} ({sidecarInfo})");
    }

    public override double GetFuelEfficiency()
    {
        return 45.0; // Motorcycles are very fuel efficient
    }
}

// Derived Truck class
public class Truck : Vehicle
{
    private double payloadCapacity;

    public Truck(string make, string model, double payloadCapacity) : base(make, model)
    {
        this.payloadCapacity = payloadCapacity;
    }

    public override void Start()
    {
        isRunning = true;
        Console.WriteLine($"{make} {model} truck engine rumbled to start!");
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Truck: {make} {model} (Payload: {payloadCapacity} tons)");
    }

    public override double GetFuelEfficiency()
    {
        return 15.0; // Trucks are less fuel efficient
    }
}

// Abstract Shape class
public abstract class Shape
{
    public abstract double GetArea();
    public abstract double GetPerimeter();
    
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"  This is a {GetType().Name}");
    }
}

// Concrete Circle class
public class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * radius * radius;
    }

    public override double GetPerimeter()
    {
        return 2 * Math.PI * radius;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"  Circle with radius {radius}");
    }
}

// Concrete Rectangle class
public class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public override double GetArea()
    {
        return width * height;
    }

    public override double GetPerimeter()
    {
        return 2 * (width + height);
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"  Rectangle {width} x {height}");
    }
}

// Concrete Triangle class
public class Triangle : Shape
{
    private double sideA, sideB, sideC;

    public Triangle(double sideA, double sideB, double sideC)
    {
        this.sideA = sideA;
        this.sideB = sideB;
        this.sideC = sideC;
    }

    public override double GetArea()
    {
        // Using Heron's formula
        double s = (sideA + sideB + sideC) / 2;
        return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
    }

    public override double GetPerimeter()
    {
        return sideA + sideB + sideC;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"  Triangle with sides {sideA}, {sideB}, {sideC}");
    }
}

// Interface for playable media
public interface IPlayable
{
    void Play();
    void Pause();
    void Stop();
    int GetDuration();
}

// Music track implementing IPlayable
public class MusicTrack : IPlayable
{
    private string title;
    private string artist;
    private int duration;

    public MusicTrack(string title, string artist, int duration)
    {
        this.title = title;
        this.artist = artist;
        this.duration = duration;
    }

    public void Play()
    {
        Console.WriteLine($"🎵 Playing: {title} by {artist}");
    }

    public void Pause()
    {
        Console.WriteLine($"⏸️ Paused: {title}");
    }

    public void Stop()
    {
        Console.WriteLine($"⏹️ Stopped: {title}");
    }

    public int GetDuration()
    {
        return duration;
    }
}

// Video file implementing IPlayable
public class VideoFile : IPlayable
{
    private string title;
    private string genre;
    private int duration;

    public VideoFile(string title, string genre, int duration)
    {
        this.title = title;
        this.genre = genre;
        this.duration = duration;
    }

    public void Play()
    {
        Console.WriteLine($"🎬 Playing video: {title} ({genre})");
    }

    public void Pause()
    {
        Console.WriteLine($"⏸️ Video paused: {title}");
    }

    public void Stop()
    {
        Console.WriteLine($"⏹️ Video stopped: {title}");
    }

    public int GetDuration()
    {
        return duration;
    }
}

// Podcast implementing IPlayable
public class Podcast : IPlayable
{
    private string title;
    private string host;
    private int duration;

    public Podcast(string title, string host, int duration)
    {
        this.title = title;
        this.host = host;
        this.duration = duration;
    }

    public void Play()
    {
        Console.WriteLine($"🎙️ Playing podcast: {title} hosted by {host}");
    }

    public void Pause()
    {
        Console.WriteLine($"⏸️ Podcast paused: {title}");
    }

    public void Stop()
    {
        Console.WriteLine($"⏹️ Podcast stopped: {title}");
    }

    public int GetDuration()
    {
        return duration;
    }
}

// Employee hierarchy for method overriding
public abstract class Employee
{
    protected string name;

    public Employee(string name)
    {
        this.name = name;
    }

    public string Name => name;

    public abstract double CalculatePay();

    public virtual void DisplayEmployeeInfo()
    {
        Console.WriteLine($"Employee: {name}");
    }
}

public class FullTimeEmployee : Employee
{
    private double annualSalary;

    public FullTimeEmployee(string name, double annualSalary) : base(name)
    {
        this.annualSalary = annualSalary;
    }

    public override double CalculatePay()
    {
        return annualSalary / 12; // Monthly pay
    }

    public override void DisplayEmployeeInfo()
    {
        Console.WriteLine($"Full-time Employee: {name}, Annual Salary: ${annualSalary:F2}");
    }
}

public class PartTimeEmployee : Employee
{
    private double hourlyRate;
    private int hoursWorked;

    public PartTimeEmployee(string name, double hourlyRate, int hoursWorked) : base(name)
    {
        this.hourlyRate = hourlyRate;
        this.hoursWorked = hoursWorked;
    }

    public override double CalculatePay()
    {
        return hourlyRate * hoursWorked;
    }

    public override void DisplayEmployeeInfo()
    {
        Console.WriteLine($"Part-time Employee: {name}, Rate: ${hourlyRate:F2}/hr, Hours: {hoursWorked}");
    }
}

public class ContractEmployee : Employee
{
    private double contractRate;
    private int hoursWorked;

    public ContractEmployee(string name, double contractRate, int hoursWorked) : base(name)
    {
        this.contractRate = contractRate;
        this.hoursWorked = hoursWorked;
    }

    public override double CalculatePay()
    {
        return contractRate * hoursWorked;
    }

    public override void DisplayEmployeeInfo()
    {
        Console.WriteLine($"Contract Employee: {name}, Rate: ${contractRate:F2}/hr, Hours: {hoursWorked}");
    }
}

// Animal hierarchy for zoo simulation
public abstract class Animal
{
    protected string name;
    protected int age;

    public Animal(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public string Name => name;
    public int Age => age;

    public abstract void MakeSound();
    public abstract void Move();
    public abstract string GetSpecies();

    public virtual void Eat()
    {
        Console.WriteLine($"{name} is eating.");
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"{GetSpecies()}: {name}, Age: {age}");
    }
}

public class Lion : Animal
{
    public Lion(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{name} roars: ROAAAAR!");
    }

    public override void Move()
    {
        Console.WriteLine($"{name} prowls majestically.");
    }

    public override string GetSpecies()
    {
        return "Lion";
    }

    public override void Eat()
    {
        Console.WriteLine($"{name} hunts and eats meat.");
    }
}

public class Elephant : Animal
{
    public Elephant(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{name} trumpets: PFFFRRRR!");
    }

    public override void Move()
    {
        Console.WriteLine($"{name} walks slowly with heavy steps.");
    }

    public override string GetSpecies()
    {
        return "Elephant";
    }

    public override void Eat()
    {
        Console.WriteLine($"{name} munches on leaves and grass.");
    }
}

public class Penguin : Animal
{
    public Penguin(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{name} squawks: SQUAWK SQUAWK!");
    }

    public override void Move()
    {
        Console.WriteLine($"{name} waddles and slides on ice.");
    }

    public override string GetSpecies()
    {
        return "Penguin";
    }

    public override void Eat()
    {
        Console.WriteLine($"{name} catches and eats fish.");
    }
}

public class Eagle : Animal
{
    public Eagle(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{name} screeches: SCREEEECH!");
    }

    public override void Move()
    {
        Console.WriteLine($"{name} soars high in the sky.");
    }

    public override string GetSpecies()
    {
        return "Eagle";
    }

    public override void Eat()
    {
        Console.WriteLine($"{name} hunts small animals from above.");
    }
}

// Zoo management class
public class Zoo
{
    public string Name { get; private set; }
    private List<Animal> animals;

    public Zoo(string name)
    {
        Name = name;
        animals = new List<Animal>();
    }

    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
        Console.WriteLine($"Added {animal.GetSpecies()} '{animal.Name}' to the zoo.");
    }

    public void ListAllAnimals()
    {
        Console.WriteLine($"\n🦁 Animals in {Name}:");
        if (animals.Count == 0)
        {
            Console.WriteLine("  No animals in the zoo.");
            return;
        }

        for (int i = 0; i < animals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            animals[i].DisplayInfo();
        }
    }

    public void FeedAllAnimals()
    {
        Console.WriteLine($"\n🍖 Feeding time at {Name}:");
        foreach (Animal animal in animals)
        {
            animal.Eat();
        }
    }

    public void AllAnimalSounds()
    {
        Console.WriteLine($"\n🔊 Animal sounds at {Name}:");
        foreach (Animal animal in animals)
        {
            animal.MakeSound();
        }
    }

    public void AllAnimalMovements()
    {
        Console.WriteLine($"\n🏃 Animal movements at {Name}:");
        foreach (Animal animal in animals)
        {
            animal.Move();
        }
    }

    public void ShowStatistics()
    {
        Console.WriteLine($"\n📊 {Name} Statistics:");
        Console.WriteLine($"  Total animals: {animals.Count}");
        
        var speciesCount = new Dictionary<string, int>();
        foreach (Animal animal in animals)
        {
            string species = animal.GetSpecies();
            if (speciesCount.ContainsKey(species))
                speciesCount[species]++;
            else
                speciesCount[species] = 1;
        }

        Console.WriteLine("  Species breakdown:");
        foreach (var species in speciesCount)
        {
            Console.WriteLine($"    {species.Key}: {species.Value}");
        }
    }
}
