namespace _15_Generics
{
    internal class Program
    {
        static T Maximum<T>(T a, T b, T c) where T: IComparable<T>
        {
            T max = a;
            max = b.CompareTo(c) == 0 ? b : c;

            max = a.CompareTo(c) == 0 ? a : c;

            max = a.CompareTo(b) == 0 ? a : b;

            return max;
        }
        static T Minimum<T>(T a, T b, T c) where T : IComparable<T>
        {
            T max = a;
            max = b.CompareTo(c) == 0 ? c : b;

            max = a.CompareTo(c) == 0 ? c : a;

            max = a.CompareTo(b) == 0 ? b : c;

            return max;
        }
        static T Sum<T>(T a, T b, T c) where T : IComparable<T>
        {
            T sum = default(T)!;
            sum = a + b + c;

            return sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            int a = 5, b = 7, c = 6;

            Console.Write("Maximum: "); Console.WriteLine(Maximum<int>(a, b, c)); 
            Console.Write("Minimum: "); Console.WriteLine(Minimum<int>(a, b, c)); 



        }
    }
}
