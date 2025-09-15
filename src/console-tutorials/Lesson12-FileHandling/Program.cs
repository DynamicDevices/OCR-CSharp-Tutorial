using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("📁 File Handling - OCR A-Level");
        Console.WriteLine("===============================\n");

        // Create a sample directory structure for our examples
        SetupSampleFiles();

        // Example 1: Basic Text File Operations
        Console.WriteLine("--- Example 1: Basic Text File Operations ---");
        BasicTextFileOperations();
        Console.WriteLine();

        // Example 2: Reading File Line by Line
        Console.WriteLine("--- Example 2: Reading Files Line by Line ---");
        ReadFileLineByLine();
        Console.WriteLine();

        // Example 3: Appending to Files
        Console.WriteLine("--- Example 3: Appending to Files ---");
        AppendToFile();
        Console.WriteLine();

        // Example 4: Working with CSV Files
        Console.WriteLine("--- Example 4: CSV File Operations ---");
        WorkWithCSVFiles();
        Console.WriteLine();

        // Example 5: JSON File Handling
        Console.WriteLine("--- Example 5: JSON File Handling ---");
        WorkWithJSONFiles();
        Console.WriteLine();

        // Example 6: Directory Operations
        Console.WriteLine("--- Example 6: Directory Operations ---");
        DirectoryOperations();
        Console.WriteLine();

        // Example 7: File Information and Properties
        Console.WriteLine("--- Example 7: File Information ---");
        FileInformation();
        Console.WriteLine();

        // Example 8: Error Handling with Files
        Console.WriteLine("--- Example 8: Error Handling ---");
        FileErrorHandling();
        Console.WriteLine();

        // Example 9: Recursive Directory Traversal
        Console.WriteLine("--- Example 9: Recursive Directory Traversal ---");
        RecursiveDirectoryTraversal("sample_data", 0);
        Console.WriteLine();

        // Interactive Section
        Console.WriteLine("--- Interactive File Creator ---");
        InteractiveFileCreator();
    }

    static void SetupSampleFiles()
    {
        // Create sample directory structure
        Directory.CreateDirectory("sample_data");
        Directory.CreateDirectory("sample_data/logs");
        Directory.CreateDirectory("sample_data/config");
        Directory.CreateDirectory("sample_data/students");

        // Create sample text file
        File.WriteAllText("sample_data/welcome.txt",
            "Welcome to C# File Handling!\n" +
            "This is a sample text file.\n" +
            "You can read, write, and manipulate files like this one.\n" +
            "File handling is essential for data persistence.");

        // Create sample log file
        string[] logEntries = {
            $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Application started",
            $"{DateTime.Now.AddMinutes(-5):yyyy-MM-dd HH:mm:ss} - User logged in",
            $"{DateTime.Now.AddMinutes(-3):yyyy-MM-dd HH:mm:ss} - File operation completed",
            $"{DateTime.Now.AddMinutes(-1):yyyy-MM-dd HH:mm:ss} - Data saved successfully"
        };
        File.WriteAllLines("sample_data/logs/app.log", logEntries);

        // Create sample CSV file
        string csvContent = "Name,Age,Grade,Subject\n" +
                           "Alice Johnson,16,A,Computer Science\n" +
                           "Bob Smith,17,B,Mathematics\n" +
                           "Carol Davis,16,A,Physics\n" +
                           "David Wilson,17,C,Chemistry\n" +
                           "Emma Brown,16,B,Biology";
        File.WriteAllText("sample_data/students/grades.csv", csvContent);

        // Create sample config file
        string configContent = "# Application Configuration\n" +
                              "AppName=C# Tutorial\n" +
                              "Version=1.0\n" +
                              "Debug=true\n" +
                              "MaxUsers=100\n" +
                              "DatabasePath=./data/app.db";
        File.WriteAllText("sample_data/config/app.config", configContent);
    }

    static void BasicTextFileOperations()
    {
        string fileName = "sample_data/hello.txt";

        // Writing to a file
        Console.WriteLine("Writing to file...");
        string content = "Hello, File Handling!\nThis is written from C# code.";
        File.WriteAllText(fileName, content);
        Console.WriteLine($"✅ Created and wrote to '{fileName}'");

        // Reading from a file
        Console.WriteLine("\nReading from file...");
        string readContent = File.ReadAllText(fileName);
        Console.WriteLine("📄 File contents:");
        Console.WriteLine(readContent);

        // Check if file exists
        if (File.Exists(fileName))
        {
            Console.WriteLine("✅ File exists and is accessible");
        }
    }

    static void ReadFileLineByLine()
    {
        string fileName = "sample_data/welcome.txt";

        Console.WriteLine($"Reading '{fileName}' line by line:");
        string[] lines = File.ReadAllLines(fileName);

        for (int i = 0; i < lines.Length; i++)
        {
            Console.WriteLine($"Line {i + 1}: {lines[i]}");
        }

        Console.WriteLine($"\nTotal lines: {lines.Length}");
        Console.WriteLine($"Total characters: {File.ReadAllText(fileName).Length}");
    }

    static void AppendToFile()
    {
        string fileName = "sample_data/logs/activity.log";

        // Create or append to log file
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string logEntry = $"[{timestamp}] User performed file append operation\n";

        File.AppendAllText(fileName, logEntry);
        Console.WriteLine("✅ Appended new log entry");

        // Add multiple entries
        List<string> entries = new List<string>
        {
            $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] System check completed",
            $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Memory usage: Normal",
            $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] All services running"
        };

        File.AppendAllLines(fileName, entries);
        Console.WriteLine("✅ Appended multiple log entries");

        // Display the log file
        Console.WriteLine("\n📄 Current log contents:");
        string[] logLines = File.ReadAllLines(fileName);
        foreach (string line in logLines.TakeLast(5)) // Show last 5 entries
        {
            Console.WriteLine($"  {line}");
        }
    }

    static void WorkWithCSVFiles()
    {
        string csvFile = "sample_data/students/grades.csv";

        Console.WriteLine("📊 Processing CSV file:");
        string[] lines = File.ReadAllLines(csvFile);

        // Parse header
        string[] headers = lines[0].Split(',');
        Console.WriteLine($"Headers: {string.Join(" | ", headers)}");
        Console.WriteLine(new string('-', 50));

        // Parse data rows
        List<Student> students = new List<Student>();
        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');
            if (values.Length >= 4)
            {
                Student student = new Student
                {
                    Name = values[0],
                    Age = int.Parse(values[1]),
                    Grade = values[2],
                    Subject = values[3]
                };
                students.Add(student);
                Console.WriteLine($"{student.Name,-15} | {student.Age,3} | {student.Grade,5} | {student.Subject}");
            }
        }

        // Add a new student
        Student newStudent = new Student { Name = "Frank Miller", Age = 17, Grade = "A", Subject = "English" };
        students.Add(newStudent);

        // Write updated CSV
        List<string> csvLines = new List<string> { string.Join(",", headers) };
        foreach (Student student in students)
        {
            csvLines.Add($"{student.Name},{student.Age},{student.Grade},{student.Subject}");
        }

        File.WriteAllLines("sample_data/students/updated_grades.csv", csvLines);
        Console.WriteLine("\n✅ Updated CSV file saved as 'updated_grades.csv'");

        // Statistics
        double avgAge = students.Average(s => s.Age);
        int gradeACount = students.Count(s => s.Grade == "A");
        Console.WriteLine($"\n📈 Statistics:");
        Console.WriteLine($"  Total students: {students.Count}");
        Console.WriteLine($"  Average age: {avgAge:F1}");
        Console.WriteLine($"  Grade A students: {gradeACount}");
    }

    static void WorkWithJSONFiles()
    {
        string jsonFile = "sample_data/config/settings.json";

        // Create settings object
        AppSettings settings = new AppSettings
        {
            ApplicationName = "C# File Handler",
            Version = "2.0.1",
            EnableLogging = true,
            MaxFileSize = 1024000,
            AllowedExtensions = new[] { ".txt", ".csv", ".json", ".log" },
            DatabaseSettings = new DatabaseConfig
            {
                ConnectionString = "Data Source=app.db",
                Timeout = 30,
                EnableRetry = true
            }
        };

        // Serialize to JSON
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string jsonString = JsonSerializer.Serialize(settings, options);
        File.WriteAllText(jsonFile, jsonString);
        Console.WriteLine("✅ Created JSON configuration file");

        // Read and deserialize JSON
        string readJson = File.ReadAllText(jsonFile);
        AppSettings? loadedSettings = JsonSerializer.Deserialize<AppSettings>(readJson);

        if (loadedSettings != null)
        {
            Console.WriteLine("\n📄 Loaded JSON settings:");
            Console.WriteLine($"  App: {loadedSettings.ApplicationName}");
            Console.WriteLine($"  Version: {loadedSettings.Version}");
            Console.WriteLine($"  Logging: {loadedSettings.EnableLogging}");
            Console.WriteLine($"  Max file size: {loadedSettings.MaxFileSize:N0} bytes");
            Console.WriteLine($"  Allowed extensions: {string.Join(", ", loadedSettings.AllowedExtensions ?? Array.Empty<string>())}");
            Console.WriteLine($"  DB Timeout: {loadedSettings.DatabaseSettings?.Timeout} seconds");
        }

        // Pretty print the JSON
        Console.WriteLine("\n📋 JSON file contents:");
        Console.WriteLine(jsonString);
    }

    static void DirectoryOperations()
    {
        string baseDir = "sample_data";
        string newDir = "sample_data/temp";

        // Create directory
        if (!Directory.Exists(newDir))
        {
            Directory.CreateDirectory(newDir);
            Console.WriteLine($"✅ Created directory: {newDir}");
        }

        // List directories
        Console.WriteLine($"\n📁 Subdirectories in '{baseDir}':");
        string[] directories = Directory.GetDirectories(baseDir);
        foreach (string dir in directories)
        {
            string dirName = Path.GetFileName(dir);
            int fileCount = Directory.GetFiles(dir).Length;
            Console.WriteLine($"  📁 {dirName} ({fileCount} files)");
        }

        // List files
        Console.WriteLine($"\n📄 Files in '{baseDir}':");
        string[] files = Directory.GetFiles(baseDir);
        foreach (string file in files)
        {
            string fileName = Path.GetFileName(file);
            FileInfo info = new FileInfo(file);
            Console.WriteLine($"  📄 {fileName} ({info.Length} bytes)");
        }

        // Get all files recursively
        Console.WriteLine($"\n🔍 All files in '{baseDir}' (recursive):");
        string[] allFiles = Directory.GetFiles(baseDir, "*.*", SearchOption.AllDirectories);
        foreach (string file in allFiles)
        {
            string relativePath = Path.GetRelativePath(baseDir, file);
            FileInfo info = new FileInfo(file);
            Console.WriteLine($"  📄 {relativePath} ({info.Length} bytes)");
        }
    }

    static void FileInformation()
    {
        string fileName = "sample_data/welcome.txt";

        if (File.Exists(fileName))
        {
            FileInfo fileInfo = new FileInfo(fileName);

            Console.WriteLine($"📊 Information for '{fileName}':");
            Console.WriteLine($"  Full path: {fileInfo.FullName}");
            Console.WriteLine($"  Size: {fileInfo.Length} bytes");
            Console.WriteLine($"  Created: {fileInfo.CreationTime}");
            Console.WriteLine($"  Modified: {fileInfo.LastWriteTime}");
            Console.WriteLine($"  Accessed: {fileInfo.LastAccessTime}");
            Console.WriteLine($"  Read-only: {fileInfo.IsReadOnly}");
            Console.WriteLine($"  Extension: {fileInfo.Extension}");
            Console.WriteLine($"  Directory: {fileInfo.DirectoryName}");

            // File attributes
            FileAttributes attributes = File.GetAttributes(fileName);
            Console.WriteLine($"  Attributes: {attributes}");
        }
    }

    static void FileErrorHandling()
    {
        Console.WriteLine("🛡️ Demonstrating proper error handling:");

        // Example 1: File not found
        try
        {
            string content = File.ReadAllText("nonexistent_file.txt");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"❌ File not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Unexpected error: {ex.Message}");
        }

        // Example 2: Directory access
        try
        {
            Directory.CreateDirectory("invalid:/path");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"❌ Invalid path: {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"❌ Access denied: {ex.Message}");
        }

        // Example 3: Safe file operations
        string testFile = "sample_data/test_error_handling.txt";
        if (TrySafeFileWrite(testFile, "This is a test"))
        {
            Console.WriteLine("✅ Safe file write succeeded");
        }

        if (TrySafeFileRead(testFile, out string content))
        {
            Console.WriteLine($"✅ Safe file read succeeded: '{content}'");
        }
    }

    static bool TrySafeFileWrite(string fileName, string content)
    {
        try
        {
            File.WriteAllText(fileName, content);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Failed to write file: {ex.Message}");
            return false;
        }
    }

    static bool TrySafeFileRead(string fileName, out string content)
    {
        content = string.Empty;
        try
        {
            if (File.Exists(fileName))
            {
                content = File.ReadAllText(fileName);
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Failed to read file: {ex.Message}");
            return false;
        }
    }

    static void RecursiveDirectoryTraversal(string path, int depth)
    {
        if (!Directory.Exists(path))
            return;

        string indent = new string(' ', depth * 2);
        Console.WriteLine($"{indent}📁 {Path.GetFileName(path)}/");

        try
        {
            // List files in current directory
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);
                Console.WriteLine($"{indent}  📄 {Path.GetFileName(file)} ({info.Length} bytes)");
            }

            // Recursively traverse subdirectories
            string[] directories = Directory.GetDirectories(path);
            foreach (string directory in directories)
            {
                RecursiveDirectoryTraversal(directory, depth + 1);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"{indent}  ❌ Access denied");
        }
    }

    static void InteractiveFileCreator()
    {
        Console.Write("Enter filename to create (or press Enter to skip): ");
        string? fileName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(fileName))
        {
            Console.WriteLine("Skipped interactive section.");
            return;
        }

        // Ensure the file is created in sample_data directory
        fileName = Path.Combine("sample_data", fileName);

        Console.WriteLine("Enter content (type 'END' on a new line to finish):");
        List<string> lines = new List<string>();

        string? line;
        while ((line = Console.ReadLine()) != null && line != "END")
        {
            lines.Add(line);
        }

        try
        {
            File.WriteAllLines(fileName, lines);
            Console.WriteLine($"✅ File '{fileName}' created successfully!");
            Console.WriteLine($"📊 File contains {lines.Count} lines and {File.ReadAllText(fileName).Length} characters.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error creating file: {ex.Message}");
        }
    }
}

// Classes for JSON serialization
public class Student
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Grade { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
}

public class AppSettings
{
    public string ApplicationName { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public bool EnableLogging { get; set; }
    public long MaxFileSize { get; set; }
    public string[]? AllowedExtensions { get; set; }
    public DatabaseConfig? DatabaseSettings { get; set; }
}

public class DatabaseConfig
{
    public string ConnectionString { get; set; } = string.Empty;
    public int Timeout { get; set; }
    public bool EnableRetry { get; set; }
}
