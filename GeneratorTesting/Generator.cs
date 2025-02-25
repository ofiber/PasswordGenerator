using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorTesting
{
    public class Generate
    {
        public static void Main()
        {
            int[] t = new int[] { 1, 1, 0, 1 };

            while (true)
            {

                int[] arr = GetPercentages(t, 18);

                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine(arr[i]);
                }

                Console.WriteLine();

                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            }
        }

        //public static string GetOptions()
        //{
        //    Console.WriteLine("How long would you like your password to be? (8-128 characters)");
        //    int length = int.Parse(Console.ReadLine());

        //    Console.WriteLine("Would you like to use symbols? (y/n)");
        //    bool useSymbols = Console.ReadLine().ToLower() == "y" ? true : false;

        //    Console.WriteLine("Would you like to use uppercase letters? (y/n)");
        //    bool useUpper = Console.ReadLine().ToLower() == "y" ? true : false;

        //    Console.WriteLine("Would you like to use lowercase letters? (y/n)");
        //    bool useLower = Console.ReadLine().ToLower() == "y" ? true : false;

        //    Console.WriteLine("Would you like to use numbers? (y/n)");
        //    bool useNumbers = Console.ReadLine().ToLower() == "y" ? true : false;

        //    return GeneratePassword(length, useSymbols, useUpper, useLower, useNumbers);
        //}

        public static string GetPassword(int length, int numOptions, bool useSymbols, bool useUpper, bool useLower, bool useNumbers)
        {
            return GeneratePassword(length, numOptions, useSymbols, useUpper, useLower, useNumbers);
        }

        private static string GeneratePassword(int length, int numOptions, bool useSymbols, bool useUpper, bool useLower, bool useNumbers)
        {
            string password = "";
            string symbols = "!@#$%^&*()_+{}|:<>?~";
            string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lower = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";

            Random random = SeedRandom();





            //for(int i = 0; i < length / numOptions; i++)
            //{
            //    if (useSymbols)
            //        password += symbols[random.Next(0, symbols.Length)];

            //    if (useUpper)
            //        password += upper[random.Next(0, upper.Length)];

            //    if (useLower)
            //        password += lower[random.Next(0, lower.Length)];

            //    if (useNumbers)
            //        password += numbers[random.Next(0, numbers.Length)];

            //}

            password = Shuffle(password, random);

            return password;
        }

        public static int[] GetPercentages(int[] options, int length)
        {
            Random random = SeedRandom();

            int[] percentages = new int[options.Length];
            int[] arr = new int[options.Length];

            int numOptions = options.Sum();

            int sum = 0;

            for(int i = 0; i < numOptions - 1; i++)
            {
                arr[i] = random.Next(1, length - (numOptions - i - 1) - sum);
                sum += arr[i];
            }

            arr[numOptions - 1] = length - sum;

            for(int i = 0; i < options.Length; i++)
            {
                if (options[i] == 1)
                {
                    percentages[i] = arr[0];
                    arr = arr.Skip(1).ToArray();
                }
                else
                {
                    percentages[i] = 0;
                }
            }
            
            return percentages;
        }

        private static string Shuffle(string password, Random r)
        {
            char[] array = password.ToCharArray();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = r.Next(n + 1);
                char value = array[k];
                array[k] = array[n];
                array[n] = value;
            }

            return new string(array);
        }

        private static Random SeedRandom()
        {
            TimeOnly time = TimeOnly.FromDateTime(DateTime.Now);
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);

            int hash1 = time.GetHashCode();
            int hash2 = date.GetHashCode();

            int seed = HashCode.Combine(hash1, hash2);

            Random random = new Random(seed);

            return random;
        }


    }
}
