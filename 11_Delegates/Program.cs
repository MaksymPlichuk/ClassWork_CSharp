using _11_Delegates;
using System;

namespace _11_Delegates
{
    class Arr
    {
        public void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine();
        }
        public int countNegative(int[] arr)
        {
            int Negative = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    Negative++;
                }
            }
            return Negative;
        }
        public int sumOfElems(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }
        public int countPrime(int[] arr)
        {
            int primeNums = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int number = arr[i];
                if (number < 2) continue;

                int dividers = 0;

                for (int j = 2; j <= Math.Sqrt(number); j++)
                {
                    if (number % j == 0)
                    {
                        dividers++;
                        break;
                    }
                }
                if (dividers == 0)
                {
                    primeNums++;
                }
            }
            return primeNums;
        }

        public void changeNegatives(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    arr[i] = 0;
                }
            }
            Print(arr);
        }

        public void sortArray(ref int[] arr)
        {
            int[] result = new int[arr.Length];
            int evenIndex = 0;
            int oddIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    result[evenIndex] = arr[i];
                    evenIndex++;
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    result[evenIndex + oddIndex] = arr[i];
                    oddIndex++;
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = result[i];
            }
            Print(arr);
        }
    }
    public delegate int ChangeArr(int[]a);
    public delegate void ChangeVoid(ref int[] a);

    internal class Program
    {
        static void Main(string[] args)
        {
            Arr arr1 = new Arr();
            Random rnd = new Random();
            int[] arr = new int [5];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-50,50);
            }
            Console.Write($"Array: "); arr1.Print(arr);
            ChangeArr changeArr = null;
            changeArr = arr1.countNegative;
            Console.WriteLine($"Number of Negatives: {changeArr(arr)}");
            changeArr = arr1.sumOfElems;
            Console.WriteLine($"Sum of Numbers: {changeArr(arr)}");
            changeArr = arr1.countPrime;
            Console.WriteLine($"Number of Prime Numbers: {changeArr(arr)}");

            ChangeVoid changeVoid = null;
            changeVoid = arr1.changeNegatives;
            Console.WriteLine($"Changing negatives to zeros: "); 
            changeVoid(ref arr);

            Console.WriteLine();

            changeVoid = arr1.sortArray;
            Console.WriteLine($"Sorting array even in the begining: ");
            changeVoid(ref arr);
        }
    }
}

