using System;

// Using top-level statements (C# 9+).
// This avoids the need for a 'class Program' and 'static void Main()'.

// 1. Get user input
Console.Write("Enter first number: ");
double x = double.Parse(Console.ReadLine()!);

Console.Write("Enter second number: ");
double y = double.Parse(Console.ReadLine()!);

// 2. Perform calculations and display results
// Addition
double sum = x + y;
Console.WriteLine($"Add: {sum}");

// Subtraction
Console.WriteLine($"Sub: {x - y}");

// Multiplication
Console.WriteLine($"Mul: {x * y}");

// Division with error handling
try
{
    if (y == 0)
    {
        // Manually throw the exception to be caught below
        throw new DivideByZeroException("Division by zero");
    }
    Console.WriteLine($"Div: {x / y}");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine(ex.Message);
}

// 3. Check if the sum is even or odd
// We use Math.Abs and a small tolerance (1e-9)
// because of potential floating-point inaccuracies.
if (Math.Abs(sum % 2) < 1e-9)
{
    Console.WriteLine("Sum is even");
}
else
{
    Console.WriteLine("Sum is odd");
}