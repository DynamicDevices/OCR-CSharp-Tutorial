# Student Management System - Comprehensive C# Project

This project demonstrates all the core concepts from the OCR A-Level C# Tutorial in a real-world application. It's a complete student management system that combines object-oriented programming, file handling, LINQ, collections, and error handling.

## 🎯 Learning Objectives

This project reinforces concepts from all lessons:
- **Lesson 1-3**: Program structure, variables, and control structures
- **Lesson 4-5**: Arrays and collections for managing data
- **Lesson 6-7**: Object-oriented programming with classes and inheritance
- **Lesson 8**: Exception handling for robust error management
- **Lesson 9-10**: Search algorithms and sorting for data organization
- **Lesson 11**: Recursion for complex data operations
- **Lesson 12**: File handling for data persistence
- **Lesson 13**: LINQ for powerful data querying and analysis

## 🏗️ System Architecture

### Core Classes
- **`Student`**: Represents a student with personal information
- **`Course`**: Represents a course with details and requirements
- **`Enrollment`**: Links students to courses with grades
- **`StudentManager`**: Main business logic and data management

### Key Features
- ✅ Student registration and management
- ✅ Course creation and enrollment
- ✅ Grade tracking and GPA calculation
- ✅ Data persistence with JSON files
- ✅ Comprehensive reporting system
- ✅ Search and filtering capabilities
- ✅ Input validation and error handling

## 🚀 How to Run

1. Navigate to the project directory:
   ```bash
   cd examples/Projects/StudentManagementSystem
   ```

2. Run the application:
   ```bash
   dotnet run
   ```

3. Follow the interactive menu system

## 📋 System Features

### 1. Student Management
- Add new students with validation
- View all students in organized tables
- Edit student information
- Delete students (with cascade deletion of enrollments)

### 2. Course Management
- Create courses with codes, names, and credit hours
- View all available courses
- Edit course details
- Delete courses (with enrollment checks)

### 3. Grade Management
- Enroll students in courses
- Enter and update grades (0-100 scale)
- View individual student transcripts
- Calculate GPAs and letter grades

### 4. Reports & Analytics
- Student performance reports
- Course statistics and pass rates
- Grade distribution analysis
- Honor roll and at-risk student identification
- Enrollment summaries

### 5. Search & Filter
- Find students by name or criteria
- Filter courses by various attributes
- Advanced LINQ-based queries
- Statistical analysis of data

### 6. Data Management
- Automatic save/load with JSON files
- Import/export functionality
- Data validation and integrity checks
- Backup and restore capabilities

## 🔧 Technical Implementation

### Object-Oriented Design
```csharp
public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public int Year { get; set; }
    
    public string FullName => $"{FirstName} {LastName}";
    
    // Constructor with validation
    public Student(string firstName, string lastName, string email, int age, int year)
    {
        // Validation logic here
    }
}
```

### LINQ Usage Examples
```csharp
// Find high-performing students
var honorRoll = students
    .Where(s => CalculateGPA(s.Id) >= 3.5)
    .OrderByDescending(s => CalculateGPA(s.Id))
    .Take(10);

// Course enrollment statistics
var courseStats = courses
    .Select(c => new {
        Course = c,
        EnrollmentCount = GetCourseEnrollments(c.Id).Count(),
        AverageGrade = GetCourseEnrollments(c.Id)
            .Where(e => e.Grade.HasValue)
            .Average(e => e.Grade.Value)
    })
    .OrderByDescending(stat => stat.AverageGrade);
```

### File Handling
```csharp
// Save data to JSON
public void SaveData()
{
    try
    {
        var data = new {
            Students = students,
            Courses = courses,
            Enrollments = enrollments
        };
        
        string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(DATA_FILE, json);
    }
    catch (Exception ex)
    {
        throw new InvalidOperationException($"Failed to save data: {ex.Message}");
    }
}
```

### Error Handling
```csharp
public void EnrollStudent(int studentId, int courseId)
{
    var student = GetStudent(studentId) ?? 
        throw new ArgumentException("Student not found");
    
    var course = GetCourse(courseId) ?? 
        throw new ArgumentException("Course not found");
    
    if (enrollments.Any(e => e.StudentId == studentId && e.CourseId == courseId))
        throw new InvalidOperationException("Student already enrolled in this course");
        
    enrollments.Add(new Enrollment(studentId, courseId));
}
```

## 📊 Sample Data

The system comes with sample data including:
- 10+ students across Years 11 and 12
- 8+ courses covering typical A-Level subjects
- Various enrollment scenarios and grade distributions
- Realistic data for testing all features

## 🎓 Educational Value

### Programming Concepts Demonstrated
1. **Class Design**: Proper encapsulation and data validation
2. **Collections**: Lists, dictionaries, and LINQ operations
3. **File I/O**: JSON serialization and error handling
4. **User Interface**: Menu-driven console application
5. **Data Validation**: Input sanitization and business rules
6. **Error Handling**: Try-catch blocks and custom exceptions
7. **Algorithm Implementation**: Sorting, searching, and statistics
8. **Code Organization**: Separation of concerns and modularity

### Real-World Skills
- Database-like operations without a database
- Data persistence and recovery
- User experience design in console applications
- Business logic implementation
- Reporting and analytics
- System architecture and design patterns

## 🔍 Code Quality Features

### Input Validation
```csharp
private static bool IsValidEmail(string email)
{
    return !string.IsNullOrWhiteSpace(email) && 
           email.Contains("@") && 
           email.Contains(".");
}
```

### Defensive Programming
```csharp
public Student? GetStudent(int id)
{
    return students.FirstOrDefault(s => s.Id == id);
}
```

### Constants and Configuration
```csharp
private const string DATA_FILE = "student_data.json";
private const int MIN_GRADE = 0;
private const int MAX_GRADE = 100;
```

## 🏆 Extensions and Challenges

### Beginner Extensions
1. Add more student fields (address, phone, etc.)
2. Implement different grading scales
3. Add course prerequisites
4. Create semester/term management

### Intermediate Extensions
1. Add teacher/instructor management
2. Implement class scheduling
3. Add attendance tracking
4. Create grade history and trends

### Advanced Extensions
1. Build a web interface with ASP.NET Core
2. Add database support with Entity Framework
3. Implement user authentication and roles
4. Add email notifications and reporting
5. Create mobile app integration

## 📝 Assessment Criteria

This project demonstrates mastery of:
- ✅ **Programming Constructs**: Variables, loops, conditions, methods
- ✅ **Data Structures**: Arrays, lists, custom objects
- ✅ **Object-Oriented Programming**: Classes, encapsulation, abstraction
- ✅ **Error Handling**: Exceptions, validation, defensive programming
- ✅ **File Handling**: Read/write operations, serialization
- ✅ **Algorithms**: Sorting, searching, data analysis
- ✅ **Problem Solving**: Breaking down complex requirements
- ✅ **Code Quality**: Readable, maintainable, documented code

## 🚀 Next Steps

After completing this project, consider:
1. **Web Development**: Learn ASP.NET Core for web applications
2. **Database Programming**: Master Entity Framework and SQL
3. **Mobile Development**: Explore Xamarin or .NET MAUI
4. **Cloud Computing**: Deploy to Azure or AWS
5. **Advanced C#**: Learn async/await, delegates, events

---

**This project represents the culmination of your C# learning journey - from basic syntax to complex application development. Well done! 🎓✨**