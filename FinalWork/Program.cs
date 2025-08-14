using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Transactions;

namespace FinalWork
{

    class OneDictionary
    {
        //від помилки The collection type 'FinalWork.OneDictionary' is abstract, an interface, or is read only, and could not be instantiated and populated. Path: $ | LineNumber: 0 | BytePositionInLine: 1.
            //проблема з JSON серіалізацією/десеріалізацією класу

        [JsonPropertyName("dict")]
        public Dictionary<string, List<string>> Dict { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonConstructor]
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


        public OneDictionary CreateDictionary()
        {
            var alldictts = LoadAllDictionaries();
            Dict = new Dictionary<string, List<string>>();

            Console.Write("Enter Dictionary name: "); Name = Console.ReadLine()!;

            foreach (var dic in alldictts) {
                 if (dic.Name == Name)
                 {
                    Console.Write("This Dictionary name is already taken! Enter new one: "); Name = Console.ReadLine()!;
                    break;
                 }
             }

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
                Console.Write("Enter Dictioanary name to select: "); name = Console.ReadLine()!;

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
                Console.WriteLine("Press [ A ] - Write more translations\t [ B ] - Exit"); var choise = Console.ReadKey(true);

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
                        Console.WriteLine("Press [ A ] - Change all Translations of the word\n [ B ] Change One Translation of the word\n [ C ] - Exit\n [ D ] - Chage key word"); var key2 = Console.ReadKey(true);
                        if (key2.Key == ConsoleKey.A)   //Очистка всіх минулих перекладів і добавка нових
                        {
                            dict.Dict[key].Clear();
                            while (true)
                            {
                                Console.Write($"Write translation for {key}: "); translation = Console.ReadLine()!; dict.Dict[key].Add(translation);
                                Console.WriteLine("Write more translations?\n [ Y ] - yes\n [ N ] - no"); var key3 = Console.ReadKey(true);
                                if (key3.Key == ConsoleKey.Y) { Console.WriteLine(); }
                                else if (key3.Key == ConsoleKey.N) { break; }
                                else { break; }
                            }

                        }
                        else if (key2.Key == ConsoleKey.B)  //замінити старий 1 переклад
                        {
                            Console.WriteLine("All translations: ");    //показ всі переклади
                            foreach (var val in dict.Dict)
                            {
                                Console.WriteLine($"{string.Join(", ", val.Value)}");
                            }
                            while (true)    //пошук введеного слова як старий переклад і заміна його на новий
                            {
                                Console.Write("Enter translation to change: "); string oldTranslation = Console.ReadLine()!;

                                if (!dict.Dict[key].Contains(oldTranslation)) Console.WriteLine($"This translation of the {key} doens't exist");

                                else if (dict.Dict[key].Contains(oldTranslation))
                                {

                                    Console.Write("Enter new translation: "); string newTranslation = Console.ReadLine()!;
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
            foreach (var k in dict.Dict)
            {
                Console.Write($"{i,2}. Key: {k.Key,-5} Translations: ");
                foreach (var t in k.Value)
                {
                    Console.Write($"{t + ", " }");
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
            else { Console.WriteLine($"Word {ts} wasn't found!"); }
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

            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("No Dictionaries found!");
                return;
            }
            try
            {


                OneDictionary newDictionary = null;
                string jsonString = File.ReadAllText(filePath);
                newDictionary = JsonSerializer.Deserialize<OneDictionary>(jsonString)!;

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
                    try
                    {
                        string jsonString = File.ReadAllText(f);
                        OneDictionary d = JsonSerializer.Deserialize<OneDictionary>(jsonString)!;

                        allDictionaries.Add(d);
                    }
                    catch (Exception ex)
                    {
                        //File error? Test.json: The JSON value could not be converted to FinalWork.OneDictionary. Path: $ | LineNumber: 0 | BytePositionInLine: 1.
                        Console.WriteLine($"File error {Path.GetFileName(f)}: {ex.Message}");
                    }
                   
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
                
                Console.WriteLine($"Name: {dic.Name}");
                Console.WriteLine($"Type: {dic.Type}\n");
            }
            Console.WriteLine("Show all Dictionaries translations?\n [ Y ] - yes\n [ N ] - no");
            while (true)
            {

                var keyInfo = Console.ReadKey(true);


                if (keyInfo.Key == ConsoleKey.Y)
                {
                    foreach (var dic in alldicts)
                    {
                        Console.WriteLine($"\nName: {dic.Name}");
                        Console.WriteLine($"Type: {dic.Type}");
                        Console.WriteLine($"\t--------");
                        foreach (var ts in dic.Dict)
                        {                               //щоб не було Word Dog: Translation System.Collections.Generic.List1[System.String]
                            Console.WriteLine($"Word {ts.Key,10}: Translation:\t {string.Join(", ", ts.Value)}");
                        }
                        Console.WriteLine();
                    }
                    return;
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
                        var keyInfo = Console.ReadKey(true);

                        if (keyInfo.Key == ConsoleKey.Y)
                        {
                            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "MyDictionaries");
                            string filePath = Path.Combine(folderPath, $"{dic.Name}.json");

                            alldicts.Remove(dic);   //видал спочакту з всіх словників а потім з файлів

                            if (File.Exists(filePath))
                            {
                                File.Delete(filePath);
                                Console.WriteLine($"{dic.Name} was succesfully removed!");
                                return;
                            }
                            
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
        //art
        public void printArt()
        {
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@*@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@*-%@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@:.*@@@@#@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@*. -@@@%-#@@@@@@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@-  :#@@+.+@@@@@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@#.  .=@%:.-#@@@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@-   .-#+. :*@@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@#*-..             .=:  .=%@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@*:                    ..    :#@@@@@@@@@@");
            Console.WriteLine("@@@@@@@%-                              .+@@@@@@@@@");
            Console.WriteLine("@@@@@@+::--:..                           -%@@@@@@@");
            Console.WriteLine("@@@@@@@@%+.                               .*@@@@@@");
            Console.WriteLine("@@@@@@#:                            ...     =@@@@@");
            Console.WriteLine("@@@@%:                             .+%-.     -%@@@");
            Console.WriteLine("@@@* .+@@+.   .%@@@@");
            Console.WriteLine("@@=.                                .:*@#:  +@@@@@");
            Console.WriteLine("@+.              :-.  +@@=            ......:%@@@@");
            Console.WriteLine("%.             :#*:. *@=..                   .*@@@");
            Console.WriteLine("=             =%%-. -%@@%%%-                  ...-");
            Console.WriteLine(".            -%@#:  -@@@@#...:.                  +");
            Console.WriteLine(".           .*@@%-  .%@@@@@@@@@@@@%*:           .@");
            Console.WriteLine(".   .-      -#@@@=.  :%@@@@@@@@@@@@@@%+.        *@");
            Console.WriteLine("= .-@%.     -#@@@@-.  ...:#@@@@@@@@@@@@%=.    .+@@");
            Console.WriteLine("%.:@@@=     :*@%=:.. ...  .-%@%@@@@@@@@@@+. :#@@@@");
            Console.WriteLine("@**@@@%:    .=@@@@@@@@@%:  .....-*@@@@@@@@*:#@@@@@");
            Console.WriteLine("@@@@@@@#:    .*@@@@@@@@@+        .:+@@@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@%-    .+@@@@@*-.:=+*#%+.   .:*@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@+.   .=%@@@@%@@@@@@@@%=.   .-%@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@%+:   .=%@@@@@@@@@@@@@#:   :*@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@@#=:. .:+#@@@@@@@@@@@%=-*@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@@@@@%*+-::.-@@@@@@@@@@@@@@@@@@@@@@@@@\n");
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {

            OneDictionary dictionary = new OneDictionary();

            dictionary.printArt();

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
            
            while (true)
            {
                Console.WriteLine(" [ 1 ] - Create Dictionary\n [ 2 ] - Add translations to the dictionary\n [ 3 ] - Replace translations\n [ 4 ] - Delete translations\n [ 5 ] - Find Translations\n [ 6 ] - Delete Dictionaries\n [ 7 ] - Show All Dictionaries\n [ 0 ] - Exit");
                Console.Write("\n---------------------------------------------------------------------\nEnter operation: "); choise = int.Parse(Console.ReadLine()!);
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
                    case 7:
                        dictionary.ShowAllDictionaries();
                        break;
                    case 0:
                        dictionary.printArt();
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Wrong choice!");
                        break;
                }
            }
        }
    }
   
}
