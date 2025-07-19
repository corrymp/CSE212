public class Program
{
    public static void Main()
    {
        SayHello(10);

        for(int i = 1; i < 6; i++) Console.WriteLine("[Factorial] {0}! = {1}", i, Factorial(i));

        for (int i = 1; i < 10; i++) Console.WriteLine("[Fibonacci] Fib({0}) = {1}", i, Fib(i));

        Permutations("ABCD");

        int[] arr = [1,3,6,18,20,25,34,38,89,95,99,100];
        Console.WriteLine("[BinarySearch] 89 in arr: {0}", BinarySearch(arr, 89));
        Console.WriteLine("[BinarySearch] 1 in arr: {0}", BinarySearch(arr, 1));
        Console.WriteLine("[BinarySearch] 17 in arr: {0}", BinarySearch(arr, 17));

        int[] nums = [1, 2, 3, 5, 8, 10];
        foreach (int n in nums) Console.WriteLine("[SumNum] 0 + ... + {0} = {1}", n, SumNum(n));
    }

    public static void SayHello(int count)
    {
        if (count <= 0) return;
        Console.WriteLine("Hello");
        SayHello(count - 1);
    }

    public static int Factorial(int n)
    {
        if (n <= 1) return 1;
        return n * Factorial(n - 1);
    }

    public static long Fib(int n, Dictionary<int, long> mem = null)
    {
        if (mem == null) mem = new Dictionary<int, long>();
        if (n <= 2) return 1;
        if (mem.TryGetValue(n, out long v)) return v;
        var res = Fib(n - 1) + Fib(n - 2);
        mem[n] = res;
        return res;
    }

    public static void Permutations(string letters, string word = "")
    {
        if (letters.Length == 0) {
            Console.WriteLine(word);
            return;
        }
        for (int i = 0; i < letters.Length; i++) Permutations(letters.Remove(i, 1), word + letters[i]);
    }

    public static bool BinarySearch(int[] sortedArray, int target)
    {
        if (sortedArray.Length == 1) return target == sortedArray[0];
        var middle = sortedArray.Length / 2;
        if (target == sortedArray[middle]) return true;
        if (target < sortedArray[middle]) return BinarySearch(sortedArray[..middle], target);
        return BinarySearch(sortedArray[middle..], target);
    }

    public static int SumNum(int n)
    {
        if (n <= 1) return 1;
        return n + SumNum(n - 1);
    }
}