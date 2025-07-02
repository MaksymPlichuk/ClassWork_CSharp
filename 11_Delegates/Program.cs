namespace _11_Delegates
{
    class Arr
    {
        int[] arr;
        public Arr()
        {
            arr = new int[5] {1,56,7,5,4 };
        }
        public int countN()
        {
            int Negative = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]<0)
                {
                    Negative++
                }
            }
            return Negative;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
