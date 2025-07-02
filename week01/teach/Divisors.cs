public static class Divisors {
    /// <summary>
    /// Entry point for the Divisors class
    /// </summary>
    public static void Run() {
        List<int> list = FindDivisors(80);
        Console.WriteLine("<List>{" + string.Join(", ", list) + "}"); // <List>{1, 2, 4, 5, 8, 10, 16, 20, 40}
        List<int> list1 = FindDivisors(79);
        Console.WriteLine("<List>{" + string.Join(", ", list1) + "}"); // <List>{1}
    }

    /// <summary>
    /// Create a list of all divisors for a number including 1
    /// and excluding the number itself. Modulo will be used
    /// to test divisibility.
    /// </summary>
    /// <param name="number">The number to find the divisor</param>
    /// <returns>List of divisors</returns>
    private static List<int> FindDivisors(int number) { // O(n) { O(n / 2 - 1) }

        // why start the loop with 1 when you already know it will be included?
        List<int> results = [1];

        // why end at the number when you already have all the results at the half way point?
        for (int i = 2, l = number / 2 + 1; i < l; i++)
            if (number % i == 0)
                results.Add(i);

        return results;
    }
}