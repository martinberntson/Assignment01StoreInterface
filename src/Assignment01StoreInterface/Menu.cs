using System;
using System.Collections.Generic;

namespace Assignment01StoreInterface
{
    public class Menu
    {
        private static int _index = 1;                                                   // Index är en pekare som säger vad som är markerat i menyn
        static readonly string _fakturaAdress = "Unreasonable Lane 991a";                         // Tyckte det här var en passande adress    
        static readonly string _besoksAdress = "Oddroad 13579";                                   // Men den här är bättre.

        public static List<string> Draw(List<string> MenuItems, out bool isRunning)     // Tar in en lista med strings, och kör sen menyn.
        {
            isRunning = true;

            List<Album> albumList = Program.GetAlbums();                                // Hämtar album från Program
            List<Movie> movieList = Program.GetMovies();                                // Hämtar filmer från Program

            _index = 0;                                                                  // Här och där i den här klassen hittar du index = X
                                                                                        // Dessa är så pekaren inte väljer beskrivningen för nuvarande menysidan...
                                                                                        // Men ibland gör de ingenting.
            while (isRunning)
            {

                string selectedMenuItem = DrawMenu(MenuItems);                          // Rita ut menyn, få tillbaka det som pekaren ligger mot.

                switch (selectedMenuItem)                                               // Nu blir det jobbigt. Här hittar vi loopar i if-satser i switchar i loopar...
                {
                    case "Enter Store":                                                 // Första steget in i affären
                        {
                            _index = 1;
                            Console.WriteLine();
                            MenuItems = new List<string>
                            {
                                "-|- Hello, and welcome to Hans-Johnny's music and film shop.           -|- \r\n" +
                                "-|- Would you like to browse our music library? Or perhaps our movies? -|-\r\n" +
                                $"-|- You can find us at {_besoksAdress}                                   -|-\r\n" +
                                $"-|- And billing at {_fakturaAdress}                              -|-\r\n",
                                "Albums",
                                "Movies",
                                "Exit"
                            };
                            break;
                        }
                    case "Albums":                                                      // När du väljer att se albumlistan.
                        {
                            _index = 1;
                            MenuItems = new List<string>
                            {
                                "-|-  Select Yes to view our current stock of albums. No to return to the main menu. -|-\r\n",
                                "Yes",
                                "No",
                            };
                            bool albumsLoop = true;
                            bool looped = false;
                            while (albumsLoop)                                          // Loopen som kör albumlistan om och om igen.
                            {                                                           // Låter dig välja album, välja om du vill se ett till album, osv.
                                selectedMenuItem = Menu.AlbumLoop(selectedMenuItem, MenuItems, out MenuItems, albumList, out albumsLoop, looped, out looped);
                            }
                            MenuItems = new List<string>                                // Tillbaka till main menu
                            {
                                "-|- Please make a new selection. -|-\r\n",
                                "Albums",
                                "Movies",
                                "Exit"
                            };
                            _index = 1;
                            break;
                        }
                    case "Movies":                                                      // Movies är lite simplare än albums
                        {
                            _index = 0;
                            MenuItems = new List<string>();
                            foreach (Movie m in movieList)                              // Skapa en lista av filmer
                            {
                                MenuItems.Add(m.GetTitle());
                            }

                            bool movieLoop = true;

                            while (movieLoop)                                           // Skriv ut listan och låt användaren välja från den
                            {
                                selectedMenuItem = MovieLoop(selectedMenuItem, MenuItems, out MenuItems, movieList, out movieLoop);
                            }

                            _index = 0;
                            Console.WriteLine("\r\nPress the any key (enter) to continue."); Console.SetWindowPosition(0, 0); Console.ReadLine();
                            Console.Clear();
                            MenuItems = new List<string>                                // Slänger ut dig direkt i main menu utan att fråga. Album är mycket vänligare.
                            {
                                "-|- Please make a new selection. -|-\r\n",
                                "Albums",
                                "Movies",
                                "Exit"
                            };
                            _index = 2;
                            break;
                        }
                    case " Exit":                                                       // I olika versioner av koden har jag haft både "Exit" och " Exit"
                        {                                                               // båda finns nu kvar och gör samma sak.
                            isRunning = false;                                          // Stänger av isRunning för att avsluta loopen i Main()
                            _index = 0;
                            Console.Clear();                                            // Tömmer console output
                            Console.ForegroundColor = ConsoleColor.DarkYellow;          // Sätter texten till mörkgul
                            Console.WriteLine("-|-Thank you for visiting our shop!\r\nPlease come visit us in person to buy some of our amazing goods!\r\nHave a nice day!");
                            Console.Read();                                             // Väntar på input innan programmet stängs.
                            break;
                        }   
                    case "Exit":                                                        // Samma som ovan.
                        {
                            isRunning = false;
                            _index = 0;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("-|-Thank you for visiting our shop!\r\nPlease come visit us in person to buy some of our amazing goods!\r\nHave a nice day!");
                            Console.Read();
                            break;
                        }
                    default:                                                            // Gör ingenting, tillbaka till början av loopen.
                        {
                            break;
                        }
                }
            }
            return MenuItems;                                                           // Skickar tillbaka nuvarande MenuItems lista
        }

        private static string AlbumLoop(string selectedMenuItem,List<string> MenuItems, out List<string> MenuItemsOut, List<Album> albumList, out bool albumsLoop, bool looped, out bool loopy)
        {                                                                               // Metoden som hanterar utskrift av album och spår.
            loopy = looped;                                                             // Den är en metod istället för del av switchen ovan för att det ser bättre ut.
            albumsLoop = true;
            if (!looped)                                                                // Den här ska bara köras en gång. Hade en bug där man behövde trycka enter två gånger.
                selectedMenuItem = DrawMenu(MenuItems);                                 // Denna if-sats är resultatet av mina försök att fixa det problemet.
            if (selectedMenuItem.Contains('Y'))                                         // Den här träffar inte bara då du svarat "Yes" innan metodanropet, men även om du
            {                                                                           // svarat "Yes" i senare val i metoden.
                _index = 0;
                MenuItems = new List<string>();
                foreach (Album a in albumList)                                          // Summerar en lista av alla albumtitlar
                {
                    MenuItems.Add(a.GetTitle());
                }

                Console.ForegroundColor = ConsoleColor.Yellow;                          // Sätter textfärg till gul

                bool yesLoop = true;
                while (yesLoop)                                                         // Loop. I en metod. Som loopas konstant. Med två lager if-sats och for-loop i sig.
                {
                    selectedMenuItem = DrawMenu(MenuItems);
                    foreach (Album a in albumList)
                    {
                        if (a.GetTitle() == selectedMenuItem)                              // Kollar om du valt ett specifikt album
                        {                                                               // Om ja, skriv ut det albumets information
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"-|- {a.GetTitle()}\r\n-|- Performed by {a.GetAlbumArtist()}\r\n-|- Released on {a.Date()}\r\n-|- It has a runtime of {a.Runtime} minutes\r\n-|- With {a.TrackTitles.Length} tracks.\r\n-|- With an average user rating of {a.AverageUserRating}\r\n-|- Available now for the low-low price of: {a.Price}:-\r\n");
                            for (int i = 0; i < a.TrackTitles.Length; i++)              // Och gå sen igenom dess arrayer av track-data
                            {                                                           // Så att den kan skriva ut alla tracks också.
                                string s;
                                if (a.TrackFeatArtists[i] != "")                        // Om Feat. Artist är en blank string (inte null) så skippar den att skriva ut den delen.
                                {
                                    s = $"{a.TrackTitles[i]}\r\n  Runtime: {a.TrackRuntimes[i]}\r\n  Featuring: {a.TrackFeatArtists[i]}\r\n";
                                    MenuItems.Add(s);
                                }
                                else
                                {
                                    s = $"{a.TrackTitles[i]}\r\n  Runtime: {a.TrackRuntimes[i]}\r\n";
                                    MenuItems.Add(s);
                                }
                                Console.WriteLine(s);                                   // Efter att if/else satt ihop en string med trackdata så skrivs det ut.
                            }
                            yesLoop = false;                                            // Avslutar loopen om man gjort ett val.
                        }
                    }
                }
                _index = 0;
                Console.WriteLine("\r\nPress the any key (enter) to continue."); Console.SetWindowPosition(0,0); Console.ReadLine();
                Console.Clear();                                                        // Dessa två rader gör så att informationen stannar på skärm tills man trycker enter.

                MenuItems = new List<string>                                            // Frågar om man vill se info från fler album.
                                    {
                                        "-|- Would you like to read information from another album? -|-\r\n",
                                        "Yes",
                                        "No"
                                    };
                bool repeat = true;
                _index = 1;
                while (repeat)                                                          // Om "Yes", loopa igen, om "No", gå tillbaka till main menu.
                {
                    selectedMenuItem = DrawMenu(MenuItems);
                    if ((selectedMenuItem.Contains('N')) | selectedMenuItem.Contains('Y'))
                        repeat = false; loopy = true;
                    if (selectedMenuItem.Contains('N'))
                    {
                        albumsLoop = false;
                        _index = 1;
                    }
                }
            }
            else if (selectedMenuItem.Contains('N'))
            {
                albumsLoop = false;
                _index = 1;
            }

            MenuItemsOut = MenuItems;                                                   // Skickar tillbaka MenuItems
            return selectedMenuItem;                                                    // Och selectedMenuItem
        }                                                                               // Finns nog bättre sätt att göra det, som att MenuItems är en static List<string> t.ex.
                                                                                        // Men nu funkar koden, så håller det så här.

        private static string MovieLoop(string selectedMenuItem, List<string> MenuItems, out List<string> MenuItemsOut, List<Movie> movieList, out bool movieLoop )
        {                                                                               // Efter AlbumLoop så känns MovieLoop väldigt lätthanterlig.
            selectedMenuItem = DrawMenu(MenuItems);
            movieLoop = true;
            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (Movie m in movieList)                                              // Loopa igenom alla filmer och kolla om en specifik film är vald, om ja, skriv ut den.
            {
                if (m.GetTitle() == selectedMenuItem)
                {
                    Console.Clear();
                    Console.WriteLine($"-|- {m.GetTitle()}\r\n-|- Directed by {m.GetMovieDirector()}\r\n-|- Released on {m.Date()}\r\n-|- It has a runtime of {m.Runtime} minutes\r\n-|- With an average user rating of {m.AverageUserRating}\r\n-|- Available now for the amazingly low price of: {m.Price}:-\r\n");
                    movieLoop = false;
                }
            }
            MenuItemsOut = MenuItems;                                                   // Skicka sen tillbaka MenuItems och selectedMenuItem.
            return selectedMenuItem;
        }

        public static bool Init(List<string> MenuItems)                                 // Denna metod frågar om album och filmer ska laddas från fil
        {                                                                               // Eller genereras från metoder.
            string selectedMenuItem = DrawMenu(MenuItems);
            if (selectedMenuItem == MenuItems[1])
            { 
                return true; 
            }
            else if (selectedMenuItem == MenuItems[2])
            { 
                return false; 
            }
            else 
            { 
                return Menu.Init(MenuItems);                                            // Kör samma trick som jag började med i TryRead()
            }                                                                           // Om input är felaktigt så kallar metoden på sig själv
        }                                                                               // Och vid korrekt input så kollapsar allt ihop.

        private static string DrawMenu(List<string> items)                              // Den här biten kod kommer från 
        {                                                                               // https://pastebin.com/csaz77JK
            Console.Clear();                                                            // Jag har modifierat den lite...
                                                                                        // Men det mesta av metoden är oförändrat.
            for (int i = 0; i < items.Count; i++)                                       // Skriver ut alla strings i listan den får in
            { 
                if (i == _index)                                                         // Det nuvarande valda listobjektet blir grå text på svart bakgrund
                {

                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(items[i]);

                }
                else                                                                    // Resten får annan färg
                {

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(items[i]);


                }
                Console.ResetColor();
            }

            Console.SetWindowPosition(0, Math.Max(_index-3, 0));                     // La till den här raden så att den scrollar upp automatiskt vid höga antal objekt i listan
                                                                                        // Math.Max används för att undvika fel ifall [index-3] skulle vara negativt.
            ConsoleKeyInfo ckey = Console.ReadKey();                                    // Jag har inte testat om det faktiskt behövs.

            if (ckey.Key == ConsoleKey.DownArrow)                                       // Kollar om man trycker på pil ner
            {
                if (_index == items.Count - 1)
                {

                }
                else
                {
                    _index++;                                                            // Då rad noll är högst upp och den räknar uppåt när man går ner i listan
                }                                                                       // Så blir pil ner en ökning av index.
            }

            else if (ckey.Key == ConsoleKey.UpArrow)                                    // Kollar om man trycker på pil upp
            {
                if (_index <= 0)
                {

                }
                else
                {
                    _index--;                                                            // Och en minskning av index från pil upp tar dig uppåt i listan.
                }
            }
            else if (ckey.Key == ConsoleKey.Enter)                                      // Om man trycker på enter så väljs det nuvarande objektet som skickas tillbaka.
            {
                if (_index < items.Count)
                    return items[_index];
                else
                    return items[items.Count - 1];
            }
            else
            {
                return "";
            }

            Console.Clear();
            return "";
        }
    }
}
