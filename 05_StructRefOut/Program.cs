namespace _05_StructRefOut
{
    class Worker
    {
        string name;
        string surname;
        string lastname;
        
        public  string Name { get; set; }
        public  string Surname { get; set; }
        public  string Lastame { get; set; }

        private int age;

        public int Age
        {
            get { return age; }
            set { 
                if (age >= 16 && age <150)
                age = value;
                else age = 0;
                }
        }

        private int salary;

        public int Salary
        {
            get { return salary; }
            set
            {
                if (salary >= 16 && salary < 150)
                    salary = value;
                else salary = 0;
            }
        }

        private DateTime dateOfWork;

        public DateTime DateOfWork
        {
            get { return dateOfWork; }
            set
            {
                if (dateOfWork < DateTime.Now)
                    dateOfWork = value;
                else throw new Exception("Wrong time!");
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*авдання 1:
            Описати клас з ім'ям Worker, що містить наступні поля:
            прізвище та ініціали працівника;
            вік працівника;
            ЗП працівника;
            дата прийняття на роботу.
            Написати програму, що виконує наступні дії:
            введення з клавіатури даних в масив, що складається з п'яти елементів типу Worker (записи повинні бути впорядковані за алфавітом);
            якщо значення якогось параметру введено не в відповідному форматі - згенерувати відповідний exception.
            вивід на екран прізвища працівника, стаж роботи якого перевищує введене з клавіатури значення.
            Рекомендація: перевірку формата даних та генерацію винятку виконуйте в блоці set{} для кожної властивості класа Worker. */
            Worker[] workers = new Worker[1];
            try
            {
                for (int i = 0; i < workers.Length; i++)
                {
                    workers[i] = new Worker();
                    Console.Write("\nEnter workers first name: "); workers[i].Name = Console.ReadLine()!;
                    Console.Write("\nEnter workers middle name: "); workers[i].Surname = Console.ReadLine()!;
                    Console.Write("\nEnter workers last name: "); workers[i].Lastame = Console.ReadLine()!;
                    Console.Write("\nEnter workers age: "); workers[i].Age = int.Parse(Console.ReadLine()!);
                    Console.Write("\nEnter workers salary: "); workers[i].Salary = int.Parse(Console.ReadLine()!);
                    Console.Write("\nEnter workers date of work: "); workers[i].DateOfWork = DateTime.Parse(Console.ReadLine()!);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
            
            foreach (Worker worker in workers) {
                Console.WriteLine(worker);
            }
        }
    }
}
