using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Assignment01StoreInterface
{
    class Initialize
    {
        public static List<string> Open()
        {
            List<string> init = new List<string> { "Enter Store", "Exit" };
            return init;
        }

        public static void Album()
        {
            AlbumReader.Read(Directory.GetCurrentDirectory() + "/AlbumData.xml");
        }

        public static void Movie()
        {
            MovieReader.Read(Directory.GetCurrentDirectory() + "/MovieData.xml");
        }

        public static async void AlbumTask(int albumCount)
        {

            Task<List<Album>> albumTask = AlbumReader.Generate(albumCount);
            // List<Album> generatedAlbums = await albumTask;
            Program.SetAlbums(await albumTask);
        }

        public static async void MovieTask(int movieCount)
        {

            Task<List<Movie>> movieTask = MovieReader.Generate(movieCount);
            // List<Movie> generatedMovies = await movieTask;
            Program.SetMovies(await movieTask);
        }

        public static void Goods()
        {
            List<string> staticOrDynamic = new List<string> 
            { "Would you like to get inventory from file or generate it procedurally?\r\n", "File", "Generate" };
            bool checkIfFile = Menu.Init(staticOrDynamic);
            List<Album> albumList = new List<Album>();
            List<Movie> movieList = new List<Movie>();
            if (checkIfFile)
            {
                AlbumReader.Read(Directory.GetCurrentDirectory() + "/AlbumData.xml");
                MovieReader.Read(Directory.GetCurrentDirectory() + "/MovieData.xml");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Plese enter how many albums you want to generate:");
                int albumCount = TryRead.Int();

                Console.Clear();
                Console.WriteLine("Plese enter how many movies you want to generate:");
                int movieCount = TryRead.Int();

                AlbumTask(albumCount);
                MovieTask(movieCount);
            }
        }
    }
}
