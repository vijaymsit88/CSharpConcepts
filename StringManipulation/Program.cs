using System;
using System.Diagnostics;
using System.Text;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            //StringCoversion();
            //StringAsArray();
            //EscapeString();
            //AppendingStrings();
            //InterpolationAndLiteral();
            //StringBuilderDemo();
            WorkingWithArrays();

        }

        private static void StringCoversion()
        {
            string testString = "tHis iS tHe FBI Calling!";
            string result;

            result = testString.ToLower();
            Console.WriteLine(result);

            result = testString.ToUpper();
            Console.WriteLine(result);
        }

        private static void StringAsArray()
        {
            string testString = "Timothy";

            for (int i = 0; i < testString.Length; i++)
            {
                Console.WriteLine(testString[i]);
            }
        }

        private static void EscapeString()
        {
            string results;
            results = "This is my \"test\" solution";
            Console.WriteLine(results);

            results = "c:\\Demo\\Test.txt";
            Console.WriteLine(results);

            //@ (called string literal) can only be used if you dont have "" within your string
            results = @"c:\Demo\Test.txt";
            Console.WriteLine(results);
        }

        private static void AppendingStrings()
        {
            string firstName = "Tim";
            string lastName = "Corey";
            string results = firstName + ", my name is " + firstName + " " + lastName;
            Console.WriteLine(results);

            results = string.Format("{0}, my name is {0} {1}", firstName, lastName);
            Console.WriteLine(results);

            // String interpolation - you can put any type of c# code inside {}
            // more readable
            // takes less place
            results = $"{firstName}, my name is {firstName} {lastName}";
            Console.WriteLine(results);
        }

        private static void InterpolationAndLiteral()
        {
            string testString = "Tim Corey";
            //@ and $ needs to be used together if we are using interpolation 
            // and we have some characters to escape.
            // Order does not matter !!
            string results = $@"C:\Demo\{testString}\Test.txt";
            Console.WriteLine(results);

            // Now this enables us to use "" in fron of a \.
            results = $@"C:\Demo\{testString}\{"\""}Test{"\""}.txt";
            Console.WriteLine(results);
        }

        private static void StringBuilderDemo()
        {
            Stopwatch regularStopwatch = new Stopwatch();
            regularStopwatch.Start();
            string test = "";

            for (int i = 0; i < 10000; i++)
            {
                test += i;
            }

            regularStopwatch.Stop();
            Console.WriteLine($"Regular Stopwatch: { regularStopwatch.ElapsedMilliseconds }ms");

            Stopwatch builderStopwatch = new Stopwatch();
            builderStopwatch.Start();
            StringBuilder sb = new();

            for (int i = 0; i < 1000000; i++)
            {
                sb.Append(i);
            }

            builderStopwatch.Stop();
            Console.WriteLine($"String Builder Stopwatch: { builderStopwatch.ElapsedMilliseconds }ms");


            // Key Takeaway-
            // If you are going to manipulate a large number of strings fr eg creating a CSV file
            // use string builder as its really faster than traditonal appending.
            // Stringbuilder is faster and takes less memory.
        }

        private static void WorkingWithArrays()
        {
            int[] ages = new int[] { 6, 7, 8, 3, 5 };
            string results;

            results = String.Concat(ages);
            Console.WriteLine(results);
            //o/p = 67835

            results = String.Join(",", ages);
            Console.WriteLine(results);
            //Op = 6,7,8,3,5

            string testString = "Jon,Tim,Mary,Sue,Bob,Jane";
            string[] resultsArray = testString.Split(",");
            Array.ForEach(resultsArray, x => Console.WriteLine(x));
            //op =
            //Jon
            //Tim
            //Mary
            //Sue
            //Bob
            //Jane

            //with spaces after ,
            testString = "Jon, Tim, Mary, Sue, Bob, Jane";
            resultsArray = testString.Split(", ");
            Array.ForEach(resultsArray, x => Console.WriteLine(x));
            //op =
            //Jon
            //Tim
            //Mary
            //Sue
            //Bob
            //Jane

        }
    }
}
