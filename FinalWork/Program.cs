using System;
using System.Text.Json;
using System.Transactions;

namespace FinalWork
{
    class MyDictionary
    {
        public string Name { get; set; }
        public string Type { get; set; }

        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        public MyDictionary() {
            Name = "Dictionary";
            Type = "English-Ukrainian";
        }

        public MyDictionary(string n, string t)
        {
            Name = n;
            Type = t;
        }
    }

    class DictionaryMethods
    {
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

        public void CreateDictionary()
        {
            List<Dictionary<string, List<string>>> Dicts = new List<Dictionary<string, List<string>>>();
            Console.Write("Enter Dictionary name");
        }
        public void AddTranslation()
        {
            string key; string translation; List<string> ts; ts = new List<string>();

            Console.Write("Write a word to translate: "); key = Console.ReadLine()!;
            dict[key] = new List<string>();

            Console.Write($"Write translation for {key}: "); translation = Console.ReadLine()!;  ts.Add( translation );
            int choise; bool active = true;
            while (active)
            {
                Console.WriteLine("[ 1 ] - Write more translations\n [ 0 ] - Exit"); choise = int.Parse( Console.ReadLine()!);
                switch (choise)
                {
                    case 1:
                        Console.Write($"Write translation for {key}: "); translation = Console.ReadLine()!; ts.Add(translation);
                        break;
                    case 0:
                        active = false;
                        break;
                    default:
                        Console.WriteLine("Wrong choise!");
                        break;
                }
            }
            SaveDictionary(dict);
        }

        private void SaveDictionary(Dictionary<string, List<string>> dict)
        {
            throw new NotImplementedException();
        }

        public void ReplaceTranslation() { }
        public void DeleteTranslation(string key) { }

        public void FindTranslation(string key) { }

        public void SaveDictionary(Dictionary dict) {
            try
            {
                string fileName = Path.Combine(Directory.GetCurrentDirectory(), $"{dict.Name}.json");
                string jsonString = JsonSerializer.Serialize(dict);
                File.WriteAllText(fileName, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Saving Error: {ex.Message}");
            }
        }
        public void LoadDictionary() { 
            
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int choise;
            Console.WriteLine("[ 1 ] - Create Dictionary\n [ 2 ] - Add translations to the dictionary\n [ 3 ] - Replace translations\n [ 4 ] - Delete translations\n [ 5 ] - Find Translations\n [ 6 ] - Load Dictionaries");
            Console.WriteLine("Enter operation"); choise = int.Parse(Console.ReadLine()!);

            while (true)
            {
                switch (choise)
                {
                    case 1:

                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Wrong choise!");
                        break;
                }
            }
        }
    }
}
