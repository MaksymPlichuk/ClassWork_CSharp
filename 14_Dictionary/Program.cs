namespace _14_Dictionary
{
    class Abonent
    {
        public int phone { get; set; }
        public string Name { get; set; }
    }
    class PhoneBook
    {

        Dictionary<int, Abonent> phones;

        public void AddNumber(int id, Abonent ab)
        {
            if (phones[id] != null)
            {
                throw new Exception("Value is Reserved");
            }
            else { phones[id] = ab; }
        }
        public void RemoveNumber(int id) {
            for (int i = 0; i < phones.Count; i++) { 
                if (phones[i].phone == id) { phones.Remove(); }
            }
        }
    internal class Program
    {
        static void Main(string[] args)
        {
            //phones
        }
    }
}
