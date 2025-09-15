# Lesson 12: File Handling

Welcome to file handling in C#! This lesson covers everything you need to know about working with files and directories - a crucial skill for any programmer dealing with data persistence and file operations.

## 🎯 What You'll Learn

- Reading and writing text files
- Working with different file formats (CSV, JSON, logs)
- Directory operations and navigation
- File information and properties
- Error handling for file operations
- Recursive directory traversal
- Best practices for file handling

## 📁 File Operations Overview

### Basic File Operations
C# provides several classes for file operations:
- **`File`**: Static methods for common file operations
- **`FileInfo`**: Instance-based file information and operations
- **`Directory`**: Static methods for directory operations
- **`DirectoryInfo`**: Instance-based directory operations
- **`Path`**: Utility methods for working with file paths

### Reading Files
```csharp
// Read entire file as string
string content = File.ReadAllText("filename.txt");

// Read all lines into array
string[] lines = File.ReadAllLines("filename.txt");

// Read lines one by one (memory efficient)
foreach (string line in File.ReadLines("filename.txt"))
{
    Console.WriteLine(line);
}
```

### Writing Files
```csharp
// Write entire string to file (overwrites existing)
File.WriteAllText("filename.txt", content);

// Write array of lines to file
File.WriteAllLines("filename.txt", lines);

// Append to existing file
File.AppendAllText("filename.txt", additionalContent);
```

## 📊 Working with Different File Formats

### 1. Plain Text Files
- Simple text content
- Configuration files
- Log files
- Documentation

### 2. CSV (Comma-Separated Values)
- Tabular data storage
- Excel-compatible format
- Easy to parse and generate
- Common for data exchange

### 3. JSON (JavaScript Object Notation)
- Structured data format
- Configuration files
- API data exchange
- Modern alternative to XML

### 4. Log Files
- Application monitoring
- Debugging information
- Audit trails
- System events

## 🔍 Directory Operations

### Navigation and Listing
```csharp
// Get current directory
string currentDir = Directory.GetCurrentDirectory();

// List directories
string[] directories = Directory.GetDirectories("path");

// List files
string[] files = Directory.GetFiles("path");

// List files with pattern
string[] txtFiles = Directory.GetFiles("path", "*.txt");

// Recursive file search
string[] allFiles = Directory.GetFiles("path", "*.*", SearchOption.AllDirectories);
```

### Creating and Managing Directories
```csharp
// Create directory (creates parent directories if needed)
Directory.CreateDirectory("new/nested/directory");

// Check if directory exists
if (Directory.Exists("path"))
{
    // Directory operations
}

// Delete directory
Directory.Delete("path", recursive: true);
```

## 🛡️ Error Handling

### Common File Exceptions
- **`FileNotFoundException`**: File doesn't exist
- **`DirectoryNotFoundException`**: Directory doesn't exist
- **`UnauthorizedAccessException`**: Permission denied
- **`IOException`**: General I/O error
- **`ArgumentException`**: Invalid path or filename

### Safe File Operations Pattern
```csharp
public static bool TrySafeFileOperation(string fileName, Action<string> operation)
{
    try
    {
        if (File.Exists(fileName))
        {
            operation(fileName);
            return true;
        }
        return false;
    }
    catch (UnauthorizedAccessException)
    {
        Console.WriteLine("Access denied");
        return false;
    }
    catch (IOException ex)
    {
        Console.WriteLine($"I/O error: {ex.Message}");
        return false;
    }
}
```

## 📈 Examples in This Lesson

### 1. Basic Text File Operations
- Creating and writing text files
- Reading file contents
- Checking file existence
- Simple content manipulation

### 2. Line-by-Line Processing
- Reading files line by line
- Processing large files efficiently
- Counting lines and characters
- Text analysis

### 3. File Appending
- Adding content to existing files
- Creating log entries
- Maintaining activity logs
- Timestamped entries

### 4. CSV File Handling
- Parsing CSV data into objects
- Creating structured data
- Writing CSV files
- Data analysis and statistics

### 5. JSON Configuration
- Serializing objects to JSON
- Deserializing JSON to objects
- Configuration file management
- Structured data storage

### 6. Directory Management
- Creating directory structures
- Listing files and folders
- Recursive directory traversal
- File system navigation

### 7. File Information
- Getting file metadata
- File size and dates
- File attributes
- Path manipulation

### 8. Error Handling
- Graceful error recovery
- User-friendly error messages
- Safe file operations
- Exception handling patterns

## 🔄 Recursive Directory Traversal

Recursion is perfect for navigating directory trees:

```csharp
void TraverseDirectory(string path, int depth = 0)
{
    if (!Directory.Exists(path)) return;
    
    string indent = new string(' ', depth * 2);
    Console.WriteLine($"{indent}📁 {Path.GetFileName(path)}/");
    
    // Process files
    foreach (string file in Directory.GetFiles(path))
    {
        Console.WriteLine($"{indent}  📄 {Path.GetFileName(file)}");
    }
    
    // Recurse into subdirectories
    foreach (string subDir in Directory.GetDirectories(path))
    {
        TraverseDirectory(subDir, depth + 1);
    }
}
```

## 💡 Best Practices

### 1. Path Handling
```csharp
// Use Path.Combine for cross-platform compatibility
string filePath = Path.Combine("data", "files", "document.txt");

// Use Path methods for file operations
string fileName = Path.GetFileName(filePath);
string extension = Path.GetExtension(filePath);
string directory = Path.GetDirectoryName(filePath);
```

### 2. Resource Management
```csharp
// Use 'using' statements for file streams
using (StreamReader reader = new StreamReader("file.txt"))
{
    string content = reader.ReadToEnd();
    // StreamReader is automatically disposed
}
```

### 3. Large File Handling
```csharp
// For large files, read line by line
foreach (string line in File.ReadLines("largefile.txt"))
{
    ProcessLine(line);
    // Memory efficient - doesn't load entire file
}
```

### 4. Validation and Sanitization
```csharp
public static bool IsValidFileName(string fileName)
{
    if (string.IsNullOrWhiteSpace(fileName))
        return false;
        
    char[] invalidChars = Path.GetInvalidFileNameChars();
    return !fileName.Any(c => invalidChars.Contains(c));
}
```

## 🎮 Try It Yourself

### Exercise 1: Student Grade Manager
Create a program that:
- Reads student data from CSV
- Calculates statistics
- Saves results to a new file
- Handles file errors gracefully

### Exercise 2: Log File Analyzer
Build a log analyzer that:
- Reads log files line by line
- Counts different log levels (INFO, WARNING, ERROR)
- Finds most common errors
- Generates a summary report

### Exercise 3: Configuration Manager
Create a config system that:
- Reads JSON configuration files
- Provides default values for missing settings
- Validates configuration data
- Saves updated configurations

### Exercise 4: Directory Organizer
Write a tool that:
- Scans a directory recursively
- Organizes files by extension
- Creates organized folder structure
- Reports on file operations

## 🔧 Advanced Techniques

### 1. File Watching
Monitor files for changes:
```csharp
FileSystemWatcher watcher = new FileSystemWatcher("path");
watcher.Changed += (sender, e) => Console.WriteLine($"File changed: {e.Name}");
watcher.EnableRaisingEvents = true;
```

### 2. Stream Operations
For more control over file I/O:
```csharp
using (FileStream stream = new FileStream("file.txt", FileMode.Open))
using (StreamReader reader = new StreamReader(stream))
{
    // Custom stream operations
}
```

### 3. Asynchronous File Operations
For better performance:
```csharp
string content = await File.ReadAllTextAsync("file.txt");
await File.WriteAllTextAsync("file.txt", content);
```

## ⚠️ Common Pitfalls

### 1. Path Separators
```csharp
// WRONG - Hard-coded separators
string path = "data\\files\\document.txt"; // Windows only

// CORRECT - Use Path.Combine
string path = Path.Combine("data", "files", "document.txt"); // Cross-platform
```

### 2. File Locking
```csharp
// WRONG - File might be locked by another process
File.WriteAllText("file.txt", content);

// BETTER - Handle sharing conflicts
try 
{
    using (FileStream fs = new FileStream("file.txt", FileMode.Create, FileAccess.Write, FileShare.Read))
    {
        // Write operations
    }
}
catch (IOException)
{
    // Handle file in use
}
```

### 3. Memory Usage
```csharp
// WRONG - Loads entire file into memory
string[] lines = File.ReadAllLines("hugefile.txt");

// BETTER - Process line by line
foreach (string line in File.ReadLines("hugefile.txt"))
{
    ProcessLine(line);
}
```

## 📚 Key Takeaways

- **Always handle exceptions** when working with files
- **Use Path methods** for cross-platform compatibility
- **Validate input** before file operations
- **Be mindful of memory usage** with large files
- **Use appropriate file formats** for your data
- **Implement proper error messages** for users
- **Consider file locking** in multi-user scenarios
- **Use recursion** for directory tree operations

## 🚀 What's Next?

In **Lesson 13: LINQ**, we'll learn how to query and manipulate data collections efficiently - including data we read from files!

---

**Remember**: File handling is like being a librarian for your program's data - organize it well, handle it carefully, and always know where to find what you need! 📚✨