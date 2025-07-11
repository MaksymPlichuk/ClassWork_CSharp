namespace _15_Generics
{
    class Stack<T>
    {
        private T[] items;
        public Stack()
        {
            items = new T[0];
        }
        public void Pop()
        {
            if (items.Length == 0)
            {
                Console.WriteLine("Stack is Empty!");
            }
            else
            {
               Array.Resize(ref items, items.Length-1);
            }
        }
        public void Push(T value)
        {
            Array.Resize(ref items,items.Length+1);
            items[items.Length-1] = value;
        }
        public void Peek()
        {
            if(items.Length == 0)
            {
                Console.WriteLine("Stack is Empty!");
            }
            else
            {
                Console.WriteLine($"The top element is: {items[items.Length-1]}");
            }
        }
        public void Count()
        {
            Console.WriteLine($"Number of Elements: {items.Length}");
        }
        public void Print()
        {
            Console.WriteLine("Stack elements: ");
            foreach(var item in items) Console.Write(item + "\t");
            Console.WriteLine();
        }
    }
    class Queue<T>
    {
        private T[] items;
        public Queue()
        {
            items = new T[0];
        }
        public void Dequeue()
        {
            if (items.Length == 0)
            {
                Console.WriteLine("Queue is Empty!");
            }
            else
            {
                T[] array = new T[items.Length-1];
                for(int i = 1; i < items.Length; i++)
                {
                    array[i-1] = items[i];
                }
                items = array;
            }
        }
        public void Inqueue(T val)
        {
            Array.Resize(ref items,items.Length+1);
            items[items.Length - 1] = val;
        }
        public void Peek()
        {
            Console.WriteLine($"The top element is: {items[0]}");
        }
        public void Count()
        {
            Console.WriteLine($"Number of Elements: {items.Length}");
        }
        public void Print()
        {
            Console.WriteLine("Queue elements: ");
            foreach (var item in items) Console.Write(item + "\t");
            Console.WriteLine();
        }
    }
    internal class Program
    {
        static T Maximum<T>(T a, T b, T c) where T: IComparable<T>
        {
            T max = a;

            if (b.CompareTo(max) > 0)  max = b;

            if (c.CompareTo(max) > 0) max = c;

            return max;
        }
        static T Minimum<T>(T a, T b, T c) where T : IComparable<T>
        {
            T min = a;

            if (b.CompareTo(min) < 0) min = b;

            if (c.CompareTo(min) < 0) min = c;

            return min;
        }
        static T Sum<T>(T a, T b, T c) where T : IComparable<T>
        {
            dynamic sum = default(T)!;
            sum = (dynamic)a + (dynamic)b + (dynamic)c;

            return sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1-3");
            int a = 5, b = 7, c = 6;

            Console.Write("Maximum: "); Console.WriteLine(Maximum<int>(a, b, c)); 
            Console.Write("Minimum: "); Console.WriteLine(Minimum<int>(a, b, c)); 
            Console.Write("Sum: "); Console.WriteLine(Sum<int>(a, b, c));

            Console.WriteLine("\nTask 4");
            Stack<int> stack = new Stack<int>();
            stack.Push(a);
            stack.Push(b);
            stack.Push(c);
            stack.Peek();
            stack.Count();
            stack.Pop();
            stack.Count();
            stack.Print();

            Console.WriteLine("\nTask 5");
            Queue<int> q = new Queue<int>();
            q.Inqueue(a);
            q.Inqueue(b);
            q.Inqueue(c);
            q.Peek();
            q.Count();
            q.Dequeue();
            q.Count();
            q.Print();
        }
    }
}
