using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("🔍 Binary Search Algorithm - OCR A-Level Computer Science");
        Console.WriteLine("=========================================================\n");

        Console.WriteLine("🏛️ Historical Context:");
        Console.WriteLine("Binary search was invented in 1946 by John Mauchly for the ENIAC computer.");
        Console.WriteLine("It uses the 'divide and conquer' strategy - split the problem in half repeatedly.");
        Console.WriteLine("This makes it incredibly fast: searching 1 million items takes only ~20 steps!");
        Console.WriteLine("Compare to linear search which might need 500,000 steps on average.\n");

        // Example 1: Binary Search vs Linear Search Comparison
        Console.WriteLine("--- Example 1: Binary vs Linear Search Comparison ---");
        
        int[] sortedNumbers = { 2, 5, 8, 12, 16, 23, 38, 45, 67, 78, 89, 99 };
        Console.WriteLine($"📊 Sorted array: [{string.Join(", ", sortedNumbers)}]");
        Console.WriteLine("(Binary search REQUIRES sorted data!)\n");

        int target = 23;
        Console.WriteLine($"🎯 Searching for: {target}\n");

        // Linear Search
        Console.WriteLine("🐌 Linear Search (checks each item):");
        int linearSteps = LinearSearchWithSteps(sortedNumbers, target);
        
        Console.WriteLine();
        
        // Binary Search  
        Console.WriteLine("🚀 Binary Search (divide and conquer):");
        int binarySteps = BinarySearchWithSteps(sortedNumbers, target);
        
        Console.WriteLine($"\n📈 Efficiency Comparison:");
        Console.WriteLine($"Linear Search: {linearSteps} steps");
        Console.WriteLine($"Binary Search: {binarySteps} steps");
        Console.WriteLine($"Binary search was {(double)linearSteps / binarySteps:F1}x faster!\n");

        // Example 2: Interactive Binary Search
        Console.WriteLine("--- Example 2: Interactive Binary Search ---");
        InteractiveBinarySearch(sortedNumbers);

        // Example 3: Algorithm Complexity Analysis
        Console.WriteLine("\n--- Example 3: Algorithm Complexity Analysis ---");
        AnalyzeComplexity();

        // Example 4: Real-World Applications
        Console.WriteLine("\n--- Example 4: Real-World Applications ---");
        RealWorldExamples();

        Console.WriteLine("\n🎯 Key Learning Points:");
        Console.WriteLine("• Binary search requires SORTED data");
        Console.WriteLine("• Time complexity: O(log n) - very efficient!");
        Console.WriteLine("• Uses divide-and-conquer strategy");
        Console.WriteLine("• Much faster than linear search for large datasets");
        Console.WriteLine("• Essential algorithm for OCR A-Level exams");
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    // Linear Search with step counting for comparison
    static int LinearSearchWithSteps(int[] array, int target)
    {
        int steps = 0;
        
        for (int i = 0; i < array.Length; i++)
        {
            steps++;
            Console.WriteLine($"  Step {steps}: Check position {i} → {array[i]}");
            
            if (array[i] == target)
            {
                Console.WriteLine($"  ✅ Found {target} at position {i}!");
                return steps;
            }
        }
        
        Console.WriteLine($"  ❌ {target} not found");
        return steps;
    }

    // Binary Search with detailed step-by-step explanation
    static int BinarySearchWithSteps(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;
        int steps = 0;
        
        Console.WriteLine($"  Initial range: positions {left} to {right}");
        
        while (left <= right)
        {
            steps++;
            int middle = left + (right - left) / 2;
            
            Console.WriteLine($"  Step {steps}: Check middle position {middle} → {array[middle]}");
            Console.WriteLine($"    Current range: [{left}..{middle}..{right}]");
            
            if (array[middle] == target)
            {
                Console.WriteLine($"  ✅ Found {target} at position {middle}!");
                return steps;
            }
            else if (array[middle] < target)
            {
                Console.WriteLine($"    {array[middle]} < {target}, search RIGHT half");
                left = middle + 1;
            }
            else
            {
                Console.WriteLine($"    {array[middle]} > {target}, search LEFT half");
                right = middle - 1;
            }
            
            if (left <= right)
            {
                Console.WriteLine($"    New range: positions {left} to {right}");
            }
        }
        
        Console.WriteLine($"  ❌ {target} not found");
        return steps;
    }

    // Standard Binary Search implementation (OCR exam style)
    static int BinarySearch(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;
        
        while (left <= right)
        {
            int middle = left + (right - left) / 2;
            
            if (array[middle] == target)
            {
                return middle; // Found at this position
            }
            else if (array[middle] < target)
            {
                left = middle + 1; // Search right half
            }
            else
            {
                right = middle - 1; // Search left half
            }
        }
        
        return -1; // Not found
    }

    static void InteractiveBinarySearch(int[] array)
    {
        Console.WriteLine("🎮 Try searching for different numbers!");
        Console.WriteLine($"Available numbers: [{string.Join(", ", array)}]");
        
        while (true)
        {
            Console.Write("\nEnter a number to search for (or 'quit' to exit): ");
            string? input = Console.ReadLine();
            
            if (input?.ToLower() == "quit")
                break;
                
            if (int.TryParse(input, out int searchTarget))
            {
                Console.WriteLine($"\n🔍 Searching for {searchTarget}:");
                int steps = BinarySearchWithSteps(array, searchTarget);
                Console.WriteLine($"Search completed in {steps} steps.");
            }
            else
            {
                Console.WriteLine("Please enter a valid number or 'quit'.");
            }
        }
    }

    static void AnalyzeComplexity()
    {
        Console.WriteLine("📊 Time Complexity Analysis:");
        Console.WriteLine();
        
        int[] sizes = { 10, 100, 1000, 10000, 100000, 1000000 };
        
        Console.WriteLine("Array Size | Linear Search | Binary Search | Improvement");
        Console.WriteLine("           | (worst case)  | (worst case)  |            ");
        Console.WriteLine("-----------|---------------|---------------|------------");
        
        foreach (int size in sizes)
        {
            int linearSteps = size; // O(n)
            int binarySteps = (int)Math.Ceiling(Math.Log2(size)); // O(log n)
            double improvement = (double)linearSteps / binarySteps;
            
            Console.WriteLine($"{size,10:N0} | {linearSteps,13:N0} | {binarySteps,13:N0} | {improvement,8:F1}x faster");
        }
        
        Console.WriteLine();
        Console.WriteLine("💡 Notice how binary search stays efficient even with huge datasets!");
        Console.WriteLine("   This is why it's used in databases, search engines, and games.");
    }

    static void RealWorldExamples()
    {
        Console.WriteLine("🌍 Real-World Applications of Binary Search:");
        Console.WriteLine();
        
        Console.WriteLine("📚 Dictionary/Phone Book:");
        Console.WriteLine("   When you look up a word, you don't start from 'A'!");
        Console.WriteLine("   You open to the middle, then narrow down - that's binary search!");
        Console.WriteLine();
        
        Console.WriteLine("🎮 Game Development:");
        Console.WriteLine("   Finding the right difficulty level for a player");
        Console.WriteLine("   Collision detection in sorted object lists");
        Console.WriteLine();
        
        Console.WriteLine("💾 Database Systems:");
        Console.WriteLine("   Finding records in sorted indexes");
        Console.WriteLine("   SQL databases use binary search for WHERE clauses");
        Console.WriteLine();
        
        Console.WriteLine("🔍 Search Engines:");
        Console.WriteLine("   Finding web pages in sorted result lists");
        Console.WriteLine("   Auto-complete suggestions");
        Console.WriteLine();
        
        Console.WriteLine("📱 Mobile Apps:");
        Console.WriteLine("   Contact lists, music libraries, photo galleries");
        Console.WriteLine("   Any app with large sorted lists uses binary search!");
        
        // Demonstrate with a simple example
        Console.WriteLine("\n🎯 Mini-Demo: Guessing Game (Human Binary Search)");
        Console.WriteLine("Think of a number between 1 and 100...");
        Console.WriteLine("I'll find it using binary search strategy:");
        
        int low = 1, high = 100, guesses = 0;
        
        while (low <= high)
        {
            guesses++;
            int guess = (low + high) / 2;
            
            Console.Write($"Guess {guesses}: Is your number {guess}? (h=higher, l=lower, c=correct): ");
            string? response = Console.ReadLine()?.ToLower();
            
            if (response == "c")
            {
                Console.WriteLine($"🎉 Found it in {guesses} guesses using binary search!");
                break;
            }
            else if (response == "h")
            {
                low = guess + 1;
            }
            else if (response == "l")
            {
                high = guess - 1;
            }
            else
            {
                Console.WriteLine("Please enter 'h', 'l', or 'c'");
                guesses--; // Don't count invalid input
            }
        }
    }
}
