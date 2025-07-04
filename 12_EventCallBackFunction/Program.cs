namespace _12_EventCallBackFunction
{
    //public event birga delegate//vsi treyder
    class Exchange
    {
        private double excRate;

        public double ExcRate
        {
            get { return excRate; }
            set
            {
                if (value > 0)
                    excRate = value;
                else value = 0;
            }
        }
        public double MinVal { get; set; }
        public double MaxVal { get; set; }

        public Exchange()
        {
            ExcRate = 0;
            MinVal = 0;
            MaxVal = 0;
        }
        public Exchange(double ec, double min, double max)
        {
            ExcRate = ec;
            MinVal = min;
            MaxVal = max;
        }
        //List<Trader> traders = new List<Trader>();
        public event MyActionDelegate MyActionDelegate;
    }
    public delegate void MyActionDelegate(double ExcRate);
    class Trader
    {
        public string Name { get; set; }
        public double CurrencyAmmont { get; set; }
        public Trader()
        {
            Name = "NN";
            CurrencyAmmont = 0;

        }
        public Trader(string n, int a)
        {
            Name = n; CurrencyAmmont = a;
        }
        public void MyAction(double ExcRate) {
            if (ExcRate < 42)
            {
                Console.WriteLine("I buy USDT");
            }
            if (ExcRate > 45)
            {
                Console.WriteLine("I sell USDT");
            }
            else { Console.WriteLine("Im am holding"); }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Exchange exchange = new Exchange() { 40, 39, 46 };
            

            foreach (Student student in students)
            {
                //teacher.ExamDelegate +=  new ExamDelegate(student.PassExam);
                teacher.ExamEvent += new ExamDelegate(student.PassExam);
            }
            
        }
    }
}
