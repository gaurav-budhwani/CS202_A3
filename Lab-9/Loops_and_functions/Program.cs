using System;
using System.Numerics;

// for loop: 1..10
Console.Write("For loop: \n");
for (int i = 1; i <= 10; i++)
{
    Console.Write(i + (i < 10 ? " " : "\n"));
}

// foreach: 1..10
Console.WriteLine("For each loop:");
int[] arr = new int[10];
for (int i = 0; i < 10; i++)
{
    arr[i] = i + 1;
}

foreach (var v in arr)
{
    Console.Write(v + (v < 10 ? " " : "\n"));
}
string? s;
do
{
    Console.Write("Type anything (or 'exit' to quit): ");
    s = Console.ReadLine();
} while (!string.Equals(s, "exit", StringComparison.OrdinalIgnoreCase));

// factorial
Console.Write("Enter a non-negative integer for factorial: ");
if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
{
    Console.WriteLine($"n! = {Factorial(n)}");
}
else
{
    Console.WriteLine("Invalid input.");
}


// Local Function
// In top-level statements, you can use local functions 
// instead of static methods in a class.
static BigInteger Factorial(int n)
{
    BigInteger f = 1;
    for (int i = 2; i <= n; i++)
    {
        f *= i;
    }
    return f;
}