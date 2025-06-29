namespace _08_InheritanceIndexers
{
    abstract class GeometricShape{
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }
    class Triangle : GeometricShape
    {
        private int a;

        public int A
        {
            get { return a; }
            set
            {
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
            set
            {
                if (value > 0) { c = value; }
                else { c = 0; }
            }
        }
        public Triangle()
        {
            A = 0; B = 0; C = 0;
        }
        public Triangle(int a, int b, int c)
        {
            A = a; B = b; C = c;
        }
        public override double GetPerimeter()
        {
            int res = A + B + C;
            Console.WriteLine($"Perimeter of Triangle: {res}");
            return res;
        }
        public override double GetArea()
        {
            double p = (A + B + C) / 2;
            double res = Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            Console.WriteLine($"Area of Triangle: {res}");
            return res;
        }
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
        public override double GetPerimeter() {
            double res = A * 4;
            Console.WriteLine($"Peimeter of Square: {res}");
            return res;
        }
        public override double GetArea() {
            double res = A * A;
            Console.WriteLine($"Area of Square: {res}");
            return res;
        }
    }
    class Rhomboid : GeometricShape
    {
        private int a;

        public int A
        {
            get { return a; }
            set
            {
                if (value > 0) a = value;
                else a = 0;
            }
        }
        private int d1;

        public int D1
        {
            get { return d1; }
            set
            {
                if (value > 0) d1 = value;
                else d1 = 0;
            }
        }
        private int d2;
        public int D2
        {
            get { return d2; }
            set
            {
                if (value > 0) d2 = value;
                else d2 = 0;
            }
        }
        public Rhomboid()
        {
            A = 0; D1 = 0; D2 = 0;
        }
        public Rhomboid(int a, int d1, int d2)
        {
            A = a; D1 = d1; D2 = d2;
        }
        public override double GetArea() { 
            double res = (D1 * D2)/2;
            Console.WriteLine($"Area of Rhomboid: {res}");
            return res;
        }
        public override double GetPerimeter(){
            double res = A*4;
            Console.WriteLine($"Peimeter of Rhomboid: {res}");
            return res;
        }
    }
    class Rectangle : GeometricShape
    {
        private int a;

        public int A
        {
            get { return a; }
            set
            {
                if (value > 0) a = value;
                else a = 0;
            }
        }
        private int b;

        public int B
        {
            get { return b; }
            set
            {
                if (value > 0) b = value;
                else b = 0;
            }
        }
        public Rectangle()
        {
            A = 0;B = 0;
        }
        public Rectangle(int a, int b)
        {
            A=a; B= b;
        }
        public override double GetArea(){
            double res = A*B;
            Console.WriteLine($"Area of Rectangle: {res}");
            return res;
        }
        public override double GetPerimeter(){
            double res = (A+B) * 2;
            Console.WriteLine($"Peimeter of Rectangle: {res}");
            return res;
        }
    }
    class Parallelogram : GeometricShape
    {
        private int a;

        public int A
        {
            get { return a; }
            set
            {
                if (value > 0) a = value;
                else a = 0;
            }
        }
        private int b;

        public int B
        {
            get { return b; }
            set
            {
                if (value > 0) b = value;
                else b = 0;
            }
        }
        private int h;

        public int H
        {
            get { return h; }
            set
            {
                if (value > 0) h = value;
                else h = 0;
            }
        }
        public Parallelogram()
        {
            A=0; B= 0; H= 0;
        }
        public Parallelogram(int a, int b, int h)
        {
            A = a; B = b; H = h;
        }
        public override double GetArea(){
            double res = A * H;
            Console.WriteLine($"Area of Parallelogram: {res}");
            return res;
        }
        public override double GetPerimeter(){
            double res = (A + B) * 2;
            Console.WriteLine($"Peimeter of Parallelogram: {res}");
            return res;
        }
    }
    class Trapezoid: GeometricShape
    {
        private int a;

        public int A
        {
            get { return a; }
            set
            {
                if (value > 0) a = value;
                else a = 0;
            }
        }
        private int b;

        public int B
        {
            get { return b; }
            set
            {
                if (value > 0) b = value;
                else b = 0;
            }
        }
        private int c;

        public int C
        {
            get { return c; }
            set
            {
                if (value > 0) c = value;
                else c = 0;
            }
        }
        private int d;

        public int D
        {
            get { return d; }
            set
            {
                if (value > 0) d = value;
                else d = 0;
            }
        }
        private int h;

        public int H
        {
            get { return h; }
            set
            {
                if (value > 0) h = value;
                else h = 0;
            }
        }
        public Trapezoid()
        {
            A=0; B=0; C=0; D = 0; H=0;
        }
        public Trapezoid(int a, int b, int c, int d, int h)
        {
            A=a; B=b; C=c; D=d; H=h;
        }
        public override double GetArea(){
            double res = (A + B) / 2 * H;
            Console.WriteLine($"Area of Trapezoid: {res}");
            return res;
        }
        public override double GetPerimeter(){
            double res = A+B+C+D;
            Console.WriteLine($"Peimeter of Trapezoid: {res}");
            return res;
        }
    }
    class Circle: GeometricShape
    {
        private int r;
        public int R
        {
            get { return r; }
            set {if (value > 0) r = value; 
                else r = 0; }
        }
        public Circle()
        {
            R= 0;
        }
        public Circle(int r)
        {
            R = r;
        }
        public override double GetArea() {
            double res = Math.PI * R*R;
            Console.WriteLine($"Area of Circle: {res}");
            return res;
        }
        public override double GetPerimeter(){
            double res = 2* Math.PI * R;
            Console.WriteLine($"Peimeter of Circle: {res}");
            return res;
        }
    }
    class Ellipse: GeometricShape
    {
        private int a;
        public int A
        {
            get { return a; }
            set
            {
                if (value > 0) a = value;
                else a = 0;
            }
        }
        private int b;

        public int B
        {
            get { return b; }
            set
            {
                if (value > 0) b = value;
                else b = 0;
            }
        }
        public Ellipse()
        {
            A= 0; B= 0;
        }
        public Ellipse(int a, int b)
        {
            A= a; B = b;
        }
        public override double GetArea(){
            double res = Math.PI * A * B;
            Console.WriteLine($"Area of Ellipse: {res}");
            return res;
        }
        public override double GetPerimeter(){
            double res = Math.PI*3*(A+B)-Math.Sqrt((3*A+B)*(A+3*B));
            Console.WriteLine($"Peimeter of Ellipse: {res}");
            return res;
        }
    }
    class CompositeShape: GeometricShape
    {
        private GeometricShape[] shapes;
        public CompositeShape(params GeometricShape[] shapes)
        {
            this.shapes = shapes;
        }
        public override double GetArea() {
            double res = 0;
            for (int i = 0; i < shapes.Length; i++) {
                res += shapes[i].GetArea();
            }
            return Math.Round(res, 3);
        }
        public override double GetPerimeter() {
            double res = 0;
            for (int i = 0; i < shapes.Length; i++)
            {
                res += shapes[i].GetPerimeter();
            }
            return Math.Round(res, 3);
        }
    }
        internal class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(4,6,8);
            Rhomboid rhomboid = new Rhomboid(5,9,6);
            Rectangle rectangle = new Rectangle(5,6);
            Parallelogram parallelogram = new Parallelogram(2,6,7);
            Trapezoid trapezoid = new Trapezoid(1, 2, 6, 4, 2);
            Circle circle = new Circle(4);
            Ellipse ellipse = new Ellipse(8,6);

            triangle.GetPerimeter();triangle.GetArea(); Console.WriteLine();
            rhomboid.GetPerimeter(); rhomboid.GetArea(); Console.WriteLine();
            rectangle.GetPerimeter(); rectangle.GetArea(); Console.WriteLine();
            parallelogram.GetPerimeter(); parallelogram.GetArea(); Console.WriteLine();
            triangle.GetPerimeter(); triangle.GetArea(); Console.WriteLine();
            circle.GetPerimeter(); circle.GetArea(); Console.WriteLine();
            ellipse.GetPerimeter(); ellipse.GetArea(); Console.WriteLine();

            Console.WriteLine("------------Composite Shape----------");
            CompositeShape compositeShape = new CompositeShape(triangle,rhomboid,rectangle,parallelogram,triangle,circle,ellipse);
            var res = compositeShape.GetPerimeter();
            Console.WriteLine($"Sum of all Shapes Perimeters: {res}"); Console.WriteLine();
            var prod = compositeShape.GetArea();
            Console.WriteLine($"Sum of all Shapes Areas: {prod}");
        }
    }
}
