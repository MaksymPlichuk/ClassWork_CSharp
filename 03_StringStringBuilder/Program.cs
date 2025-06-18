using System.Text;

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
            Console.WriteLine("Enter a word to find out if its palindrom: ");
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
            double lowPerc = 100*numOfLower/line2.Length;
            double uppPerc = 100*numOfUpper/line2.Length;

            Console.WriteLine($"Percentage of lower symbols {lowPerc}, Percentage of upper symbols {uppPerc}");

            Console.WriteLine("\nTask 4");
            string[] words = { "Apple", "Pinapple", "Melon", "Peach", "Orange", "Pear" };
            Console.Write("Before edit: ");
            for (int i = 0; i < words.Length; i++)
            {
                Console.Write(words[i] + " ");
                if (words[i].Length>4)
                {
                    words[i] = words[i].Substring(0, words[i].Length - 3) + "$$$";
                }
            }
            Console.Write("\nAfter edit :");
            foreach (string word in words) { Console.Write(word + " ");}
            Console.WriteLine();

            Console.WriteLine("\nTask 5");
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam lacinia nulla eget ante cursus varius.";
            string[] textwords = text.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int number;
           
            while (true)
            {
                Console.Write("Enter index of word to get it first letter: ");
                number = int.Parse(Console.ReadLine()!);
                if (number < 0 || number > textwords.Length)
                {
                    Console.WriteLine("Wrong number!");
                }
                else {break; }
            }
            for (int i = 0; i < textwords.Length; i++) {
                if (i == number)
                {
                   Console.WriteLine($"The word is:{textwords[i]}");
                   Console.WriteLine($"The first letter is: {textwords[i].Substring(0,1)}");
                }    
            }

            Console.WriteLine("\nTask 6");
            string text2 = "The first rule of fight club is - you don't talk about fight club. \n The second rule of fight club is - you don't talk about fight club. \n The third rule of fight club is - when someone says \"stop\" or goes limp, the  fight is over. \n Fourth rule is - only two guys to a fight. \n Fifth rule - one fight at a time. \n Sixth rule - no shirts, no shoes. \n Seventh rule - fights go on as long as they have to. \n And the eighth and final rule - if this is your first night at fight club, you have to fight.";
            string[] text2words = text2.Split(new char[] { ' ', '-', '.', ',', '!', '?', '/' }, StringSplitOptions.RemoveEmptyEntries);
            string text2new = string.Join("*", text2words);
            Console.WriteLine(text2new);

            Console.WriteLine("\nTask 7");
            StringBuilder sb = new StringBuilder();
            string userword = "";
            while (true)
            {
                Console.Write("Enter a word: "); userword = Console.ReadLine()!;
                if (userword.EndsWith('.'))
                {
                    sb.Append(userword);
                    break;
                }
                else { sb.Append(userword + ", "); }

            }
            Console.WriteLine($"\nResult: {sb}");
            Console.WriteLine();
        }
    }
}
