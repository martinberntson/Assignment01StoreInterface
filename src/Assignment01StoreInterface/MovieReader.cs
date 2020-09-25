using System;
using System.Collections.Generic;
using System.Xml;
using System.Threading.Tasks;


namespace Assignment01StoreInterface
{
    class MovieReader
    {
        public static async void Read(string FilePath)                  // Metoden som läser in filmer från fil.
        {
            List<Movie> movies = new List<Movie>();
            XmlDocument xDoc = new XmlDocument();

            try { xDoc.Load(FilePath); }                                // Snabbt test för att se om filen finns där programmet förväntar sig att det ska vara.
            catch (System.IO.FileNotFoundException)                     // Om inte så går den och skapar 25 filmobjekt genom generator-metoden.
            {
                Console.WriteLine("MovieData.xml was not found.\r\nGenerating new data...\r\nPress the any key (enter) to continue."); Console.Read();
                Task<List<Movie>> task = MovieReader.Generate(25);
                Program.SetMovies(await task);
                return;
            }

            XmlNodeList itemNodes = xDoc.SelectNodes("//Movies/Movie"); // Väljer var i XML-dokumentet man ska börja leta
                foreach (XmlNode movieNode in itemNodes)                // Går igenom varje Movie objekt i XML-dokumentet
                {
                    movies.Add(new Movie(movieNode.Attributes["Title"].Value, 
                        movieNode.Attributes["Director"].Value, 
                        movieNode.Attributes["ReleaseDate"].Value, 
                        Convert.ToDecimal(movieNode.Attributes["AverageUserRating"].Value), 
                        Convert.ToByte(movieNode.Attributes["Runtime"].Value), 
                        Convert.ToByte(movieNode.Attributes["Price"].Value)));  // Kallar på Movie()-konstruktorn, lägger till nya filmen i movies listan
                }
            Program.SetMovies(movies);                                  // Skickar in movies till den set-metod som finns i Program.cs
        }

        public static async Task<List<Movie>> Generate(int numberToGenerate)
        {                                                               // Generatorn för filmer kallar på metoder i Generator-klassen för att skapa nya filmer från luft.
            List<Movie> movieList = new List<Movie>();
            await Task.Run(() =>                                        // Gör den här delen något? Kanske? Vet inte.
            {
                for (int i = numberToGenerate; i > 0; i--)              // Flertal metodanrop till Generator-klassen för att skapa nya Movie objekt.
                {
                    string s1 = Generator.MovieTitle();
                    string s2 = Generator.Name();
                    string s3 = Generator.Date();
                    decimal d1 = Generator.Rating();
                    byte b1 = Generator.MovieRuntime();
                    byte b2 = Generator.Price();
                    movieList.Add(new Movie(s1, s2, s3, d1, b1, b2));
                }
            });
            return movieList;                                           // När listan är fylld så skicaks den tillbaka.

        }
    }
}
