using System.Collections;
using System.Reflection;

namespace _10_StandartInterfaces
{
    class Director: ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public object Clone()
        {
            Director temp = (Director)this.MemberwiseClone();
            return temp;
        }
        public override string ToString()
        {
            return $"First name: {FirstName}, Last name {LastName}";
        }
    }
    enum Genre
    {
        Comedy,Horror,Adventure,Drama,Action
    }
    class Movie: ICloneable, IComparable
    {
        public string Title { get; set; }

        public Director Director { get; set; }

        public string Country { get; set; }

        public Genre Genre { get; set; }

        public int Year { get; set; }

        public short Rating { get; set; }

        public Movie()
        {
            Title = "None";
            Director = new Director();
            Country = "None";
            Genre = new Genre();
            Year = 0;
            Rating = 0;
        }
        public Movie(string t, Director d, string c, Genre g, int y, short r)
        {
            Title = t;
            Director = d;
            Country = c;
            Genre = g;
            Year = y;
            Rating = r;
        }
        public object Clone()
        {
            Movie temp = (Movie)this.MemberwiseClone();
            temp.Director = new Director()
            {
                FirstName = this.Director.FirstName,
                LastName = this.Director.LastName
            };
            return temp;
        }

        public int CompareTo(object? obj)
        {
            return this.Title.CompareTo((obj as Movie)!.Title);
        }

        public override string ToString()
        {
            return $"Title: {Title}\nDirector: {Director}\nCountry: {Country}\nGenre: {Genre}\nYear: {Year}\nRating: {Rating}\n";
        }
    }
    class CompareByRating : IComparer<Movie>
    {
        public int Compare(Movie? x, Movie? y)
        {
            return x!.Rating.CompareTo(y!.Rating);
        }
    }
    class CompareByYear : IComparer<Movie>
    {
        public int Compare(Movie? x, Movie? y)
        {
            return x!.Year.CompareTo(y!.Year);
        }
    }
    class Cinema: IEnumerable
    {
        public Movie[] Movies { get; set; }

        public string Adress { get; set; }

        public IEnumerator GetEnumerator()
        {
            return Movies.GetEnumerator();
        }

        public void Sort()
        {
            Array.Sort(Movies);
        }
        public void Sort(IComparer<Movie> comparer)
        {
            Array.Sort(Movies, comparer);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Director d1 = new Director() { FirstName = "Christofer", LastName = "Nolan" };
            Director d2 = new Director() { FirstName = "Steven", LastName = "Spielberg" };
            Director d3 = new Director() { FirstName = "David", LastName = "Fincher" };

            Movie m1 = new Movie()
            {
                Title = "Oppenheimer",
                Director = d1,
                Country = "USA",
                Genre = Genre.Drama,
                Year = 2024,
                Rating = 8
            };
            Movie m2 = new Movie()
            {
                Title = "Interstellar",
                Director = d2,
                Country = "USA",
                Genre = Genre.Drama,
                Year = 2014,
                Rating = 9
            };
            Movie m3 = new Movie()
            {
                Title = "Figth Club",
                Director = d3,
                Country = "USA",
                Genre = Genre.Action,
                Year = 1999,
                Rating = 7
            };
            Movie[] movies = { m1, m2, m3 };
            Cinema cinema1 = new Cinema() { Movies = movies, Adress = "Soborna Street 16" };

            Console.WriteLine("\t--------All Movies--------");
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }

            Console.WriteLine("\t--------Sorting Movies By Title--------\n");
            cinema1.Sort();
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }

            Console.WriteLine("\t--------Sorting Movies By Rating--------\n");
            cinema1.Sort(new CompareByRating());
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }

            Console.WriteLine("\t--------Sorting Movies By Year--------\n");
            cinema1.Sort(new CompareByYear());
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }

            Director d4 = (d3.Clone() as Director)!;
            Console.WriteLine("\t--------Director 4 --------\n");
            Console.WriteLine(d4);
            d3 = new Director { FirstName = "James ", LastName = "Camaron" };
            Console.WriteLine("\n\t--------After change Director 3 & Director 4 --------\n");
            m3.Director = d3;
            Console.WriteLine(d3);
            Console.WriteLine(d4);
            Console.WriteLine();
            Console.WriteLine(m3);
        }
    }
}
