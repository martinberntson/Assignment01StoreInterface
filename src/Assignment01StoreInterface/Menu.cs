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
                                "Hello, and welcome to Hans-Johnny's music and film shop.\r\n" +
                                "Would you like to browse our music library? Or perhaps our movies?\r\n",
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
                                "Here's our current stock of albums. Would you like to look at a specific one?\r\n",
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
                                "Please make a new selection\r\n",
                                "Albums",
                                "Movies",
                                "Exit"
                            };
                            index = 0;
                            break;
                        }
                    case "Movies":
                        {       // Todo: Add a "keep browsing movies?" option.
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
                                "Please make a new selection.\r\n",
                                "Albums",
                                "Movies",
                                "Exit"
                            };
                            index = 0;
                            break;
                        }
                    case " Exit":
                        {
                            isRunning = false;
                            index = 0;
                            break;
                        }
                    case "Exit":
                        {
                            isRunning = false;
                            index = 0;
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


        /* So the following method needs selectedMenuItem for the DrawMenu(), as well as MenuItems to send in.
         * Or maybe it doesn't really need selectedMenuItem to be sent in, but I can't be bothered testing it right now.
         * MenuItems are necessary, though, since they can carry over from previous loops.
         * albumsLoop determines if the loop break, loopy and looped are there to stop a bug that caused you to have to select "Yes" twice in a menu option.
         * MenuItemsOut is just MenuItems, except sent back since it can't be the same as the input.
        */
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
                // All albums are now in a list that I want to be able to go through.
                bool yesLoop = true;
                while (yesLoop)
                {
                    selectedMenuItem = DrawMenu(MenuItems);
                    foreach (Album a in albumList)
                    {
                        if (a.Title() == selectedMenuItem)
                        {
                            Console.Clear();
                            Console.WriteLine($"{a.Title()}, performed by {a.AlbumArtist()}, released on {a.Date()} with a rating of {a.averageUserRating}\r\n Available now at a price of {a.price}:-\r\n");
                            foreach (string s in a.AlbumTracks())
                            {
                                MenuItems.Add(s);
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
                                        "Would you like to read additional album information?\r\n",
                                        "Yes",
                                        "No"
                                    };
                index = 1;
                bool repeat = true;
                while (repeat)
                {
                    selectedMenuItem = DrawMenu(MenuItems);
                    if ((selectedMenuItem.Contains('N')) | selectedMenuItem.Contains('Y')) // This will work as long as there's no album named "Yes" or "No"
                        repeat = false; loopy = true;                                                  // It just checks if a selection has been made before breaking the loop.
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
            }

            MenuItemsOut = MenuItems;
            return selectedMenuItem;
        }

        /* Thanks to movies not having subclasses it's a lot simpler here.
         * Takes in selectedMenuItem, which may or may not be necessary, as well as the MenuItems list and movieList for data to work with.
         * It returns selectedMenuItem for use outside, while outputs MenuItemsOut as a copy of MenuItems, and movieLoop set to false once all work is done.
         * Overall, much shorter and more nice-looking than stupid AlbumLoop.
        */
        private static string MovieLoop(string selectedMenuItem, List<string> MenuItems, out List<string> MenuItemsOut, List<Movie> movieList, out bool movieLoop )
        {
            selectedMenuItem = DrawMenu(MenuItems);
            movieLoop = true;
            foreach (Movie m in movieList)
            {
                if (m.Title() == selectedMenuItem)
                {
                    Console.Clear();
                    Console.WriteLine($"{m.Title()}, directed by {m.MovieDirector()}, released on {m.Date()} with a rating of {m.averageUserRating}\r\n Available now at a price of {m.price}:-\r\n");
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
                    Console.WriteLine(items[i]);
                }
                Console.ResetColor();
            }

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

    }
}
