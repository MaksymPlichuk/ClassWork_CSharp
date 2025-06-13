namespace _02_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Task 1");
            int[] arr = new int[5];
            int even = 0;
            int uneven = 0;
            int countUniqe = 0;
            int[] uniq = new int[5];

            for (int i = 0; i < arr.Length; i++) {
                Console.Write($"Enter {i+1} element: ");
                arr[i] = int.Parse(Console.ReadLine()!);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0) { uneven++; }
                else if (arr[i] % 2 == 0) { even++; }

                bool uniqe = true;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        uniqe = false;
                        break;
                    }
                }
                if (uniqe)
                {
                    countUniqe++;
                    uniq[countUniqe - 1] = arr[i];
                }
            }
            Console.WriteLine($"Number of uniqe elements: {uniq.Length}"); 
            Console.WriteLine($"Number of even elements: {even}"); 
            Console.WriteLine($"Number of uneven elements: {uneven}");

            Console.WriteLine("\nTask 2");
         
            int[] arr2 = new int[5];
            int value;
            int numOfValues=0;
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write($"Enter {i + 1} element: ");
                arr2[i] = int.Parse(Console.ReadLine()!);
            }
            Console.Write("\nEnter a value to compare less than: ");
            value = int.Parse(Console.ReadLine()!);
            for (int i = 0; i < arr2.Length; i++)
            {
                if (arr2[i]<value)
                {
                    numOfValues++;
                }
            }
            Console.WriteLine($"Number of values that are less than {value} are : {numOfValues}");

            Console.WriteLine("\nTask 3");
            Random random = new Random();
            int[] A = new int[5];
            double[,] B = new double[3,4];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                Console.Write($"Enter {i + 1} element: ");
                A[i] = int.Parse(Console.ReadLine()!);
            }
            Console.WriteLine("First Array: ");
            for (int i = 0; i < A.GetLength(0); i++)
            {
                Console.Write(A[i] + " ");
            }
            Console.WriteLine();
          
            Console.WriteLine("\nSecond Array: ");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = Math.Round(random.NextDouble(),2);
                    Console.Write(B[i,j] + " ");
                }
                Console.WriteLine();
            }
            int min = A[0]; int max = A[0]; int sum = 0; int product = 1; int sumEven = 0;

            for (int i = 0;i < A.GetLength(0); i++) { 
                if (A[i] < min) {min = A[i];}
                if (A[i] > max) {max = A[i];}
                if (A[i] % 2 == 0) { sumEven += A[i]; }
                sum += A[i];
                product*=A[i];
            }
            Console.WriteLine($"\nArray 1: Minium {min}, Maximum {max}, Sum {sum}, Product {product}, Sum of even {sumEven}");

            double min2 = B[0,0]; double max2 = B[0,0]; double sum2 = 0; double product2 = 1; double sumUnvenJ = 0;
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    if (B[i,j] < min2) { min2 = B[i, j]; }
                    if (B[i,j] > max2) { max2 = B[i, j]; }
                    if (j % 2 != 0) { sumUnvenJ += B[i, j]; }
                    sum2 += B[i, j];
                    product2 *= B[i, j];
                }
            }
            Console.WriteLine($"Array 2: Minium {min2}, Maximum {max2}, Sum {sum2}, Product {product2}, Sum of Uneven Columns {sumUnvenJ}");

            Console.WriteLine("\nTask 4");
            int[,] arr4 = new int[5,5];
            int max4 = arr4[0,0]; int min4 = arr4[0, 0]; int sumBetween = 0;
            for (int i = 0; i < arr4.GetLength(0); i++)
            {
                for (int j = 0; j < arr4.GetLength(1); j++)
                {
                    arr4[i, j] = random.Next(-100,101);
                    Console.Write(arr4[i, j] + " ");
                    if (arr4[i, j] > max4) { max4 = arr4[i, j]; }
                    if (arr4[i, j] < min4) { min4 = arr4[i, j]; }
                }
                Console.WriteLine();
            }
            for (int i = 0; i < arr4.GetLength(0); i++)
            {
                for (int j = 0; j < arr4.GetLength(1); j++)
                {
                    if (arr4[i, j] < max4 && arr4[i, j] > min4) {sumBetween+=arr4[i,j]; }
                }
            }
            Console.WriteLine($"\nArray 4: Minimum {min4}, Maximum {max4}, Sum Between {sumBetween}");

            Console.WriteLine("\nTask 5");
            int[] arr5 = new int[5];
            int count5 = 0;
            Console.WriteLine("Array 5: ");
            for (int i = 0; i < arr5.Length; i++)
            {
                arr5[i] = random.Next(100);
                Console.Write(arr5[i] + " ");    
            }
            int min5 = arr5[0];
            for (int i = 0; i < arr5.Length; i++)
            {
                if (arr5[i] < min5) { min5 = arr5[i]; }
            }
            Console.WriteLine($"\nMinimum element {min5}");
            Console.Write($"\nElements that are > than {min5}+5: ");
            for (int i = 0; i < arr5.Length; i++)
            {
                if (arr5[i] >= min5 + 5) { count5++; Console.Write(arr5[i] + " "); }
            }
            Console.WriteLine($"\nNumber of Elements that are > than {min5}+5: {count5}");
        }
    }
}
