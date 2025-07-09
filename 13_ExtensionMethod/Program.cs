namespace _13_ExtensionMethod
{
    static class Extensions
    {
        public static void IsPalindrom(this string data)
        {
            char[] sentence = data.ToCharArray();
            string reverse = "";

            for (int i = sentence.Length - 1; i >= 0; i--) {
                reverse = reverse + sentence[i];
            }

            if (data == reverse) { Console.WriteLine($"The sentence '{data}' is Palindrom!"); }
            else { Console.WriteLine($"The sentence '{data}' is not a Palindrom!"); }
        }
        public static void Encryption(this string data, int key)
        {
            char[] word = data.ToCharArray();
            for (int i = 0; i < word.Length; i++)
            {
                word[i] = (char)(word[i] + key);
            }
            string res = new string(word);
            Console.WriteLine($"Encrypted word: {res}");
        }
        public static void SimilarFinder(this int[] data) {
            int res = 0;
            for (int i = 0; i < data.Length; i++) 
            {
                for (int j = i+1; j < data.Length - 1; j++) 
                {
                    if (data[i] == data[j]) 
                    { 
                        res++;
                        break;
                    }
                }
            }
            Console.WriteLine($"Number of simmilar elements: {res}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            string s1;
            Console.Write("Enter a sentence: "); s1 = Console.ReadLine()!;
            s1.IsPalindrom();

            Console.WriteLine("\nTask 2");
            string word; int key;
            Console.Write("Enter a word: "); word = Console.ReadLine()!;
            Console.Write("Enter a number to encrypt: "); key = int.Parse(Console.ReadLine()!);
            word.Encryption(key);

            Console.WriteLine("\nTask 3");
            Random rnd = new Random();
            int[] arr = new int[5];
            for (int i = 0;i < arr.Length;i++)
            {
                arr[i] = rnd.Next(1,5);
                Console.Write(arr[i]+"\t");
            }
            Console.WriteLine();
            arr.SimilarFinder();

        }
    }
}
