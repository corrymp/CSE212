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

# Stacks
## Undo Example
```
front                                                                      back
--------------------------------------------------------------------------------- push |
| type  | type   | type | type    | type     | type    | type | type  | type    |   <---
| "The" | "rain" | "in" | "Spain" | "mainly" | "stays" | "in" | "the" | "plain" |   ---|
--------------------------------------------------------------------------------- pop  V

undo
-----------------------------------------------------------------------
| type  | type   | type | type    | type     | type    | type | type  |
| "The" | "rain" | "in" | "Spain" | "mainly" | "stays" | "in" | "the" |
-----------------------------------------------------------------------

undo x5
-------------------------
| type  | type   | type |
| "The" | "rain" | "in" |
-------------------------

type new words
-----------------------------------------------------------------------------
| type  | type   | type | type      | type    | type     | type | type      |
| "The" | "rain" | "in" | "Rexburg" | "stays" | "mainly" | "in" | "Rexburg" |
-----------------------------------------------------------------------------
```

## Function Stack
```
A -> ((B -> C) && (B -> D -> E))
A(){ B(){ C(); D(){ E() }}}

E(){}
D(){ E(); }
C(){}
B(){ C(); D(); }
A(){ B(); }
A();

  ---   |       Front   Back
  |A|   | A running |A|
  ---   | B running |A|B|
   |    | C running |A|B|C|
   V    | C finish  |A|B|
  ---   | D running |A|B|D|
  |B|   | E running |A|B|D|E|
  ---   | E finish  |A|B|D|
  | |   | D finish  |A|B|
 |- -|  | B finish  |A|
 V   V  | A finish  |
--- --- |
|C| |D| | 
--- --- |
     |  |
     V  |
    --- | 
    |E| |
    --- |
```

## C# Stack Methods
Operation   Code                    Performance     Description
push(val)   stack.Push(val);        O(1)            Adds val to back of stack
pop()       var val = stack.Pop();  O(1)            Removes and returns item from back of stack
size()      var len = stack.Count;  O(1)            Returns stack size
empty()     if(stack.Count == 0){}  O(1)            true if empty stack

## Activity
```cs
using System;
using System.Collections.Generic;

Console.WriteLine("\n======================\nSimple Stack\n======================");

var stack = new Stack<int>();
stack.Push(1);
stack.Push(2);
stack.Push(3);
stack.Pop();
stack.Pop();
stack.Push(4);
stack.Push(5);
stack.Pop();
stack.Push(6);
stack.Push(7);
stack.Push(8);
stack.Push(9);
stack.Pop();
stack.Pop();
stack.Push(10);
stack.Pop();
stack.Pop();
stack.Pop();
stack.Push(11);
stack.Push(12);
stack.Pop();
stack.Pop();
stack.Pop();
stack.Push(13);
stack.Push(14);
stack.Push(15);
stack.Push(16);
stack.Pop();
stack.Pop();
stack.Pop();
stack.Push(17);
stack.Push(18);
stack.Pop();
stack.Push(19);
stack.Push(20);
stack.Pop();
stack.Pop();

Console.WriteLine("Final contents:");
Console.WriteLine(String.Join(", ", stack.ToArray()));
```
What is the output?
> 
> ======================
> Simple Stack
> ======================
> Final contents:
> 1, 13, 17

# Queues
## Common Queue Methods
Operation       Code                    Performance     Description
enqueue(val)    q.Enqueue(val);         O(1)            Adds val to back of queue
dequeue()       var val = q.Dequeue();  O(1)            Removed item from queue
size()          q.Count;                O(1)            Number of queued items
empty()         if(q.Count == 0){}      O(1)            true if empty queue

## Example Code: character queue
```cs
var q = new Queue<char>();
q.Enqueue('A');
char ch = q.Dequeue(); // => 'A'
```

## Activity
```cs
using System;
using System.Collections.Generic;

Console.WriteLine("\n======================\nSimple Queue\n======================");

var queue = new Queue<int>();
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);
queue.Dequeue();
queue.Dequeue();
queue.Enqueue(4);
queue.Enqueue(5);
queue.Dequeue();
queue.Enqueue(6);
queue.Enqueue(7);
queue.Enqueue(8);
queue.Enqueue(9);
queue.Dequeue();
queue.Dequeue();
queue.Enqueue(10);
queue.Dequeue();
queue.Dequeue();
queue.Dequeue();
queue.Enqueue(11);
queue.Enqueue(12);
queue.Dequeue();
queue.Dequeue();
queue.Dequeue();
queue.Enqueue(13);
queue.Enqueue(14);
queue.Enqueue(15);
queue.Enqueue(16);
queue.Dequeue();
queue.Dequeue();
queue.Dequeue();
queue.Enqueue(17);
queue.Enqueue(18);
queue.Dequeue();
queue.Enqueue(19);
queue.Enqueue(20);
queue.Dequeue();
queue.Dequeue();

Console.WriteLine("Final contents:");
Console.WriteLine(String.Join(", ", queue.ToArray()));
```
What is the output?
> ======================
> Simple Queue
> ======================
> Final contents:
> 18, 19, 20

# Code Review
## Activity
```cs
// MysteryProgram.cs
using System;
using System.Collections.Generic;

class D
{
    static void Main()
    {
        int[] d = R(5);
        Array.Sort(d);
        Console.WriteLine("Values: " + string.Join(", ", d));
        int s = C(d);
        Console.WriteLine("Total: " + s);
    }

    static int[] R(int n)
    {
        Random r = new Random();
        int[] d = new int[n];
        for (int i = 0; i < n; i++)
        {
            d[i] = r.Next(1, 7);
        }
        return d;
    }

    static int C(int[] d)
    {
        int s = 0;
        Dictionary<int, int> c = new Dictionary<int, int>();
        foreach (int x in d)
        {
            if (c.ContainsKey(x))
            {
                c[x]++;
            }
            else
            {
                c[x] = 1;
            }
        }
        foreach (int v in c.Values)
        {
            switch (v)
            {
                case 2:
                    s += 10;
                    break;
                case 3:
                    s += 20;
                    break;
                case 4:
                    s += 30;
                    break;
                case 5:
                    s += 40;
                    break;
            }
        }
        return s;
    }
}
```

```cs
// MysteryProgram.cs (re-writen with loops unrolled and using my JavaScript logic so idk if it actually runs)
using System;
using System.Collections.Generic;
class Program {
    static void Main() {
        int[] fiveRandomNumbers = nRandomNumbers(5);
        Array.Sort(fiveRandomNumbers);
        Console.WriteLine("Values: " + string.Join(", ", fiveRandomNumbers));
        int sum = C(fiveRandomNumbers);
        Console.WriteLine("Total: " + sum);
    }
    static int[] nRandomNumbers(int five) {
        Random random = new Random();
        int[] intArray = new int[five];
        intArray[0] = random.Next(1, 7);
        intArray[1] = random.Next(1, 7);
        intArray[2] = random.Next(1, 7);
        intArray[3] = random.Next(1, 7);
        intArray[4] = random.Next(1, 7);
        return intArray;
    }
    static int C(int[] fiveRandomNumbers) {
        int sum = 0;
        Dictionary<int, int> dictionaryOfNumbers = new Dictionary<int, int>();
        dictionaryOfNumbers.ContainsKey(fiveRandomNumbers[0]) ? dictionaryOfNumbers[fiveRandomNumbers[0]]++ : dictionaryOfNumbers[fiveRandomNumbers[0]] = 1;
        dictionaryOfNumbers.ContainsKey(fiveRandomNumbers[1]) ? dictionaryOfNumbers[fiveRandomNumbers[1]]++ : dictionaryOfNumbers[fiveRandomNumbers[1]] = 1;
        dictionaryOfNumbers.ContainsKey(fiveRandomNumbers[2]) ? dictionaryOfNumbers[fiveRandomNumbers[2]]++ : dictionaryOfNumbers[fiveRandomNumbers[2]] = 1;
        dictionaryOfNumbers.ContainsKey(fiveRandomNumbers[3]) ? dictionaryOfNumbers[fiveRandomNumbers[3]]++ : dictionaryOfNumbers[fiveRandomNumbers[3]] = 1;
        dictionaryOfNumbers.ContainsKey(fiveRandomNumbers[4]) ? dictionaryOfNumbers[fiveRandomNumbers[4]]++ : dictionaryOfNumbers[fiveRandomNumbers[4]] = 1;
        // if all numbers are unique, the last one must be 1 and therefore does not matter
        sum += dictionaryOfNumbers[0] == 2 ? 10 : dictionaryOfNumbers[0] == 3 ? 20 : dictionaryOfNumbers[0] == 4 ? 30 : dictionaryOfNumbers[0] == 5 ? 40 : 0;
        sum += dictionaryOfNumbers[1] == 2 ? 10 : dictionaryOfNumbers[1] == 3 ? 20 : dictionaryOfNumbers[1] == 4 ? 30 : dictionaryOfNumbers[1] == 5 ? 40 : 0;
        sum += dictionaryOfNumbers[2] == 2 ? 10 : dictionaryOfNumbers[2] == 3 ? 20 : dictionaryOfNumbers[2] == 4 ? 30 : dictionaryOfNumbers[2] == 5 ? 40 : 0;
        sum += dictionaryOfNumbers[3] == 2 ? 10 : dictionaryOfNumbers[3] == 3 ? 20 : dictionaryOfNumbers[3] == 4 ? 30 : dictionaryOfNumbers[3] == 5 ? 40 : 0;
        return sum;
    }
}
```

```cs
// not actually C# I just like the colors
Call stack + variables etc.:
|
main
main | int[] d = R(5) | r = Random()
main | int[] d = R(5) | d = int[] // d=[]
main | int[] d = R(5) | d[0] = r.Next(1, 7) // assume 3; d=[3]
main | int[] d = R(5) | d[1] = r.Next(1, 7) // assume 2; d=[3,2]
main | int[] d = R(5) | d[2] = r.Next(1, 7) // assume 4; d=[3,2,4]
main | int[] d = R(5) | d[3] = r.Next(1, 7) // assume 2; d=[3,2,4,2]
main | int[] d = R(5) | d[4] = r.Next(1, 7) // assume 5; d=[3,2,4,2,5]
main | int[] d = R(5) | return d // d=[3,2,4,2,5]
main | Array.Sort(d=[3,2,4,2,5]) // d=[2,2,3,4,5]
main | string {intermediate value} = string.Join(", ", d=[2,2,3,4,5]) // "2, 2, 3, 4, 5"
main | Console.WriteLine("Values: " + {intermediate value}) // "Values: 2, 2, 3, 4, 5"
main | int s = C(d=[2,2,3,4,5]) | s = int 0
main | int s = C(d=[2,2,3,4,5]) | c = Dictionary<int, int> // c={}
main | int s = C(d=[2,2,3,4,5]) | c.ContainsKey(d[0]) ? c[d[0]]++ : c[d[0]] = 1 // c={2:1}
main | int s = C(d=[2,2,3,4,5]) | c.ContainsKey(d[1]) ? c[d[1]]++ : c[d[1]] = 1 // c={2:2}
main | int s = C(d=[2,2,3,4,5]) | c.ContainsKey(d[2]) ? c[d[2]]++ : c[d[2]] = 1 // c={2:2, 3:1}
main | int s = C(d=[2,2,3,4,5]) | c.ContainsKey(d[3]) ? c[d[3]]++ : c[d[3]] = 1 // c={2:2, 3:1, 4:1}
main | int s = C(d=[2,2,3,4,5]) | c.ContainsKey(d[4]) ? c[d[4]]++ : c[d[4]] = 1 // c={2:2, 3:1, 4:1, 5:1}
main | int s = C(d=[2,2,3,4,5]) | s += c.Values[0] == 2 ? 10 : c.Values[0] == 3 ? 20 : c.Values[0] == 4 ? 30 : c.Values[0] == 5 ? 40 : 0 // c.Values[0]=2; s=10
main | int s = C(d=[2,2,3,4,5]) | s += c.Values[1] == 2 ? 10 : c.Values[1] == 3 ? 20 : c.Values[1] == 4 ? 30 : c.Values[1] == 5 ? 40 : 0 // c.Values[1]=1; s=10
main | int s = C(d=[2,2,3,4,5]) | s += c.Values[2] == 2 ? 10 : c.Values[2] == 3 ? 20 : c.Values[2] == 4 ? 30 : c.Values[2] == 5 ? 40 : 0 // c.Values[2]=1; s=10
main | int s = C(d=[2,2,3,4,5]) | s += c.Values[3] == 2 ? 10 : c.Values[3] == 3 ? 20 : c.Values[3] == 4 ? 30 : c.Values[3] == 5 ? 40 : 0 // c.Values[3]=1; s=10
main | int s = C(d=[2,2,3,4,5]) | return s // s=10
main | Console.WriteLine("Total: " + s=10) // "Total: 10"
main
|
```
> Values: 2, 2, 3, 4, 5
> Total: 110

# Finding Defects using Tests

## Example: Leap Year
### Requirments:
- Every 4 years shall be a leap year.
- Every 100 years shall not be a leap year.
- Every 400 years shall be a leap year.

### Tests:
- test 1
 - scenario: year 1996 (multiple of: 4)
 - expected result: true

- test 2
 - scenario: year 1900 (multiple of: 4, 100)
 - expected result: false

- test 2
 - scenario: year 2000 (multiple of: 4, 100, 400)
 - expected result: true

- test 2
 - scenario: year 2003 (multiple of: null)
 - expected result: false

### Running tests
works-but-suboptimal
```cs
var res = IsLeapYear(1996);
Console.WriteLine(res);

res = IsLeapYear(1900);
Console.WriteLine(res);

res = IsLeapYear(2000);
Console.WriteLine(res);

res = IsLeapYear(2003);
Console.WriteLine(res);
```

better way
```cs
Trace.Assert(IsLeapYear(1996), "1996 should be a leap year");
Trace.Assert(!IsLeapYear(1900), "1900 should not be a leap year");
Trace.Assert(IsLeapYear(2000), "2000 should be a leap year");
Trace.Assert(!IsLeapYear(2003), "2002 should not be a leap year");
```

more complex cases
```cs
Console.WriteLine("Test 1");
var q = new Queue();
q.Enqueue(100);
q.Enqueue(200);
q.Enqueue(300);
Trace.Assert(q.Dequeue() == 100);
Trace.Assert(q.Dequeue() == 200);
Trace.Assert(q.Dequeue() == 300);
```
