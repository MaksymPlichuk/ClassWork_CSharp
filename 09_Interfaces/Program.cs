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
    class Array : IOutput, Imath, Isort
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
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{i + 1} element = {arr[i]}");
            }
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

        public void SortAsc()
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        var temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("Elements sorted by ascending");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{i + 1} element = {arr[i]}");
            }
        }

        public void SortDesc()
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        var temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("Elements sorted by decending");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{i + 1} element = {arr[i]}");
            }
        }

        public void SortByParam(bool isAsc)
        {
            Console.WriteLine("\nSorting By Parameter");
            if (isAsc) { SortAsc();}
            else { SortDesc(); }
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
            Console.WriteLine("Enter value to search for");
            while (true)
            {
                try
                {
                    val = int.Parse(Console.ReadLine()!);
                    Console.WriteLine(array.Search(val));
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
           
            Console.WriteLine("\nTask 3");
            array.SortAsc(); Console.WriteLine();
            array.SortDesc(); Console.WriteLine();
            bool param = true;
            Console.WriteLine("Enter parameter(true/false): ");
            while (true)
            {
                try{
                    param = bool.Parse(Console.ReadLine()!);
                    array.SortByParam(param);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
              
            
            
            
        }
    }
}
