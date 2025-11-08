using System;

class Program
{
    static void Main()
    {
        // Bubble Sort
        int[] a = { 5, 2, 9, 1, 5, 6 };
        BubbleSort(a);
        Console.WriteLine("Bubble-sorted: " + string.Join(" ", a));

        // 2D to 1D (row-major and column-major)
        int[,] m = { { 1, 2, 3 }, { 4, 5, 6 } }; // 2x3
        int[] rowMajor = ToRowMajor(m);
        int[] colMajor = ToColMajor(m);
        Console.WriteLine("Row-major: " + string.Join(" ", rowMajor));
        Console.WriteLine("Col-major: " + string.Join(" ", colMajor));

        // Matrix multiplication C = A x B
        int[,] A = { { 1, 2 }, { 3, 4 } };       // 2x2
        int[,] B = { { 5, 6 }, { 7, 8 } };       // 2x2
        int[,] C = Multiply(A, B);         // 2x2
        Console.WriteLine("C = A x B:");
        Print2D(C);
    }

    static void BubbleSort(int[] arr)
    {
        for (int n = arr.Length; n > 1; n--)
        {
            bool swapped = false;
            for (int i = 0; i < n - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
                    swapped = true;
                }
            }
            if (!swapped) break;
        }
    }

    static int[] ToRowMajor(int[,] m)
    {
        int r = m.GetLength(0), c = m.GetLength(1), k = 0;
        int[] outArr = new int[r * c];
        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                outArr[k++] = m[i, j];
        return outArr;
    }

    static int[] ToColMajor(int[,] m)
    {
        int r = m.GetLength(0), c = m.GetLength(1), k = 0;
        int[] outArr = new int[r * c];
        for (int j = 0; j < c; j++)
            for (int i = 0; i < r; i++)
                outArr[k++] = m[i, j];
        return outArr;
    }

    static int[,] Multiply(int[,] A, int[,] B)
    {
        int rA = A.GetLength(0), cA = A.GetLength(1);
        int rB = B.GetLength(0), cB = B.GetLength(1);
        if (cA != rB) throw new ArgumentException("Incompatible dimensions");

        int[,] C = new int[rA, cB];
        for (int i = 0; i < rA; i++)
            for (int j = 0; j < cB; j++)
            {
                int sum = 0;
                for (int k = 0; k < cA; k++) sum += A[i, k] * B[k, j];
                C[i, j] = sum;
            }
        return C;
    }

    static void Print2D<T>(T[,] m)
    {   
        int r = m.GetLength(0), c = m.GetLength(1);
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++) Console.Write(m[i, j] + (j + 1 < c ? " " : ""));
            Console.WriteLine();
        }
    }
}