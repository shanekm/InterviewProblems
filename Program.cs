using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace InterviewProblems
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //ReverseStringRecursion.Reverse("tesz");

            //object[] arr = new object[] { 1, 2, "test", };
            //foreach (var item in arr)
            //{
            //    if (item is string) 
            //        Console.WriteLine(item);
            //}

            string s = "the man the plan the canal Panama";
            Regex reg = new Regex(@"\bthe\W+(?:\w+\W+){0,4}canal\b");
            Console.WriteLine((reg.Matches(s).Count)); // Wrong

            Regex r = new Regex(@"\bthe\W+(?:\w+\W+){0,4}canal\b");

            int output = 0;
            int start = 0;
            while (start < s.Length)
            {
                Match m = r.Match(s, start);
                if (!m.Success) { break; }
                Console.WriteLine(m.Value);
                output++;
                start = m.Index + 1;
            }
            Console.WriteLine(output);


            IsPalindrome.IsPalindromeInput("mam");
            FibonacciSequenceRecursive.Recursive(10);

            // get type
            Type type = typeof(int);
            Console.WriteLine(type is int); // False - type is Type class
            Console.WriteLine(type);
            Console.WriteLine(typeof(int));
            Console.WriteLine(type == typeof(int)); // True
            Console.WriteLine(typeof(Animal));

            // at runtime
            int i = 0;
            Type type2 = i.GetType();
            Console.WriteLine(i is int);      // True
            Console.WriteLine(type2 is int);  // False

            if (i.GetType() == typeof(int))
            {
                Console.WriteLine("i is int: " + type);
            }


            //if an instance is in the inheritance tree
            var dog = new Dog();
            Console.WriteLine(dog is Animal);

            // Implicit: conversion to base type is safe.
            Dog d = new Dog();
            Animal a = d;                   // Implicit: sub => base = safe
            Console.WriteLine(a.AnimalName);// Base access
            Console.WriteLine(a);           // Dog
            Console.WriteLine(a is Animal); // True
            Console.WriteLine(a is Dog);    // True

            
            Dog d2 = (Dog)a;                // Explicit: base => sub
            Console.WriteLine(d2.DogName, d2.AnimalName); // Both access
            Console.WriteLine(d2);          // Dog

            Animal a2 = new Dog();
            Console.WriteLine(a2.AnimalName);// Base access
            Console.WriteLine(a2);           // Dog
            Console.WriteLine(a2 is Animal); // True
            Console.WriteLine(a2 is Dog);    // True

            Dog d3 = (Dog)a2;                // Ok - new Dog() above
            Console.WriteLine(d3.DogName,d3.AnimalName); // Both access
            Console.WriteLine(d3 is Animal); // True
            Console.WriteLine(d3 is Dog);    // True

            var animal = new Animal();
            Console.WriteLine(animal);
            //Dog d3 = (Dog)animal;                // Error - can't convert base to sub
            //Console.WriteLine(d3);
            Console.WriteLine(animal is Animal); // True
            Console.WriteLine(animal is Dog);    // False
        }
    }

    public class Animal
    {
        public string AnimalName { get { return "animal"; } }
    }

    public class Dog : Animal
    {
        public string DogName { get { return "dog"; } }
    }

    public class IsAlphabetic
    {
        bool IsAllAlphabetic(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsLetter(c))
                    return false;
            }

            return true;
        }
    }

    public class IsPrime
    {
        int IsNumberPrime(int number)
        {
            if (number <= 1) return 0; // zero and one are not prime
            int i;
            for (i = 2; i * i <= number; i++)
            {
                if (number % i == 0) return 0;
            }
            return 1;
        }
    }

    public class ReverseString
    {
        public static string Reverse(string str)
        {
            var charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

    public class ReverseStringRecursion
    {
        public static void Reverse(string str)
        {
            if (str.Length > 0)
            {
                var ch = str[0];
                // prints the last n-1 charactors in reverse order
                Reverse(str.Substring(1));
                Console.Write(ch); // prints that last char
            }
        }
    }

    public static class ReverseInt
    {
        public static int Reverse(int num)
        {
            var result = 0;
            while (num > 0)
            {
                result = result*10 + num%10;
                num /= 10;
            }
            return result;
        }
    }

    public static class ReverseIntShorthand
    {
        public static int Reverse(int num)
        {
            return num.ToString()
                .Reverse()
                .Aggregate(0, (b, x) => 10*b + x - '0');
        }
    }

    public class RecursiveDirectorySearch
    {
        private string[] filenames = Directory.GetFiles("dirName", "*.*", SearchOption.AllDirectories);

        private static void DirSearch(string sDir)
        {
            try
            {
                foreach (var d in Directory.GetDirectories(sDir))
                {
                    foreach (var f in Directory.GetFiles(d))
                    {
                        Console.WriteLine(f);
                    }
                    DirSearch(d);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }

    public class RecursiveCountdown
    {
        // Prints out 5, 4, 3, 2, 1, 0
        public static void CountDown(int number)
        {
            Console.WriteLine(number);
            if (number > 0)
            {
                CountDown(number - 1);
            }
        }
    }


    public class MostOccuringWord
    {
        private readonly Dictionary<string, int> dict = new Dictionary<string, int>();
        private readonly string[] source = {"test1", "test2", "test3", "test4", "test1", "test1", "test3"};

        public void GetMostOccuringWord()
        {
            foreach (var s in source)
            {
                if (dict.Keys.Contains(s))
                    dict[s] = dict[s]++; // add one to value
                else
                    dict.Add(s, 1);
            }
        }
    }

    public class MostOccuringCharacter
    {
        private readonly Dictionary<char, int> dict = new Dictionary<char, int>();
        private readonly char[] source = "test1asdffds23423434".ToCharArray();

        public void GetMostOccuringChar()
        {
            foreach (var s in source)
            {
                if (dict.Keys.Contains(s))
                    dict[s] = dict[s]++; // add one to value
                else
                    dict.Add(s, 1);
            }
        }
    }

    public class FibonacciSequence
    {
        public void Fibonacci_(int len)
        {
            int a = 0, b = 1, c = 0;
            Console.Write("{0} {1}", a, b);

            for (var i = 2; i < len; i++)
            {
                c = a + b;
                Console.Write(" {0}", c);
                a = b;
                b = c;
            }
        }
    }

    public class FibonacciSequenceRecursive
    {
        public static void Recursive(int len)
        {
            Fibonacci_Recursive(0, 1, 1, len);
        }

        private static void Fibonacci_Recursive(int a, int b, int counter, int len)
        {
            if (counter <= len)
            {
                Console.Write("{0} ", a);
                Fibonacci_Recursive(b, a + b, counter + 1, len);
            }
        }
    }

    public static class Prime
    {
        static bool isPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }

    public class FizzBuzz
    {
        // for multiples of 3 print "Fizz" instead of the number
        // for multiples of 5 print "Buzz" instead of the number
        // for multiples of both 3 and 5 print "FizzBuzz" instead of the number
        public void DoFizzBuzz()
        {
            for (var i = 1; i <= 100; i++)
            {
                if ((i%3 == 0) && (i%5 == 0))
                    Console.WriteLine("FizzBuzz");
                else if (i%3 == 0)
                    Console.WriteLine("Fizz");
                else if (i%5 == 0)
                    Console.WriteLine("Buzz");
                else
                    Console.WriteLine(i);
            }
        }
    }

    public class Queue<T>
    {
        private readonly System.Collections.Generic.Stack<T> inbox 
            = new System.Collections.Generic.Stack<T>();
        private readonly System.Collections.Generic.Stack<T> outbox 
            = new System.Collections.Generic.Stack<T>();

        public void queue(T item)
        {
            inbox.Push(item);
        }

        public T dequeue()
        {
            if (outbox.Count == 0) // important
            {
                while (inbox.Count != 0)
                {
                    outbox.Push(inbox.Pop());
                }
            }
            return outbox.Pop();
        }
    }

    public class Stack<T>
    {
        private System.Collections.Generic.Queue<T> inbox 
            = new System.Collections.Generic.Queue<T>();
        private System.Collections.Generic.Queue<T> outbox 
            = new System.Collections.Generic.Queue<T>();

        public void push(T item)
        {
            inbox.Enqueue(item);
        }

        public T pop()
        {
            if (outbox.Count != 0) // important
            {
                while (inbox.Count > 1)
                {
                    outbox.Enqueue(inbox.Dequeue());
                }
            }
            var result = inbox.Dequeue();
            inbox = outbox; // change names

            return result;
        }
    }

    public class IsPalindrome
    {
        public static bool IsPalindromeInput(string value)
        {
            var min = 0;
            var max = value.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                var a = value[min];
                var b = value[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                min++;
                max--;
            }
        }
    }

    public sealed class Singleton
    {
        private Singleton()
        {
        }

        public static Singleton Instance { get; } = new Singleton();
    }
}