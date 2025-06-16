namespace _04_IntroToOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Freezer f=new Freezer(5,5,5,5,5);
            Freezer[]freezers = new Freezer[5];
            freezers[0] = f;
            freezers[1] = new Freezer(50,56,63,65,98);
            freezers[2] = new Freezer(120,56,54,65,365);
            freezers[3] = new Freezer(654,87,6412,63,653);
            freezers[4] = new Freezer(1245,62,78,5242,875);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"---------Fridge {i+1}---------");
                Console.WriteLine(freezers[i].ToString());
            }
        }
    }
}
