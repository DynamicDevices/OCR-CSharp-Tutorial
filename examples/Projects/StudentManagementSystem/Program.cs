using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class Program
{
    private static StudentManager studentManager = new StudentManager();

    static void Main(string[] args)
    {
        Console.WriteLine("🎓 Student Management System - OCR A-Level Project");
        Console.WriteLine("==================================================");
        Console.WriteLine("This project combines concepts from all lessons:");
        Console.WriteLine("• Object-Oriented Programming • File Handling");
        Console.WriteLine("• Collections & LINQ • Exception Handling");
        Console.WriteLine();

        // Load existing data
        studentManager.LoadData();

        // Main menu loop
        bool running = true;
        while (running)
        {
            try
            {
                DisplayMainMenu();
                string choice = Console.ReadLine() ?? "";
                running = ProcessMenuChoice(choice);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        // Save data before exit
        studentManager.SaveData();
        Console.WriteLine("\n👋 Thank you for using the Student Management System!");
    }

    static void DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine("🎓 STUDENT MANAGEMENT SYSTEM");
        Console.WriteLine("============================");
        Console.WriteLine($"📊 Total Students: {studentManager.GetStudentCount()}");
        Console.WriteLine($"📚 Total Courses: {studentManager.GetCourseCount()}");
        Console.WriteLine();
        Console.WriteLine("1. 👥 Add Student");
        Console.WriteLine("2. 📚 Add Course");
        Console.WriteLine("3. 📝 Enroll Student in Course");
        Console.WriteLine("4. 📊 Enter Grade");
        Console.WriteLine("5. 👁️  View All Students");
        Console.WriteLine("6. 🔍 View Student Report");
        Console.WriteLine("7. 📈 System Statistics");
        Console.WriteLine("8. 🚪 Exit");
        Console.WriteLine();
        Console.Write("Select option (1-8): ");
    }

    static bool ProcessMenuChoice(string choice)
    {
        switch (choice)
        {
            case "1":
                AddStudent();
                break;
            case "2":
                AddCourse();
                break;
            case "3":
                EnrollStudent();
                break;
            case "4":
                EnterGrade();
                break;
            case "5":
                ViewAllStudents();
                break;
            case "6":
                ViewStudentReport();
                break;
            case "7":
                ShowStatistics();
                break;
            case "8":
                return false;
            default:
                Console.WriteLine("❌ Invalid choice. Press any key to try again...");
                Console.ReadKey();
                break;
        }

        if (choice != "8")
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        return true;
    }

    static void AddStudent()
    {
        Console.Clear();
        Console.WriteLine("➕ ADD NEW STUDENT");
        Console.WriteLine("==================");

        try
        {
            Console.Write("First Name: ");
            string firstName = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be empty.");

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be empty.");

            Console.Write("Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age) || age < 16 || age > 19)
                throw new ArgumentException("Please enter a valid age (16-19).");

            Console.Write("Year (11 or 12): ");
            if (!int.TryParse(Console.ReadLine(), out int year) || (year != 11 && year != 12))
                throw new ArgumentException("Year must be 11 or 12.");

            Student student = new Student(firstName, lastName, age, year);
            studentManager.AddStudent(student);

            Console.WriteLine($"✅ Student {student.FullName} added successfully! (ID: {student.Id})");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error adding student: {ex.Message}");
        }
    }

    static void AddCourse()
    {
        Console.Clear();
        Console.WriteLine("➕ ADD NEW COURSE");
        Console.WriteLine("=================");

        try
        {
            Console.Write("Course Code (e.g., CS101): ");
            string code = Console.ReadLine()?.ToUpper() ?? "";
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Course code cannot be empty.");

            Console.Write("Course Name: ");
            string name = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Course name cannot be empty.");

            Course course = new Course(code, name);
            studentManager.AddCourse(course);

            Console.WriteLine($"✅ Course {course.Code} - {course.Name} added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error adding course: {ex.Message}");
        }
    }

    static void EnrollStudent()
    {
        Console.Clear();
        Console.WriteLine("📝 ENROLL STUDENT IN COURSE");
        Console.WriteLine("===========================");

        Console.Write("Enter Student ID: ");
        if (!int.TryParse(Console.ReadLine(), out int studentId))
        {
            Console.WriteLine("❌ Invalid Student ID.");
            return;
        }

        var student = studentManager.GetStudent(studentId);
        if (student == null)
        {
            Console.WriteLine("❌ Student not found.");
            return;
        }

        Console.Write("Enter Course Code: ");
        string courseCode = Console.ReadLine()?.ToUpper() ?? "";

        var course = studentManager.GetCourseByCode(courseCode);
        if (course == null)
        {
            Console.WriteLine("❌ Course not found.");
            return;
        }

        try
        {
            studentManager.EnrollStudent(studentId, course.Id);
            Console.WriteLine($"✅ {student.FullName} enrolled in {course.Code} - {course.Name}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }

    static void EnterGrade()
    {
        Console.Clear();
        Console.WriteLine("📊 ENTER GRADE");
        Console.WriteLine("==============");

        Console.Write("Enter Student ID: ");
        if (!int.TryParse(Console.ReadLine(), out int studentId))
        {
            Console.WriteLine("❌ Invalid Student ID.");
            return;
        }

        var student = studentManager.GetStudent(studentId);
        if (student == null)
        {
            Console.WriteLine("❌ Student not found.");
            return;
        }

        Console.Write("Enter Course Code: ");
        string courseCode = Console.ReadLine()?.ToUpper() ?? "";

        var course = studentManager.GetCourseByCode(courseCode);
        if (course == null)
        {
            Console.WriteLine("❌ Course not found.");
            return;
        }

        Console.Write("Enter Grade (0-100): ");
        if (!int.TryParse(Console.ReadLine(), out int grade) || grade < 0 || grade > 100)
        {
            Console.WriteLine("❌ Invalid grade. Must be between 0 and 100.");
            return;
        }

        try
        {
            studentManager.SetGrade(studentId, course.Id, grade);
            Console.WriteLine($"✅ Grade {grade}% set for {student.FullName} in {course.Code}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }

    static void ViewAllStudents()
    {
        Console.Clear();
        Console.WriteLine("👁️  ALL STUDENTS");
        Console.WriteLine("================");

        var students = studentManager.GetAllStudents();
        if (!students.Any())
        {
            Console.WriteLine("📭 No students found.");
            return;
        }

        Console.WriteLine($"{"ID",-5} {"Name",-20} {"Age",-5} {"Year",-6} {"Courses",-8} {"Avg Grade",-10}");
        Console.WriteLine(new string('-', 60));

        foreach (var student in students.OrderBy(s => s.LastName))
        {
            var enrollments = studentManager.GetStudentEnrollments(student.Id);
            var gradedEnrollments = enrollments.Where(e => e.Grade.HasValue).ToList();

            double avgGrade = gradedEnrollments.Any()
                ? gradedEnrollments.Average(e => e.Grade!.Value)
                : 0;

            string avgDisplay = gradedEnrollments.Any() ? $"{avgGrade:F1}%" : "N/A";

            Console.WriteLine($"{student.Id,-5} {student.FullName,-20} {student.Age,-5} {student.Year,-6} {enrollments.Count(),-8} {avgDisplay,-10}");
        }
    }

    static void ViewStudentReport()
    {
        Console.Clear();
        Console.WriteLine("🔍 STUDENT REPORT");
        Console.WriteLine("=================");

        Console.Write("Enter Student ID: ");
        if (!int.TryParse(Console.ReadLine(), out int studentId))
        {
            Console.WriteLine("❌ Invalid Student ID.");
            return;
        }

        var student = studentManager.GetStudent(studentId);
        if (student == null)
        {
            Console.WriteLine("❌ Student not found.");
            return;
        }

        Console.WriteLine($"\n📋 Report for {student.FullName}");
        Console.WriteLine($"Age: {student.Age}, Year: {student.Year}");
        Console.WriteLine();

        var enrollments = studentManager.GetStudentEnrollments(studentId);
        if (!enrollments.Any())
        {
            Console.WriteLine("📭 No course enrollments found.");
            return;
        }

        Console.WriteLine($"{"Course",-8} {"Name",-20} {"Grade",-8} {"Letter",-8}");
        Console.WriteLine(new string('-', 50));

        var gradedEnrollments = enrollments.Where(e => e.Grade.HasValue).ToList();

        foreach (var enrollment in enrollments)
        {
            var course = studentManager.GetCourse(enrollment.CourseId);
            if (course != null)
            {
                string gradeDisplay = enrollment.Grade?.ToString() ?? "Not Set";
                string letterGrade = enrollment.Grade.HasValue ? GetLetterGrade(enrollment.Grade.Value) : "N/A";

                Console.WriteLine($"{course.Code,-8} {course.Name,-20} {gradeDisplay,-8} {letterGrade,-8}");
            }
        }

        if (gradedEnrollments.Any())
        {
            double avgGrade = gradedEnrollments.Average(e => e.Grade!.Value);
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"📊 Overall Average: {avgGrade:F1}% ({GetLetterGrade((int)avgGrade)})");
            Console.WriteLine($"📚 Completed Courses: {gradedEnrollments.Count} / {enrollments.Count()}");
        }
    }

    static void ShowStatistics()
    {
        Console.Clear();
        Console.WriteLine("📈 SYSTEM STATISTICS");
        Console.WriteLine("===================");

        var students = studentManager.GetAllStudents();
        var courses = studentManager.GetAllCourses();

        Console.WriteLine($"👥 Total Students: {students.Count()}");
        Console.WriteLine($"📚 Total Courses: {courses.Count()}");

        if (students.Any())
        {
            var year11Count = students.Count(s => s.Year == 11);
            var year12Count = students.Count(s => s.Year == 12);

            Console.WriteLine($"   Year 11: {year11Count}");
            Console.WriteLine($"   Year 12: {year12Count}");

            double avgAge = students.Average(s => s.Age);
            Console.WriteLine($"📊 Average Age: {avgAge:F1} years");
        }

        // Grade statistics
        var allEnrollments = studentManager.GetAllEnrollments();
        var gradedEnrollments = allEnrollments.Where(e => e.Grade.HasValue).ToList();

        if (gradedEnrollments.Any())
        {
            double overallAverage = gradedEnrollments.Average(e => e.Grade!.Value);
            int totalGrades = gradedEnrollments.Count;

            Console.WriteLine($"📝 Total Grades Entered: {totalGrades}");
            Console.WriteLine($"📊 Overall Average Grade: {overallAverage:F1}%");

            var gradeDistribution = gradedEnrollments
                .GroupBy(e => GetLetterGrade(e.Grade!.Value))
                .OrderByDescending(g => g.Count());

            Console.WriteLine("\n📈 Grade Distribution:");
            foreach (var group in gradeDistribution)
            {
                double percentage = (double)group.Count() / totalGrades * 100;
                Console.WriteLine($"   {group.Key}: {group.Count()} ({percentage:F1}%)");
            }
        }

        // Course enrollment stats
        if (courses.Any())
        {
            Console.WriteLine("\n📚 Course Enrollment Statistics:");
            foreach (var course in courses.OrderBy(c => c.Code))
            {
                var courseEnrollments = studentManager.GetCourseEnrollments(course.Id);
                var courseGrades = courseEnrollments.Where(e => e.Grade.HasValue).ToList();

                string avgGrade = courseGrades.Any()
                    ? $"{courseGrades.Average(e => e.Grade!.Value):F1}%"
                    : "N/A";

                Console.WriteLine($"   {course.Code}: {courseEnrollments.Count()} enrolled, avg: {avgGrade}");
            }
        }
    }

    static string GetLetterGrade(int grade)
    {
        return grade >= 90 ? "A" :
               grade >= 80 ? "B" :
               grade >= 70 ? "C" :
               grade >= 60 ? "D" : "F";
    }
}

// Supporting Classes
public class Student
{
    private static int nextId = 1;

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int Year { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    public Student() { } // For JSON deserialization

    public Student(string firstName, string lastName, int age, int year)
    {
        Id = nextId++;
        FirstName = firstName ?? throw new ArgumentException("First name cannot be null");
        LastName = lastName ?? throw new ArgumentException("Last name cannot be null");
        Age = age;
        Year = year;
    }
}

public class Course
{
    private static int nextId = 1;

    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }

    public Course() { } // For JSON deserialization

    public Course(string code, string name)
    {
        Id = nextId++;
        Code = code ?? throw new ArgumentException("Course code cannot be null");
        Name = name ?? throw new ArgumentException("Course name cannot be null");
    }
}

public class Enrollment
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public int? Grade { get; set; }
    public DateTime EnrollmentDate { get; set; }

    public Enrollment() { } // For JSON deserialization

    public Enrollment(int studentId, int courseId)
    {
        StudentId = studentId;
        CourseId = courseId;
        EnrollmentDate = DateTime.Now;
    }
}

public class StudentManager
{
    private List<Student> students = new List<Student>();
    private List<Course> courses = new List<Course>();
    private List<Enrollment> enrollments = new List<Enrollment>();
    private const string DATA_FILE = "student_data.json";

    public StudentManager()
    {
        // Add sample data
        InitializeSampleData();
    }

    private void InitializeSampleData()
    {
        // Sample students
        students.AddRange(new[]
        {
            new Student("Alice", "Johnson", 16, 11),
            new Student("Bob", "Smith", 17, 12),
            new Student("Carol", "Davis", 16, 11),
            new Student("David", "Wilson", 18, 12),
            new Student("Emma", "Brown", 17, 12)
        });

        // Sample courses
        courses.AddRange(new[]
        {
            new Course("CS101", "Computer Science"),
            new Course("MATH201", "Advanced Mathematics"),
            new Course("PHY101", "Physics"),
            new Course("CHEM101", "Chemistry"),
            new Course("BIO101", "Biology")
        });

        // Sample enrollments
        enrollments.AddRange(new[]
        {
            new Enrollment(1, 1) { Grade = 95 },
            new Enrollment(1, 2) { Grade = 87 },
            new Enrollment(2, 1) { Grade = 82 },
            new Enrollment(3, 3) { Grade = 91 },
            new Enrollment(4, 4) { Grade = 76 },
            new Enrollment(5, 5) { Grade = 89 }
        });
    }

    public void AddStudent(Student student) => students.Add(student);
    public void AddCourse(Course course) => courses.Add(course);

    public void EnrollStudent(int studentId, int courseId)
    {
        if (enrollments.Any(e => e.StudentId == studentId && e.CourseId == courseId))
            throw new InvalidOperationException("Student already enrolled in this course");

        enrollments.Add(new Enrollment(studentId, courseId));
    }

    public void SetGrade(int studentId, int courseId, int grade)
    {
        var enrollment = enrollments.FirstOrDefault(e => e.StudentId == studentId && e.CourseId == courseId);
        if (enrollment == null)
            throw new InvalidOperationException("Student not enrolled in this course");

        enrollment.Grade = grade;
    }

    public Student? GetStudent(int id) => students.FirstOrDefault(s => s.Id == id);
    public Course? GetCourse(int id) => courses.FirstOrDefault(c => c.Id == id);
    public Course? GetCourseByCode(string code) => courses.FirstOrDefault(c => c.Code.Equals(code, StringComparison.OrdinalIgnoreCase));

    public IEnumerable<Student> GetAllStudents() => students;
    public IEnumerable<Course> GetAllCourses() => courses;
    public IEnumerable<Enrollment> GetAllEnrollments() => enrollments;

    public IEnumerable<Enrollment> GetStudentEnrollments(int studentId) =>
        enrollments.Where(e => e.StudentId == studentId);

    public IEnumerable<Enrollment> GetCourseEnrollments(int courseId) =>
        enrollments.Where(e => e.CourseId == courseId);

    public int GetStudentCount() => students.Count;
    public int GetCourseCount() => courses.Count;

    public void SaveData()
    {
        try
        {
            var data = new { Students = students, Courses = courses, Enrollments = enrollments };
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(DATA_FILE, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Warning: Could not save data - {ex.Message}");
        }
    }

    public void LoadData()
    {
        try
        {
            if (File.Exists(DATA_FILE))
            {
                string json = File.ReadAllText(DATA_FILE);
                using var doc = JsonDocument.Parse(json);

                if (doc.RootElement.TryGetProperty("Students", out var studentsElement))
                {
                    var loadedStudents = JsonSerializer.Deserialize<List<Student>>(studentsElement.GetRawText());
                    if (loadedStudents != null) students = loadedStudents;
                }

                if (doc.RootElement.TryGetProperty("Courses", out var coursesElement))
                {
                    var loadedCourses = JsonSerializer.Deserialize<List<Course>>(coursesElement.GetRawText());
                    if (loadedCourses != null) courses = loadedCourses;
                }

                if (doc.RootElement.TryGetProperty("Enrollments", out var enrollmentsElement))
                {
                    var loadedEnrollments = JsonSerializer.Deserialize<List<Enrollment>>(enrollmentsElement.GetRawText());
                    if (loadedEnrollments != null) enrollments = loadedEnrollments;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Warning: Could not load saved data - {ex.Message}");
            Console.WriteLine("Using sample data instead.");
        }
    }
}
