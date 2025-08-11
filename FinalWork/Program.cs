namespace FinalWork
{
    class Dictionary
    {
        Dictionary<string, string> dict = new Dictionary<string, string>();
        public void AddTranslation(string key, string value)
        {
            dict[key] = value;
        }
        public void ReplaceTranslation() { }
        public void DeleteTranslation(string key) { }

        public void FindTranslation(string key) { }

        public void SaveDictionary() { }
        public void LoadDictionary() { }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter operation");
            while (true)
            {

            }
        }
    }
}
