using System.Drawing;

namespace _07_OverloadOperators
{
    class Square
    {
        private int a;

        public Square() { int a = 0; }
        public Square(int val) {int a = val;}
        //public static return_type operator [symbol](parameters )
        public override string ToString()
        {

            return $"a: {a}";
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
        public static explicit operator Square(Rectanlge sq)
        {
            return new Square(sq.A + sq.B);
        }
        public static explicit operator int(Square sq)
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

        public Rectanlge() { int a = 0;int b = 0; }
        public Rectanlge(int av,int bv) { int a = av; int b = bv; }

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
            return sq1.A+sq1.B < sq2.A+sq1.B;
        }
        public static bool operator >(Rectanlge sq1, Rectanlge sq2)
        {
            return (sq1.A+ sq1.B > sq2.A+ sq1.B);
        }
        public static bool operator <=(Rectanlge sq1, Rectanlge sq2)
        {
            return sq1.A+ sq1.B <= sq2.A+ sq1.B;
        }
        public static bool operator >=(Rectanlge sq1, Rectanlge sq2)
        {
            return (sq1.A+ sq1.B >= sq2.A+ sq1.B);
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
            return new Rectanlge(sq.A*sq.A,sq.A+150);
        }
        public static implicit operator int(Rectanlge sq)
        {
            return sq.A * sq.B;
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
