# Lesson 1: Hello World and Basic Syntax

Welcome to your first C# lesson! In this lesson, you'll write your very first C# program and learn about the basic structure of C# code.

## 🎯 What You'll Learn

- How to create a C# program
- Understanding the basic structure of C# code
- How to display text on the screen
- How to run your program

## 📝 Your First Program

Let's start with the classic "Hello World" program. This is traditionally the first program every programmer writes!

### Step 1: Understanding the Code

Look at the `Program.cs` file in this folder. Here's what each part does:

```csharp
using System;  // This imports the System library

class Program   // This creates a class called Program
{
    static void Main(string[] args)  // This is the main method - where your program starts
    {
        Console.WriteLine("Hello, World!");  // This prints text to the screen
    }
}
```

### Step 2: Breaking Down the Structure

1. **`using System;`** - This tells C# we want to use built-in features like `Console.WriteLine`
2. **`class Program`** - Every C# program needs at least one class. Think of it as a container for your code
3. **`static void Main(string[] args)`** - This is the entry point. When you run your program, it starts here
4. **`Console.WriteLine("Hello, World!");`** - This displays text on the screen

### Step 3: Running Your Program

1. Open a terminal in this folder
2. Type: `dotnet run`
3. You should see "Hello, World!" appear on the screen!

## 🔧 Try It Yourself

### Exercise 1: Change the Message
Modify the program to display your name instead of "Hello, World!"

### Exercise 2: Multiple Messages
Add more `Console.WriteLine` statements to display multiple lines of text.

### Exercise 3: ASCII Art
Try creating some simple ASCII art with text!

## 🎨 Fun Challenges

1. **Personal Greeting**: Make the program display "Hello, [Your Name]! Welcome to C#!"
2. **Story Time**: Write a short 3-line story using multiple `Console.WriteLine` statements
3. **Pattern**: Create a simple pattern using characters like `*`, `-`, or `+`

## 🤔 Understanding Errors

If your program doesn't work, don't worry! Here are common mistakes:

- **Missing semicolon (`;`)** - Every statement in C# must end with a semicolon
- **Missing quotes (`"`)** - Text must be surrounded by double quotes
- **Spelling mistakes** - C# is case-sensitive, so `console` is different from `Console`

## 🏆 What's Next?

Great job on writing your first C# program! In the next lesson, we'll learn about variables - how to store and work with different types of data.

## 💡 Key Takeaways

- Every C# program needs a `Main` method
- Use `Console.WriteLine()` to display text
- Don't forget semicolons at the end of statements
- C# is case-sensitive
- Practice makes perfect!

---

**Ready for the next lesson?** Head to `Lesson02-Variables` when you're comfortable with this material!

