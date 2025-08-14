using System;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Transactions;

namespace FinalWork
{
    class MyDictionaries
    {
        List<OneDictionary> Dictionaries;

    }

    class OneDictionary: IEnumerable
    {
        public Dictionary<string, List<string>> Dict { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }


        public OneDictionary()
        {
            Dict = new Dictionary<string, List<string>>();
            Name = "Dictionary";
            Type = "English-Ukrainian";
        }

        public OneDictionary(Dictionary<string, List<string>> d,string n, string t)
        {
            Dict = d;
            Name = n;
            Type = t;
        }
        public IEnumerator GetEnumerator()
        {
            return Dict.GetEnumerator();
        }
        public OneDictionary CreateDictionary()
        {
           Dict = new Dictionary<string, List<string>>();
            Console.Write("Enter Dictionary name"); Name = Console.ReadLine()!;
            Console.Write("Enter Dictionary type"); Type = Console.ReadLine()!;

            return new OneDictionary(Dict, Name, Type);
        }
        public void SelectDictionary()
        {

        }
        public void AddTranslation()    //TODO
        {
            string key; 
            string translation; 
            List<string> ts; ts = new List<string>();

            Console.Write("Write a word to translate: "); key = Console.ReadLine()!;
            Dict[key] = new List<string>();

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
            SaveDictionary(Dict);
        }

        public void ReplaceTranslation() { }
        public void DeleteTranslation(string key) { }

        public void FindTranslation(string key) { }

        public void SaveDictionary(OneDictionary dict) {
            try
            {
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "MyDictionaries");
                string fileName = Path.Combine(folderPath, $"{dict.Name}.json");
                string jsonString = JsonSerializer.Serialize(dict);
                File.WriteAllText(fileName, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Saving Error: {ex.Message}");
            }
        }
        public void LoadOneDictionary(OneDictionary dict) {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "MyDictionaries");
            string filePath = Path.Combine(folderPath, $"{dict.Name}.json");

            if (!File.Exists(folderPath))
            {
                Console.WriteLine("No Dictionaries found!");
                return;
            }
            try
            {

                Console.WriteLine($"----{dict.Name}----");
                Console.WriteLine($"----{dict.Type}----");
                Console.WriteLine($"{"--info--",2}");

                OneDictionary newDictionary = null;
                string jsonString = File.ReadAllText(filePath);
                newDictionary = JsonSerializer.Deserialize<OneDictionary>(jsonString)!;

                foreach (var item in newDictionary)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            
        }
        
        public List<OneDictionary> LoadAllDictionaries()
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "MyDictionaries");
            var allDictionaries = new List<OneDictionary>();

            try
            {
                string[] files = Directory.GetFiles(folderPath, ".json");

                foreach (var f in files)
                {
                    string jsonString = File.ReadAllText(f);
                    OneDictionary d = JsonSerializer.Deserialize<OneDictionary>(jsonString)!;

                    allDictionaries.Add(d);
                }
            }

            catch (Exception e) { Console.WriteLine(e.Message); }
            return allDictionaries;
        }
        public void ShowAllDictionaries()
        {
            var alldicts = LoadAllDictionaries();
            Console.WriteLine("===All Dictionaries===");

            foreach (var dic in alldicts) {
                Console.WriteLine(dic.Name);
                Console.WriteLine(dic.Type);
            }
            Console.WriteLine("Show all Dictionaries translations?\n [ Y ] - yes\n [ N ] - no");
            while (true) {

                var keyInfo = Console.ReadKey();


                if (keyInfo.Key == ConsoleKey.Y)
                {
                    foreach (var dic in alldicts)
                    {
                        Console.WriteLine($"----{dic.Name}----");
                        Console.WriteLine($"----{dic.Type}----");
                        Console.WriteLine($"{"--info--",2}");
                        foreach (var info in dic)
                        {
                            Console.WriteLine(info);
                        }
                        Console.WriteLine();
                    }
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.WriteLine("Exiting...");
                    return;
                }
                else { Console.WriteLine("\nEnter Y or N!"); }
            }
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string newFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "MyDictionaries");
            try
            {
                if (!Directory.Exists(newFolderPath))
                {
                    Directory.CreateDirectory(newFolderPath);
                    Console.WriteLine("-Folder MyDictionaries was Succsesfully created!-");
                }
                else
                    Console.WriteLine("Folder MyDictionaries exists");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            
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
