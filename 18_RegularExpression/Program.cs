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
                floatNums[i] = float.Parse(text.Value);
                i++;
            }

            Console.WriteLine("\n\tTo ints array: ");
            {
                for (int j = 0; j < floatNums.Length; j++)
                {
                    Console.Write(floatNums[j] + " ");
                }
                
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            string path = Path.Combine(Directory.GetCurrentDirectory(), "numbers.txt");
            WriteToFile(path);
            FindFloat(path);

            
        }
    }
}
