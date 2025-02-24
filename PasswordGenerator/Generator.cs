﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public class Generate
    {
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

        public static string GetPassword(int length, int[] options, bool useSymbols, bool useUpper, bool useLower, bool useNumbers)
        {
            return GeneratePassword(length, options, useSymbols, useUpper, useLower, useNumbers);
        }

        private static string GeneratePassword(int length, int[] options, bool useSymbols, bool useUpper, bool useLower, bool useNumbers)
        {
            string password = "";
            string symbols = "!@#$%^&*()_+{}|:<>?~";
            string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lower = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";

            Random random = SeedRandom();


            int[] percentages = GetPercentages(options, length);


            if(options[0] == 1)
            {
                for (int i = 0; i < percentages[0]; i++)
                {
                    password += lower[random.Next(0, lower.Length)];
                }
            }

            if (options[1] == 1)
            {
                for (int i = 0; i < percentages[1]; i++)
                {
                    password += upper[random.Next(0, upper.Length)];
                }
            }

            if (options[2] == 1)
            {
                for (int i = 0; i < percentages[2]; i++)
                {
                    password += numbers[random.Next(0, numbers.Length)];
                }
            }

            if (options[3] == 1)
            {
                for (int i = 0; i < percentages[3]; i++)
                {
                    password += symbols[random.Next(0, symbols.Length)];
                }
            }


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

        private static int[] GetPercentages(int[] options, int length)
        {
            int numOptions = 0;
            int[] arr = new int[4];

            foreach (int option in options)
            {
                if (option == 1)
                    numOptions++;
                else
                    arr[option] = -1;
            }

            Random random = SeedRandom();
            int remainingLength = length;
            int[] percentages = new int[numOptions];

            for (int i = 0; i < numOptions - 1; i++)
            {
                int randomPercentage = random.Next(1, remainingLength);
                percentages[i] = randomPercentage;
                remainingLength -= randomPercentage;

                if (remainingLength == 0)
                    break;
            }

            percentages[numOptions - 1] = remainingLength;


            int j = 0;
            for (int i = 0; i < numOptions; i++)
            {

                if (j !> percentages.Length && percentages[j] == 0)
                {
                    int index = Array.IndexOf(percentages, percentages.Max());

                    percentages[index] -= 1;

                    percentages[i] = 1;
                }

                if (arr[i] == 0)
                {
                    arr[i] = percentages[j];
                    j++;
                }
            }

            if (arr[0] == 11)
                return GetPercentages(options, length);
            else
                return arr;
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
