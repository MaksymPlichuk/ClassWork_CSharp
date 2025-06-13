namespace _03_StringStringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            string str1 = "Lorem ipsum dolor";
            string str2 = "LLL";
            Console.WriteLine($"Before: {str1} , {str2}");
            str2 = str1.Insert(5, str2);
            Console.WriteLine($"After: {str2}");

            Console.WriteLine("\nTask 2");
            Console.WriteLine("Enter a word: ");
            string word1 = Console.ReadLine()!;
            char[] word2 = word1.ToCharArray();
            string reverse = "";

            for (int i = word2.Length - 1; i >= 0; i--) { 
                reverse = reverse + word2[i];
            }
            Console.WriteLine(reverse);
            if (reverse==word1) { Console.WriteLine($"The word {word1} is palindrom!");}
            else { Console.WriteLine($"The word {word1} is not palindrom!"); }

            Console.WriteLine("\nTask 3");
            int numOfUpper = 0;
            int numOfLower = 0;
            Console.WriteLine("Enter a line: ");
            string line1 = Console.ReadLine()!;
            char[]line2 = line1.ToCharArray();
            for (int i = 0; i < line2.Length; i++)
            {
                if (Char.IsLower(line2[i])) { numOfLower++; }
                if (Char.IsUpper(line2[i])) { numOfUpper++; }
            }
            double lowPerc = 0.1*numOfLower/line2.Length;
            double uppPerc = 0.1*numOfUpper/line2.Length;

            Console.WriteLine($"Percentage of lower symbols {lowPerc}, Percentage of lower symbols {uppPerc}");
        }
    }
}
