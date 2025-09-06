using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("🔢 Arrays and Data Structures - OCR A-Level Computer Science");
        Console.WriteLine("============================================================\n");

        // Let's start with a simple explanation
        Console.WriteLine("📖 What is an Array?");
        Console.WriteLine("An array is like a row of boxes, each holding one piece of data.");
        Console.WriteLine("Think of it like lockers in school - each locker has a number (index)");
        Console.WriteLine("and can store one item. Arrays in programming work the same way!\n");
        
        Console.WriteLine("🏛️ A Bit of History:");
        Console.WriteLine("Arrays were invented in the 1940s for early computers like ENIAC.");
        Console.WriteLine("Back then, computer memory was VERY expensive and limited!");
        Console.WriteLine("Arrays let programmers store lots of related data efficiently in one block.");
        Console.WriteLine("Today we take memory for granted, but arrays are still the fastest way");
        Console.WriteLine("to access data because items are stored right next to each other.\n");

        // Example 1: Basic Array Declaration and Initialization
        Console.WriteLine("--- Example 1: Creating Your First Arrays ---");
        Console.WriteLine("Let's create some arrays step by step...\n");
        
        // Method 1: Create empty array then fill it
        Console.WriteLine("📦 Method 1: Create an empty array, then fill it");
        Console.WriteLine("Think: 'Give me 5 empty boxes for numbers'");
        int[] numbers = new int[5]; // Array of 5 integers, all start as 0
        
        Console.WriteLine("Empty array created. Now let's fill the boxes:");
        numbers[0] = 10;  // Put 10 in the first box (index 0)
        numbers[1] = 20;  // Put 20 in the second box (index 1)
        numbers[2] = 30;  // Put 30 in the third box (index 2)
        numbers[3] = 40;  // Put 40 in the fourth box (index 3)
        numbers[4] = 50;  // Put 50 in the fifth box (index 4)
        
        Console.WriteLine("✅ Filled all 5 boxes with numbers!\n");

        // Method 2: Create and fill at the same time
        Console.WriteLine("📦 Method 2: Create and fill at the same time");
        Console.WriteLine("Think: 'Here are my subjects, put them in boxes automatically'");
        string[] subjects = { "Computer Science", "Mathematics", "Physics", "English" };
        Console.WriteLine("✅ Created array with 4 subjects automatically!\n");
        
        // Method 3: Another way to do the same thing
        Console.WriteLine("📦 Method 3: Another way to create and fill");
        Console.WriteLine("This is just a different way to write Method 2:");
        double[] grades = new double[] { 85.5, 92.0, 78.5, 88.0 };
        Console.WriteLine("✅ Created array with 4 grades!\n");

        // Now let's see what's in our arrays
        Console.WriteLine("🔍 Let's look inside our arrays:");
        Console.WriteLine("\nNumbers array (Method 1):");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine($"  Box {i}: {numbers[i]}");
        }

        Console.WriteLine("\nSubjects array (Method 2):");
        for (int i = 0; i < subjects.Length; i++)
        {
            Console.WriteLine($"  Box {i}: {subjects[i]}");
        }
        
        Console.WriteLine("\nGrades array (Method 3):");
        for (int i = 0; i < grades.Length; i++)
        {
            Console.WriteLine($"  Box {i}: {grades[i]}%");
        }

        Console.WriteLine("\n💡 Key Point: Array indexes start at 0, not 1!");
        Console.WriteLine("   So a 5-item array has indexes: 0, 1, 2, 3, 4");
        Console.WriteLine("   This is very important to remember!\n");
        
        Console.WriteLine("🤔 Why Start at 0? Historical Reason:");
        Console.WriteLine("In the 1960s, computer scientists realized that starting at 0 made");
        Console.WriteLine("the math much simpler for the computer. If you want item 3:");
        Console.WriteLine("• Starting at 1: Computer calculates 'start + (3-1) × item_size'");
        Console.WriteLine("• Starting at 0: Computer calculates 'start + 3 × item_size'");
        Console.WriteLine("Removing that '-1' made computers faster! This became the standard.");
        Console.WriteLine("Languages like C (1972) used 0-indexing, and most languages copied this.\n");

        // Example 2: Working with Arrays - Finding Information
        Console.WriteLine("--- Example 2: Let's Analyze Some Test Scores ---");
        Console.WriteLine("Imagine you're a teacher with 10 students' test scores.");
        Console.WriteLine("You want to find the highest, lowest, and average scores.\n");
        
        int[] testScores = { 85, 92, 78, 96, 88, 74, 91, 83, 89, 95 };
        Console.WriteLine($"📊 Our test scores: [{string.Join(", ", testScores)}]\n");
        
        // Find maximum value - step by step explanation
        Console.WriteLine("🔍 Finding the HIGHEST score:");
        Console.WriteLine("1. Start by assuming the first score is the highest");
        int max = testScores[0];
        Console.WriteLine($"   Starting assumption: {max} is the highest");
        
        Console.WriteLine("2. Check each other score to see if it's higher");
        for (int i = 1; i < testScores.Length; i++)
        {
            Console.WriteLine($"   Checking score {i}: {testScores[i]}");
            if (testScores[i] > max)
            {
                Console.WriteLine($"   → {testScores[i]} is higher than {max}! New highest = {testScores[i]}");
                max = testScores[i];
            }
            else
            {
                Console.WriteLine($"   → {testScores[i]} is not higher than {max}, keep {max}");
            }
        }
        Console.WriteLine($"✅ Final highest score: {max}\n");
        
        // Find minimum value - with simpler explanation now they understand the pattern
        Console.WriteLine("🔍 Finding the LOWEST score:");
        Console.WriteLine("Same idea, but looking for smaller numbers...");
        int min = testScores[0];
        for (int i = 1; i < testScores.Length; i++)
        {
            if (testScores[i] < min)
            {
                min = testScores[i];
            }
        }
        Console.WriteLine($"✅ Lowest score: {min}\n");
        
        // Calculate average - step by step
        Console.WriteLine("🔍 Calculating the AVERAGE score:");
        Console.WriteLine("1. Add up all the scores");
        int sum = 0;
        for (int i = 0; i < testScores.Length; i++)
        {
            sum += testScores[i];
            Console.WriteLine($"   Adding {testScores[i]}: running total = {sum}");
        }
        Console.WriteLine($"2. Total of all scores: {sum}");
        Console.WriteLine($"3. Number of students: {testScores.Length}");
        
        double average = (double)sum / testScores.Length;
        Console.WriteLine($"4. Average = {sum} ÷ {testScores.Length} = {average:F2}");
        
        Console.WriteLine($"\n📈 SUMMARY:");
        Console.WriteLine($"   Highest score: {max}%");
        Console.WriteLine($"   Lowest score:  {min}%");
        Console.WriteLine($"   Average score: {average:F2}%");
        Console.WriteLine();

        // Example 3: Searching for a Specific Score
        Console.WriteLine("--- Example 3: Finding a Specific Score (Linear Search) ---");
        Console.WriteLine("Let's say a student asks: 'Did anyone get 92 on the test?'");
        Console.WriteLine("We need to search through our array to find out!\n");
        
        Console.WriteLine("🔍 How Linear Search Works:");
        Console.WriteLine("1. Start at the beginning of the array");
        Console.WriteLine("2. Check each item one by one");
        Console.WriteLine("3. If we find what we're looking for, remember where it was");
        Console.WriteLine("4. If we reach the end without finding it, it's not there\n");
        
        Console.WriteLine("📚 Historical Context - Linear Search:");
        Console.WriteLine("This is humanity's oldest search method! Ancient librarians used it");
        Console.WriteLine("to find scrolls - start at one end, check each scroll until found.");
        Console.WriteLine("It's simple but can be slow. For 1 million items, you might need");
        Console.WriteLine("to check 500,000 on average. That's why faster methods were invented!\n");
        
        Console.Write("Enter a score to search for: ");
        if (int.TryParse(Console.ReadLine(), out int searchValue))
        {
            Console.WriteLine($"\n🔎 Searching for {searchValue} in our test scores...");
            int position = LinearSearchWithExplanation(testScores, searchValue);
            
            if (position != -1)
            {
                Console.WriteLine($"🎉 Found it! Score {searchValue} is at position {position}");
                Console.WriteLine($"   (Remember: position {position} means it's the {position + 1}th score in the list)");
            }
            else
            {
                Console.WriteLine($"❌ Score {searchValue} was not found in the array");
                Console.WriteLine("   No student got that exact score.");
            }
        }
        Console.WriteLine();

        // Example 4: Sorting Arrays - Bubble Sort Algorithm
        Console.WriteLine("--- Example 4: Sorting Arrays (Bubble Sort) ---");
        Console.WriteLine("Sometimes we need our data in order - smallest to largest, A to Z, etc.");
        Console.WriteLine("Let's learn the simplest sorting algorithm: Bubble Sort!\n");
        
        Console.WriteLine("🫧 Why 'Bubble' Sort? Historical Name:");
        Console.WriteLine("Invented in 1956, it's called 'bubble' because small numbers 'bubble up'");
        Console.WriteLine("to the top of the list, just like air bubbles rise in water!");
        Console.WriteLine("It's not the fastest method, but it's easy to understand and implement.");
        Console.WriteLine("Fun fact: It was one of the first sorting algorithms taught to students!\n");
        
        int[] unsortedArray = { 64, 34, 25, 12, 22, 11, 90 };
        Console.WriteLine($"🔢 Original array: [{string.Join(", ", unsortedArray)}]");
        Console.WriteLine("Watch how bubble sort works - it compares neighbors and swaps them:");
        
        BubbleSortWithExplanation(unsortedArray);
        Console.WriteLine($"✅ Sorted array:   [{string.Join(", ", unsortedArray)}]");
        Console.WriteLine("\nNotice how the largest numbers 'bubbled' to the right side!\n");

        // Example 5: Multi-dimensional Arrays
        Console.WriteLine("--- Example 5: 2D Arrays (Matrices) ---");
        Console.WriteLine("Sometimes we need data arranged in rows and columns, like a spreadsheet!");
        Console.WriteLine("2D arrays are perfect for grids, game boards, images, and tables.\n");
        
        Console.WriteLine("🧮 Historical Context - Matrices:");
        Console.WriteLine("The concept comes from mathematics - matrices were invented in 1850s");
        Console.WriteLine("by Arthur Cayley for solving systems of equations. Early computers in");
        Console.WriteLine("the 1940s used 2D arrays to store these mathematical matrices.");
        Console.WriteLine("Today we use them for images (pixels), game boards, spreadsheets, etc!\n");
        
        // Create a 3x3 multiplication table
        int[,] multiplicationTable = new int[3, 3];
        
        Console.WriteLine("📊 Let's create a 3×3 multiplication table:");
        Console.WriteLine("This shows how 2D arrays work with [row, column] indexing:");
        
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                multiplicationTable[row, col] = (row + 1) * (col + 1);
                Console.Write($"{multiplicationTable[row, col],4}");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Each position is accessed like multiplicationTable[row, col]\n");

        // Example 6: Jagged Arrays
        Console.WriteLine("--- Example 6: Jagged Arrays ---");
        
        // Array of arrays - each sub-array can have different lengths
        int[][] jaggedArray = new int[3][];
        jaggedArray[0] = new int[] { 1, 2, 3 };
        jaggedArray[1] = new int[] { 4, 5, 6, 7, 8 };
        jaggedArray[2] = new int[] { 9, 10 };
        
        Console.WriteLine("Jagged Array:");
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            Console.Write($"Row {i}: ");
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write($"{jaggedArray[i][j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // Example 7: Array Methods and Properties
        Console.WriteLine("--- Example 7: Built-in Array Methods ---");
        
        int[] sampleArray = { 5, 2, 8, 1, 9, 3 };
        Console.WriteLine($"Original: [{string.Join(", ", sampleArray)}]");
        
        // Using Array.Sort() - built-in sorting
        int[] sortedCopy = new int[sampleArray.Length];
        Array.Copy(sampleArray, sortedCopy, sampleArray.Length);
        Array.Sort(sortedCopy);
        Console.WriteLine($"Sorted:   [{string.Join(", ", sortedCopy)}]");
        
        // Using Array.Reverse()
        Array.Reverse(sortedCopy);
        Console.WriteLine($"Reversed: [{string.Join(", ", sortedCopy)}]");
        
        // Using Array.IndexOf()
        int indexOfFive = Array.IndexOf(sampleArray, 5);
        Console.WriteLine($"Index of 5: {indexOfFive}");
        Console.WriteLine();

        // Interactive Exercise
        Console.WriteLine("--- Interactive Exercise: Grade Calculator ---");
        Console.Write("How many students? ");
        if (int.TryParse(Console.ReadLine(), out int studentCount) && studentCount > 0)
        {
            double[] studentGrades = new double[studentCount];
            
            // Input grades
            for (int i = 0; i < studentCount; i++)
            {
                Console.Write($"Enter grade for student {i + 1}: ");
                if (double.TryParse(Console.ReadLine(), out double grade))
                {
                    studentGrades[i] = grade;
                }
            }
            
            // Calculate statistics
            double total = 0;
            double highest = studentGrades[0];
            double lowest = studentGrades[0];
            
            for (int i = 0; i < studentGrades.Length; i++)
            {
                total += studentGrades[i];
                if (studentGrades[i] > highest) highest = studentGrades[i];
                if (studentGrades[i] < lowest) lowest = studentGrades[i];
            }
            
            double classAverage = total / studentCount;
            
            Console.WriteLine("\n📊 Class Statistics:");
            Console.WriteLine($"Number of students: {studentCount}");
            Console.WriteLine($"Class average: {classAverage:F2}%");
            Console.WriteLine($"Highest grade: {highest:F2}%");
            Console.WriteLine($"Lowest grade: {lowest:F2}%");
            
            // Count grades by category
            int aGrades = 0, bGrades = 0, cGrades = 0, dGrades = 0, fGrades = 0;
            
            for (int i = 0; i < studentGrades.Length; i++)
            {
                if (studentGrades[i] >= 90) aGrades++;
                else if (studentGrades[i] >= 80) bGrades++;
                else if (studentGrades[i] >= 70) cGrades++;
                else if (studentGrades[i] >= 60) dGrades++;
                else fGrades++;
            }
            
            Console.WriteLine("\n📈 Grade Distribution:");
            Console.WriteLine($"A grades (90-100): {aGrades}");
            Console.WriteLine($"B grades (80-89):  {bGrades}");
            Console.WriteLine($"C grades (70-79):  {cGrades}");
            Console.WriteLine($"D grades (60-69):  {dGrades}");
            Console.WriteLine($"F grades (0-59):   {fGrades}");
        }

        Console.WriteLine("\n🎯 Key Learning Points:");
        Console.WriteLine("• Arrays store multiple values of the same type");
        Console.WriteLine("• Array indices start at 0 and go to Length-1");
        Console.WriteLine("• Linear search checks each element sequentially");
        Console.WriteLine("• Bubble sort compares adjacent elements and swaps them");
        Console.WriteLine("• 2D arrays are useful for matrices and tables");
        Console.WriteLine("• Always validate array bounds to avoid errors");
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    // Linear Search Algorithm - OCR Specification Requirement
    static int LinearSearch(int[] array, int target)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == target)
            {
                return i; // Return the index where target was found
            }
        }
        return -1; // Return -1 if target not found
    }

    // Linear Search with Step-by-Step Explanation for Learning
    static int LinearSearchWithExplanation(int[] array, int target)
    {
        Console.WriteLine($"   Array to search: [{string.Join(", ", array)}]");
        Console.WriteLine($"   Looking for: {target}");
        Console.WriteLine();
        
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine($"   Step {i + 1}: Checking position {i} → {array[i]}");
            
            if (array[i] == target)
            {
                Console.WriteLine($"   ✅ MATCH! Found {target} at position {i}");
                return i; // Return the index where target was found
            }
            else
            {
                Console.WriteLine($"   ❌ {array[i]} ≠ {target}, keep looking...");
            }
        }
        
        Console.WriteLine($"   🔚 Reached end of array. {target} not found.");
        return -1; // Return -1 if target not found
    }

    // Bubble Sort Algorithm - OCR Specification Requirement
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

    // Bubble Sort with Step-by-Step Explanation for Learning
    static void BubbleSortWithExplanation(int[] array)
    {
        int n = array.Length;
        Console.WriteLine($"   Starting with: [{string.Join(", ", array)}]");
        Console.WriteLine("   Strategy: Compare neighbors, swap if left > right");
        Console.WriteLine();
        
        for (int i = 0; i < n - 1; i++)
        {
            Console.WriteLine($"   🔄 Pass {i + 1}: Looking for the {i + 1}th largest number");
            bool swapped = false;
            
            for (int j = 0; j < n - i - 1; j++)
            {
                Console.WriteLine($"      Comparing {array[j]} and {array[j + 1]}");
                
                if (array[j] > array[j + 1])
                {
                    // Swap elements
                    Console.WriteLine($"      → {array[j]} > {array[j + 1]}, so swap them!");
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    swapped = true;
                    Console.WriteLine($"      → Now: [{string.Join(", ", array)}]");
                }
                else
                {
                    Console.WriteLine($"      → {array[j]} ≤ {array[j + 1]}, no swap needed");
                }
            }
            
            Console.WriteLine($"   ✅ After pass {i + 1}: [{string.Join(", ", array)}]");
            Console.WriteLine($"      (Largest number {array[n - 1 - i]} is now in position!)");
            Console.WriteLine();
            
            if (!swapped)
            {
                Console.WriteLine("   🎉 No swaps needed - array is sorted!");
                break;
            }
        }
    }
}
