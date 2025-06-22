using System.ComponentModel.Design;
using System.Security.Cryptography;
using System.Threading.Channels;

namespace _05_StructRefOut
{
    class Worker
    {

        
        public  string Name { get; set; }
        public  string Surname { get; set; }
        public  string Lastname { get; set; }

        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                if (value > 15 && value < 150)
                    age = value;
                else throw new Exception("Age must be from 16 to 150!");
            }
        }

        private int salary;

        public int Salary
        {
            get { return salary; }
            set
            {
                if (value >= 0)
                    salary = value;
                else { salary = 0;
                    Console.WriteLine("Salary must be positive!");
                }
            }
        }

        private DateTime dateOfWork;

        public DateTime DateOfWork
        {
            get { return dateOfWork; }
            set
            {
                if (value < DateTime.Now)
                    dateOfWork = value;
                else throw new Exception("Wrong time!");
            }
        }

    }

    class Calc
    {
        private int a;
        private int b;

        public void initialize()
        {
            Console.Write("Enter a: "); a = int.Parse(Console.ReadLine()!);
            Console.Write("Enter b: "); b = int.Parse(Console.ReadLine()!);
        }
        public void add()
        {
            initialize();
            int res = a + b;
            Console.WriteLine($"Result {a} + {b} = {res}");
        }
        public void sub()
        {
            initialize();
            int res = a - b;
            Console.WriteLine($"Result {a} - {b} = {res}");
        }
        public void multy()
        {
            initialize();
            int res = a * b;
            Console.WriteLine($"Result {a} * {b} = {res}");
        }
        public void div()
        {
            /*
            while (true) { 
            initialize();
                if (b == 0) { Console.WriteLine("Error Can't divide by zero"); }
                else break;
            }*/
            initialize();
            int res = a / b;
            Console.WriteLine($"Result {a} / {b} = {res}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            bool cycle = true;
            Worker[] workers = new Worker[5];
            while (cycle) { 
                try
                {
                    for (int i = 0; i < workers.Length; i++)
                    {
                        workers[i] = new Worker();
                        Console.Write("Enter workers first name: "); workers[i].Name = Console.ReadLine()!;
                        Console.Write("Enter workers middle name: "); workers[i].Surname = Console.ReadLine()!;
                        Console.Write("Enter workers last name: "); workers[i].Lastname = Console.ReadLine()!;
                        Console.Write("Enter workers age: "); workers[i].Age = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter workers salary: "); workers[i].Salary = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter workers date of work (yyyy/mm/dd): "); workers[i].DateOfWork = DateTime.Parse(Console.ReadLine()!);
                        cycle = false;
                    }
                }
                    
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message); ;
                }
            }
            Console.WriteLine($"---Workers---");
            foreach (Worker worker in workers) {
                
                Console.WriteLine($"First name: {worker.Name}\nMiddle name: {worker.Surname}\nLast name: {worker.Lastname}\nAge: {worker.Age}\nSalary: {worker.Salary}\nDate of Work: {worker.DateOfWork}\n ");
            }
            
            Console.WriteLine("Task 2");
            Calc c = new Calc();
            bool cycle2 = true;
            while (cycle2)
            {
                try
                {
                    Console.WriteLine("\nAdding 2 Numbers: ");
                    c.add();
                    Console.WriteLine("\nSubtracting 2 Numbers: ");
                    c.sub();
                    Console.WriteLine("\nMultiplying 2 Numbers: ");
                    c.multy();
                    Console.WriteLine("\nDividing 2 Numbers: ");
                    c.div();
                    break;
                }

                catch (DivideByZeroException e)
                {
                    Console.WriteLine("Divizion by 0!");
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Arguments must be numbers!");
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unknown error!");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
