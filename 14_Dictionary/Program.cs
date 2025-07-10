using _14_Dictionary;
using System.Collections;
using System.Numerics;

namespace _14_Dictionary
{
    class Abonent
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        public string LastName { get; set; }

        private DateTime birthday;

        public DateTime Birthday
        {
            get { return birthday; }
            set { if (value < DateTime.Now) { birthday = value; }
                else { throw new Exception("Wrong Birthdate!"); }
            }
        }
        public Abonent()
        {
            FirstName = "";
            MiddleName = "";
            LastName = "";
            Birthday = new DateTime(2000, 01, 01);
        }
        public override string ToString()
        {
            return $"Full name: {FirstName} {MiddleName} {LastName}, Birthdate: {Birthday}";
        }
    }
    class PhoneBook : IEnumerable
    {

        Dictionary<int, Abonent> phones;

        public void AddNumber(int phone, Abonent ab)
        {
            if (phones.ContainsKey(phone))
            {
                throw new Exception("Value is Reserved");
            }
            else { phones.Add(phone, ab); }
        }

        public void RemoveNumber(int phone)
        {
            if (phones.ContainsKey(phone))
            {
                phones.Remove(phone);
            }
            else { Console.WriteLine("Phone not found!"); }
        }

        public void ChangeData(int phone, Abonent ab)
        {
            if (phones.ContainsKey(phone))
            {
                phones[phone] = ab;
            }
            else { Console.WriteLine("This number is not in Database!"); }
        }
        public IEnumerator GetEnumerator()
        {
            return phones.GetEnumerator();
        }

        public void Print()
        {
            foreach (KeyValuePair<int, Abonent> phone in phones)
            {
                Console.WriteLine($"phone: {phone.Key,5}. Value: {phone.Value,20}");
            }
        }
        public PhoneBook()
        {
            phones = new Dictionary<int, Abonent>();
        }

    }
    class Statistic
    {
        public Dictionary<string, int> GetCount()
        {
            string sentence = "Ось будинок, який збудував Джек. А це пшениця, яка у темній коморі зберігається у будинку, який збудував Джек. А це веселий птах--синиця, який часто краде пшеницю, яка в темній коморі зберігається у будинку, який збудував Джек.";
            string[] words = sentence.Split(new char[] { ' ', '?', '!', ',', '.', }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> table = new Dictionary<string, int>();

            foreach (string word in words) {

                if (string.IsNullOrWhiteSpace(word)) continue;

                if (table.ContainsKey(word)) { 
                    table[word]++;
                }
                else table[word] = 1;
            }
            return table;
        }
        public void Print(Dictionary<string, int> table)
        {
            Console.WriteLine($"{"#",-3} {"Word",-15} {"Ammount",-15}");
            int i = 1;
            foreach (KeyValuePair<string, int> item in table)
            {
                Console.WriteLine($"{i,-3} {item.Key,-15} {item.Value,-15}");
                i++;
            }
        }
    }
}
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            PhoneBook phoneBook = new PhoneBook();

            //Dictionary<int, Abonent> phones = new Dictionary<int, Abonent>();
            phoneBook.AddNumber(1234567890, new Abonent() { FirstName = "Will", MiddleName = "Christofer", LastName = "Smith", Birthday = new DateTime(1968, 09, 28) });
            phoneBook.AddNumber(1213141516, new Abonent() { FirstName = "Brad", MiddleName = "Bradley", LastName = "Pit", Birthday = new DateTime(1963, 12, 18) });
            phoneBook.Print();

            Console.WriteLine("\n--Changed Data--");
            phoneBook.ChangeData(1213141516, new Abonent() { FirstName = "Marshal", MiddleName = "Bruse", LastName = "Matters", Birthday = new DateTime(1972, 10, 17) });
            phoneBook.Print();

            Console.WriteLine("\n--Removed Number--");
            phoneBook.RemoveNumber(1234567890);

            phoneBook.Print();

            Console.WriteLine("\nTask 2");
            Statistic statistic = new Statistic();
            var table = statistic.GetCount();
            statistic.Print(table);

        }
    }
