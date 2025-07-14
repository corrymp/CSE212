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

# Analyze
## MysteryStack1
```cs
// MysteryStack1.cs
public static class MysteryStack1 {
    public static string Run(string text) {
        var stack = new Stack();
        foreach(var letter in text) stack.Push(letter);
        var result = "";
        while(stack.Count > 0) result += stack.Pop();
        return result;
    }
}
```

```cs
// MysteryStack1.cs (re-writen and unrolled)
public static class MysteryStack1 {
    public static string Run(string t) {
        var s = new Stack();
        
        var l = t[0];   s.Push(l); //l='r0'; s=['r0']
        l = t[1];       s.Push(l); //l='a1'; s=['r0','a1']
        l = t[2];       s.Push(l); //l='c2'; s=['r0','a1','c2']
        l = t[3];       s.Push(l); //l='e3'; s=['r0','a1','c2','e3']
        l = t[4];       s.Push(l); //l='r4'; s=['r0','a1','c2','e3','c4']
        l = t[5];       s.Push(l); //l='a5'; s=['r0','a1','c2','e3','c4','a5']
        l = t[6];       s.Push(l); //l='r6'; s=['r0','a1','c2','e3','c4','a5','r6']

        var r = "";
        r += s.Pop(); // r="r";       s=['r0','a1','c2','e3','c4','a5','r6'] 
        r += s.Pop(); // r="ra";      s=['r0','a1','c2','e3','c4','a5'] 
        r += s.Pop(); // r="rac";     s=['r0','a1','c2','e3','c4'] 
        r += s.Pop(); // r="race";    s=['r0','a1','c2','e3'] 
        r += s.Pop(); // r="racec";   s=['r0','a1','c2'] 
        r += s.Pop(); // r="raceca";  s=['r0','a1'] 
        r += s.Pop(); // r="racecar"; s=['r0'] 

        return r; // "racecar"
    }
}
```

```cs
Call stack vars etc.:
|
Run | t="racecar";
Run | var s=Stack(); // s=[]
Run | s.Push(t[0]); // s=['r']
Run | s.Push(t[1]); // s=['r','a']
Run | s.Push(t[2]); // s=['r','a','c']
Run | s.Push(t[3]); // s=['r','a','c','e']
Run | s.Push(t[4]); // s=['r','a','c','e','c']
Run | s.Push(t[5]); // s=['r','a','c','e','c','a']
Run | s.Push(t[6]); // s=['r','a','c','e','c','a','r']
Run | var r = ""; // r=""
Run | r += s.Pop(); // s=['r','a','c','e','c','a','r']; r="r"
Run | r += s.Pop(); // s=['r','a','c','e','c','a']; r="ra"
Run | r += s.Pop(); // s=['r','a','c','e','c']; r="rac"
Run | r += s.Pop(); // s=['r','a','c','e']; r="race"
Run | r += s.Pop(); // s=['r','a','c']; r="racec"
Run | r += s.Pop(); // s=['r','a']; r="raceca"
Run | r += s.Pop(); // s=['r']; r="racecar"
Run | return r; // r="racecar"
|
Run | t="stressed";
Run | var s=Stack(); // s=[]
Run | s.Push(t[0]); // s=['s']
Run | s.Push(t[1]); // s=['s','t']
Run | s.Push(t[2]); // s=['s','t','r']
Run | s.Push(t[3]); // s=['s','t','r','e']
Run | s.Push(t[4]); // s=['s','t','r','e','s']
Run | s.Push(t[5]); // s=['s','t','r','e','s','s']
Run | s.Push(t[6]); // s=['s','t','r','e','s','s','e']
Run | s.Push(t[7]); // s=['s','t','r','e','s','s','e','d']
Run | var r = ""; // r=""
Run | r += s.Pop(); // s=['s','t','r','e','s','s','e','d']; r="d"
Run | r += s.Pop(); // s=['s','t','r','e','s','s','e']; r="de"
Run | r += s.Pop(); // s=['s','t','r','e','s','s']; r="des"
Run | r += s.Pop(); // s=['s','t','r','e','s']; r="dess"
Run | r += s.Pop(); // s=['s','t','r','e']; r="desse"
Run | r += s.Pop(); // s=['s','t','r']; r="desser"
Run | r += s.Pop(); // s=['s','t']; r="dessert"
Run | r += s.Pop(); // s=['s']; r="desserts"
Run | return r; // r="desserts"
|
Run | t="a nut for a jar of tuna";
Run | var s=Stack(); // s=[]
Run | s.Push(t[0]);  // s=['a']
Run | s.Push(t[1]);  // s=['a',' ']
Run | s.Push(t[2]);  // s=['a',' ','n']
Run | s.Push(t[3]);  // s=['a',' ','n','u']
Run | s.Push(t[4]);  // s=['a',' ','n','u','t']
Run | s.Push(t[5]);  // s=['a',' ','n','u','t',' ']
Run | s.Push(t[6]);  // s=['a',' ','n','u','t',' ','f']
Run | s.Push(t[7]);  // s=['a',' ','n','u','t',' ','f','o']
Run | s.Push(t[8]);  // s=['a',' ','n','u','t',' ','f','o','r']
Run | s.Push(t[9]);  // s=['a',' ','n','u','t',' ','f','o','r',' ']
Run | s.Push(t[10]); // s=['a',' ','n','u','t',' ','f','o','r',' ','a']
Run | s.Push(t[11]); // s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ']
Run | s.Push(t[12]); // s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j']
Run | s.Push(t[13]); // s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j','a']
Run | s.Push(t[14]); // s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j','a','r']
Run | s.Push(t[15]); // s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j','a','r',' ']
Run | s.Push(t[16]); // s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j','a','r',' ','o']
Run | s.Push(t[17]); // s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j','a','r',' ','o','f']
Run | s.Push(t[18]); // s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j','a','r',' ','o','f',' ']
Run | s.Push(t[29]); // s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j','a','r',' ','o','f',' ','t']
Run | s.Push(t[20]); // s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j','a','r',' ','o','f',' ','t','u']
Run | s.Push(t[21]); // s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j','a','r',' ','o','f',' ','t','u','n']
Run | s.Push(t[22]); // s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j','a','r',' ','o','f',' ','t','u','n','a']
Run | var r = "";   // r=""
Run | r += s.Pop(); // r="a"                      ; s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j','a','r',' ','o','f',' ','t','u','n']
Run | r += s.Pop(); // r="an"                     ; s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j','a','r',' ','o','f',' ','t','u']
Run | r += s.Pop(); // r="anu"                    ; s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j','a','r',' ','o','f',' ','t']
Run | r += s.Pop(); // r="anut"                   ; s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j','a','r',' ','o','f',' ']
Run | r += s.Pop(); // r="anut "                  ; s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j','a','r',' ','o','f']
Run | r += s.Pop(); // r="anut f"                 ; s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j','a','r',' ','o']
Run | r += s.Pop(); // r="anut fo"                ; s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j','a','r',' ']
Run | r += s.Pop(); // r="anut fo "               ; s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j','a','r']
Run | r += s.Pop(); // r="anut fo r"              ; s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j','a']
Run | r += s.Pop(); // r="anut fo ra"             ; s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ','j']
Run | r += s.Pop(); // r="anut fo raj"            ; s=['a',' ','n','u','t',' ','f','o','r',' ','a',' ']
Run | r += s.Pop(); // r="anut fo raj "           ; s=['a',' ','n','u','t',' ','f','o','r',' ','a']
Run | r += s.Pop(); // r="anut fo raj a"          ; s=['a',' ','n','u','t',' ','f','o','r',' ']
Run | r += s.Pop(); // r="anut fo raj a "         ; s=['a',' ','n','u','t',' ','f','o','r']
Run | r += s.Pop(); // r="anut fo raj a r"        ; s=['a',' ','n','u','t',' ','f','o']
Run | r += s.Pop(); // r="anut fo raj a ro"       ; s=['a',' ','n','u','t',' ','f']
Run | r += s.Pop(); // r="anut fo raj a rof"      ; s=['a',' ','n','u','t',' ']
Run | r += s.Pop(); // r="anut fo raj a rof "     ; s=['a',' ','n','u','t']
Run | r += s.Pop(); // r="anut fo raj a rof t"    ; s=['a',' ','n','u']
Run | r += s.Pop(); // r="anut fo raj a rof tu"   ; s=['a',' ','n']
Run | r += s.Pop(); // r="anut fo raj a rof tun"  ; s=['a',' ']
Run | r += s.Pop(); // r="anut fo raj a rof tun " ; s=['a']
Run | r += s.Pop(); // r="anut fo raj a rof tun a"; s=[]
Run | return r; // r="anut fo raj a rof tun a"
|
```

## MysteryStack2
```cs
public static class MysteryStack2 {
    private static bool IsFloat(string text) {
        return float.TryParse(text, out _);
    }

    public static float Run(string text) {
        var stack = new Stack<float>();
        foreach (var item in text.Split(' ')) {
            if (item == "+" || item == "-" || item == "*" || item == "/") {
                if (stack.Count < 2)
                    throw new ApplicationException("Invalid Case 1!");

                var op2 = stack.Pop();
                var op1 = stack.Pop();
                float res;
                if (item == "+") {
                    res = op1 + op2;
                }
                else if (item == "-") {
                    res = op1 - op2;
                }
                else if (item == "*") {
                    res = op1 * op2;
                }
                else {
                    if (op2 == 0)
                        throw new ApplicationException("Invalid Case 2!");

                    res = op1 / op2;
                }

                stack.Push(res);
            }
            else if (IsFloat(item)) {
                stack.Push(float.Parse(item));
            }
            else if (item == "") {
            }
            else {
                throw new ApplicationException("Invalid Case 3!");
            }
        }

        if (stack.Count != 1)
            throw new ApplicationException("Invalid Case 4!");

        return stack.Pop();
    }
}
```

```cs
public static class MysteryStack2 {
    private static bool IsFloat(string t) {
        return float.TryParse(t, out _);
    }
    public static float Run(string t) {
        var stack = new Stack<float>();
        foreach (var i in t.Split(' ')) {
            if("+-*/".includes(i)) {
                if (stack.Count < 2) throw new ApplicationException("err1"); // not enough operands
                var o2 = stack.Pop();
                var o1 = stack.Pop();
                float res;
                if (i == "+") res = o1 + o2;
                else if (i == "-") res = o1 - o2;
                else if (i == "*") res = o1 * o2;
                else if (o2 == 0) throw new ApplicationException("err2"); // divide-by-0
                else res = o1 / o2;
                stack.Push(res);
            }
            else if (IsFloat(i)) stack.Push(float.Parse(i));
            else if (i == "") {}
            else throw new ApplicationException("err3"); // invalid input (letter, unknown symbol)
        }
        if (stack.Count != 1) throw new ApplicationException("err4"); // not enough operators (leftover numbers)
        return stack.Pop();
    }
}
```
```cs
|
Run | t="5 3 7 + *";
Run | var stack = Stack<float>();   // stack=[]
Run | var intrmdt = t.Split(' ');   // intrmdt=['5','3','7','+','*']
Run | var i = intrmdt[0];           // i='5'
Run | var prsdFlt = float.Parse(i); // prsdFlt=5
Run | stack.Push(prsdFlt);          // stack=[5]
Run | i = intrmdt[1];               // i='3'
Run | prsdFlt = float.Parse(i);     // prsdFlt=3
Run | stack.Push(prsdFlt);          // stack=[5,3]
Run | i = intrmdt[2];               // i='7'
Run | prsdFlt = float.Parse(i);     // prsdFlt=7
Run | stack.Push(prsdFlt);          // stack=[5,3,7]
Run | i = intrmdt[3];               // i='+'
Run | var op2 = stack.Pop();        // op2=7
Run | var op1 = stack.Pop();        // op1=3
Run | float res = op1 + op2;        // r=10
Run | stack.Push(res);              // stack=[5,10]
Run | i = intrmdt[4];               // i='*'
Run | op2 = stack.Pop();            // op2=10
Run | op1 = stack.Pop();            // op1=5
Run | res = op1 * op2;              // res=50
Run | stack.push(res);              // stack=[50]
Run | return stack.Pop();           // 50
|
Run | text = "6 2 + 5 3 - /"
Run | var stack = Stack<float>();   // stack=[]
Run | var intrmdt = t.Split(' ');   // intrmdt=['6','2','+','5','3','-','/']
Run | var i = intVal[0];            // i='6'
Run | var prsdFlt = float.Parse(i); // prsdFlt=6
Run | stack.Push(prsdFlt);          // stack=[6]
Run | i = intrmdt[1];               // i='2'
Run | prsdFlt = float.Parse(i);     // prsdFlt=2
Run | stack.Push(prsdFlt);          // stack=[6,2]
Run | i = intrmdt[2];               // i='+'
Run | var op2 = stack.Pop();        // op2=2
Run | var op1 = stack.Pop();        // op1=6
Run | float res = op1 + op2;        // res=8
Run | stack.Push(res);              // stack=[8]
Run | i = intrmdt[3];               // i='5'
Run | prsdFlt = float.Parse(i);     // prsdFlt=5
Run | stack.Push(prsdFlt);          // stack=[8,5]
Run | i = intrmdt[4];               // i='3'
Run | prsdFlt = float.Parse(i);     // prsdFlt=3
Run | stack.Push(prsdFlt);          // stack=[8,5,3]
Run | i = intrmdt[5];               // i='-'
Run | var op2 = stack.Pop();        // op2=3
Run | var op1 = stack.Pop();        // op1=5
Run | float res = op1 - op2;        // res=2
Run | stack.Push(res);              // stack=[8,2]
Run | i = intrmdt[5];               // i='/'
Run | var op2 = stack.Pop();        // op2=2
Run | var op1 = stack.Pop();        // op1=8
Run | float res = op1 / op2;        // res=4
Run | stack.Push(res);              // stack=[4]
Run | return stack.Pop();           // 4
|
```

- Invalid Case 1!: "1 +"
- Invalid Case 2!: "1 0 /"
- Invalid Case 3!: "1 a +"
- Invalid Case 4!: "


# Sets
- unique items
- O(1) lookup

## common operations
operation   code                perf    description
add(val)    set.Add(val)        O(1)    adds "val" to set
remove(val) set.Remove(val)     O(1)    removes "val" from set
member(val) set.Contains(val)   O(1)    checks if "val" is in the set
size()      set.Count           O(1)    number of items in set

## example code: intersection & union
```cs
var set1 = new HashSet() {1,2,3,4,5};
var set2 = new HashSet() {4,5,6,7,8};
var set3 = set1.Intersect(set2).ToHashSet(); // {4,5}
var set4 = set1.Union(set2).ToHashSet(); // {1,2,3,4,5,6,7,8}
```

# Maps
- unique
- key-value pairs

## how to make:
```cs
var dict1 = new Dictionary<string, double>();
var dict2 = new Dictionary<string, double>() {{"key1", 2.1}, {"key2", 2.3}};
```

## common operations
operation       code                    perf    description
put(key,val)    map.Add(key,val)        O(1)    adds or replaces row
put(key,val)    map[key] = val          O(1)    gets value at key
get(key)        map[key]                O(1)    gets value at key
remove(key)     map.Remove(key)         O(1)    removes row at key
member(key)     map.ContainsKey(key)    O(1)    checks if key in map
size()          map.Count               O(1)    # of items in map

## example code: objects are maps
```cs
class PersonDataMapping {
    public string FirstName {get; set; }
    public string LastName {get; set; }
    public double Age {get; set; }
}
```

## example code: complex map data
```json
{
    "timestamp": 1584638006,
    "message": "success",
    "iss_position": {
        "longitude": -149.9053,
        "latitude": -35.9225
    }
}
```
```cs
class SpaceStation {
    public long Timestamp {get; set;}
    public string Message {get; set; }
    public Location IssPosition {get; set; }
}
class Location {
    public double Longitude {get; set; }
    public double Latitude {get; set; }
}

var spaceStation = JsonSerializer.Deserialize<SpaceStation>(json);
var lon = spaceStation.IssPosition.Longitude;
var lat = spaceStation.IssPosition.Latitude;
Console.WriteLine($"Space station at Lon: {lon} Lat: {lat}");
```

```json
{
    "people": [
        {"craft": "ISS", "name": "Andrew Morgan" },
        {"craft": "ISS", "name": "Oleg Skripochka" },
        {"craft": "ISS", "name": "Jessica Meir" }
    ],
    "message": "success",
    "number": 3
}
```
```cs
class Space {
    public Person[] People  {get; set;}
    public string Message {get; set;}
    public int Number {get; set;}
}
class Person {
    public string Craft {get; set;}
    public string Name {get; set;}
}

var space = JsonSerializer.Deserialize<Space>(json);
foreach(var person in space.People) Console.WriteLine(person.Name);
```

## example code: building summary tables
```cs
var letters = new[] {'A', 'A', 'B', 'G', 'C', 'G', 'G', 'D', 'B'};
var summaryTable = new Dictionary<char, int>();

foreach(var letter in letters) {
    if(!summaryTable.ContainsKey(letter)) summaryTable[letter] = 1;
    else summaryTable[letter] += 1;
}
Console.WriteLine(string.Join(", ", summaryTable));
// [A, 2], [B, 2], [G, 3], [C, 1], [D, 1]
```

# Articulating Answers to Technical Questions
## instructions
Consider the following scenario:
> "Write code to find the first time in a string when a letter is duplicated."

Answer each of the following:
1. what are possible scenarios to consider? (for example, think of a few strings that you would want to try with the solution)
2. what are some data structures that may be useful?
  2.2 and what would their perf be?
3. what are the boundry conditions that you should consider for this problem?
4. outline a possible solution

## my answers
1. 
  I believe good strings to check against would be strings that:
    1. start with a double letter, such as "Aaron",
    2. have multiple double letters, such as "solutions",
    3. have the double letters at the ends of the string, such as "",
    4. don't have any double letters at all, such as "consider"

2. 
  I believe a good data structure to use is a Set
  It would have O(1) performance
  The worst case would be where the only duplicates are the first and last letters of a long string

3. 
  Some edge cases to look out for include: 
    1. duplicate letters with differing cases (A VS a),
    2. empty strings and strings without letters ("", "  ", "1997"),
    3. no double letters (case, consider, etc.)

4. 
  ```cs
    // First we make the base class
    class DuplicateLetterFinder {
        // Then establish the root method. It will return the index of the duplicate letter, or -1 if there are no duplicates
        public static int FindFirstDuplicate(string str) {
            // Early return if the string only contains numbers
            if (float.TryParse(str, out _)) return -1;
    
            // We then make a new HashSet of all letters to help with filtering out any numbers and punctuation
            HashSet<char> letters = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'];
    
            // And another new HashSet to hold the letter already checked
            var set = new HashSet<char>();
    
            // Then we start iterating over the string. "i" will be the returned index of the double letter once found
            for (int i = 0; i < str.Length; i++) {
            
                // We isolate and lowercase a single letter from the string
                char l = char.ToLower(str[i]);
    
                // Return the index if the letter is already in the set, and if not, add it to the set if it's a letter 
                if (set.Contains(l)) return i;
                if (letters.Contains(l)) set.Add(l);
            }
    
            // Finally, we return -1 if there are no duplicates
            return -1;
        }
    
        // Method to test with many different strings
        public static void Run() {
            string[] words = [
                "Aaron", // 1 (a)
                "solutions", // 6 (o)
                "", // -1 (empty string)
                "consider", // -1 (no duplicates)
                "1997", // -1 (only numbers)
                "  ", // -1 (only whitespace)
                "...", // -1 (only punctuation)
                "Hello World", // 3 (l)
                "What is up? My spirits sure are!", // 15 (s)
                "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" // 36 (A)
            ];
            foreach (string word in words) Console.WriteLine("{0}: {1}", word, FindFirstDuplicate(word));
        }
    } 
  ```

