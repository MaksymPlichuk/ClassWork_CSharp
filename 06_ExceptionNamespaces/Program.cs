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
        {/*
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
            */
            Console.WriteLine("Task 2");
            CreditCard c = new CreditCard();
            try
            {
                Console.Write("Enter card number: "); c.CreditNumber = Console.ReadLine()!;
            }
            catch (Exception e )
            {
                Console.WriteLine(e.Message);
            } 
            try
            {
                Console.Write("Enter full holder name: "); c.FullName = Console.ReadLine()!;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
            try
            {
                Console.Write("Enter card cvc: "); c.Cvc = Console.ReadLine()!;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Arguments must be numbers!");
                Console.WriteLine(e.Message);
            }
            try
            {
                Console.Write("Enter card date of expire: "); c.DateOfExpire = DateTime.Parse(Console.ReadLine()!);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
                

        }
    }
}
