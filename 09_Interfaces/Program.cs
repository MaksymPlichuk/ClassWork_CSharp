using System;

namespace _09_Interfaces
{
    interface IOutput
    {
        void Show();
        void Show(string info);
    }
    interface Imath
    {
        int Max();
        int Min();
        double Avg();
        bool Search(int valueToSearch);

    }

    interface Isort
    {
        void SortAsc();
        void SortDesc();
        void SortByParam(bool isAsc);
    }
    class Array : IOutput, Imath
    {
        Random random = new Random();
        private int[] arr; 
        public Array()
        {
            arr = new int[5];
        }
        private void Fillarr()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(100);
            }
        }
        public void Show()
        {
            Fillarr();
            for (int i = 0; i < arr.Length; i++) {
                Console.WriteLine($"{i+1} element = {arr[i]}");
            }
        }

        public void Show(string info)
        {
            Console.WriteLine(info);
            Show();
        }

        public int Max()
        {
            return arr.Max();
        }

        public int Min()
        {
            return arr.Min();
        }

        public double Avg()
        {
            return arr.Average();
        }

        public bool Search(int valueToSearch)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == valueToSearch) return true;
                
            }
            return false;
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            Array array = new Array();
            array.Show();
            string msg;
            Console.Write("Write some info about array: ");msg=Console.ReadLine()!;
            array.Show(msg);

            Console.WriteLine("\nTask 2");
            Console.WriteLine($"Max value: {array.Max()}"); 
            Console.WriteLine($"Min value: {array.Min()}"); 
            Console.WriteLine($"Average value: {array.Avg()}"); 
            int val;
            Console.WriteLine("Enter value to search for"); val = int.Parse(Console.ReadLine()!);
            Console.WriteLine(array.Search(val));

            Console.WriteLine("\nTask 3");
        }
    }
}
