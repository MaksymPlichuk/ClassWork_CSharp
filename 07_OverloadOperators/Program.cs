using System.Drawing;

namespace _07_OverloadOperators
{
    class Square
    {
        private int a;

        public Square() { A = 0; }
        public Square(int val) { A = val;}
        //public static return_type operator [symbol](parameters )
        public override string ToString()
        {

            return $"A: {A}";
        }

        public int A
        {
            get { return a; }
            set {if (value < 0)
                    a = 0;
                else a = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Square square &&
                   a == square.a;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(a);
        }

        public static Square operator ++(Square sq)
        {
            sq.A++;
            return sq;
        }
        public static Square operator --(Square sq)
        {
            sq.A--;
            return sq;
        }
        public static Square operator +(Square sq1,Square sq2)
        {
            Square res = new Square
            {
                A = sq1.A + sq2.A
            };
            return res;
        }
        public static Square operator -(Square sq1,Square sq2)
        {
            Square res = new Square
            { 
                A = sq1.A - sq2.A
            };
            return res;
        }
        public static Square operator *(Square sq1,Square sq2)
        {
            Square res = new Square
            {
                A = sq1.A * sq2.A
            };
            return res;
        }
        public static Square operator /(Square sq1,Square sq2)
        {
            Square res = new Square
            {
                A = sq1.A / sq2.A
            };
            return res;
        }
        public static bool operator <(Square sq1,Square sq2)
        {
            return sq1.A < sq2.A;
        }
        public static bool operator >(Square sq1,Square sq2)
        {
            return (sq1.A > sq2.A);
        }
        public static bool operator <=(Square sq1, Square sq2)
        {
            return sq1.A <= sq2.A;
        }
        public static bool operator >=(Square sq1, Square sq2)
        {
            return (sq1.A >= sq2.A);
        }
        public static bool operator ==(Square sq1, Square sq2)
        {
            return (sq1.A == sq2.A);
        } 
        public static bool operator !=(Square sq1, Square sq2)
        {
            return (sq1.A != sq2.A);
        }

        public static bool operator true(Square sq1)
        {
            return sq1.A != 0;
        }
        public static bool operator false(Square sq1)
        {
            return sq1.A == 0;
        }
        public static explicit operator Square(Rectanlge rc)
        {
            return new Square(rc.A + rc.B);
        }
        public static implicit operator int(Square sq)
        {
            return sq.A * sq.A;
        }
    }
    class Rectanlge
    {
        private int a;
        private int b;
        

        public int A
        {
            get { return a; }
            set { if (value < 0) a = 0;
                else { a = value; }
            }
        }
        public int B
        {
            get { return b; }
            set { if (value < 0) b = 0;
                else { b = value; }
            }
        }

        public Rectanlge() {  A = 0; B = 0; }
        public Rectanlge(int av,int bv) { A = av;  B = bv; }

        public override string ToString()
        {

            return $"A: {A}, B: {B}";
        }
        public static Rectanlge operator ++(Rectanlge sq)
        {
            sq.A++;
            sq.B++;
            return sq;
        }
        public static Rectanlge operator --(Rectanlge sq)
        {
            sq.A--;
            sq.B--;
            return sq;
        }
        public static Rectanlge operator +(Rectanlge sq1, Rectanlge sq2)
        {
            Rectanlge res = new Rectanlge
            {
                A = sq1.A + sq2.A,
                B = sq1.B + sq2.B
            };
            return res;
        }
        public static Rectanlge operator -(Rectanlge sq1, Rectanlge sq2)
        {
            Rectanlge res = new Rectanlge
            {
                A = sq1.A - sq2.A,
                B = sq1.B - sq2.B
            };
            return res;
        }
        public static Rectanlge operator *(Rectanlge sq1, Rectanlge sq2)
        {
            Rectanlge res = new Rectanlge
            {
                A = sq1.A * sq2.A,
                B = sq1.B * sq2.B
            };
            return res;
        }
        public static Rectanlge operator /(Rectanlge sq1, Rectanlge sq2)
        {
            Rectanlge res = new Rectanlge
            {
                A = sq1.A / sq2.A,
                B = sq1.B / sq2.B
            };
            return res;
        }
        public static bool operator <(Rectanlge sq1, Rectanlge sq2)
        {
            return sq1.A+sq1.B < sq2.A+sq2.B;
        }
        public static bool operator >(Rectanlge sq1, Rectanlge sq2)
        {
            return (sq1.A+ sq1.B > sq2.A+ sq2.B);
        }
        public static bool operator <=(Rectanlge sq1, Rectanlge sq2)
        {
            return sq1.A+ sq1.B <= sq2.A+ sq2.B;
        }
        public static bool operator >=(Rectanlge sq1, Rectanlge sq2)
        {
            return (sq1.A+ sq1.B >= sq2.A+ sq2.B);
        }
        public static bool operator ==(Rectanlge sq1, Rectanlge sq2)
        {
            return (sq1.A == sq2.A && sq1.B == sq2.B);
        }
        public static bool operator !=(Rectanlge sq1, Rectanlge sq2)
        {
            return (sq1.A != sq2.A || sq1.B != sq2.B);
        }

        public static bool operator true(Rectanlge sq1)
        {
            return sq1.A != 0 && sq1.B != 0;
        }
        public static bool operator false(Rectanlge sq1)
        {
            return sq1.A == 0 && sq1.B == 0; ;
        }

        public override bool Equals(object? obj)
        {
            return obj is Rectanlge rectanlge &&
                   a == rectanlge.a &&
                   b == rectanlge.b &&
                   A == rectanlge.A &&
                   B == rectanlge.B;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(a, b, A, B);
        }

        public static implicit operator Rectanlge(Square sq)
        {
            return new Rectanlge(sq.A*sq.A,sq.A+1000);
        }
        public static explicit operator int(Rectanlge sq)
        {
            return sq.A * sq.B;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Square sq = new Square(5);
            Rectanlge rc = new Rectanlge(7, 9);
            

            Square sq2 = new Square(4);
            Console.Write($"Square 1: {sq}"); Console.Write($"\t\tSquare 2: {sq2}\n");
            Console.WriteLine($"Increment: {sq++}");
            Console.WriteLine($"Decrement: {sq--}");
            Console.WriteLine();
            Console.WriteLine($"Adding sq and sq2: {sq+sq2}");
            Console.WriteLine($"Subtracting sq and sq2: {sq-sq2}");
            Console.WriteLine($"Multypliyng sq and sq2: {sq*sq2}");
            Console.WriteLine($"Dividing sq and sq2: {sq/sq2}");
            Console.WriteLine();
            Console.WriteLine($"Comparing sq > sq2: {sq>sq2}");
            Console.WriteLine($"Comparing sq >= sq2: {sq>=sq2}");
            Console.WriteLine($"Comparing sq < sq2: {sq<sq2}");
            Console.WriteLine($"Comparing sq <= sq2: {sq<=sq2}");
            Console.WriteLine($"Comparing sq == sq2: {sq==sq2}");
            Console.WriteLine($"Comparing sq != sq2: {sq!=sq2}");
            Console.WriteLine();
            Console.WriteLine("Comparing if sq is true (!= 0)");
            if (sq) { Console.WriteLine("sq is True"); }
            else { Console.WriteLine("sq is False"); }
            Console.WriteLine();
            int a = 6;
            a = sq;
            Console.WriteLine($"Converting sq to int: {a}");
            Square convRc = (Square)rc;
            Console.WriteLine($"Converting explicitly Rectangle to Square: {convRc}");

            Rectanlge rc2 = new Rectanlge(1, 4);
            Console.Write($"\nRectangle 1: {rc}"); Console.Write($"\t\tRectangle 2: {rc2}\n");
            Console.WriteLine($"Increment: {rc++}");
            Console.WriteLine($"Decrement: {rc--}");
            Console.WriteLine();
            Console.WriteLine($"Adding rc and rc2: {rc + rc2}");
            Console.WriteLine($"Subtracting rc and rc2: {rc - rc2}");
            Console.WriteLine($"Multypliyng rc and rc2: {rc * rc2}");
            Console.WriteLine($"Dividing rc and rc2: {rc / rc2}");
            Console.WriteLine();
            Console.WriteLine($"Comparing rc > rc2: {rc > rc2}");
            Console.WriteLine($"Comparing rc >= rc2: {rc >= rc2}");
            Console.WriteLine($"Comparing rc < rc2: {rc < rc2}");
            Console.WriteLine($"Comparing rc <= rc2: {rc <= rc2}");
            Console.WriteLine($"Comparing rc == rc2: {rc == rc2}");
            Console.WriteLine($"Comparing rc != rc2: {rc != rc2}");
            Console.WriteLine();
            Console.WriteLine("Comparing if rc is true (!= 0)");
            if (rc) { Console.WriteLine("rc is True"); }
            else { Console.WriteLine("rc is False"); }
            int b = 4;
            b = (int)rc;
            Console.WriteLine($"Converting rc to int: {b}");
            Rectanlge convSq = sq;
            Console.WriteLine($"Converting implicitly Square to Rectangle: {convSq}");
        }
    }
}
