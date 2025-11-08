// output reasoning level 0

/*
using System; //namespace
class Program //default visibility4 is ‘internal’ if not specified
{
    ublic static void Main(string[] args)
    {
    int a = 0; //default visibility is ‘private’ (in a class)
    Console.WriteLine(a++);
    }
}
*/

/*
using System;
class Program
{
    public void Main(string[] args) 
    {
    int a = 0;
    Console.WriteLine(a++);
    }
}
*/

// output reasoning level 1
/*
class Program
{
    public static void Main(string[] args)
    {
    int a = 0;
    int b = a++;
    Console.WriteLine(a++.ToString(),++a,-a++);
    Console.WriteLine((a++).ToString() + (-a++).ToString());
    Console.WriteLine(~b);
    }
}
*/

/*
using System;
//you can also write top level code outside of a class. C# takes
care of this by providing internal entry point Main
Console.WriteLine("int x = 3;");
Console.WriteLine("int y = 2 + ++x;");
int x = 3; //default visibility is ‘internal’ (outside a class)
int y = 2 + ++x;
Console.WriteLine($"x = {x} and y = {y}");
Console.WriteLine("x = 3 << 2;");
Console.WriteLine("y = 10 >> 1;");
x = 3 << 2;
y = 10 >> 1;
Console.WriteLine($"x = {x} and y = {y}");
x = ~x;
y = ~y;
Console.WriteLine($"x = {x} and y = {y}");
*/

// output reasoning level 2
/*
using System;
public class Program
{
    static void Main()
    {
        try
        {
            int i=int.MaxValue;
            Console.WriteLine(-(i+1)-i);
            for(i=0; i<=int.MaxValue;i++); //note semicolon here
            Console.WriteLine("Program ended!");
        }
    catch(Exception ex)
    {   
        Console.WriteLine(ex.ToString());
    }
    }
}   
*/

using System;
public class Program
{
    static void Main(string[] args)
    {
        Main(["CS202"]);
    }
}