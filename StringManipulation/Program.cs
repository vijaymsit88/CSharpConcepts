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
            //WorkingWithArrays();
            //PadAndTrim();
            //searchingStrings();
            //OrderingStrings();
            GettingASubstring();

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
            //op = 67835

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

        private static void PadAndTrim()
        {
            string testString = "      Hello World    ";
            string results;

            results = testString.TrimStart();
            Console.WriteLine($"'{results}'");

            results = testString.TrimEnd();
            Console.WriteLine($"'{results}'");

            results = testString.Trim();
            Console.WriteLine($"'{results}'");

            // Only single characters can be added in padding
            testString = "1.15";
            results = testString.PadLeft(10, '0');
            Console.WriteLine($"'{results}'");

            results = testString.PadRight(10, '0');
            Console.WriteLine($"'{results}'");

        }

        private static void searchingStrings()
        {
            string testString = "This is a test of the search. Let's see how its testing works out.";
            bool resultsBoolean;
            int resultsInt;

            //StartsWith is case sensitive.
            resultsBoolean = testString.StartsWith("This is");
            Console.WriteLine($"Starts with \"This is\": {resultsBoolean}");

            //EndsWith is case sensitive.
            resultsBoolean = testString.EndsWith("works out.");
            Console.WriteLine($"Ends with \"works out\": {resultsBoolean}");

            resultsBoolean = testString.Contains("test");
            Console.WriteLine($"Starts with \"test\": {resultsBoolean}");

            resultsBoolean = testString.Contains("tests");
            Console.WriteLine($"Ends with \"tests\": {resultsBoolean}");

            //To find index of starting of a word
            // it gives index as 10 which is the starting index of 't'est
            resultsInt = testString.IndexOf("test");
            Console.WriteLine($"Index of\"test\": {resultsInt}");
            //op = 10

            //giving 2nd parameter will start searching from this index onwards (including)
            resultsInt = testString.IndexOf("test", 11);
            Console.WriteLine($"Index of\"test\" after character 10: {resultsInt}");

            // If nothing is found then it gives -1

            
            resultsInt = testString.LastIndexOf("test");
            Console.WriteLine($"Last Index of\"test\": {resultsInt}");

            //If you give a 2nd parameter to LastIndexOf then it looks backwards in the string in reverse order.
            //op = 10
            //Last index of counts from 2nd parameter till very begining of the string.
            resultsInt = testString.LastIndexOf("test", 50);
            Console.WriteLine($"Last Index of\"test\" before character 50: {resultsInt}");
            //op = 10

            resultsInt = testString.LastIndexOf("test", 10);
            Console.WriteLine($"Last Index of\"test\" before character 10: {resultsInt}");
            //op = -1

        }

        private static void CompareStrings()
        {
            // str1.CompareTo(str2) --> str1 cannot be null
            // String.Compare(str1, str2) --> str1 and str2 both can be null
            // str1 is subtracted from str2 and the result decides which is greater.

            // Equality -->
            // String.Equals(str1, str2)
            // it is case sensitive

            // to make it case sensitive
            //String.Equals(str1, str2, StringComparison.InvariantCultureIgnoreCase)
        }

        private static void GettingASubstring()
        {
            string testString = "This is a test of substring. Let's see how its testing works out.";
            string results;

            results = testString.Substring(5);
            Console.WriteLine(results);
            //starts from 5th index (inclusive)
            //op = is a test of substring. Let's see how its testing works out.

            results = testString.Substring(5, 4);
            Console.WriteLine(results);
            //starts from 5th index (inclusive)
            //starts from index 5 and take 4 characters from there.
            //op = is a
        }

    }
}
