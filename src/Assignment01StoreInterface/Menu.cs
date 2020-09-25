using System;
using System.Collections.Generic;

namespace Assignment01StoreInterface
{
    public class Menu
    {
        private static int index = 1;
        static string fakturaAdress = "Unreasonable Lane 991a";
        static string besoksAdress = "Oddroad 13579";

        public static List<string> Draw(List<string> MenuItems, out bool isRunning)
        {
            isRunning = true;

            List<Album> albumList = Program.GetAlbums();
            List<Movie> movieList = Program.GetMovies();

            index = 0;  


            while (isRunning)
            {

                string selectedMenuItem = DrawMenu(MenuItems);

                switch (selectedMenuItem)
                {
                    case "Enter Store":
                        {
                            index = 1;
                            Console.WriteLine();
                            MenuItems = new List<string>
                            {
                                "-|- Hello, and welcome to Hans-Johnny's music and film shop.           -|- \r\n" +
                                "-|- Would you like to browse our music library? Or perhaps our movies? -|-\r\n" +
                                $"-|- You can find us at {besoksAdress}                                   -|-\r\n" +
                                $"-|- And billing at {fakturaAdress}                              -|-\r\n",
                                "Albums",
                                "Movies",
                                "Exit"
                            };
                            break;
                        }
                    case "Albums":
                        {
                            index = 1;
                            MenuItems = new List<string>
                            {
                                "-|-  Here's our current stock of albums. Would you like to look at a specific one?  -|-\r\n",
                                "Yes",
                                "No",
                            };
                            bool albumsLoop = true;
                            bool looped = false;

                            while (albumsLoop)
                            {
                                selectedMenuItem = Menu.AlbumLoop(selectedMenuItem, MenuItems, out MenuItems, albumList, out albumsLoop, looped, out looped);
                            }
                            MenuItems = new List<string>
                            {
                                "-|- Please make a new selection. -|-\r\n",
                                "Albums",
                                "Movies",
                                "Exit"
                            };
                            index = 1;
                            break;
                        }
                    case "Movies":
                        {
                            index = 0;
                            MenuItems = new List<string>();
                            foreach (Movie m in movieList)
                            {
                                MenuItems.Add(m.Title());
                            }

                            bool movieLoop = true;

                            while (movieLoop)
                            {
                                selectedMenuItem = MovieLoop(selectedMenuItem, MenuItems, out MenuItems, movieList, out movieLoop);
                            }

                            index = 0;
                            Console.WriteLine("\r\nPress the any key (enter) to continue."); Console.ReadLine();
                            Console.Clear();
                            MenuItems = new List<string>
                            {
                                "-|- Please make a new selection. -|-\r\n",
                                "Albums",
                                "Movies",
                                "Exit"
                            };
                            index = 2;
                            break;
                        }
                    case " Exit":
                        {
                            isRunning = false;
                            index = 0;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("-|-Thank you for visiting our shop!\r\nPlease come visit us in person to buy some of our amazing goods!\r\nHave a nice day!");
                            Console.Read();
                            break;
                        }
                    case "Exit":
                        {
                            isRunning = false;
                            index = 0;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("-|-Thank you for visiting our shop!\r\nPlease come visit us in person to buy some of our amazing goods!\r\nHave a nice day!");
                            Console.Read();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            return MenuItems;
        }

        private static string AlbumLoop(string selectedMenuItem,List<string> MenuItems, out List<string> MenuItemsOut, List<Album> albumList, out bool albumsLoop, bool looped, out bool loopy)
        {
            loopy = looped;
            albumsLoop = true;
            if (!looped)
                selectedMenuItem = DrawMenu(MenuItems);
            if (selectedMenuItem.Contains('Y'))
            {
                index = 0;
                MenuItems = new List<string>();
                foreach (Album a in albumList)
                {
                    MenuItems.Add(a.Title());
                }

                Console.ForegroundColor = ConsoleColor.Yellow;

                bool yesLoop = true;
                while (yesLoop)
                {
                    selectedMenuItem = DrawMenu(MenuItems);
                    foreach (Album a in albumList)
                    {
                        if (a.Title() == selectedMenuItem)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"-|- {a.Title()}\r\n-|- Performed by {a.AlbumArtist()}\r\n-|- Released on {a.Date()}\r\n-|- With an average user rating of {a.averageUserRating}\r\n-|- Available now for the low-low price of: {a.price}:-\r\n");
                            for (int i = 0; i < a.trackTitles.Length; i++)
                            {
                                string s;
                                if (a.trackFeatArtists[i] != "")
                                {
                                    s = $"{a.trackTitles[i]}\r\n  Runtime: {a.trackRuntimes[i]}\r\n  Featuring: {a.trackFeatArtists[i]}\r\n";
                                    MenuItems.Add(s);
                                }
                                else
                                {
                                    s = $"{a.trackTitles[i]}\r\n  Runtime: {a.trackRuntimes[i]}\r\n";
                                    MenuItems.Add(s);
                                }
                                Console.WriteLine(s);
                            }
                            yesLoop = false;
                        }
                    }
                }
                index = 0;
                Console.WriteLine("\r\nPress the any key (enter) to continue."); Console.ReadLine();
                Console.Clear();

                MenuItems = new List<string>
                                    {
                                        "-|- Would you like to read additional album information? -|-\r\n",
                                        "Yes",
                                        "No"
                                    };
                bool repeat = true;
                index = 1;
                while (repeat)
                {
                    selectedMenuItem = DrawMenu(MenuItems);
                    if ((selectedMenuItem.Contains('N')) | selectedMenuItem.Contains('Y'))
                        repeat = false; loopy = true;
                    if (selectedMenuItem.Contains('N'))
                    {
                        albumsLoop = false;
                        index = 1;
                    }
                }
            }
            else if (selectedMenuItem.Contains('N'))
            {
                albumsLoop = false;
                index = 1;
            }

            MenuItemsOut = MenuItems;
            return selectedMenuItem;
        }

        private static string MovieLoop(string selectedMenuItem, List<string> MenuItems, out List<string> MenuItemsOut, List<Movie> movieList, out bool movieLoop )
        {
            selectedMenuItem = DrawMenu(MenuItems);
            movieLoop = true;
            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (Movie m in movieList)
            {
                if (m.Title() == selectedMenuItem)
                {
                    Console.Clear();
                    Console.WriteLine($"-|-{m.Title()}\r\n-|- Directed by {m.MovieDirector()}\r\n-|- Released on {m.Date()}\r\n-|- With an average user rating of {m.averageUserRating}\r\n-|- Available now for the amazingly low price of: {m.price}:-\r\n");
                    movieLoop = false;
                }
            }
            MenuItemsOut = MenuItems;
            return selectedMenuItem;
        }

        public static bool Init(List<string> MenuItems)
        {
            string selectedMenuItem = DrawMenu(MenuItems);
            if (selectedMenuItem == MenuItems[1])
            { return true; }
            else if (selectedMenuItem == MenuItems[2])
            { return false; }
            else { return Menu.Init(MenuItems); }
        }

        private static string DrawMenu(List<string> items)
        {



            Console.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                if (i == index)
                {

                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(items[i]);

                }
                else
                {

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(items[i]);


                }
                Console.ResetColor();
            }

            Console.SetWindowPosition(0, Math.Max(index-3, 0));

            ConsoleKeyInfo ckey = Console.ReadKey();

            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (index == items.Count - 1)
                {

                }
                else
                {
                    index++;
                }
            }

            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (index <= 0)
                {

                }
                else
                {
                    index--;
                }
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                if (index < items.Count)
                    return items[index];
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

        private static ConsoleColor ColorChanger(ConsoleColor input)
        {
            if (input == ConsoleColor.Red)

                switch (input)
                {
                    case ConsoleColor.Red:
                        input = ConsoleColor.DarkRed;
                        break;
                    case ConsoleColor.DarkRed:
                        input = ConsoleColor.Blue;
                        break;
                    case ConsoleColor.Blue:
                        input = ConsoleColor.DarkBlue;
                        break;
                    case ConsoleColor.DarkBlue:
                        input = ConsoleColor.Magenta;
                        break;
                    case ConsoleColor.Magenta:
                        input = ConsoleColor.DarkMagenta;
                        break;
                    case ConsoleColor.DarkMagenta:
                        input = ConsoleColor.Yellow;
                        break;
                    case ConsoleColor.Yellow:
                        input = ConsoleColor.Green;
                        break;
                    case ConsoleColor.Green:
                        input = ConsoleColor.DarkGreen;
                        break;
                    case ConsoleColor.DarkGreen:
                        input = ConsoleColor.Red;
                        break;
                    default:
                        break;
                }

            return input;
        }

    }
}
