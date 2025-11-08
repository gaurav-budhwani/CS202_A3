using System;
using System.Threading;
using System.Runtime.CompilerServices;

sealed class Demo
{
    public static int Alive;
    public static readonly CountdownEvent FinalizeCountdown = new CountdownEvent(3);

    private int data;

    public Demo()
    {
        Interlocked.Increment(ref Alive);
        Console.WriteLine($"Constructor Called | Alive={Alive}");
    }

    ~Demo()
    {
        Interlocked.Decrement(ref Alive);
        Console.WriteLine($"Object Destroyed | Alive={Alive}");
        // signal that one object has finalized
        FinalizeCountdown.Signal();
    }

    public void SetData(int x) => data = x;
    public void Show() => Console.WriteLine($"data = {data}");
}

class Program
{
    // Prevent inlining so locals really die at method end (important in Debug).
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void CreateAndUseThree()
    {
        var p1 = new Demo(); p1.SetData(10); p1.Show();
        var p2 = new Demo(); p2.SetData(20); p2.Show();
        var p3 = new Demo(); p3.SetData(30); p3.Show();
        // <-- p1, p2, p3 go out of scope after this method returns
    }

    static void Main()
    {
        CreateAndUseThree();

        // Force GC and wait for finalizers
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        // Wait (up to 5s) until all 3 finalizers have printed
        if (!Demo.FinalizeCountdown.Wait(5000))
        {
            // retry once if needed
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Demo.FinalizeCountdown.Wait(2000);
        }

        Console.WriteLine("After GC + finalizers. Press Enter to exit...");
        Console.ReadLine();
    }
}