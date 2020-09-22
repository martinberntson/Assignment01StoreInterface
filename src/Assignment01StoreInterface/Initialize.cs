using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assignment01StoreInterface
{
    class Initialize
    {
        public static List<string> Menu()
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
    }
}
