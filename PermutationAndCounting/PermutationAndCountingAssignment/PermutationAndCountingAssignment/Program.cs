using System;
using System.Reflection;
using System.Text;

namespace PermutationAndCountingAssignment
{
    public class Program
    {
        //https://steemit.com/csharp/@simondev/c-generic-permutation-ordered-sub-sets-with-linq
        //ChatGPT
        //https://betterexplained.com/articles/easy-permutations-and-combinations/


        static int count = 0;
        static void Main(string[] args)
        {

            Program program = new Program();
            int[] arr1 = new int[5];
            Console.WriteLine("input of 5 characters/numbers/symbols displays the following:\n\n\n");

            // Take user input of 5 characters/numbers/symbols
            Console.Write("Enter 5 characters/numbers/symbols: ");
            string inputStr = Console.ReadLine();
            //Console.WriteLine(inputStr);


            // Get all permutations of inputStr of length 1 to 5 and diplay them
            for (int i = 1; i <= 5; i++)
            {
                List<string> permutationTemp = GetPermutations(inputStr, i);
                Console.WriteLine($"{permutationTemp.Count()} permutations of length {i}:");
                foreach (string p in permutationTemp)
                {
                    Console.WriteLine(p);
                }
            }
            /////
            //program.TransitionText();
            ///////
            /////

            //List<List<string>> partitions = OrderedPartitions(inputStr);
            //Console.WriteLine("All ordered partitions of " + inputStr + ":");
            //foreach (List<string> partition in partitions)
            //{
            //    Console.WriteLine(string.Join(" ", partition));
            //}
            ///////
            program.TransitionText();
            ///////
            char[] charArray = inputStr.ToCharArray();
            //Array.Sort(charArray);
            Console.WriteLine("All combinations of 5C1, 5C2, 5C3, 5C4, 5C5:");
            string output = "";

            //Get all combinations of length 1 to 5 and diplay them
            for (int i = 0;i <= 5; i++) 
            {
                GenerateCombinations(inputStr, i, output);
                Console.WriteLine($"Total number of combinations: {count}");
            }

           


            //Console.WriteLine("Total count: " + CountCombinations(inputStr, ""));

        }
       
        public void TransitionText()
        {
            Console.WriteLine("\n\nPress Any Key for Next pattern");
            Console.ReadKey();
            Console.Clear();
        }
        
        // recursive function 
        public int factorial(int num)
        {
            // termination condition
            if (num == 0)
                return 1;
            else
                // recursive call
                return num * factorial(num - 1);
        }

        public static List<string> GetPermutations(string str, int len)
        {
            var result = new List<string>();

            // Base case: if len is 1, return a list of all individual characters in str
            if (len == 1)
            {
                foreach (char c in str)
                {
                    result.Add(c.ToString());
                }
            }
            else
            {
                // Loop through each char srtring
                for (int i = 0; i < str.Length; i++)
                {
                    // Get all permutations of the remaining characters char
                    List<string> subPermutations = GetPermutations(str.Remove(i, 1), len - 1);// N!/(n-l)!

                    // Add the current character to the beginning of each sub-permutation to create new permutations
                    foreach (string subPerm in subPermutations)
                    {
                        result.Add(str[i] + subPerm);
                    }
                }
            }

            return result;
        }

        //OrderedPartitions code starts here
        static List<List<string>> OrderedPartitions(string input)
        {
            int i;
            List<List<string>> partitions = new List<List<string>>();
            if (string.IsNullOrEmpty(input))
            {
                partitions.Add(new List<string>());
                return partitions;
            }
            for (i = 0; i < input.Length; i++)
            {
                string prefix = input.Substring(0, i + 1);
                List<List<string>> suffixPartitions = OrderedPartitions(input.Substring(i + 1));
                foreach (List<string> suffixPartition in suffixPartitions)
                {
                    suffixPartition.Insert(0, prefix);
                    partitions.Add(suffixPartition);
                }
            }
            return partitions;
        }
        //Combination code starts here
        static void GenerateCombinations(string input, int length, string output)
        {

            if (length == 0)//if 0 we have 1 combination
            {
                Console.WriteLine(output);
                count++;//number of combinations
                return;
            }

            for (int i = 0; i < input.Length; i++)//number of ways to combine 
            {
                string newOutput = output + input[i];
                string newInput = input.Substring(0, i) + input.Substring(i + 1);//get remienders 
                GenerateCombinations(newInput, length - 1, newOutput);
            }
        }
    }
}