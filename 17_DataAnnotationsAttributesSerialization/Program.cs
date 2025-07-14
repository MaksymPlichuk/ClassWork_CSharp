using System.ComponentModel.DataAnnotations;

namespace _17_DataAnnotationsAttributesSerialization
{
    class User
    {
        [Required]
        [Range(1000, 9999,ErrorMessage = "Wrong ID")]
        public int id { get; set; }

        [Required(ErrorMessage = "Name not setted")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Wrong lenght")]
        public string Login { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
