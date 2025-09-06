# Lesson 4: Arrays and Data Structures

## 🎯 Learning Objectives (OCR A-Level Alignment)

This lesson covers **OCR Specification Section 1.4.2** - Data Structures, specifically:
- Arrays and their implementation
- Linear search algorithm
- Bubble sort algorithm
- Multi-dimensional arrays
- Algorithm efficiency concepts

## 📚 What You'll Learn

### Core Concepts
- **Array Declaration and Initialization**: Different ways to create and populate arrays
- **Array Operations**: Accessing, modifying, and iterating through array elements
- **Search Algorithms**: Linear search implementation and analysis
- **Sorting Algorithms**: Bubble sort implementation and analysis
- **Multi-dimensional Arrays**: 2D arrays and jagged arrays
- **Array Methods**: Built-in C# array functionality

### OCR Assessment Objectives
- **AO1**: Demonstrate knowledge of array data structures and algorithms
- **AO2**: Apply array operations to solve computational problems
- **AO3**: Analyze algorithm efficiency and choose appropriate data structures

## 🚀 Running the Code

```bash
cd Lesson04-Arrays
dotnet run
```

## 🔍 Key Programming Concepts

### 1. Array Declaration
```csharp
// Fixed size array
int[] numbers = new int[5];

// Array with initial values
string[] subjects = { "Computer Science", "Mathematics", "Physics" };

// Alternative initialization
double[] grades = new double[] { 85.5, 92.0, 78.5 };
```

### 2. Linear Search Algorithm
```csharp
static int LinearSearch(int[] array, int target)
{
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] == target)
            return i;
    }
    return -1; // Not found
}
```

### 3. Bubble Sort Algorithm
```csharp
static void BubbleSort(int[] array)
{
    int n = array.Length;
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            if (array[j] > array[j + 1])
            {
                // Swap elements
                int temp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = temp;
            }
        }
    }
}
```

## 📊 Algorithm Analysis (OCR Requirement)

### Linear Search
- **Time Complexity**: O(n) - worst case checks every element
- **Space Complexity**: O(1) - uses constant extra space
- **Best Case**: O(1) - target is first element
- **Worst Case**: O(n) - target is last element or not present

### Bubble Sort
- **Time Complexity**: O(n²) - nested loops through array
- **Space Complexity**: O(1) - sorts in place
- **Best Case**: O(n) - array already sorted (with optimization)
- **Worst Case**: O(n²) - array sorted in reverse order

## 🎮 Interactive Exercises

The program includes several hands-on exercises:

1. **Array Basics**: Create and manipulate different types of arrays
2. **Search Practice**: Find elements using linear search
3. **Sorting Demo**: Watch bubble sort in action
4. **Grade Calculator**: Real-world application with statistics
5. **2D Arrays**: Work with matrices and tables

## 🔗 OCR Specification Links

### Component 1: Computer Systems
- **1.4.2**: Data structures and their uses
- **1.4.2**: Arrays as a data structure

### Component 2: Algorithms and Programming  
- **2.3.1**: Standard algorithms (searching and sorting)
- **2.3.1**: Algorithm efficiency and Big O notation

## 💡 Study Tips for OCR Exams

### Common Exam Questions
1. **Array Implementation**: "Write code to declare and initialize an array"
2. **Search Algorithms**: "Implement linear search and explain its efficiency"
3. **Sorting Algorithms**: "Trace through bubble sort with a given dataset"
4. **Algorithm Analysis**: "Compare the efficiency of different sorting methods"

### Key Points to Remember
- Arrays are **zero-indexed** (first element is at index 0)
- Always check **array bounds** to avoid runtime errors
- Linear search is **O(n)** but works on unsorted data
- Bubble sort is **O(n²)** but simple to understand and implement
- **2D arrays** use `array[row, col]` syntax in C#

## 🔄 Next Steps

After mastering this lesson:
1. **Practice**: Implement other search algorithms (binary search)
2. **Explore**: Try other sorting algorithms (selection sort, insertion sort)
3. **Apply**: Use arrays in real-world programming projects
4. **Advance**: Move to Lesson 5 - Collections and Generic Data Structures

## 📖 Additional Resources

- [Microsoft C# Arrays Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/)
- [OCR A-Level Computer Science Specification](https://www.ocr.org.uk/qualifications/as-and-a-level/computer-science-h046-h446-from-2015/)
- [Algorithm Visualization Tools](https://visualgo.net/en/sorting)

---

**OCR A-Level Computer Science - Phase 2 Implementation**  
**Contact**: info@dynamicdevices.co.uk  
**License**: Creative Commons Attribution-NonCommercial 4.0 International
