using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("⚡ Advanced Sorting Algorithms - OCR A-Level Computer Science");
        Console.WriteLine("============================================================\n");

        Console.WriteLine("🏛️ Historical Context:");
        Console.WriteLine("While bubble sort (1956) was simple, it was too slow for large datasets.");
        Console.WriteLine("Computer scientists developed faster algorithms using 'divide and conquer':");
        Console.WriteLine("• Merge Sort (1945) - invented by John von Neumann for EDVAC computer");
        Console.WriteLine("• Quick Sort (1960) - invented by Tony Hoare, still widely used today");
        Console.WriteLine("These algorithms revolutionized data processing and made modern computing possible!\n");

        // Example 1: Sorting Algorithm Comparison
        Console.WriteLine("--- Example 1: Sorting Algorithm Comparison ---");
        CompareAllSortingAlgorithms();

        // Example 2: Merge Sort Deep Dive
        Console.WriteLine("\n--- Example 2: Merge Sort Deep Dive ---");
        MergeSortDemo();

        // Example 3: Quick Sort Deep Dive  
        Console.WriteLine("\n--- Example 3: Quick Sort Deep Dive ---");
        QuickSortDemo();

        // Example 4: Performance Analysis
        Console.WriteLine("\n--- Example 4: Performance Analysis ---");
        PerformanceAnalysis();

        // Example 5: When to Use Which Algorithm
        Console.WriteLine("\n--- Example 5: Algorithm Selection Guide ---");
        AlgorithmSelectionGuide();

        Console.WriteLine("\n🎯 Key Learning Points:");
        Console.WriteLine("• Merge Sort: O(n log n) guaranteed, stable, uses extra memory");
        Console.WriteLine("• Quick Sort: O(n log n) average, O(n²) worst case, in-place");
        Console.WriteLine("• Divide and conquer is a powerful problem-solving strategy");
        Console.WriteLine("• Algorithm choice depends on data size, memory, and stability needs");
        Console.WriteLine("• Understanding complexity helps choose the right tool for the job");
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void CompareAllSortingAlgorithms()
    {
        int[] originalArray = { 64, 34, 25, 12, 22, 11, 90, 5, 77, 30 };
        Console.WriteLine($"📊 Original array: [{string.Join(", ", originalArray)}]\n");

        // Test each algorithm
        Console.WriteLine("🫧 Bubble Sort (from Lesson 4):");
        int[] bubbleArray = (int[])originalArray.Clone();
        var bubbleStopwatch = Stopwatch.StartNew();
        BubbleSort(bubbleArray);
        bubbleStopwatch.Stop();
        Console.WriteLine($"   Result: [{string.Join(", ", bubbleArray)}]");
        Console.WriteLine($"   Time: {bubbleStopwatch.ElapsedTicks} ticks\n");

        Console.WriteLine("🔀 Merge Sort:");
        int[] mergeArray = (int[])originalArray.Clone();
        var mergeStopwatch = Stopwatch.StartNew();
        MergeSort(mergeArray, 0, mergeArray.Length - 1);
        mergeStopwatch.Stop();
        Console.WriteLine($"   Result: [{string.Join(", ", mergeArray)}]");
        Console.WriteLine($"   Time: {mergeStopwatch.ElapsedTicks} ticks\n");

        Console.WriteLine("⚡ Quick Sort:");
        int[] quickArray = (int[])originalArray.Clone();
        var quickStopwatch = Stopwatch.StartNew();
        QuickSort(quickArray, 0, quickArray.Length - 1);
        quickStopwatch.Stop();
        Console.WriteLine($"   Result: [{string.Join(", ", quickArray)}]");
        Console.WriteLine($"   Time: {quickStopwatch.ElapsedTicks} ticks\n");

        Console.WriteLine("📈 Speed Comparison (smaller is faster):");
        Console.WriteLine($"   Bubble Sort: {bubbleStopwatch.ElapsedTicks} ticks");
        Console.WriteLine($"   Merge Sort:  {mergeStopwatch.ElapsedTicks} ticks");
        Console.WriteLine($"   Quick Sort:  {quickStopwatch.ElapsedTicks} ticks");
    }

    static void MergeSortDemo()
    {
        Console.WriteLine("🔀 Merge Sort: 'Divide and Conquer' Strategy");
        Console.WriteLine("Strategy: Split array in half, sort each half, then merge them back together\n");

        int[] array = { 38, 27, 43, 3, 9, 82, 10 };
        Console.WriteLine($"📊 Starting array: [{string.Join(", ", array)}]");
        Console.WriteLine("\n🔄 Watch the divide and conquer process:");
        
        MergeSortWithVisualization(array, 0, array.Length - 1, 0);
        
        Console.WriteLine($"\n✅ Final sorted array: [{string.Join(", ", array)}]");
        Console.WriteLine("\n💡 Key Insights:");
        Console.WriteLine("   • Always splits exactly in half (balanced)");
        Console.WriteLine("   • Guaranteed O(n log n) performance");
        Console.WriteLine("   • Stable sort (maintains relative order of equal elements)");
        Console.WriteLine("   • Uses extra memory for temporary arrays");
    }

    static void QuickSortDemo()
    {
        Console.WriteLine("⚡ Quick Sort: 'Pivot and Partition' Strategy");
        Console.WriteLine("Strategy: Pick a pivot, partition around it, then sort each partition\n");

        int[] array = { 64, 34, 25, 12, 22, 11, 90 };
        Console.WriteLine($"📊 Starting array: [{string.Join(", ", array)}]");
        Console.WriteLine("\n🎯 Watch the pivot and partition process:");
        
        QuickSortWithVisualization(array, 0, array.Length - 1, 0);
        
        Console.WriteLine($"\n✅ Final sorted array: [{string.Join(", ", array)}]");
        Console.WriteLine("\n💡 Key Insights:");
        Console.WriteLine("   • Performance depends on pivot choice");
        Console.WriteLine("   • Average case: O(n log n), Worst case: O(n²)");
        Console.WriteLine("   • In-place sorting (uses minimal extra memory)");
        Console.WriteLine("   • Not stable (may change relative order of equal elements)");
    }

    static void PerformanceAnalysis()
    {
        Console.WriteLine("📊 Performance Analysis with Different Data Sizes:");
        Console.WriteLine();
        
        int[] sizes = { 100, 500, 1000, 2000 };
        
        Console.WriteLine("Data Size | Bubble Sort | Merge Sort | Quick Sort | Best Algorithm");
        Console.WriteLine("----------|-------------|------------|------------|---------------");
        
        foreach (int size in sizes)
        {
            // Generate random data
            Random rand = new Random(42); // Fixed seed for consistent results
            int[] data = new int[size];
            for (int i = 0; i < size; i++)
            {
                data[i] = rand.Next(1, 1000);
            }

            // Test Bubble Sort
            int[] bubbleData = (int[])data.Clone();
            var bubbleTime = Stopwatch.StartNew();
            BubbleSort(bubbleData);
            bubbleTime.Stop();

            // Test Merge Sort
            int[] mergeData = (int[])data.Clone();
            var mergeTime = Stopwatch.StartNew();
            MergeSort(mergeData, 0, mergeData.Length - 1);
            mergeTime.Stop();

            // Test Quick Sort
            int[] quickData = (int[])data.Clone();
            var quickTime = Stopwatch.StartNew();
            QuickSort(quickData, 0, quickData.Length - 1);
            quickTime.Stop();

            // Determine best algorithm
            long bubbleTicks = bubbleTime.ElapsedTicks;
            long mergeTicks = mergeTime.ElapsedTicks;
            long quickTicks = quickTime.ElapsedTicks;
            
            string best = "Quick Sort";
            if (mergeTicks < quickTicks && mergeTicks < bubbleTicks) best = "Merge Sort";
            else if (bubbleTicks < quickTicks && bubbleTicks < mergeTicks) best = "Bubble Sort";

            Console.WriteLine($"{size,9} | {bubbleTicks,11} | {mergeTicks,10} | {quickTicks,10} | {best}");
        }
        
        Console.WriteLine("\n💡 Observations:");
        Console.WriteLine("   • Bubble sort gets dramatically slower with more data");
        Console.WriteLine("   • Merge and Quick sort scale much better");
        Console.WriteLine("   • Quick sort is often fastest in practice");
        Console.WriteLine("   • Merge sort is more predictable (always O(n log n))");
    }

    static void AlgorithmSelectionGuide()
    {
        Console.WriteLine("🎯 When to Use Each Sorting Algorithm:");
        Console.WriteLine();
        
        Console.WriteLine("🫧 Bubble Sort:");
        Console.WriteLine("   ✅ Good for: Learning, very small datasets (< 50 items)");
        Console.WriteLine("   ❌ Avoid for: Any real-world application with > 100 items");
        Console.WriteLine("   📚 OCR Exams: Know how it works, understand O(n²) complexity");
        Console.WriteLine();
        
        Console.WriteLine("🔀 Merge Sort:");
        Console.WriteLine("   ✅ Good for: Stable sorting, guaranteed performance, external sorting");
        Console.WriteLine("   ✅ Use when: You need predictable O(n log n) performance");
        Console.WriteLine("   ❌ Avoid when: Memory is very limited (uses O(n) extra space)");
        Console.WriteLine("   🌍 Real-world: Database sorting, file merging, stable sorts");
        Console.WriteLine();
        
        Console.WriteLine("⚡ Quick Sort:");
        Console.WriteLine("   ✅ Good for: General-purpose sorting, in-place sorting");
        Console.WriteLine("   ✅ Use when: Average case performance matters most");
        Console.WriteLine("   ❌ Avoid when: Worst-case O(n²) is unacceptable");
        Console.WriteLine("   🌍 Real-world: Standard library sorts, system utilities");
        Console.WriteLine();
        
        Console.WriteLine("🏆 Modern Hybrid Approaches:");
        Console.WriteLine("   • C# Array.Sort() uses Introsort (Quick + Heap + Insertion)");
        Console.WriteLine("   • Python uses Timsort (Merge + Insertion)");
        Console.WriteLine("   • Java uses Dual-Pivot Quicksort");
        Console.WriteLine("   💡 Real systems combine multiple algorithms for best performance!");
    }

    // Bubble Sort (from previous lesson, for comparison)
    static void BubbleSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // Swap
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    // Merge Sort Implementation
    static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;
            
            // Sort first and second halves
            MergeSort(array, left, middle);
            MergeSort(array, middle + 1, right);
            
            // Merge the sorted halves
            Merge(array, left, middle, right);
        }
    }

    static void Merge(int[] array, int left, int middle, int right)
    {
        // Create temporary arrays for the two halves
        int leftSize = middle - left + 1;
        int rightSize = right - middle;
        
        int[] leftArray = new int[leftSize];
        int[] rightArray = new int[rightSize];
        
        // Copy data to temporary arrays
        Array.Copy(array, left, leftArray, 0, leftSize);
        Array.Copy(array, middle + 1, rightArray, 0, rightSize);
        
        // Merge the temporary arrays back into array[left..right]
        int i = 0, j = 0, k = left;
        
        while (i < leftSize && j < rightSize)
        {
            if (leftArray[i] <= rightArray[j])
            {
                array[k] = leftArray[i];
                i++;
            }
            else
            {
                array[k] = rightArray[j];
                j++;
            }
            k++;
        }
        
        // Copy remaining elements
        while (i < leftSize)
        {
            array[k] = leftArray[i];
            i++;
            k++;
        }
        
        while (j < rightSize)
        {
            array[k] = rightArray[j];
            j++;
            k++;
        }
    }

    // Quick Sort Implementation
    static void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            // Partition the array and get pivot index
            int pivotIndex = Partition(array, low, high);
            
            // Recursively sort elements before and after partition
            QuickSort(array, low, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, high);
        }
    }

    static int Partition(int[] array, int low, int high)
    {
        // Choose the rightmost element as pivot
        int pivot = array[high];
        int i = low - 1; // Index of smaller element
        
        for (int j = low; j < high; j++)
        {
            // If current element is smaller than or equal to pivot
            if (array[j] <= pivot)
            {
                i++;
                // Swap elements
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
        
        // Place pivot in correct position
        int temp2 = array[i + 1];
        array[i + 1] = array[high];
        array[high] = temp2;
        
        return i + 1;
    }

    // Visualization versions (with step-by-step output)
    static void MergeSortWithVisualization(int[] array, int left, int right, int depth)
    {
        string indent = new string(' ', depth * 2);
        
        if (left < right)
        {
            int middle = left + (right - left) / 2;
            
            Console.WriteLine($"{indent}📂 Split [{left}..{right}]: [{string.Join(", ", array[left..(right+1)])}]");
            Console.WriteLine($"{indent}   ↳ Left: [{left}..{middle}], Right: [{middle+1}..{right}]");
            
            MergeSortWithVisualization(array, left, middle, depth + 1);
            MergeSortWithVisualization(array, middle + 1, right, depth + 1);
            
            Merge(array, left, middle, right);
            Console.WriteLine($"{indent}🔗 Merged [{left}..{right}]: [{string.Join(", ", array[left..(right+1)])}]");
        }
    }

    static void QuickSortWithVisualization(int[] array, int low, int high, int depth)
    {
        string indent = new string(' ', depth * 2);
        
        if (low < high)
        {
            Console.WriteLine($"{indent}🎯 Partition [{low}..{high}]: [{string.Join(", ", array[low..(high+1)])}]");
            Console.WriteLine($"{indent}   Pivot: {array[high]}");
            
            int pivotIndex = Partition(array, low, high);
            
            Console.WriteLine($"{indent}   Result: [{string.Join(", ", array[low..(high+1)])}] (pivot at {pivotIndex})");
            
            QuickSortWithVisualization(array, low, pivotIndex - 1, depth + 1);
            QuickSortWithVisualization(array, pivotIndex + 1, high, depth + 1);
        }
    }
}
