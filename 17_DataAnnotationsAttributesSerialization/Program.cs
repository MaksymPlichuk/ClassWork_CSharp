using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.Json;

namespace _17_DataAnnotationsAttributesSerialization
{
    class User
    {
        [Required(ErrorMessage = "ID not set")]
        [Range(1000, 9999,ErrorMessage = "ID range 1000-9999")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name not setted")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Minimum length 3")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Login contains special characters")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password not set")]
        [MinLength(8,ErrorMessage = "Minimum length 8")]
        [RegularExpression(@"^[a-zA-Z0-9]+$",ErrorMessage = "Pasword contains special characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password not confirmed")]
        [Compare(nameof(Password),ErrorMessage = "Passowords dont match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email not set")]
        [EmailAddress(ErrorMessage = "Wrong email format ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Credit card not set")]
        [RegularExpression(@"^\d{16}$",ErrorMessage = "Card length 16")]
        public string CreditCard { get; set; }

        [Required(ErrorMessage = "Phone not set")]
        [RegularExpression(@"^\+38\-0\d{2}\-\d{3}\-\d{2}\-\d{2}$",ErrorMessage = "Phone doesnt match +38-0**-***-**-** format")]
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"Login: {Login}, Password: {Password}, Confirm password: {ConfirmPassword}, Email: {Email}, CreditCard: {CreditCard}, Phone: {Phone}";
        }
    }
    internal class Program
    {
        private static Dictionary<int, User> users = new Dictionary<int, User>();

        public static void CreateUser()
        {
            User user = new User();
            bool isValid = true;
            do
            {

                Console.Write("Enter user ID: "); user.Id = int.Parse(Console.ReadLine()!);
                Console.Write("Enter user Login: "); user.Login = Console.ReadLine()!;
                Console.Write("Enter user Password: "); user.Password = Console.ReadLine()!;
                Console.Write("Confirm user Password: "); user.ConfirmPassword = Console.ReadLine()!;
                Console.Write("Enter user Email: "); user.Email = Console.ReadLine()!;
                Console.Write("Enter user CreditCard number: "); user.CreditCard = Console.ReadLine()!;
                Console.Write("Enter user Phone number: "); user.Phone = Console.ReadLine()!;
                Console.WriteLine();

                var result = new List<ValidationResult>();
                var context = new ValidationContext(user);
                if (!(isValid = Validator.TryValidateObject(user, context, result, true)))
                {
                    foreach (ValidationResult error in result)
                    {
                        Console.WriteLine(error.MemberNames.FirstOrDefault() + ": " + error.ErrorMessage);
                    }
                }
                else
                {
                    if (users.ContainsKey(user.Id))
                    {
                        Console.WriteLine("User with this ID exists!");
                        isValid = false;
                    }
                }
                Console.WriteLine();

            } while (!isValid);
            Console.WriteLine("User is valid");

            users[user.Id] = user;
            SaveToFile();
        }
        public static void UpdateUser() {
            
            Console.Write("Enter user ID to update: "); int id = int.Parse(Console.ReadLine()!);
            if (!users.ContainsKey(id)) { Console.WriteLine($"User with {id} not found!"); return; }

            User user = users[id];
            bool isValid = true;
            do
            {
                Console.Write("Enter new user ID: "); user.Id = int.Parse(Console.ReadLine()!);
                Console.Write("Enter new user Login: "); user.Login = Console.ReadLine()!;
                Console.Write("Enter new user Password: "); user.Password = Console.ReadLine()!;
                Console.Write("Confirnm new user Password: "); user.ConfirmPassword = Console.ReadLine()!;
                Console.Write("Enter new user Email: "); user.Email = Console.ReadLine()!;
                Console.Write("Enter new user CreditCard number: "); user.CreditCard = Console.ReadLine()!;
                Console.Write("Enter new user Phone number: "); user.Phone = Console.ReadLine()!;
                Console.WriteLine();

                var result = new List<ValidationResult>();
                var context = new ValidationContext(user);
                if (!(isValid = Validator.TryValidateObject(user, context, result, true)))
                {
                    foreach (ValidationResult error in result)
                    {
                        Console.WriteLine(error.MemberNames.FirstOrDefault() + ": " + error.ErrorMessage);
                    }
                }
                Console.WriteLine();

            } while (!isValid);
            Console.WriteLine("User was updated!");
            if (user.Id != id) { users.Remove(id); }

            users[user.Id] = user;
            SaveToFile();
        }

        public static void RemoveUser() { 

            Console.Write("Enter user ID to remove him: "); int id = int.Parse(Console.ReadLine()!);
            if (users.Remove(id))
            {
                Console.WriteLine($"User with id {id} was removed!");
                SaveToFile();
            }
            else { Console.WriteLine($"User with id {id} was not found!"); }
            
        }

        public static void ShowAllUsers() {

            if (users.Count == 0) { Console.WriteLine("User databasae is empty"); }
            else
            {
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Key,5} {user.Value}");
                }
            }
        }

        public static void SaveToFile()
        {
            string fileName = "Users.json";
            string jsonString = JsonSerializer.Serialize(users);
            File.WriteAllText(fileName, jsonString);

            Console.WriteLine("Data saved!");
        }
        public static void ReadFromFile(string fileName)
        {
            if (!File.Exists(fileName)) { Console.WriteLine("File doesn't exist!"); }
            else
            {
                Dictionary<int, User> newUsers = null;
                string jsonString = File.ReadAllText(fileName);
                newUsers = JsonSerializer.Deserialize<Dictionary<int, User>>(jsonString)!;

                if (newUsers != null) { users = newUsers; }

                Console.WriteLine("Data loaded!");
            }
        }

        static void Main(string[] args)
        {
            ReadFromFile("Users.json");
            int choise = 0;
            while (true)
            {
                Console.WriteLine("\n-Select Operation-");
                Console.WriteLine("[ 1 ] - Create User");
                Console.WriteLine("[ 2 ] - Update User");
                Console.WriteLine("[ 3 ] - Show Users");
                Console.WriteLine("[ 4 ] - Delet User");
                Console.WriteLine("[ 0 ] - Exit");

                try
                {
                    choise = int.Parse(Console.ReadLine()!);
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong Choise");
                }
               
                switch (choise)
                {
                    case 1:
                        CreateUser(); 
                        break;
                    case 2:
                        UpdateUser();
                        break;
                    case 3:
                        ShowAllUsers();
                        break;
                    case 4:
                        RemoveUser();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Wrong choise");
                        break;
                }
            }
        }
    }
}
