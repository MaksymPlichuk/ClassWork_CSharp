namespace _06_ExceptionNamespaces
{
    class CreditCard
    {
        string creditNumber;
        string fullName;

        public string CreditNumber
        {
            get { return creditNumber; }
            set
            {
                if (value.Length == 16) { creditNumber = value; }
                else { throw new Exception("Card number length must be 16!"); }
            }
        }
        public string FullName
        {
            get { return fullName; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    fullName = value;
                }
                else { throw new Exception("Name can't be empty!"); }
            }
        }

        private string cvc;

        public string Cvc
        {
            get { return cvc; }
            set
            {
                if (value.Length == 3) { cvc = value; }
                else { throw new Exception("Cvc length must be 3!"); }
            }
        }

        private DateTime dateOfExpire;

        public DateTime DateOfExpire
        {
            get { return dateOfExpire; }
            set
            {
                if (value < DateTime.Now)
                { dateOfExpire = value; }
                else { throw new Exception("Wrong time!"); }
            }

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task1
            Console.WriteLine("Task 1");
            string num ;
            try
            {
                Console.Write("Enter a number: ");
                num = Console.ReadLine()!;
                int.Parse(num);
                Console.WriteLine($"Number: {num}");
            }           
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("ArgumentNullException");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter a number!");
                Console.WriteLine(ex.Message);
            }
            #endregion
            
            Console.WriteLine("Task 2");
            CreditCard c = new CreditCard();
            try
            {
                Console.Write("Enter card number: "); c.CreditNumber = Console.ReadLine()!;
                Console.Write("Enter full holder name: "); c.FullName = Console.ReadLine()!;
                Console.Write("Enter card cvc: "); c.Cvc = Console.ReadLine()!;
                Console.Write("Enter card date of expire: "); c.DateOfExpire = DateTime.Parse(Console.ReadLine()!);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Arguments must be numbers!");
                Console.WriteLine(e.Message);
            } 
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Task 3");
            string formula;
            Console.Write("Enter mathematic formula: ");formula = Console.ReadLine()!;
            string[] numbers = formula.Split(['*', '/', '+', '-', '?'],StringSplitOptions.RemoveEmptyEntries);
            int[] ints = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++) {
                try
                {
                    ints[i] = int.Parse(numbers[i]);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Arguments must be numbers!");
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            int prod = 1;
            string res;
            res = string.Join(" * ", numbers);
            for (int i = 0; i < ints.Length; i++)
            {
                prod *= ints[i];
            }
            Console.WriteLine($"Result: {res} = {prod}");
        }
    }
}
