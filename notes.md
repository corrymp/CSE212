# Dynamic Arrays

## Fixed Arrays
- does not grow or shrink
- all items same size
- adjacent in memory
- less memory use (metadata)

```c#
var numbers = new int[3];
numbers[0] = 1;
numbers[1] = 2;
numbers[2] = 3;
// OR
var numbers = new[] { 1, 2, 3 };
```

## Dynamic Arrays
- expandable (grows and shrinks)
- Size and Capacity
- doubles in Capacity when filled

```c#
var numbers = new List<int>();
numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
// OR
var numbers = new List<int> { 1, 2, 3 };
```

## Table of Common Operations
Operation               Code                        Description
`lookup(index)`         `value = list[index]`       Gets value at index
`append(value)`         `list.Add(value)`           Adds value to next index
`insert(index,value)`   `list.Insert(index,value)`  Adds value to index and moves all following items up an index
`remove(index)`         `list.Remove(index)`        Removes item at index and moves all following items down an index
`size()`                `list.Count`                Returns the size of the array
`capacity()`            `list.Capacity`             Returns the capacity of the array
`empty()`               `list.Count == 0`           Returns true if the array is empty

### Looping through Arrays and/or Lists
```c#
// iterator
foreach(var item in list) Console.WriteLine(item);

// list for loop
for (var i = 0; i < list.Count; i++) Console.WriteLine(list[i]);
// array for loop
for (var i = 0; i < array.Length; i++) Console.WriteLine(array[i]);
```
## Activity 

### With a pencil and paper (uh, no thanks. I choose death), draw a dynamic array with an initial capacity of 4.
```
-----------------
|   |   |   |   |
-----------------
  0   1   2   3
  Length: 4
  Capacity: 4
```

### Manually insert (by writing the letters in your boxes) the following: A, B, C, D, E. 
```
-----------------
| A | B | C | D |
-----------------
  0   1   2   3
  Length: 4
  Capacity: 4
```

### Observe what you need to do when adding the E.
```
---------------------
| A | B | C | D | E |
---------------------
  0   1   2   3   4
  Length: 5
  Capacity: 8
```

### Remove the letter B and add it to the end of the dynamic array. 
```
---------------------
| A | C | D | E | B |
---------------------
  0   1   2   3   4
  Length: 5
  Capacity: 8
```

### Observe the impact of adjusting something early in the list versus later in the list.
```
---------------------
| A | B | C | E | D |
---------------------
  0   1   2   3   4
  Length: 5
  Capacity: 8
```

====

# Big O Notation and Linear Performance

## O(n)
```c#
bool FindBob(List nameList) { 
    foreach (var name in nameList) 
        if (name == "Bob") 
            return true;

    return false;
}
```

## O(2n) -> O(n)
```c#
void MultipleLoops(int n) {
    for (int i = 0; i < n; i++) 
        Console.WriteLine(i);

    for (int j = 0; j < n; j++) 
        Console.WriteLine(j * j);
}
```

## O(n^2)
```c#
void MultiplicationTable(int n) {
    for (int i = 0; i < n; i++) 
        for (int j = 0; j < n; j++) 
            Console.WriteLine((i + 1) * (j + 1));
}
```

## O(3n) -> O(n)
```c#
void ShortMultiplicationTable(int n) {
    for (int i = 0; i < n; i++) 
        for (int j = 0; j < 3; j++) 
            Console.WriteLine((i + 1) * (j + 1));
}
```

## run: O( 10 O(LoL) );  LoL: O(n^3);  Time: O( O(Alg) * times );  Total: O(10n^3) -> O(n^3)
```c#
public void run() {
    var executionTime = Time(() => LotsOfLoops(100), 10);

    Console.WriteLine($"Execution Time: {executionTime} ms");
}

private void LotsOfLoops(int n) {
    int total = 0;

    for (int i = 0; i < n; i++) 
        for (int j = 0; j < n; j++) 
            for (int k = 0; k < n; k++) 
                total += i * j * k;

    Console.WriteLine(total);
}

private double Time(Action executeAlgorithm, int times) {
    var sw = Stopwatch.StartNew();

    for (var i = 0; i < times; ++i) executeAlgorithm();

    sw.Stop();

    return sw.Elapsed.TotalMilliseconds / times;
}
```

## Run: O( 1000 O(LoL) ); LoL: O(n^3); Total: O(1000n^3) -> O(n^3)
```c#
public void run() {
    var stopwatch = Stopwatch.StartNew();
    var work = LotsOfLoops(1000);

    stopwatch.Stop();
    
    Console.WriteLine("Innermost count is: {0} ms", work);
    Console.WriteLine("Execution Time: {0} ms", stopwatch.Elapsed.TotalMilliseconds);
}

private void LotsOfLoops(int n) {
    int total = 0;
    int count = 0;

    for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++)
            for (int k = 0; k < n; k++) {
                total += i * j * k;
                count++;
            }

    Console.WriteLine(total);

    return count;
}
```

## O(2n) -> O(n)
```c#
static void DoSomething(int n) {
    for (int i = 0; i < n; i++) 
        Console.WriteLine(n * n);

    for (i = n; i > 0; i--) 
        Console.WriteLine(n * n * n);
}
```

## O(n^2)
```c#
static void DoSomethingElse(List<string> words) {
    for (int i = 0; i < words.Count; i++) 
        for (int j = 0; j < words.Count; j++) 
            Console.WriteLine(".");
}
```

## O(43n) -> O(n)
```c#
static void DoAnotherThing(List<string> words) {
    string sentence = "The quick brown fox jumps over the lazy dog";

    for (int i = 0; i < words.Count i++) 
        for(int j = 0; j < sentence.Length; j++) 
            Console.WriteLine(".");
}
```

====

# Analysis

## Part 1: Analyze Code

- Open the file Sorting.cs and determine the big O notation for the SortArray function.

> O(n^2)
> (O(.5n^2 - .5n) with coefficients)


- Open the file StandardDeviation.cs 
- determine the big O notation for the three implementations.

> 1. O(n) (O(2n) with constants)
> 2. O(n^2)
> 3. O(n) (O(2n) with constants assuming .Sum() is also O(n))


- Using either a graphing calculator or a graphing website (e.g. desmos.com), 
  put the following in order (best performance, …, worst performance) for when n is large:
  O(n^2), O(1), O(2^n), O(n log n), O(log n), O(n)

> O(1)
> O(log n)
> O(n)
> O(n log n)
> O(n^2)
> O(2^n)


## Part 2: Predicting, Measuring, and Comparing - Two Sorting Algorithms

- Open up the following code: Search.cs
- This file contains two different functions called SearchSorted1 and SearchSorted2. 
- Both of these functions will search for an item in a sorted list. 
- Predict the performance of each function using big O notation and 

> 1. O(n)
> 2. O(log n)


- provide your answer in the response document.

> 1. goes over every number in order untill it finds the target
> 2. starts in the middle of the list and keeps cutting the search reagion in half until it finds the target


- Run the code and observe the outputs. 

- Here is what the columns in the table represent:
  - n           -   The size of the data given to the functions in this test
  - sort1-count -   The number of loop iterations (i.e. work) done by SearchSorted1
  - sort2-count -   The number of loop iterations (i.e. work) done by SearchSorted2
  - sort1-time  -   The time in milliseconds it took to complete SearchSorted1
  - sort2-time  -   The time in milliseconds it took to complete SearchSorted2

- Answer the following questions:
  - What is the performance using big O notation for each function (based on both your predictions and the actual results)?
  - Which function has the better performance in the worst case?

> 1. O(n): when looking for a number not in the sorted list, it had to check every number to verify that fact
> 2. O(log n): when looking for a number not in the sorted list, it 

> 2 had better performance

====

