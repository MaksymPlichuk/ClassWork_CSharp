using System.Diagnostics.CodeAnalysis;

namespace _01_IntroToDotNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            Console.WriteLine("It's easy to win forgiveness for being wrong;");
            Console.WriteLine("being right is what gets you into real trouble.");
            Console.WriteLine("Bjarne Stroustrup");

            Console.WriteLine("Task 2");
            int sum = 0;
            int product = 1;
            int[] arr = new int[5];
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter {i + 1} number: ");
                arr[i] = int.Parse(Console.ReadLine()!);
            }

            int min = arr[0]; int max = arr[0];
            for (int i = 0; i < 5; i++)
            {
                sum += arr[i];
                product *= arr[i];
                if (arr[i] < min) { min = arr[i]; }
                if (arr[i] > max) { max = arr[i]; }
            }
            Console.WriteLine($"Sum:{sum}");
            Console.WriteLine($"Product:{product}");
            Console.WriteLine($"Min:{min} Max: {max}");

            Console.WriteLine("Task 3");
            int number = 0;
            int result = 0;
            Console.Write("Enter a number to mirror: ");
            number = int.Parse(Console.ReadLine()!); ;
            while (number>0)  
            {
                result = result * 10 + number % 10;
                number=number / 10;
            }
            Console.WriteLine($"Reversed number: {result}");

            Console.WriteLine("Task 4");
            int res;
            int a = 0;
            int b = 1;
            int start, end;
            Console.Write("Enter Fibonacci range start: ");
            start = int.Parse(Console.ReadLine()!);
            Console.Write("Enter Fibonacci range end: "); end = int.Parse(Console.ReadLine() !);
            Console.WriteLine();
            while (start < end)
            {
                res = a + b;
                a = b;
                b = res;
                start++;
                Console.WriteLine(res);
            }

            Console.WriteLine("Task 5");
            int start2;
            int end2;
            Console.Write("Enter number range start: ");
            start2 = int.Parse(Console.ReadLine()!);
            Console.Write("Enter number range end: "); end2 = int.Parse(Console.ReadLine()!);
            while (start2 <= end2) {
                for (int i = 0; i < start2; i++) { Console.Write($"{start2} "); };
                Console.WriteLine();
                start2++;
            }

            Console.WriteLine("Task 6");
            int length;
            char symbol;
            string direction;
            Console.Write("Enter length of the line: "); length = int.Parse(Console.ReadLine()!);
            Console.Write("Enter symbol of the line: "); symbol = char.Parse(Console.ReadLine()!);
            Console.Write("Enter direction (horizontal/vertical): "); direction = (Console.ReadLine()!);
            while (true)
            {
                if (direction=="horizontal") { 
                for (int i = 0; i<length;i++)
                    {
                        Console.Write(symbol);
                    }
                break; 
                }
                else if (direction == "vertical")
                {
                    for (int i = 0; i < length; i++)
                    {
                        Console.WriteLine(symbol);
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Direction!");
                    Console.Write("Wrong Enter direction (horizontal/vertical): "); direction = (Console.ReadLine()!);
                }
            }
        }
    }
}
