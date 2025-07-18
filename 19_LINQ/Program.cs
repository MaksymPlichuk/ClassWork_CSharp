namespace _19_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            int[] nums = { 1, -2, 3, -4, 5, 6, -7, 8, };
            
            Console.Write("All nums: ");
            foreach (int item in nums)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            var PositiveNums = nums.Where(i=> i > 0).OrderBy(i => i);
            Console.Write("Positive numbers: ");
            foreach (int i in PositiveNums) {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            var Positive2 = from int i in nums where i > 0 orderby i select i;
            Console.Write("Positive numbers 2: ");
            foreach (int i in Positive2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Task 2");

            int[] nums2 = { 19, -25, 37, -42, 564, 621, -74, 89, 6, 52 };
            Console.Write("All numbers: ");
            foreach (int i in nums2)
            {
                Console.Write(i + " ");
            }

            var BigPositive = nums2.Where(i=> i>= 10 && i<= 99).Count();
            Console.WriteLine($"Number of positive decimal numbers: {BigPositive}");

            var BigAvg = nums2.Average(i >= 10 && i <= 99);
        }
    }
}
