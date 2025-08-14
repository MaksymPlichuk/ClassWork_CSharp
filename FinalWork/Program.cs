using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Transactions;

namespace FinalWork
{

    class OneDictionary : IEnumerable
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

        public OneDictionary(Dictionary<string, List<string>> d, string n, string t)
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
            Console.Write("Enter Dictionary name: "); Name = Console.ReadLine()!;
            Console.Write("Enter Dictionary type: "); Type = Console.ReadLine()!;

            var newDict = new OneDictionary(Dict, Name, Type);
            SaveDictionary(newDict);
            return newDict;
        }
        public OneDictionary SelectDictionary()
        {
            string name;
            ShowAllDictionaries();
            var dts = LoadAllDictionaries();
            if (dts.Count == 0) { Console.WriteLine("No dictioanaries found!"); return null; }

            while (true)
            {
                Console.Write("Enter Dictioanary name: "); name = Console.ReadLine()!;

                for (int i = 0; i < dts.Count; i++)
                {
                    if (dts[i].Name == name)
                    {
                        Console.WriteLine("Dictionary is selected!");
                        return dts[i];
                    }
                }
                Console.WriteLine("Wrong Dictioanary name! Enter name again!");
            }

        }
        public void AddTranslation()
        {
            var dict = SelectDictionary();
            string key;
            string translation;

            while (true)
            {
                Console.Write("Write a word to translate: "); key = Console.ReadLine()!;

                if (dict.Dict.Count != 0)
                {
                    if (dict.Dict.ContainsKey(key))
                    {
                        Console.WriteLine("This key already existst!");
                    }
                    else
                    {

                        dict.Dict[key] = new List<string>();    //Dict - типу core на якому працює словник
                        break;
                    }
                }
                else { 
                    dict.Dict[key] = new List<string>();
                    break;
                }
            }

            Console.Write($"Write translation for {key}: "); translation = Console.ReadLine()!;
            dict.Dict[key].Add(translation);

            bool active = true;

            while (active)
            {
                Console.WriteLine("Press [ A ] - Write more translations\t [ B ] - Exit"); var choise = Console.ReadKey();

                if (choise.Key == ConsoleKey.A)
                {
                    Console.Write($"Write translation for {key}: "); translation = Console.ReadLine()!; dict.Dict[key].Add(translation);
                }
                else if (choise.Key == ConsoleKey.B)
                {
                    active = false;
                }
                else { Console.WriteLine("Wrong Key! "); }
            }
            SaveDictionary(dict);
        }

        public void ReplaceTranslation()
        {

            var dict = SelectDictionary();
            string key; string tskey; string translation;



            while (true)
            {
                Console.Write("Write a key word to translate: "); key = Console.ReadLine()!;


                if (dict.Dict.ContainsKey(key))
                {
                    while (true)
                    {
                        Console.WriteLine("Press [ A ] - Change all Translations of the word\n[ B ] Change One Translation of the word\n [ C ] - Exit\n [ D ] - Chage key word"); var key2 = Console.ReadKey();
                        if (key2.Key == ConsoleKey.A)   //Очистка всіх минулих перекладів і добавка нових
                        {
                            dict.Dict[key].Clear();
                            while (true)
                            {
                                Console.Write($"Write translation for {key}: "); translation = Console.ReadLine()!; dict.Dict[key].Add(translation);
                                Console.WriteLine("Write more translations?\n [ Y ] - yes\n [ N ] - no"); var key3 = Console.ReadKey();
                                if (key3.Key == ConsoleKey.Y) { Console.WriteLine(); }
                                else if (key3.Key == ConsoleKey.N) { break; }
                                else { break; }
                            }

                        }
                        else if (key2.Key == ConsoleKey.B)  //замінити старий 1 переклад
                        {
                            Console.WriteLine("All translations: ");    //показ всі переклади
                            foreach (var val in dict.Dict.Values)
                            {
                                Console.WriteLine($" {val}");
                            }
                            while (true)    //пошук введеного слова як старий переклад і заміна його на новий
                            {
                                Console.Write("Enter translation to change: "); string oldTranslation = Console.ReadLine()!;

                                if (!dict.Dict[key].Contains(oldTranslation)) Console.WriteLine($"This translation of the {key} doens't exist");

                                else if (dict.Dict[key].Contains(oldTranslation))
                                {

                                    Console.Write("Enter new translation"); string newTranslation = Console.ReadLine()!;
                                    dict.Dict[key].Remove(oldTranslation); dict.Dict[key].Add(newTranslation);
                                    Console.WriteLine("Old Translation was succesfully replaced!");
                                    SaveDictionary(dict); return;
                                }
                            }


                        }

                        else if (key2.Key == ConsoleKey.C) { SaveDictionary(dict); return; }

                        else if (key2.Key == ConsoleKey.D) { break; }

                        else { Console.WriteLine("Wrong Key! "); }
                    }
                }
                else
                {
                    Console.WriteLine("This key doesn't Exist");
                }
            }

        }

        public void DeleteTranslation()
        {

            var dict = SelectDictionary();
            Console.WriteLine();

            string key;
            string translation; int i = 1;

            //просто показ всі слова і переклади
            Console.WriteLine("==All words and translations==");
            foreach (var k in dict.Dict.Keys)
            {
                Console.Write($"{i,2}. Key: {k,-5} Translations: ");
                foreach (var t in k)
                {
                    Console.Write(t);
                }
                Console.WriteLine();
                i++;
            }


            while (true)
            {
                Console.Write("Write a word to delete translation: "); key = Console.ReadLine()!;

                if (dict.Dict.ContainsKey(key))
                {
                    dict.Dict[key].Clear();
                    dict.Dict.Remove(key);
                    Console.WriteLine("Word and its Translations were removed!");
                    SaveDictionary(dict);
                    return;
                }
                else
                {
                    Console.WriteLine("Wrong key word!");
                }
            }

        }

        public void FindTranslation()
        {

            Console.WriteLine("Select Dictionary type to find translation in");
            var dict = SelectDictionary();

            Console.WriteLine("Enter word to find translation"); string ts = Console.ReadLine()!;

            if (dict.Dict.ContainsKey(ts))
            {
                Console.WriteLine($"Translations of the word {ts}: ");
                foreach (var t in dict.Dict[ts])
                {
                    Console.WriteLine($"\t{t}");
                }
                Console.WriteLine();
            }
        }

        public void SaveDictionary(OneDictionary dict)
        {
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
        public void LoadOneDictionary(OneDictionary dict)
        {
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
            {       //запис всі назви файлів які кінчаються на .json
                string[] files = Directory.GetFiles(folderPath, "*.json");

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

            Console.WriteLine("\n===All Dictionaries===");

            foreach (var dic in alldicts)
            {
                
                Console.WriteLine(dic.Name);
                Console.WriteLine(dic.Type);
            }
            Console.WriteLine("Show all Dictionaries translations?\n [ Y ] - yes\n [ N ] - no");
            while (true)
            {

                var keyInfo = Console.ReadKey();


                if (keyInfo.Key == ConsoleKey.Y)
                {
                    foreach (var dic in alldicts)
                    {
                        Console.WriteLine($"----{dic.Name}----");
                        Console.WriteLine($"----{dic.Type}----");
                        Console.WriteLine($"{"--info--",2}");
                        foreach (var ts in dic.Dict)
                        {
                            Console.WriteLine(ts);
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

        public void RemoveDictionary()
        {

            ShowAllDictionaries();

            var alldicts = LoadAllDictionaries();


            while (true)
            {
                Console.WriteLine("Enter Dictioanary name to remove it: ");
                string dicname = Console.ReadLine()!;
                foreach (var dic in alldicts)
                {
                    if (dic.Name == dicname)
                    {                                   //підтвердження
                        Console.WriteLine($"Do you really want to delete {dic.Name}?\nPress [ Y ] - to continue\n [ N ] to cancel\n [ E ] - to exit");
                        var keyInfo = Console.ReadKey();

                        if (keyInfo.Key == ConsoleKey.Y)
                        {
                            alldicts.Remove(dic);
                            Console.WriteLine($"{dic.Name} was succesfully removed!");
                        }
                        else if (keyInfo.Key == ConsoleKey.N)
                        {
                            break;
                        }
                        else if (keyInfo.Key == ConsoleKey.E)
                        {
                            return;
                        }
                    }
                }
                Console.WriteLine($"Dictionary with name {dicname} wasn't found!");
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
                        Console.WriteLine("Folder MyDictionaries exists ready to work!");
                }
                catch (Exception e) { Console.WriteLine(e.Message); }



                int choise;
                Console.WriteLine("[ 1 ] - Create Dictionary\n [ 2 ] - Add translations to the dictionary\n [ 3 ] - Replace translations\n [ 4 ] - Delete translations\n [ 5 ] - Find Translations\n [ 6 ] - Delete Dictionaries");

                OneDictionary dictionary = new OneDictionary();

                while (true)
                {
                    Console.Write("\nEnter operation: "); choise = int.Parse(Console.ReadLine()!);
                    switch (choise)
                    {
                        case 1:
                            dictionary.CreateDictionary();
                            break;
                        case 2:
                            dictionary.AddTranslation();
                            break;
                        case 3:
                            dictionary.ReplaceTranslation();
                            break;
                        case 4:
                            dictionary.DeleteTranslation();
                            break;
                        case 5:
                            dictionary.FindTranslation();
                            break;
                        case 6:
                            dictionary.RemoveDictionary();
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("Wrong choice!");
                            break;
                    }
                }
            }
        }
    }
}
