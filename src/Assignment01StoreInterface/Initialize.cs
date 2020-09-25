using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Assignment01StoreInterface
{
    class Initialize                                                                // Den huvudsakliga funktionen för den här klassen är att hålla kod som annars
    {                                                                               // skulle bli stora block i Main().
        public static List<string> Open()                                           // Första listan som skrivs ut efter att movieList och albumList populerats.
        {
            List<string> init = new List<string> 
            { 
                "Enter Store", 
                "Exit" 
            };
            return init;
        }

        public static void Album()                                                  // Ett metodanrop som huvudsakligen bara utför ett metodanrop med argument.
        {
            AlbumReader.Read(Directory.GetCurrentDirectory() + "/AlbumData.xml");
        }

        public static void Movie()                                                  // Ett metodanrop som huvudsakligen bara utför ett metodanrop med argument.
        {
            MovieReader.Read(Directory.GetCurrentDirectory() + "/MovieData.xml");
        }

        public static async void AlbumTask(int albumCount)                          // Tar in en integer för antalet album som ska skapas.
        {

            Task<List<Album>> albumTask = AlbumReader.Generate(albumCount);         // Skickar in dess input och sparar det i en Task<List<Album>>
            Program.SetAlbums(await albumTask);                                     // Väntar på att generatorn är klar, skickar sen tillbaka resultatet.
        }

        public static async void MovieTask(int movieCount)                          // I princip samma sak som AlbumTask för Movies istället.
        {

            Task<List<Movie>> movieTask = MovieReader.Generate(movieCount);
            Program.SetMovies(await movieTask);
        }

        public static void Goods()                                                  // Denna metod populerar movieList och albumList i Program klassen
        {
            List<string> staticOrDynamic = new List<string>                         // Menyval och beskrivning.
            {
                "-|- Would you like to get inventory from file or generate it procedurally?\r\n-|- Warning! Just because you can input two billion does not mean it's a good idea!\r\n-|- Be responsible, please! (suggested values between 10 and 100)\r\n", 
                "File", 
                "Generate" 
            };
            bool checkIfFile = Menu.Init(staticOrDynamic);                          // Kallar på menyn för att få svar ja eller nej om det ska läsas från fil.
            List<Album> albumList = new List<Album>();
            List<Movie> movieList = new List<Movie>();

            if (checkIfFile)                                                        // Om användaren valde att läsa från fil, kalla på de metoderna.
            {
                AlbumReader.Read(Directory.GetCurrentDirectory() + "/AlbumData.xml");
                MovieReader.Read(Directory.GetCurrentDirectory() + "/MovieData.xml");
            }
            else                                                                    // Annars så frågar den hur många album och filmer som ska skapas genom Generator klassen.
            {
                Console.Clear();
                Console.WriteLine("Plese enter how many albums you want to generate:");
                int albumCount = TryRead.Int();                                     // TryRead-klassen existerar för att se till att det inte blir felaktiga inputs.
                                                                                    // Den har specifika metoder för varje input-typ användaren kan behöva skicka in.
                Console.Clear();                                                    // Då koden har ändrats så används bara en av TryRead-klassens metoder i den här versionen.
                Console.WriteLine("Plese enter how many movies you want to generate:");
                int movieCount = TryRead.Int();

                AlbumTask(albumCount);                                              // Skicka antalet som användaren skrev in i metodenanropet.
                MovieTask(movieCount);                                              // Det är extra krångligt då vissa saker tidigare kallades från Main()
            }
        }
    }
}
