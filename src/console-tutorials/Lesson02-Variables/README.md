# Lesson 2: Variables and Data Types

Now that you can write a basic program, let's learn how to store and work with different types of information using variables!

## 🎯 What You'll Learn

- What variables are and why they're useful
- Different data types in C#
- How to declare and use variables
- Basic operations with variables
- Getting input from the user

## 🧠 What Are Variables?

Think of variables as labeled boxes where you can store different types of information. Just like you might have a box labeled "toys" or "books", variables have names and hold specific types of data.

## 📊 Common Data Types

### Numbers
- **`int`** - Whole numbers (like 5, -10, 1000)
- **`double`** - Decimal numbers (like 3.14, -2.5, 100.0)

### Text
- **`string`** - Text and words (like "Hello", "C# is fun!")
- **`char`** - Single characters (like 'A', '5', '!')

### True/False
- **`bool`** - True or false values (like true, false)

## 💻 Using Variables

### Declaring Variables
```csharp
int age = 12;                    // Whole number
double height = 5.5;             // Decimal number
string name = "Alex";            // Text
char grade = 'A';                // Single character
bool isStudent = true;           // True or false
```

### Displaying Variables
```csharp
Console.WriteLine("Name: " + name);
Console.WriteLine("Age: " + age);
Console.WriteLine($"Hello, {name}! You are {age} years old.");  // String interpolation
```

## 🔧 Try the Examples

Run the program in this folder to see variables in action! Look at `Program.cs` to understand how each example works.

## 🎮 Exercises

### Exercise 1: About You
Create variables to store information about yourself:
- Your name
- Your age
- Your favorite number
- Whether you like pizza (true/false)

Then display all this information in a nice format.

### Exercise 2: Simple Math
Create two number variables and show:
- Their sum (addition)
- Their difference (subtraction)
- Their product (multiplication)

### Exercise 3: Mad Libs
Create a simple mad libs game using string variables:
- Ask for an adjective, noun, and verb
- Create a funny sentence using these words

## 🎯 Getting User Input

You can ask the user to type information:

```csharp
Console.Write("What's your name? ");
string userName = Console.ReadLine();
Console.WriteLine($"Nice to meet you, {userName}!");
```

## 🤔 Common Mistakes

1. **Forgetting to declare the type**: `myNumber = 5;` ❌ → `int myNumber = 5;` ✅
2. **Wrong quotes for strings**: `string name = 'Alex';` ❌ → `string name = "Alex";` ✅
3. **Case sensitivity**: `String` vs `string` (use lowercase)

## 🧮 Math Operations

- **Addition**: `+`
- **Subtraction**: `-`
- **Multiplication**: `*`
- **Division**: `/`
- **Remainder**: `%`

```csharp
int a = 10;
int b = 3;
Console.WriteLine(a + b);  // 13
Console.WriteLine(a - b);  // 7
Console.WriteLine(a * b);  // 30
Console.WriteLine(a / b);  // 3 (integer division)
Console.WriteLine(a % b);  // 1 (remainder)
```

## 🏆 Challenge Project: Personal Calculator

Create a program that:
1. Asks for your name
2. Asks for two numbers
3. Shows the result of adding, subtracting, multiplying, and dividing those numbers
4. Displays everything in a nice, personalized format

## 💡 Key Takeaways

- Variables store different types of data
- Always declare the type when creating a variable
- Use meaningful names for your variables
- String interpolation (`$"Hello {name}"`) is a clean way to combine text and variables
- You can get input from users with `Console.ReadLine()`

---

**Ready for more?** In the next lesson, we'll learn how to make decisions in our programs using if/else statements!

