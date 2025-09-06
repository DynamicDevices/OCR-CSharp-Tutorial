# Lesson 3: Control Structures

Now let's learn how to make your programs smart! Control structures let your program make decisions and repeat actions.

## 🎯 What You'll Learn

- Making decisions with if/else statements
- Comparing values with comparison operators
- Repeating actions with loops
- Using switch statements for multiple choices
- Building interactive programs

## 🤔 Making Decisions with If/Else

Sometimes your program needs to do different things based on conditions. That's where if/else comes in!

### Basic If Statement
```csharp
int age = 16;
if (age >= 18)
{
    Console.WriteLine("You can vote!");
}
```

### If/Else Statement
```csharp
int age = 16;
if (age >= 18)
{
    Console.WriteLine("You can vote!");
}
else
{
    Console.WriteLine("You're too young to vote.");
}
```

### Multiple Conditions (If/Else If/Else)
```csharp
int score = 85;
if (score >= 90)
{
    Console.WriteLine("Grade: A");
}
else if (score >= 80)
{
    Console.WriteLine("Grade: B");
}
else if (score >= 70)
{
    Console.WriteLine("Grade: C");
}
else
{
    Console.WriteLine("Grade: F");
}
```

## 🔍 Comparison Operators

- **`==`** - Equal to
- **`!=`** - Not equal to
- **`>`** - Greater than
- **`<`** - Less than
- **`>=`** - Greater than or equal to
- **`<=`** - Less than or equal to

## 🔗 Logical Operators

- **`&&`** - AND (both conditions must be true)
- **`||`** - OR (at least one condition must be true)
- **`!`** - NOT (opposite of the condition)

```csharp
int age = 20;
bool hasLicense = true;

if (age >= 18 && hasLicense)
{
    Console.WriteLine("You can drive!");
}
```

## 🔄 Loops - Repeating Actions

### For Loop (when you know how many times to repeat)
```csharp
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"Count: {i}");
}
```

### While Loop (repeat while a condition is true)
```csharp
int countdown = 5;
while (countdown > 0)
{
    Console.WriteLine($"Countdown: {countdown}");
    countdown--;
}
Console.WriteLine("Blast off!");
```

### Do-While Loop (run at least once, then check condition)
```csharp
string answer;
do
{
    Console.Write("Do you want to continue? (yes/no): ");
    answer = Console.ReadLine();
} while (answer != "no");
```

## 🎛️ Switch Statements

When you have many possible values to check:

```csharp
Console.Write("Enter a day number (1-7): ");
int day = int.Parse(Console.ReadLine());

switch (day)
{
    case 1:
        Console.WriteLine("Monday");
        break;
    case 2:
        Console.WriteLine("Tuesday");
        break;
    case 3:
        Console.WriteLine("Wednesday");
        break;
    // ... more cases
    default:
        Console.WriteLine("Invalid day number");
        break;
}
```

## 🎮 Exercises

### Exercise 1: Age Classifier
Write a program that asks for someone's age and tells them:
- "Child" if under 13
- "Teenager" if 13-19
- "Adult" if 20 or older

### Exercise 2: Number Guessing Game
Create a simple guessing game:
1. Pick a secret number (1-10)
2. Ask the user to guess
3. Tell them if they're right or wrong
4. Let them guess again if wrong

### Exercise 3: Multiplication Table
Use a loop to display the multiplication table for any number the user enters.

### Exercise 4: Password Checker
Create a simple password checker that keeps asking for a password until the correct one is entered.

## 🏆 Challenge Project: Simple Calculator

Create a calculator that:
1. Shows a menu of operations (+, -, *, /)
2. Gets two numbers from the user
3. Performs the chosen operation
4. Shows the result
5. Asks if they want to calculate again

## 🎯 Interactive Examples

Run the program in this folder to see all these concepts in action! The program includes:
- Age verification
- Grade calculator
- Simple guessing game
- Countdown timer
- Menu system

## 💡 Tips for Success

1. **Use meaningful variable names**: `userAge` instead of `x`
2. **Indent your code properly**: It makes it easier to read
3. **Test different scenarios**: What happens with different inputs?
4. **Don't forget the `break;` in switch statements**
5. **Be careful with infinite loops**: Make sure your while loops can end!

## 🤔 Common Mistakes

1. **Using `=` instead of `==`**: 
   - `if (age = 18)` ❌ (assignment)
   - `if (age == 18)` ✅ (comparison)

2. **Forgetting braces with multiple statements**:
   ```csharp
   if (condition)
       Console.WriteLine("First line");
       Console.WriteLine("Second line"); // This always runs!
   ```

3. **Infinite loops**:
   ```csharp
   while (true)  // This never ends!
   {
       Console.WriteLine("Forever...");
   }
   ```

## 💡 Key Takeaways

- If/else statements let your program make decisions
- Loops let you repeat code efficiently
- Comparison operators (`==`, `>`, `<`, etc.) compare values
- Logical operators (`&&`, `||`, `!`) combine conditions
- Switch statements are great for multiple specific values
- Always test your programs with different inputs

---

**Ready for the next level?** In Lesson 4, we'll learn about methods - how to organize your code into reusable pieces!

