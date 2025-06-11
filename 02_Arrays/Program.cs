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

            Console.WriteLine("Task 2");
         
            int[] arr2 = new int[5];
            int value;
            int numOfValues=0;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Enter {i + 1} element: ");
                arr[i] = int.Parse(Console.ReadLine()!);
            }
            Console.Write("Enter a value to compare less than: ");
            value = int.Parse(Console.ReadLine()!);
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]<value)
                {
                    numOfValues++;
                }
            }
            Console.WriteLine($"Number of values that are less than {value} are : {numOfValues}");

            Console.WriteLine("Task 3");
            /*Оголосити одновимірний (5 елементів) масив з назвою
		A i двовимірний масив (3 рядки, 4 стовпці) дробових чисел
		з назвою B. Заповнити одновимірний масив А числами,
		введеними з клавіатури користувачем, а двовимірний
		масив В — випадковими числами за допомогою циклів.
		Вивести на екран значення масивів: масиву А — в один
		рядок, масиву В — у вигляді матриці. Знайти у даних
		масивах загальний максимальний елемент, мінімальний
		елемент, загальну суму усіх елементів, загальний добуток
		усіх елементів, суму парних елементів масиву А, суму
		непарних стовпців масиву В.*/
        }
    }
}
