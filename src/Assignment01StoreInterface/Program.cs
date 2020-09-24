using System;
using System.Collections.Generic;

namespace Assignment01StoreInterface
{
    class Program
    {
        static private List<Album> albumList;       // Predefined since there's no getting around them existing
        static private List<Movie> movieList;
        static void Main(string[] args)
        {
            // Step the first; load the two .xml files containing all the album and movie data.
            // If the XML files are missing it generates 25 random instances of the corresponding data set.
            // If the user decides to generate a new set of data they can input an integer corresponding to how many objects to generate.
            // During testing, 500 000 of each put the program at about 400MB RAM usage, taking 20s to generate the data and about 3-4s to sort it.
            albumList = Initialize.Goods(out movieList);

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
            while(isRunning)
            {
                menuItems = Menu.Draw(menuItems, out isRunning);
            }
        }

        /*public static List<Album> GetAlbums() // This code, I believe, was from when I tried to do an async thing that just didn't work the way I wanted it to.
        {
            return albumList;
        }
        public static List<Movie> GetMovies()
        {
            return movieList;
        }*/



    }
}
