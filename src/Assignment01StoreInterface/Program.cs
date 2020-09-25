using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment01StoreInterface
{
    class Program
    {
        static private List<Album> albumList = new List<Album>();       // Predefined since there's no getting around them existing
        static private List<Movie> movieList = new List<Movie>();

       
        static async Task Main(string[] args)
        {
            // Step the first; load the two .xml files containing all the album and movie data.
            // If the XML files are missing it generates 25 random instances of the corresponding data set.
            // If the user decides to generate a new set of data they can input an integer corresponding to how many objects to generate.
            // During testing, 500 000 of each put the program at about 400MB RAM usage, taking 20s to generate the data and about 3-4s to sort it.
            bool check = false;
            Initialize.Goods();
            Console.Clear();
            Console.WriteLine("Initializing...");
            while(!check)
            {
                if ((albumList.Count > 0) && (movieList.Count > 0))  // Kollar ifall movieList och albumList har fått sitt innehåll från Initialize.Goods() innan vi går vidare.
                    check = true;
            }

            // movieList.Sort((x,y) => x.Date().CompareTo(y.Date()));
            // albumList.Sort((x,y) => x.averageUserRating.CompareTo(y.averageUserRating));

            while (check)
            {
                // This just adds two strings to a list, it doesn't do anything other than make Main() look more tidy.
                List<string> menuItems = Initialize.Open();

                // Sort the album data by average user rating, exception if null. At this point, there should be virtually no way of the list being null, but who knows.
                Album[] sortedAlbumList;
                sortedAlbumList = Sorter.AlbumSortRating(albumList);
                try
                {
                    Array.Reverse(sortedAlbumList);
                }
                catch { }

                // Sort the movie data by release date, exception if null. Like albums, should be virtually no way of the list being null here.
                // The try/catches are pretty much development leftovers.
                Movie[] sortedMovieList;
                sortedMovieList = Sorter.MovieSort(movieList);
                try
                {
                    Array.Reverse(sortedMovieList);
                }
                catch { }


                // Here is where pretty much the entire program runs; everything that actually outputs relevant information is done through the Menu class.
                bool isRunning = true;
                while (isRunning)
                {
                    menuItems = Menu.Draw(menuItems, out isRunning);
                }
                check = false;
            }
        }

        public static List<Album> GetAlbums()
        {
            return albumList;
        }
        public static void SetAlbums(List<Album> AlbumList)
        {
            albumList = AlbumList;
            //foreach (Album a in AlbumList)
            //{ 
            //    //albumList.Add(a); 
            //}
        }
        public static List<Movie> GetMovies()
        {
            return movieList;
        }
        public static void SetMovies(List<Movie> MovieList)
        {
            movieList = MovieList;
            //foreach (Movie m in MovieList)
            //{ 

            //    //movieList.Add(m);
            //}
        }


    }
}
