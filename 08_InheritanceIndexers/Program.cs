namespace _08_InheritanceIndexers
{
    abstract class GeometricShape{
        public abstract void GetArea();
        public abstract void Perimeter();
    }
    class Triangle: GeometricShape
    {
        private int a;

        public int A
        {
            get { return a; }
            set {
                if (value > 0) { a = value; }
                else { a = 0; }
                }
        }
        private int b;

        public int B
        {
            get { return b; }
            set
            {
                if (value > 0) { b = value; }
                else { b = 0; }
            }
        }
        private int c;

        public int C
        {
            get { return c; }
            set {
                if (value > 0) { c = value; }
                else { c = 0; }
                }
        }
        public Triangle()
        {
            A=0; B=0; C=0;
        }
        public Triangle(int a,int b,int c)
        {
            A = a; A = b; A = c;
        }
        public override void Perimeter() {
            int res = A + B + C;
            Console.WriteLine($"Perimeter of Tirangle: {res}");
        }
        public override void GetArea()
        {
            double p = (A + B + C) / 2;
           double res = Math.Sqrt(p*(p-A)*(p-B)*(p-C));
           Console.WriteLine($"Area of Tirangle: {res}");
        }
        class Square: GeometricShape
        {
            private int a;

            public int A
            {
                get { return a; }
                set {
                    if (value > 0) { a = value; }
                    else { a = 0; }
                }
            }
            public Square()
            {
                A = 0;
            }
            public Square(int a)
            {
                A = a;
            }
            public override void Perimeter() {
                int res = A * 4;
                Console.WriteLine($"Peimeter of Square: {res}");
            }
            public override void GetArea() {
                int res = A * A;
                Console.WriteLine($"Area of Square: {res}");
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
