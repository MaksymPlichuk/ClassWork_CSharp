using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace _18_RegularExpression
{
    internal class Program
    {
        static void WriteToFile(string path)
        {
            string definedText = "3 5,23 5,65 8.95 2 56 74 63 56 4 g 5 9.512 85,32 1,7 3.5";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(definedText);
            }
        }
        static void FindFloat(string path) {
            string allText = File.ReadAllText(path);
            var pattern = @"\d+\.\d+ | \d+\,\d+";
            Regex regex = new Regex(pattern);

            var m = regex.Matches(allText);
            float[] floatNums = new float[m.Count];
            int i = 0;

            foreach (Match text in m)
            {
                Console.Write(text.Value + " ");
            }
            Console.WriteLine("\n");
            foreach (Match text in m)
            {
                try
                {
                    floatNums[i] = float.Parse(text.Value);
                }
                catch
                {
                    Console.WriteLine($"Couldn't convert {text} to int :( ");
                }
                i++;
            }

            Console.WriteLine("\n\tTo ints array: ");

            for (int j = 0; j < floatNums.Length; j++)
            {
                Console.Write(floatNums[j] + " ");
            }
            Console.WriteLine();

        }
        static void UserReg()
        {
            Console.Write("\nEnter email: "); string email = Console.ReadLine()!;
            string pattern = @"^[a-zA-Z0-9-._]{4,}\@[a-z-A-Z0-9]{2,}\.[a-zA-Z0-9]+$";
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(email)) { 
                Console.WriteLine("\nWrong email!");
                return; 
            }

            Console.Write("Enter password: "); string password = Console.ReadLine()!;
            string pattern2 = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[-_])[a-zA-Z0-9-_]{6,}$";

            regex = new Regex(pattern2);
            if (!regex.IsMatch(password)) { 
                Console.WriteLine("\nWrong password!"); 
                return; 
            }

            Console.WriteLine($"\nEmail is correct: {email}");
            Console.WriteLine($"Password is correct: {password}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1-2");
            string path = Path.Combine(Directory.GetCurrentDirectory(), "numbers.txt");
            WriteToFile(path);
            FindFloat(path);

            Console.WriteLine("\nTask 5");
            UserReg();
        }
    }
}
