using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._01home
{
    public enum Genre
    {
        Action,
        Comedy,
        Drama,
        Horror,
        Romance,
        SciFi,
        Thriller,
        Other
    }

   
    public class Director : ICloneable
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public Director(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        
        public object Clone()
        {
            return new Director(Name, BirthDate);
        }

        public override string ToString()
        {
            return $"{Name} (Born: {BirthDate.ToShortDateString()})";
        }
    }

    
    public class Movie : IComparable, ICloneable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Director Director { get; set; }
        public string Country { get; set; }
        public Genre Genre { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }

        public Movie(string title, string description, Director director, string country, Genre genre, int year, double rating)
        {
            Title = title;
            Description = description;
            Director = director;
            Country = country;
            Genre = genre;
            Year = year;
            Rating = rating;
        }

        
        public int CompareTo(object obj)
        {
            Movie otherMovie = obj as Movie;
            if (otherMovie != null)
            {
                return this.Title.CompareTo(otherMovie.Title);
            }
            throw new ArgumentException("Object is not a Movie");
        }

       
        public object Clone()
        {
            return new Movie(Title, Description, (Director)Director.Clone(), Country, Genre, Year, Rating);
        }

        public override string ToString()
        {
            return $"Title: {Title}\nDescription: {Description}\nDirector: {Director}\nCountry: {Country}\nGenre: {Genre}\nYear: {Year}\nRating: {Rating}";
        }
    }

    
    public class Cinema : IEnumerable<Movie>
    {
        private List<Movie> movies = new List<Movie>();

       
        public void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }

        
        public void SortMovies(IComparer<Movie> comparer)
        {
            movies.Sort(comparer);
        }

     
        public IEnumerator<Movie> GetEnumerator()
        {
            return movies.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class TitleComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.Title.CompareTo(y.Title);
        }
    }


    public class RatingComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.Rating.CompareTo(y.Rating);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Director director1 = new Director("Christopher Nolan", new DateTime(1970, 7, 30));
            Director director2 = new Director("Quentin Tarantino", new DateTime(1963, 3, 27));

            Movie movie1 = new Movie("Inception", "Dreams within dreams", director1, "USA", Genre.SciFi, 2010, 8.8);
            Movie movie2 = new Movie("Pulp Fiction", "Crime and drama", director2, "USA", Genre.Thriller, 1994, 8.9);
            Movie movie3 = new Movie("The Dark Knight", "Superhero action", director1, "USA", Genre.Action, 2008, 9.0);

            Cinema cinema = new Cinema();
            cinema.AddMovie(movie1);
            cinema.AddMovie(movie2);
            cinema.AddMovie(movie3);

            
            Console.WriteLine("Unsorted Movies:");
            foreach (Movie movie in cinema)
            {
                Console.WriteLine(movie);
                Console.WriteLine();
            }

            
            Console.WriteLine("Movies sorted by Title:");
            cinema.SortMovies(new TitleComparer());
            foreach (Movie movie in cinema)
            {
                Console.WriteLine(movie);
                Console.WriteLine();
            }

            
            Console.WriteLine("Movies sorted by Rating:");
            cinema.SortMovies(new RatingComparer());
            foreach (Movie movie in cinema)
            {
                Console.WriteLine(movie);
                Console.WriteLine();
            }
        }
    }
}
