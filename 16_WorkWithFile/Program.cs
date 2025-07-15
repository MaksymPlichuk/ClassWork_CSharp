using System;
using System.Text;

namespace _16_WorkWithFile
{
    internal class Program
    {
        static void WriteFile(string path)
        {

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {

                Console.WriteLine("Enter elements of array : ");
                string writeText = "";
                for (int i = 0; i < 5; i++) 
                {
                    Console.Write($"Element {i+1}: ");
                    writeText += Console.ReadLine()! + "\t";
                    Console.WriteLine();
                }

                byte[] writeBites = Encoding.UTF8.GetBytes(writeText);
                fs.Write(writeBites, 0, writeBites.Length);

                Console.WriteLine("File was recorded!!!!");

            }

        }
        static string ReadFile(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            else { throw new Exception("Wrong file path!"); }
        }

        static void WriteRandom(string path1, string path2) {
            Random rnd = new Random();
            int even = 0; int uneven = 0;
            using (StreamWriter evennums = new StreamWriter(path1))
            using (StreamWriter unevennums = new StreamWriter(path2))
            {
                Console.WriteLine("Generating Numbers.....");
                Thread.Sleep(300);
                int[] nums = new int[1000];
                for (int i = 0;i < nums.Length; i++)
                {
                    nums[i] = rnd.Next(0,10000);
                    if (nums[i] % 2 == 0) { evennums.Write(nums[i] + " "); 
                        even++;
                    }
                    else { unevennums.Write(nums[i] + " ");
                        uneven++;
                    }

                }
            }
            Console.WriteLine($"\n\t\t--Statistic-- ");
            Console.WriteLine($"Number of even numbers: {even}, Number of uneven numbers: {uneven}");
            Console.WriteLine("Enter any Key to see file results");
            Console.ReadKey();
            Console.WriteLine("\nEven numbers:");
            Console.WriteLine(ReadFile(path1));
            Console.WriteLine("\nUneven numbers:");
            Console.WriteLine(ReadFile(path2));

        }

        static void FindString(string path)
        {
            string definedText = "Lorem ipsum dolor sit manet, manet manetum et. Vivamus viverra viverra nisi, quis quis iud blandit siuq. Integer integer iud sapien. Proin proin dui dui a a feugiat feugiat. Donec nec nec turpis turpis. Ut ut magna magna in in facilisis facilisis. Nulla nulla lacinia lacinia odio odio, eget eget libero libero.";

            using (StreamWriter st = new StreamWriter(path))
            {
                st.WriteLine(definedText);
            }

            Console.Write("Enter word to find: ");
            string word = " "; word = Console.ReadLine()!;

            int wordcount = 0; int reverseWordCount = 0;
            string wordReverse = new string(word.Reverse().ToArray());

            var allText = File.ReadAllText(path);

            string[] words = allText.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == word)
                {
                    Console.WriteLine($"Found word at: {i + 1}");
                    wordcount++;
                }
                if (words[i] == wordReverse)
                {
                    reverseWordCount++;
                }
            }
            if (wordcount == 0)
            {
                Console.WriteLine("Word not Found!");
            }
            Console.WriteLine($"Number of word inputs: {wordcount}");
            Console.WriteLine($"Number of reverse word inputs: {reverseWordCount}");
        }

        static void FileStats(string path)
        {
            int sentence = 0;
            int uppercase = 0; int lowercase = 0;
            int vovel = 0; int consonant = 0; int digits = 0;
            string vovels = "aeiouAEIOU";

            Console.WriteLine($"File name: {Path.GetFileName(path)}");

            string allText = File.ReadAllText(path);
            foreach (char symb in allText)
            {
                if (symb == '.' || symb == '!' || symb == '?') { sentence++; }
                if (char.IsUpper(symb)) { uppercase++; }
                if (char.IsLower(symb)) { lowercase++; }
                if (char.IsDigit(symb)) { digits++; }
                if (char.IsLetter(symb))
                {
                    if (vovels.Contains(symb)) { vovel++; }
                    else { consonant++; }
                }
            }
            Console.WriteLine($" Number of sentences: {sentence}\n Number of Uppercase letters: {uppercase}\n Number of Lowercase letters: {lowercase}");
            Console.WriteLine($" Number of Digits: {digits}\n Number of vovels: {vovel}\n Number of consonants: {consonant}\n");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Task 1 - 3");
            string path = Path.Combine(Directory.GetCurrentDirectory(), "text.txt");
            WriteFile(path);
            Console.WriteLine(ReadFile(path));

            Console.WriteLine("\nTask 4");
            string path2 = Path.Combine(Directory.GetCurrentDirectory(), "even.txt");
            string path3 = Path.Combine(Directory.GetCurrentDirectory(), "uneven.txt");
            WriteRandom(path2, path3);

            Console.WriteLine("\nTask 5");
            string path4 = Path.Combine(Directory.GetCurrentDirectory(), "string.txt");
            FindString(path4);
            
            Console.WriteLine("\nTask 6");
            Console.WriteLine("Enter path to File or File name: ");
            string uspath;
            while (true)
            {
               uspath = Console.ReadLine()!;
                if (!File.Exists(uspath))
                {
                    Console.WriteLine("Wrong File path!");
                }
                else { break; }
            }
            FileStats(uspath);
        }
    }
}
