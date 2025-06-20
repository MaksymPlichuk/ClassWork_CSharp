namespace _06_ExceptionNamespaces
{
    class CreditCard
    {
        string creditNumber;
        string fullName;
        int cvc;
        DateTime dateOfExpire;

        public string CreditNumber
        {
            get { return creditNumber; }
            set
            {
                if (creditNumber.Length == 16) { creditNumber = value; }
                else { throw new Exception("Card number length must be 16!"); }
            }
        }
        public string FullName
        {
            get { return fullName; }
            set
            {
                if (value != string.IsNullOrEmpty)
                {
                    fullName = value;
                }  
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
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter a number!");
                Console.WriteLine(ex.Message);
            }
            #endregion

        }
    }
}
