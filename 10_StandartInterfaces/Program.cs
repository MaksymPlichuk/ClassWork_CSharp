namespace _10_StandartInterfaces
{
    class Director: ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public object Clone()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"First name: {FirstName}, Last name {LastName}";
        }
    }
    enum Genre
    {
        Comedy,Horror,Adventure,Drama
    }
    class Movie: ICloneable, IComparable
    {
        public string Title { get; set; }

        public Director Director { get; set; }

        public string Country { get; set; }

        public Genre Genre { get; set; }

        public int Year { get; set; }

        public short Rating { get; set; }

        public object Clone()
        {
            Movie temp = (Movie)this.MemberwiseClone();
            temp.StudentCard = new StudentCard()
            {
                Number = this.StudentCard.Number,
                Series = this.StudentCard.Series
            };
            return temp;
        }

        public int CompareTo(object? obj)
        {
            return this.Title.CompareTo((obj as Movie)!.Title);
        }

        public override string ToString()
        {
            return $"Title: {Title}\nDirector: {Director}\nCountry: {Country}\nGenre: {Genre}\nYear: {Year}\nRating: {Rating}";
        }
    }
    class Cinema: IEnumerable
    {
        public Movie[] Movies { get; set; }

        public string Adress { get; set; }

        public void Sort()
        {
            Array.Sort(Movies);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
