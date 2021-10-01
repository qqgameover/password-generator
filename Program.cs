using System;
using System.Linq;

namespace password_generator
{
    class Program
    {
        static readonly Random Random = new Random();
        static void Main(string[] args)
        {
            DisplayInfo();
            string arguments = Console.ReadLine();
            GenerateAndDisplayPassword(arguments);
        }

        private static void GenerateAndDisplayPassword(string arguments)
        {
            string[] splitArguments = arguments.Split(" ");
            if (!ValidateArgs(splitArguments)) return;
            int argumentInt = Convert.ToInt32(splitArguments[0]);
            if (splitArguments.Length == 1)
            {
                ConstructPassword(argumentInt);
                return;
            }
            string otherArgs = splitArguments[1];
            ConstructPassword(argumentInt, otherArgs);
        }

        private static char RandomLetters(int min, int max)
        {
            return (char)Random.Next(min, max);
        }

        private static void ConstructPassword(int length, string otherArgs)
        {
            var word = "";
            foreach (var t in otherArgs)
            {
                    word += Convert.ToString(t) switch
                    {
                        "L" => RandomLetters(65, 90),
                        "l" => RandomLetters(97, 122),
                        "s" => RandomLetters(33, 47),
                        _ => RandomLetters(48, 57)
                    };
            }
            for (var i = 0; i < length - word.Length; i++)
            {
                word += RandomLetters(33, 120);
            }
            Console.WriteLine(word);
        }

        private static void ConstructPassword(int length)
        {
            var word = "";
            {
                for (var i = 0; i < length; i++)
                {
                    word += RandomLetters(33, 120);
                }
            }
            Console.WriteLine(word);
        }

        private static bool ValidateArgs(string[] args)
        {
            if (args[0].Any(char.IsDigit)) return true;
            DisplayInfo();
            return false;
        }

        private static void DisplayInfo() 
        {
            Console.WriteLine("The first 1-2 chars should contain ints followed by a space to decide the length of the password");
            Console.WriteLine("Followed by l for minimum one lowercase letter, L for minimum one uppercase letter");
            Console.WriteLine("then s for symbol, and d for digits");
            Console.WriteLine("For example: 14 llLsd");
        }
    }
}
