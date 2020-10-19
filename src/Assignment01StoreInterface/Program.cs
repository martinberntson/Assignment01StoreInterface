using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment01StoreInterface
{
    class Program
    {
        static private List<Album> albumList = new List<Album>();
        static private List<Movie> movieList = new List<Movie>();

       
        static async Task Main(string[] args)                   // Det finns en varning om att den körs sync'ad. Det är helt okej.
        {
            bool check = false;
            Initialize.Goods();                                 // Kallar metoden som populerar de statiska listorna
            Console.Clear();                                    // Tar bort text från skärmen
            Console.WriteLine("Initializing...");               // Och skriver text så användaren vet att det är dags att vänta.

            while(!check)                                       // Om man använder från fil, eller genererar små mängder, så märks knappt denna loop
            {                                                   // Men om man skapar 100 000 eller fler objekt så kan det ta ett tag.
                if ((albumList.Count > 0) && (movieList.Count > 0)) 
                    check = true;                               // While-loopen med if-sats i ser till att både movieList och albumList har innehåll
            }                                                   // Utan att kolla det så kan man få en hel exceptions p.g.a. att listorna är null. 



            while (check)                                       // Kommer inte ihåg om den här loopen fixar något problem eller om den bara är från mina många försök
            {                                                   // Att få async att fungera. Oavsett, den finns, och saker fungerar, så...

                List<string> menuItems = Initialize.Open();     // Hämtar en lista för senare bruk

                Album[] sortedAlbumList;
                sortedAlbumList = Sorter.AlbumSortRating(albumList);
                try                                             // Försöker sortera albumlistan med min hemmagjorda sorteringsmetod.
                {
                    Array.Reverse(sortedAlbumList);
                    albumList = sortedAlbumList.ToList<Album>();
                }
                catch { }                                       // Och inget händer om det inte fungerar.


                Movie[] sortedMovieList;
                sortedMovieList = Sorter.MovieSort(movieList);
                try                                             // Försöker sortera filmerna med en väldigt liknande hemmagjord sorteringsmetod.
                {
                    Array.Reverse(sortedMovieList);
                    movieList = sortedMovieList.ToList<Movie>();
                }
                catch { }                                       // Och än en gång så händer inget om det inte funkar.



                bool isRunning = true;
                while (isRunning)                               // Den här loopen ser inte så imponerande ut, men det mesta användaren kan göra händer här.
                {
                    menuItems = Menu.Draw(menuItems, out isRunning);
                }                                               // Och när loopen slutar så stänger programmet ner.

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
        }
        public static List<Movie> GetMovies()
        {
            return movieList;
        }
        public static void SetMovies(List<Movie> MovieList)
        {
            movieList = MovieList;
        }
    }
}
