# Console-Based C# Tutorials

Traditional console applications for learning C# programming fundamentals.

## 🎯 Purpose

These console tutorials provide a traditional development environment experience where students:
- Learn to use the command line and IDE
- Practice debugging with breakpoints and step-through
- Experience the full development workflow
- Build confidence with "real" programming tools

## 📚 Lessons

### [Lesson 1: Program Structure and Basic Syntax](Lesson01-HelloWorld/)
**OCR Topics**: Programming fundamentals, program structure, input/output operations

- Understanding C# program structure
- Basic syntax and code organization
- Console input/output operations
- Comments and documentation

**Run**: `cd Lesson01-HelloWorld && dotnet run`

### [Lesson 2: Variables and Data Types](Lesson02-Variables/)
**OCR Topics**: Data representation, variable types, type conversion

- Primitive data types (int, double, bool, char, string)
- Variable declaration and initialization
- Constants and literals
- Type conversion and casting
- String interpolation and formatting

**Run**: `cd Lesson02-Variables && dotnet run`

### [Lesson 3: Selection and Iteration](Lesson03-ControlStructures/)
**OCR Topics**: Programming constructs, computational thinking

- Selection constructs (if/else, switch/case)
- Iteration constructs (for, while, do-while)
- Boolean logic and comparison operators
- Nested structures and complex conditions

**Run**: `cd Lesson03-ControlStructures && dotnet run`

## 🚀 Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) installed
- Command line access (Terminal, Command Prompt, or PowerShell)
- Text editor or IDE (Visual Studio Code recommended)

### Quick Start
```bash
# Clone the repository
git clone https://github.com/yourusername/OCR-CSharp-Tutorial.git
cd OCR-CSharp-Tutorial/src/console-tutorials

# Run Lesson 1
cd Lesson01-HelloWorld
dotnet run

# Run Lesson 2
cd ../Lesson02-Variables
dotnet run

# Run Lesson 3
cd ../Lesson03-ControlStructures
dotnet run
```

## 🛠️ Development Workflow

### Running a Lesson
1. Navigate to the lesson folder
2. Run `dotnet run` to execute the program
3. Follow the interactive prompts
4. Examine the source code in `Program.cs`

### Modifying Examples
1. Open `Program.cs` in your preferred editor
2. Make changes to experiment with concepts
3. Save the file
4. Run `dotnet run` to see your changes

### Debugging
- Use `Console.WriteLine()` to output debug information
- Add breakpoints in your IDE for step-through debugging
- Use `Console.ReadKey()` to pause execution

## 🎓 Learning Approach

### For Students
1. **Read First**: Review the README.md in each lesson
2. **Run Original**: Execute the program as provided
3. **Experiment**: Modify the code to test your understanding
4. **Practice**: Complete the exercises in each lesson
5. **Apply**: Move on to the next lesson when comfortable

### For Teachers
- **Demonstrations**: Run programs during class to show concepts
- **Assignments**: Students can complete exercises independently
- **Assessment**: Use the examples as starting points for tasks
- **Differentiation**: Advanced students can extend the programs

## 🔧 Troubleshooting

### Common Issues

**"dotnet command not found"**
- Install the .NET 8.0 SDK from Microsoft
- Restart your terminal after installation
- Verify with `dotnet --version`

**Build Errors**
- Check that you're in the correct lesson folder
- Ensure the `.csproj` file exists
- Run `dotnet restore` to restore packages

**Runtime Errors**
- Read error messages carefully
- Check for typos in variable names (C# is case-sensitive)
- Ensure all statements end with semicolons

## 📈 Progression Path

1. **Start Here**: Complete all three lessons in order
2. **Practice**: Work through the exercises in each lesson
3. **Apply**: Move to the [examples folder](../../examples/) for projects
4. **Enhance**: Try the [interactive web version](../web-tutorial/) for additional features

## 💡 Study Tips

- **Type, Don't Copy**: Manually type code examples to build muscle memory
- **Experiment Freely**: Change values and see what happens
- **Read Error Messages**: They often tell you exactly what's wrong
- **Use Meaningful Names**: Practice good variable naming from the start
- **Comment Your Code**: Explain what your code does in plain English

## 🔗 Related Resources

- **[Interactive Web Version](../web-tutorial/)**: Browser-based learning with immediate feedback
- **[Practice Examples](../../examples/)**: Complete projects and assessment tasks
- **[Documentation](../../docs/)**: Detailed project information and guides

---

**Ready to start?** Begin with [Lesson 1: Program Structure](Lesson01-HelloWorld/) and work your way through each lesson systematically.
