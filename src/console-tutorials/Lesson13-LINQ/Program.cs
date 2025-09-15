using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("🔍 LINQ (Language Integrated Query) - OCR A-Level");
        Console.WriteLine("=================================================\n");

        // Example 1: Basic LINQ with Numbers
        Console.WriteLine("--- Example 1: Basic LINQ Operations ---");
        BasicLINQOperations();
        Console.WriteLine();

        // Example 2: LINQ with Objects (Students)
        Console.WriteLine("--- Example 2: LINQ with Objects ---");
        LINQWithObjects();
        Console.WriteLine();

        // Example 3: Query Syntax vs Method Syntax
        Console.WriteLine("--- Example 3: Query vs Method Syntax ---");
        QueryVsMethodSyntax();
        Console.WriteLine();

        // Example 4: Grouping and Aggregation
        Console.WriteLine("--- Example 4: Grouping and Aggregation ---");
        GroupingAndAggregation();
        Console.WriteLine();

        // Example 5: Joining Data
        Console.WriteLine("--- Example 5: Joining Collections ---");
        JoiningData();
        Console.WriteLine();

        // Example 6: Advanced LINQ Operations
        Console.WriteLine("--- Example 6: Advanced Operations ---");
        AdvancedLINQOperations();
        Console.WriteLine();

        // Example 7: LINQ with Files and Strings
        Console.WriteLine("--- Example 7: LINQ with Text Data ---");
        LINQWithTextData();
        Console.WriteLine();

        // Example 8: Performance Considerations
        Console.WriteLine("--- Example 8: Performance and Deferred Execution ---");
        PerformanceDemo();
        Console.WriteLine();

        // Interactive Section
        Console.WriteLine("--- Interactive LINQ Explorer ---");
        InteractiveLINQDemo();
    }

    static void BasicLINQOperations()
    {
        // Sample data
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20, 25, 30 };
        Console.WriteLine($"Numbers: [{string.Join(", ", numbers)}]");

        // Filtering
        var evenNumbers = numbers.Where(n => n % 2 == 0);
        Console.WriteLine($"Even numbers: [{string.Join(", ", evenNumbers)}]");

        var largeNumbers = numbers.Where(n => n > 10);
        Console.WriteLine($"Numbers > 10: [{string.Join(", ", largeNumbers)}]");

        // Transformation
        var squares = numbers.Select(n => n * n);
        Console.WriteLine($"Squares: [{string.Join(", ", squares)}]");

        var doubledEvens = numbers
            .Where(n => n % 2 == 0)
            .Select(n => n * 2);
        Console.WriteLine($"Doubled evens: [{string.Join(", ", doubledEvens)}]");

        // Aggregation
        int sum = numbers.Sum();
        double average = numbers.Average();
        int max = numbers.Max();
        int min = numbers.Min();
        int count = numbers.Count();

        Console.WriteLine($"\nAggregations:");
        Console.WriteLine($"  Sum: {sum}");
        Console.WriteLine($"  Average: {average:F2}");
        Console.WriteLine($"  Max: {max}");
        Console.WriteLine($"  Min: {min}");
        Console.WriteLine($"  Count: {count}");

        // Ordering
        var descending = numbers.OrderByDescending(n => n);
        Console.WriteLine($"Descending: [{string.Join(", ", descending)}]");

        // Take and Skip
        var firstFive = numbers.Take(5);
        var skipFive = numbers.Skip(5);
        Console.WriteLine($"First 5: [{string.Join(", ", firstFive)}]");
        Console.WriteLine($"Skip 5: [{string.Join(", ", skipFive)}]");

        // Any and All
        bool hasEven = numbers.Any(n => n % 2 == 0);
        bool allPositive = numbers.All(n => n > 0);
        Console.WriteLine($"Has even numbers: {hasEven}");
        Console.WriteLine($"All positive: {allPositive}");

        // First and Single
        int firstEven = numbers.First(n => n % 2 == 0);
        int? firstLarge = numbers.FirstOrDefault(n => n > 100);
        Console.WriteLine($"First even: {firstEven}");
        Console.WriteLine($"First > 100: {firstLarge?.ToString() ?? "None"}");
    }

    static void LINQWithObjects()
    {
        // Create sample students
        List<Student> students = CreateSampleStudents();

        Console.WriteLine($"Total students: {students.Count}");

        // Filter by criteria
        var year11Students = students.Where(s => s.Year == 11);
        Console.WriteLine($"\nYear 11 students: {year11Students.Count()}");
        foreach (var student in year11Students)
        {
            Console.WriteLine($"  {student.Name} - {student.Subject} ({student.Grade}%)");
        }

        // High achievers
        var highAchievers = students.Where(s => s.Grade >= 90);
        Console.WriteLine($"\nHigh achievers (≥90%): {highAchievers.Count()}");
        foreach (var student in highAchievers.OrderByDescending(s => s.Grade))
        {
            Console.WriteLine($"  {student.Name}: {student.Grade}% in {student.Subject}");
        }

        // Subject statistics
        var computerScienceStudents = students.Where(s => s.Subject == "Computer Science");
        if (computerScienceStudents.Any())
        {
            double avgCS = computerScienceStudents.Average(s => s.Grade);
            Console.WriteLine($"\nComputer Science average: {avgCS:F1}%");
        }

        // Age groups
        var ageGroups = students
            .GroupBy(s => s.Age)
            .OrderBy(g => g.Key);

        Console.WriteLine("\nStudents by age:");
        foreach (var group in ageGroups)
        {
            Console.WriteLine($"  Age {group.Key}: {group.Count()} students");
            foreach (var student in group)
            {
                Console.WriteLine($"    - {student.Name}");
            }
        }

        // Anonymous types for projections
        var studentSummary = students.Select(s => new
        {
            s.Name,
            s.Subject,
            GradeLevel = s.Grade >= 90 ? "Excellent" : s.Grade >= 80 ? "Good" : "Needs Improvement"
        });

        Console.WriteLine("\nStudent performance summary:");
        foreach (var summary in studentSummary)
        {
            Console.WriteLine($"  {summary.Name} ({summary.Subject}): {summary.GradeLevel}");
        }
    }

    static void QueryVsMethodSyntax()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Console.WriteLine("Comparing Query Syntax vs Method Syntax:");

        // Method Syntax
        var evenSquaresMethod = numbers
            .Where(n => n % 2 == 0)
            .Select(n => n * n)
            .OrderByDescending(n => n);

        // Query Syntax
        var evenSquaresQuery = from n in numbers
                               where n % 2 == 0
                               orderby n * n descending
                               select n * n;

        Console.WriteLine($"Method syntax result: [{string.Join(", ", evenSquaresMethod)}]");
        Console.WriteLine($"Query syntax result:  [{string.Join(", ", evenSquaresQuery)}]");

        // More complex query example
        List<Student> students = CreateSampleStudents();

        // Method Syntax - Complex query
        var topStudentsMethod = students
            .Where(s => s.Grade > 85)
            .OrderByDescending(s => s.Grade)
            .ThenBy(s => s.Name)
            .Take(3)
            .Select(s => new { s.Name, s.Grade, s.Subject });

        // Query Syntax - Same query
        var topStudentsQuery = (from s in students
                                where s.Grade > 85
                                orderby s.Grade descending, s.Name
                                select new { s.Name, s.Grade, s.Subject })
                               .Take(3);

        Console.WriteLine("\nTop 3 students (Grade > 85):");
        Console.WriteLine("Method syntax:");
        foreach (var student in topStudentsMethod)
        {
            Console.WriteLine($"  {student.Name}: {student.Grade}% ({student.Subject})");
        }

        Console.WriteLine("Query syntax:");
        foreach (var student in topStudentsQuery)
        {
            Console.WriteLine($"  {student.Name}: {student.Grade}% ({student.Subject})");
        }
    }

    static void GroupingAndAggregation()
    {
        List<Student> students = CreateSampleStudents();

        // Group by subject
        var subjectGroups = students.GroupBy(s => s.Subject);
        Console.WriteLine("Students grouped by subject:");
        foreach (var group in subjectGroups)
        {
            Console.WriteLine($"\n{group.Key}:");
            Console.WriteLine($"  Count: {group.Count()}");
            Console.WriteLine($"  Average grade: {group.Average(s => s.Grade):F1}%");
            Console.WriteLine($"  Highest grade: {group.Max(s => s.Grade)}%");
            Console.WriteLine($"  Students: {string.Join(", ", group.Select(s => s.Name))}");
        }

        // Group by year and calculate statistics
        var yearStats = students
            .GroupBy(s => s.Year)
            .Select(g => new
            {
                Year = g.Key,
                Count = g.Count(),
                AverageGrade = g.Average(s => s.Grade),
                TopStudent = g.OrderByDescending(s => s.Grade).First().Name,
                SubjectCount = g.Select(s => s.Subject).Distinct().Count()
            });

        Console.WriteLine("\nYear-wise statistics:");
        foreach (var stats in yearStats.OrderBy(s => s.Year))
        {
            Console.WriteLine($"Year {stats.Year}:");
            Console.WriteLine($"  Students: {stats.Count}");
            Console.WriteLine($"  Average grade: {stats.AverageGrade:F1}%");
            Console.WriteLine($"  Top student: {stats.TopStudent}");
            Console.WriteLine($"  Subjects taught: {stats.SubjectCount}");
        }

        // Grade distribution
        var gradeDistribution = students
            .GroupBy(s => s.Grade / 10 * 10) // Group by 10s (80-89, 90-99, etc.)
            .OrderBy(g => g.Key);

        Console.WriteLine("\nGrade distribution:");
        foreach (var group in gradeDistribution)
        {
            string range = $"{group.Key}-{group.Key + 9}%";
            Console.WriteLine($"  {range}: {group.Count()} students");
        }
    }

    static void JoiningData()
    {
        // Sample data - Students and their enrolled courses
        List<Student> students = CreateSampleStudents();

        List<Course> courses = new List<Course>
        {
            new Course { Id = 1, Name = "Advanced Programming", Subject = "Computer Science", Credits = 4 },
            new Course { Id = 2, Name = "Calculus II", Subject = "Mathematics", Credits = 3 },
            new Course { Id = 3, Name = "Quantum Physics", Subject = "Physics", Credits = 4 },
            new Course { Id = 4, Name = "Organic Chemistry", Subject = "Chemistry", Credits = 3 },
            new Course { Id = 5, Name = "Molecular Biology", Subject = "Biology", Credits = 3 }
        };

        List<Enrollment> enrollments = new List<Enrollment>
        {
            new Enrollment { StudentId = 1, CourseId = 1, Semester = "Fall 2024" },
            new Enrollment { StudentId = 1, CourseId = 2, Semester = "Fall 2024" },
            new Enrollment { StudentId = 2, CourseId = 2, Semester = "Fall 2024" },
            new Enrollment { StudentId = 2, CourseId = 3, Semester = "Spring 2024" },
            new Enrollment { StudentId = 3, CourseId = 3, Semester = "Fall 2024" },
            new Enrollment { StudentId = 4, CourseId = 4, Semester = "Fall 2024" },
            new Enrollment { StudentId = 5, CourseId = 5, Semester = "Spring 2024" },
            new Enrollment { StudentId = 6, CourseId = 1, Semester = "Fall 2024" }
        };

        // Inner Join - Students with their courses
        var studentCourses = from s in students
                             join e in enrollments on s.Id equals e.StudentId
                             join c in courses on e.CourseId equals c.Id
                             select new
                             {
                                 StudentName = s.Name,
                                 CourseName = c.Name,
                                 Credits = c.Credits,
                                 Semester = e.Semester,
                                 StudentGrade = s.Grade
                             };

        Console.WriteLine("Student-Course enrollments (Inner Join):");
        foreach (var sc in studentCourses.OrderBy(sc => sc.StudentName))
        {
            Console.WriteLine($"  {sc.StudentName} → {sc.CourseName} ({sc.Credits} credits, {sc.Semester})");
        }

        // Group Join - Students with all their courses
        var studentsWithCourses = from s in students
                                  join e in enrollments on s.Id equals e.StudentId into studentEnrollments
                                  select new
                                  {
                                      Student = s,
                                      CourseCount = studentEnrollments.Count(),
                                      Courses = from se in studentEnrollments
                                                join c in courses on se.CourseId equals c.Id
                                                select c
                                  };

        Console.WriteLine("\nStudents with their course loads:");
        foreach (var swc in studentsWithCourses)
        {
            Console.WriteLine($"{swc.Student.Name} (Grade: {swc.Student.Grade}%)");
            if (swc.CourseCount > 0)
            {
                foreach (var course in swc.Courses)
                {
                    Console.WriteLine($"  - {course.Name} ({course.Credits} credits)");
                }
                int totalCredits = swc.Courses.Sum(c => c.Credits);
                Console.WriteLine($"  Total credits: {totalCredits}");
            }
            else
            {
                Console.WriteLine($"  No course enrollments");
            }
        }
    }

    static void AdvancedLINQOperations()
    {
        List<Student> students = CreateSampleStudents();

        // Distinct
        var subjects = students.Select(s => s.Subject).Distinct().OrderBy(s => s);
        Console.WriteLine($"Unique subjects: {string.Join(", ", subjects)}");

        // Except, Intersect, Union
        var year11Subjects = students.Where(s => s.Year == 11).Select(s => s.Subject);
        var year12Subjects = students.Where(s => s.Year == 12).Select(s => s.Subject);

        var onlyYear11 = year11Subjects.Except(year12Subjects);
        var onlyYear12 = year12Subjects.Except(year11Subjects);
        var bothYears = year11Subjects.Intersect(year12Subjects);

        Console.WriteLine($"\nSubjects only in Year 11: {string.Join(", ", onlyYear11)}");
        Console.WriteLine($"Subjects only in Year 12: {string.Join(", ", onlyYear12)}");
        Console.WriteLine($"Subjects in both years: {string.Join(", ", bothYears)}");

        // Zip - combine two sequences
        string[] names = { "Alice", "Bob", "Carol" };
        int[] scores = { 95, 87, 92 };
        var nameScorePairs = names.Zip(scores, (name, score) => $"{name}: {score}");
        Console.WriteLine($"\nName-Score pairs: {string.Join(", ", nameScorePairs)}");

        // Aggregate
        int[] numbers = { 1, 2, 3, 4, 5 };
        int product = numbers.Aggregate((a, b) => a * b);
        Console.WriteLine($"Product of {string.Join(" × ", numbers)} = {product}");

        // SelectMany - flatten nested collections
        List<List<int>> numberLists = new List<List<int>>
        {
            new List<int> { 1, 2, 3 },
            new List<int> { 4, 5, 6 },
            new List<int> { 7, 8, 9 }
        };

        var flattenedNumbers = numberLists.SelectMany(list => list);
        Console.WriteLine($"Flattened numbers: [{string.Join(", ", flattenedNumbers)}]");
    }

    static void LINQWithTextData()
    {
        string sampleText = @"
        The quick brown fox jumps over the lazy dog.
        Programming in C# is fun and rewarding.
        LINQ makes data queries elegant and powerful.
        Students learn best through practical examples.
        Error handling is crucial for robust applications.
        ";

        // Split into words and analyze
        string[] words = sampleText
            .Split(new char[] { ' ', '\n', '\r', '.', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(w => w.Trim().ToLower())
            .Where(w => !string.IsNullOrEmpty(w))
            .ToArray();

        Console.WriteLine($"Total words: {words.Length}");

        // Word frequency
        var wordFrequency = words
            .GroupBy(w => w)
            .Select(g => new { Word = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .ThenBy(x => x.Word);

        Console.WriteLine("\nWord frequency (top 10):");
        foreach (var item in wordFrequency.Take(10))
        {
            Console.WriteLine($"  '{item.Word}': {item.Count} times");
        }

        // Words by length
        var wordsByLength = words
            .Distinct()
            .GroupBy(w => w.Length)
            .OrderBy(g => g.Key);

        Console.WriteLine("\nWords grouped by length:");
        foreach (var group in wordsByLength)
        {
            Console.WriteLine($"  Length {group.Key}: {string.Join(", ", group.OrderBy(w => w))}");
        }

        // Character analysis
        var characters = sampleText
            .Where(c => char.IsLetter(c))
            .Select(c => char.ToLower(c));

        var vowels = characters.Where(c => "aeiou".Contains(c)).Count();
        var consonants = characters.Count() - vowels;

        Console.WriteLine($"\nCharacter analysis:");
        Console.WriteLine($"  Total letters: {characters.Count()}");
        Console.WriteLine($"  Vowels: {vowels}");
        Console.WriteLine($"  Consonants: {consonants}");
        Console.WriteLine($"  Vowel percentage: {(double)vowels / characters.Count() * 100:F1}%");
    }

    static void PerformanceDemo()
    {
        Console.WriteLine("Demonstrating deferred execution and performance considerations:");

        // Deferred execution example
        Console.WriteLine("\n1. Deferred Execution:");
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        Console.WriteLine("Original list: [1, 2, 3, 4, 5]");

        var query = numbers.Where(n => n % 2 == 0);
        Console.WriteLine("Created query for even numbers (not executed yet)");

        numbers.Add(6);
        numbers.Add(8);
        Console.WriteLine("Added 6 and 8 to original list");

        Console.WriteLine($"Query result: [{string.Join(", ", query)}]"); // Now executed
        Console.WriteLine("Query picked up the new even numbers!");

        // Performance considerations
        Console.WriteLine("\n2. Performance Best Practices:");
        Console.WriteLine("  - Use Where() before Select() to filter early");
        Console.WriteLine("  - Use Take() to limit results");
        Console.WriteLine("  - Use ToList() only when you need immediate execution");
        Console.WriteLine("  - Chain operations efficiently");

        // Example of efficient chaining
        var efficientQuery = Enumerable.Range(1, 1000)
            .Where(n => n % 2 == 0)      // Filter first
            .Take(10)                    // Limit results early
            .Select(n => n * n);         // Transform only what's needed

        Console.WriteLine($"Efficient query (first 10 even squares): [{string.Join(", ", efficientQuery)}]");

        // Any vs Count for existence checks
        List<int> largeList = Enumerable.Range(1, 10000).ToList();
        bool anyResult = largeList.Any(n => n > 5000);
        Console.WriteLine($"Any number > 5000: {anyResult} (efficient existence check)");
    }

    static void InteractiveLINQDemo()
    {
        List<Student> students = CreateSampleStudents();

        Console.WriteLine("Available operations:");
        Console.WriteLine("1. Filter by grade threshold");
        Console.WriteLine("2. Group by subject");
        Console.WriteLine("3. Find student by name");
        Console.WriteLine("4. Subject statistics");
        Console.WriteLine("5. Skip interactive demo");

        Console.Write("\nChoose an option (1-5): ");
        string choice = Console.ReadLine() ?? "5";

        switch (choice)
        {
            case "1":
                FilterByGrade(students);
                break;
            case "2":
                GroupBySubject(students);
                break;
            case "3":
                FindStudentByName(students);
                break;
            case "4":
                SubjectStatistics(students);
                break;
            default:
                Console.WriteLine("Skipped interactive demo.");
                break;
        }
    }

    static void FilterByGrade(List<Student> students)
    {
        Console.Write("Enter minimum grade (0-100): ");
        if (int.TryParse(Console.ReadLine(), out int threshold) && threshold >= 0 && threshold <= 100)
        {
            var filtered = students
                .Where(s => s.Grade >= threshold)
                .OrderByDescending(s => s.Grade);

            Console.WriteLine($"\nStudents with grade >= {threshold}%:");
            foreach (var student in filtered)
            {
                Console.WriteLine($"  {student.Name}: {student.Grade}% in {student.Subject}");
            }
            Console.WriteLine($"Total: {filtered.Count()} students");
        }
        else
        {
            Console.WriteLine("Invalid grade entered.");
        }
    }

    static void GroupBySubject(List<Student> students)
    {
        var grouped = students
            .GroupBy(s => s.Subject)
            .OrderBy(g => g.Key);

        Console.WriteLine("\nStudents grouped by subject:");
        foreach (var group in grouped)
        {
            Console.WriteLine($"\n{group.Key}:");
            foreach (var student in group.OrderByDescending(s => s.Grade))
            {
                Console.WriteLine($"  {student.Name}: {student.Grade}%");
            }
            Console.WriteLine($"  Average: {group.Average(s => s.Grade):F1}%");
        }
    }

    static void FindStudentByName(List<Student> students)
    {
        Console.Write("Enter student name (or part of name): ");
        string searchTerm = Console.ReadLine() ?? "";

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var matches = students
                .Where(s => s.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .OrderBy(s => s.Name);

            if (matches.Any())
            {
                Console.WriteLine($"\nMatching students:");
                foreach (var student in matches)
                {
                    Console.WriteLine($"  {student.Name} (Age {student.Age}, Year {student.Year})");
                    Console.WriteLine($"    Subject: {student.Subject}, Grade: {student.Grade}%");
                }
            }
            else
            {
                Console.WriteLine("No students found matching that name.");
            }
        }
    }

    static void SubjectStatistics(List<Student> students)
    {
        var stats = students
            .GroupBy(s => s.Subject)
            .Select(g => new
            {
                Subject = g.Key,
                Count = g.Count(),
                Average = g.Average(s => s.Grade),
                Highest = g.Max(s => s.Grade),
                Lowest = g.Min(s => s.Grade),
                TopStudent = g.OrderByDescending(s => s.Grade).First().Name
            })
            .OrderByDescending(s => s.Average);

        Console.WriteLine("\nSubject Statistics:");
        foreach (var stat in stats)
        {
            Console.WriteLine($"\n{stat.Subject}:");
            Console.WriteLine($"  Students: {stat.Count}");
            Console.WriteLine($"  Average: {stat.Average:F1}%");
            Console.WriteLine($"  Range: {stat.Lowest}% - {stat.Highest}%");
            Console.WriteLine($"  Top student: {stat.TopStudent}");
        }
    }

    static List<Student> CreateSampleStudents()
    {
        return new List<Student>
        {
            new Student { Id = 1, Name = "Alice Johnson", Age = 16, Grade = 95, Subject = "Computer Science", Year = 11 },
            new Student { Id = 2, Name = "Bob Smith", Age = 17, Grade = 87, Subject = "Mathematics", Year = 12 },
            new Student { Id = 3, Name = "Carol Davis", Age = 16, Grade = 92, Subject = "Physics", Year = 11 },
            new Student { Id = 4, Name = "David Wilson", Age = 18, Grade = 78, Subject = "Chemistry", Year = 12 },
            new Student { Id = 5, Name = "Emma Brown", Age = 17, Grade = 89, Subject = "Biology", Year = 12 },
            new Student { Id = 6, Name = "Frank Miller", Age = 16, Grade = 94, Subject = "Computer Science", Year = 11 },
            new Student { Id = 7, Name = "Grace Lee", Age = 17, Grade = 85, Subject = "Mathematics", Year = 12 },
            new Student { Id = 8, Name = "Henry Taylor", Age = 16, Grade = 91, Subject = "Physics", Year = 11 }
        };
    }
}

// Supporting classes
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public int Grade { get; set; }
    public string Subject { get; set; } = string.Empty;
    public int Year { get; set; }
}

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public int Credits { get; set; }
}

public class Enrollment
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public string Semester { get; set; } = string.Empty;
}
