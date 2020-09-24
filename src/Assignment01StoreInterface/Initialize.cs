using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment01StoreInterface
{
    class Initialize
    {
        public static List<string> Open()
        {
            List<string> init = new List<string> { "Enter Store", "Exit" };
            return init;
        }

        public static List<Album> Album()
        {
            List<Album> albumList = AlbumReader.Read(Directory.GetCurrentDirectory() + "/AlbumData.xml");
            return albumList;
        }

        public static List<Movie> Movie()
        {
            List<Movie> movieList = MovieReader.Read(Directory.GetCurrentDirectory() + "/MovieData.xml");
            return movieList;
        }

        public static List<Album> Goods(out List<Movie> MovieList)
        {
            List<string> staticOrDynamic = new List<string> 
            { "Would you like to get inventory from file or generate it procedurally?", "File", "Generate" };
            bool checkIfFile = Menu.Init(staticOrDynamic);
            List<Album> albumList = new List<Album>();
            List<Movie> movieList = new List<Movie>();
            if (checkIfFile)
            {
                albumList = AlbumReader.Read(Directory.GetCurrentDirectory() + "/AlbumData.xml");
                movieList = MovieReader.Read(Directory.GetCurrentDirectory() + "/MovieData.xml");
                MovieList = movieList;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Plese enter how many albums you want to generate:");
                int albumCount = TryRead.Int();

                Console.Clear();
                Console.WriteLine("Plese enter how many movies you want to generate:");
                int movieCount = TryRead.Int();
                albumList = AlbumReader.Generate(albumCount);
                movieList = MovieReader.Generate(movieCount);
                MovieList = movieList;
            }

            return albumList;
        }
    }
}
