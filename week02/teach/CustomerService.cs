/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: The queue size should be what is written, unless less than or equal to 0, in which case it's 10
        // Expected Result: 10, 10, 1
        Console.WriteLine("Test 1");

        var cs = new CustomerService(0);
        Console.WriteLine("should be: [size=0 maxSize=10 => ]; is: ", cs);

        cs = new CustomerService(-1);
        Console.WriteLine("should be: [size=0 maxSize=10 => ]; is: ", cs);

        cs = new CustomerService(1);
        Console.WriteLine("should be: [size=0 maxSize=1 => ]; is: ", cs);

        // Defect(s) Found: null

        Console.WriteLine("=================");

        // Test 2
        // Scenario: The queue should not accept up to and including the specified size, and should give an error message if attempting to add while full
        // Expected Result: add, add, add, no add
        Console.WriteLine("Test 2");

        Console.ToggleUsingTestInputs(true);
        cs = new CustomerService(3);
        Console.WriteLine("should be: [size=0 maxSize=3 => ]; is: ", cs);
        cs.AddNewCustomer();
        Console.WriteLine("should be: [size=1 maxSize=3 => (...) ]; is: ", cs);
        cs.AddNewCustomer();
        Console.WriteLine("should be: [size=2 maxSize=3 => (...) ]; is: ", cs);
        cs.AddNewCustomer();
        Console.WriteLine("should be: [size=3 maxSize=3 => (...) ]; is: ", cs);
        cs.AddNewCustomer();
        Console.WriteLine("should be: [size=3 maxSize=3 => (...) ]; is: ", cs);

        // Defect(s) Found: off-by-one-error

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3
        // Scenario: The queue should display the details of customers served, and should give an error message if attempting to serve a customer when there are none
        // Expected Result: add, add, serve, serve, no serve
        Console.WriteLine("Test 3");

        cs = new CustomerService(2);
        Console.WriteLine("should be: [size=0 maxSize=2 => ]; is: ", cs);
        Console.ToggleUsingTestInputs();
        cs.AddNewCustomer();
        Console.ToggleUsingTestInputs();
        Console.WriteLine("should be: [size=1 maxSize=2 => (...) ]; is: ", cs);
        cs.AddNewCustomer();
        Console.WriteLine("should be: [size=2 maxSize=2 => (...) ]; is: ", cs);
        cs.ServeCustomer();
        Console.WriteLine("should be: [size=1 maxSize=2 => (...) ]; is: ", cs);
        cs.ServeCustomer();
        Console.WriteLine("should be: [size=0 maxSize=2 => ]; is: ", cs);
        cs.ServeCustomer();
        Console.WriteLine("should be: [size=0 maxSize=2 => ]; is: ", cs);
        // Defect(s) Found: customer was removed from queue before being saved to return, thus skipping them. There were no checks for empty queues which caused crashes
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count > 0) {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }

        Console.WriteLine("All customers have been served.");
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}

// The solution to the "I don't want to type it every time" problem:
public static class Console {
    private static bool useTestInputs = false;
    private static int testInputIndex = 0;
    public static bool ToggleUsingTestInputs(bool? state = null) {
        bool currentState = useTestInputs;
        if (state != null) useTestInputs = (bool)state;
        else useTestInputs = !useTestInputs;
        System.Console.WriteLine("Toggled using test inputs to {0} (was {1})", useTestInputs, currentState);
        return useTestInputs;
    }
    private static readonly string[] testInputs = [
        "Corry", "0", "I need help testing!",
        "Dinis", "1", "I need help helping test!",
        "Maximiliano", "2", "I need help helping helping test!",
        "Faharetana", "3", "I just want to say hi!"
    ];
    private static int fallbackIndex = 0;
    private static string FallbackInputs() {
        string[] alphanumerics = ["A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z","0","1","2","3","4","5","6","7","8","9"];
        string l = alphanumerics[fallbackIndex % alphanumerics.Length];
        fallbackIndex++;
        return l;
    }
    public static void Write(params object[] strs) => System.Console.Write(string.Join("", strs));
    public static void WriteLine(params object[] strs) => System.Console.WriteLine(string.Join("",strs));
    public static string ReadLine() {
        if (useTestInputs) {
            string res;
            if (testInputIndex < testInputs.Length) res = testInputs[testInputIndex++];
            else res = FallbackInputs();
            System.Console.WriteLine(res);
            return res;
        }
        return System.Console.ReadLine();
    }
}
