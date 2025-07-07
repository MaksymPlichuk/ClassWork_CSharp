namespace _12_EventCallBackFunction
{
    //public event birga delegate
    class Exchange
    {
        private double excRate;

        public double ExcRate
        {
            get { return excRate; }
            set
            {
                if (value > 0) { 
                    excRate = value;
                    MyActionDelegate?.Invoke(excRate);
                }
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
            excRate = ec;
            MinVal = min;
            MaxVal = max;
        }
        public event MyActionDelegate MyActionDelegate;
        public void ChangeRate(double newRate)
        {
            Console.WriteLine($"Changing rate form {ExcRate} to {newRate}");
            ExcRate = newRate;
            Console.WriteLine();
        }
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

            Console.WriteLine($"Trader {Name} sees rate: {ExcRate}");
            if (ExcRate < 42)
            {
                Console.WriteLine($"{Name}: I buy USDT for {ExcRate}");
            }
            else if (ExcRate > 45)
            {
                Console.WriteLine($"{Name}: I sell USDT for {ExcRate}");
            }
            else { Console.WriteLine($"{Name}: Im am holding"); }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Exchange exchange = new Exchange() { MinVal = 39, MaxVal = 46 };
            exchange.ExcRate = 40;

            List<Trader> traders = new List<Trader>();
            Trader t1 = new Trader() {Name = "Bill", CurrencyAmmont = 5000};
            Trader t2 = new Trader() {Name = "John", CurrencyAmmont = 3000};
            Trader t3 = new Trader() {Name = "Ivan", CurrencyAmmont = 25000};

            traders.Add(t1);
            traders.Add(t2);
            traders.Add(t3);

            foreach (Trader tr in traders)
            {
                exchange.MyActionDelegate += tr.MyAction;
            }

            Console.WriteLine($"Starting Rate: {exchange.ExcRate}");
            Console.WriteLine();

            Console.WriteLine($"Changing rate to 41:");
            exchange.ChangeRate(41);
            Console.WriteLine();

            exchange.ChangeRate(46);
            Console.WriteLine();

            exchange.ChangeRate(40);
            Console.WriteLine();
        }
    }
}
