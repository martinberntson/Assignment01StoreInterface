using RemakeOneYearLater.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RemakeOneYearLater
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
            Console.WriteLine();
        }
        static async Task<Task<string>> MainAsync()
        {
            Task<IEnumerable<Movie>> moviesTask = Services.DataReader.ReadMoviesAsync(
                $"{AppDomain.CurrentDomain.BaseDirectory}Data/MovieData.xml"
                );
            Task<IEnumerable<Album>> albumsTask = Services.DataReader.ReadAlbumsAndTracksAsync(
                $"{AppDomain.CurrentDomain.BaseDirectory}Data/AlbumData.xml"
                );
            var movies = await moviesTask;
            var albums = await albumsTask;

            return Task.FromResult<string>("");
        }
    }
}
