namespace PermutationAndCountingAssignment
{
    public class Program
    {
        //https://steemit.com/csharp/@simondev/c-generic-permutation-ordered-sub-sets-with-linq
        //ChatGPT

        static void Main(string[] args)
        {
            Program program = new Program();
            int[] arr1 = new int[5];
            Console.WriteLine("input of 5 characters/numbers/symbols displays the following:\n\n\n");

            // Take user input of 5 characters/numbers/symbols
            Console.Write("Enter 5 characters/numbers/symbols: ");
            string inputStr = Console.ReadLine();
            //Console.WriteLine(inputStr);

            //int n = inputStr.Length;
            //permute(inputStr, 0, n - 1);

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
            program.TransitionText();
            /////
            ///

            List<List<string>> partitions = OrderedPartitions(inputStr);
            Console.WriteLine("All ordered partitions of " + inputStr + ":");
            foreach (List<string> partition in partitions)
            {
                Console.WriteLine(string.Join(" ", partition));
            }
            /////
            program.TransitionText();
            /////
            char[] charArray = inputStr.ToCharArray();
            Console.WriteLine("All combinations of 5C1, 5C2, 5C3, 5C4, 5C5:");


            for (int i = 1; i <= 5; i++)
            {
                int count = CountCombinations(inputStr.Length, i);
                Console.WriteLine($"5C{i} ({count} combinations):");
                PrintCombinations(inputStr.ToCharArray(), i);
                Console.WriteLine();
            }
        }
        private static void permute(string str, int l, int r)
        {
            if (l == r)
                Console.WriteLine(str);
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = swap(str, l, i);
                    permute(str, l + 1, r);
                    str = swap(str, l, i);
                }
            }
        }
        public static String swap(String a,
                            int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
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
                // Loop through each character in str
                for (int i = 0; i < str.Length; i++)
                {
                    // Get all permutations of the remaining characters with length len-1
                    List<string> subPermutations = GetPermutations(str.Remove(i, 1), len - 1);

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
        static int CountCombinations(int n, int r)
        {
            if (n < r) return 0;
            if (r == 0 || r == n) return 1;
            return CountCombinations(n - 1, r - 1) + CountCombinations(n - 1, r);
        }

        static void PrintCombinations(char[] input, int k, string prefix = "")
        {
            if (k == 0)
            {
                Console.WriteLine(prefix);
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                char[] newInput = new char[input.Length - i - 1];
                Array.Copy(input, i + 1, newInput, 0, input.Length - i - 1);
                PrintCombinations(newInput, k - 1, prefix + input[i]);
            }
        }
    }
}