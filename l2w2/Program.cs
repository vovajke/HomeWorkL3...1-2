using System;

namespace l2w2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Способ 1");
            Console.WriteLine();
            Console.WriteLine("Введите строку, нажмите Enter и она будет перевернута:");
            string str = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(ReverseStringSolve1(str));

            Console.WriteLine();
            Console.WriteLine("Способ 2");
            Console.WriteLine();

            Console.WriteLine($"Было: {str}");
            Console.WriteLine($"Стало: {ReverseStringSolve2(str)}");

            Console.ReadKey();
        }

        public static string ReverseStringSolve1(string stringToReverse)
        {
            char[] result = stringToReverse.ToCharArray();

            Array.Reverse(result);

            return new string(result);
        }

        public static string ReverseStringSolve2(string stringToReverse)
        {
            char[] result = new char[stringToReverse.Length];

            for (int i = stringToReverse.Length - 1; i >= 0; i--)
            {
                result[stringToReverse.Length - 1 - i] = stringToReverse[i];
            }

            return new string(result);
        }
    }
}

