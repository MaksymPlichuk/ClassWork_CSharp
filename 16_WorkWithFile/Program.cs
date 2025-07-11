using System.Text;

namespace _16_WorkWithFile
{
    internal class Program
    {
        static void WriteFile(string path)
        {

            using (FileStream fs = new FileStream(path, FileMode.Create,
                FileAccess.Write, FileShare.None))
            {

                Console.WriteLine("Enter elements of array : ");
                string writeText = "";
                for (int i = 0; i < 5; i++) 
                {
                    writeText += Console.ReadLine()!;
                }

                byte[] writeBites = Encoding.Default.GetBytes(writeText);
                fs.Write(writeBites, 0, writeBites.Length);

                Console.WriteLine("File was recorded!!!!");

            }

        }
        static string ReadFile(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            else { throw new Exception("Wrong file path!"); }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
