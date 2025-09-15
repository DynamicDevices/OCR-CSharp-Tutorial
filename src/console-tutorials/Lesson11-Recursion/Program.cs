using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("🔄 Recursion - OCR A-Level");
        Console.WriteLine("==========================\n");

        // Example 1: Factorial
        Console.WriteLine("--- Example 1: Factorial ---");
        int number = 5;
        Console.WriteLine($"Calculating {number}! (factorial)");
        Console.WriteLine($"Iterative method: {FactorialIterative(number)}");
        Console.WriteLine($"Recursive method: {FactorialRecursive(number)}");
        Console.WriteLine($"Step-by-step for {number}!:");
        TraceFactorial(number);
        Console.WriteLine();

        // Example 2: Fibonacci Sequence
        Console.WriteLine("--- Example 2: Fibonacci Sequence ---");
        int fibCount = 10;
        Console.WriteLine($"First {fibCount} Fibonacci numbers:");
        Console.Write("Iterative: ");
        for (int i = 0; i < fibCount; i++)
        {
            Console.Write($"{FibonacciIterative(i)} ");
        }
        Console.WriteLine();

        Console.Write("Recursive: ");
        for (int i = 0; i < fibCount; i++)
        {
            Console.Write($"{FibonacciRecursive(i)} ");
        }
        Console.WriteLine();

        Console.WriteLine($"\nFibonacci(7) = {FibonacciRecursive(7)}");
        Console.WriteLine("Tracing Fibonacci(5):");
        TraceFibonacci(5, 0);
        Console.WriteLine();

        // Example 3: Binary Tree Traversal
        Console.WriteLine("--- Example 3: Binary Tree Traversal ---");
        BinaryTree tree = new BinaryTree();
        tree.Insert(50);
        tree.Insert(30);
        tree.Insert(70);
        tree.Insert(20);
        tree.Insert(40);
        tree.Insert(60);
        tree.Insert(80);

        Console.WriteLine("Binary Search Tree created with values: 50, 30, 70, 20, 40, 60, 80");
        Console.WriteLine("Tree structure:");
        Console.WriteLine("       50");
        Console.WriteLine("      /  \\");
        Console.WriteLine("    30    70");
        Console.WriteLine("   / \\   / \\");
        Console.WriteLine("  20 40 60 80");
        Console.WriteLine();

        Console.Write("In-Order Traversal (Left-Root-Right): ");
        tree.InOrderTraversal();
        Console.WriteLine();

        Console.Write("Pre-Order Traversal (Root-Left-Right): ");
        tree.PreOrderTraversal();
        Console.WriteLine();

        Console.Write("Post-Order Traversal (Left-Right-Root): ");
        tree.PostOrderTraversal();
        Console.WriteLine();
        Console.WriteLine();

        // Example 4: Tower of Hanoi
        Console.WriteLine("--- Example 4: Tower of Hanoi ---");
        int disks = 3;
        Console.WriteLine($"Solving Tower of Hanoi with {disks} disks:");
        Console.WriteLine("Moving disks from Tower A to Tower C using Tower B as auxiliary");
        TowerOfHanoi(disks, 'A', 'C', 'B');
        Console.WriteLine();

        // Example 5: Sum of Array using Recursion
        Console.WriteLine("--- Example 5: Array Sum Recursion ---");
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Console.WriteLine($"Array: [{string.Join(", ", numbers)}]");
        Console.WriteLine($"Sum using iteration: {SumArrayIterative(numbers)}");
        Console.WriteLine($"Sum using recursion: {SumArrayRecursive(numbers, 0)}");
        Console.WriteLine();

        // Example 6: String Reversal
        Console.WriteLine("--- Example 6: String Reversal ---");
        string text = "Hello World";
        Console.WriteLine($"Original string: \"{text}\"");
        Console.WriteLine($"Reversed (iterative): \"{ReverseStringIterative(text)}\"");
        Console.WriteLine($"Reversed (recursive): \"{ReverseStringRecursive(text)}\"");
        Console.WriteLine();

        // Example 7: Greatest Common Divisor (GCD)
        Console.WriteLine("--- Example 7: Greatest Common Divisor (Euclidean Algorithm) ---");
        int a = 48, b = 18;
        Console.WriteLine($"Finding GCD of {a} and {b}:");
        Console.WriteLine($"GCD({a}, {b}) = {GCD(a, b)}");
        Console.WriteLine("Steps:");
        TraceGCD(a, b, 1);
        Console.WriteLine();

        // Interactive section
        Console.WriteLine("--- Interactive Challenge ---");
        Console.Write("Enter a number to calculate its factorial: ");
        string input = Console.ReadLine() ?? "5";
        if (int.TryParse(input, out int userNumber) && userNumber >= 0 && userNumber <= 12)
        {
            Console.WriteLine($"{userNumber}! = {FactorialRecursive(userNumber)}");
        }
        else
        {
            Console.WriteLine("Please enter a valid number between 0 and 12.");
        }
    }

    // Factorial using recursion
    static int FactorialRecursive(int n)
    {
        // Base case: 0! = 1 and 1! = 1
        if (n <= 1)
            return 1;

        // Recursive case: n! = n * (n-1)!
        return n * FactorialRecursive(n - 1);
    }

    // Factorial using iteration (for comparison)
    static int FactorialIterative(int n)
    {
        int result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    // Trace factorial calculation
    static void TraceFactorial(int n)
    {
        Console.WriteLine($"  {n}! = {n} × {n-1}!");
        if (n > 1)
        {
            TraceFactorial(n - 1);
        }
        else
        {
            Console.WriteLine($"  1! = 1 (base case)");
        }
    }

    // Fibonacci using recursion
    static int FibonacciRecursive(int n)
    {
        // Base cases: F(0) = 0, F(1) = 1
        if (n <= 1)
            return n;

        // Recursive case: F(n) = F(n-1) + F(n-2)
        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    // Fibonacci using iteration (for comparison)
    static int FibonacciIterative(int n)
    {
        if (n <= 1) return n;

        int a = 0, b = 1;
        for (int i = 2; i <= n; i++)
        {
            int temp = a + b;
            a = b;
            b = temp;
        }
        return b;
    }

    // Trace Fibonacci calculation
    static int TraceFibonacci(int n, int depth)
    {
        string indent = new string(' ', depth * 2);
        Console.WriteLine($"{indent}Fib({n})");

        if (n <= 1)
        {
            Console.WriteLine($"{indent}  = {n} (base case)");
            return n;
        }

        int result1 = TraceFibonacci(n - 1, depth + 1);
        int result2 = TraceFibonacci(n - 2, depth + 1);
        int result = result1 + result2;

        Console.WriteLine($"{indent}  = {result1} + {result2} = {result}");
        return result;
    }

    // Sum array using recursion
    static int SumArrayRecursive(int[] arr, int index)
    {
        // Base case: if we've processed all elements
        if (index >= arr.Length)
            return 0;

        // Recursive case: current element + sum of remaining elements
        return arr[index] + SumArrayRecursive(arr, index + 1);
    }

    // Sum array using iteration (for comparison)
    static int SumArrayIterative(int[] arr)
    {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;
    }

    // Reverse string using recursion
    static string ReverseStringRecursive(string str)
    {
        // Base case: empty or single character string
        if (str.Length <= 1)
            return str;

        // Recursive case: last character + reverse of remaining string
        return str[str.Length - 1] + ReverseStringRecursive(str.Substring(0, str.Length - 1));
    }

    // Reverse string using iteration (for comparison)
    static string ReverseStringIterative(string str)
    {
        char[] chars = str.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }

    // Greatest Common Divisor using Euclidean algorithm (recursive)
    static int GCD(int a, int b)
    {
        // Base case: if b is 0, then GCD is a
        if (b == 0)
            return a;

        // Recursive case: GCD(a, b) = GCD(b, a mod b)
        return GCD(b, a % b);
    }

    // Trace GCD calculation
    static int TraceGCD(int a, int b, int step)
    {
        Console.WriteLine($"  Step {step}: GCD({a}, {b})");

        if (b == 0)
        {
            Console.WriteLine($"  Result: {a} (base case: b = 0)");
            return a;
        }

        int remainder = a % b;
        Console.WriteLine($"    {a} = {b} × {a / b} + {remainder}");
        return TraceGCD(b, remainder, step + 1);
    }

    // Tower of Hanoi solution
    static void TowerOfHanoi(int disks, char source, char destination, char auxiliary)
    {
        // Base case: only one disk to move
        if (disks == 1)
        {
            Console.WriteLine($"  Move disk 1 from {source} to {destination}");
            return;
        }

        // Move n-1 disks from source to auxiliary tower
        TowerOfHanoi(disks - 1, source, auxiliary, destination);

        // Move the largest disk from source to destination
        Console.WriteLine($"  Move disk {disks} from {source} to {destination}");

        // Move n-1 disks from auxiliary to destination tower
        TowerOfHanoi(disks - 1, auxiliary, destination, source);
    }
}

// Binary Tree class for traversal examples
class TreeNode
{
    public int Data { get; set; }
    public TreeNode? Left { get; set; }
    public TreeNode? Right { get; set; }

    public TreeNode(int data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}

class BinaryTree
{
    private TreeNode? root;

    public void Insert(int data)
    {
        root = InsertRecursive(root, data);
    }

    private TreeNode InsertRecursive(TreeNode? node, int data)
    {
        // Base case: if node is null, create new node
        if (node == null)
            return new TreeNode(data);

        // Recursive case: insert in appropriate subtree
        if (data < node.Data)
            node.Left = InsertRecursive(node.Left, data);
        else if (data > node.Data)
            node.Right = InsertRecursive(node.Right, data);

        return node;
    }

    public void InOrderTraversal()
    {
        InOrderRecursive(root);
    }

    private void InOrderRecursive(TreeNode? node)
    {
        if (node != null)
        {
            InOrderRecursive(node.Left);   // Visit left subtree
            Console.Write($"{node.Data} ");  // Visit root
            InOrderRecursive(node.Right);  // Visit right subtree
        }
    }

    public void PreOrderTraversal()
    {
        PreOrderRecursive(root);
    }

    private void PreOrderRecursive(TreeNode? node)
    {
        if (node != null)
        {
            Console.Write($"{node.Data} ");  // Visit root
            PreOrderRecursive(node.Left);   // Visit left subtree
            PreOrderRecursive(node.Right);  // Visit right subtree
        }
    }

    public void PostOrderTraversal()
    {
        PostOrderRecursive(root);
    }

    private void PostOrderRecursive(TreeNode? node)
    {
        if (node != null)
        {
            PostOrderRecursive(node.Left);   // Visit left subtree
            PostOrderRecursive(node.Right);  // Visit right subtree
            Console.Write($"{node.Data} ");    // Visit root
        }
    }
}
