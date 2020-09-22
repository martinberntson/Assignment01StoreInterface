using Assignment01StoreInterface;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;

namespace Assignment01StoreInterface
{
    public class Menu
    {
        private static int index = 0;
        static string fakturaAdress = "Unreasonable Lane 991a";
        static string besoksAdress = "Oddroad 13579";

        public static List<string> Draw(List<string> MenuItems, out bool isRunning)
        {
            isRunning = true;

            List<Album> albumList = Program.GetAlbums();
            List<Movie> movieList = Program.GetMovies();


            while (isRunning)
            {

                string selectedMenuItem = DrawMenu(MenuItems);

                switch (selectedMenuItem)
                {
                    case "Enter Store":
                        {
                            index = 2;
                            Console.WriteLine();
                            MenuItems = new List<string>
                            {
                                "Hello, and welcome to Hans-Johnny's music and film shop.\r\n" +
                                "Would you like to browse our music library? Or perhaps our movies?",
                                " Albums",
                                " Movies",
                                " Exit"
                            };
                            index = 0;
                            break;
                        }
                    case " Albums":
                        {
                            index = 1;
                            MenuItems = new List<string>
                            {
                                "Here's our current stock of albums. Would you like to look at a specific one?",
                                " Yes",
                                " No",
                            };
                            bool albumsLoop = true;
                            while (albumsLoop)
                            {
                                selectedMenuItem = DrawMenu(MenuItems);
                                if (selectedMenuItem.Contains('Y'))
                                {
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
                                                Console.WriteLine($"{a.Title()}, performed by {a.AlbumArtist()}, released on {a.Date()} with a rating of {a.averageUserRating}\r\n Available now at a price of {a.price}:-");
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
                                    Console.WriteLine("\r\nPress any key to continue."); Console.ReadLine();
                                    Console.Clear();

                                    MenuItems = new List<string>
                                    {
                                        "Would you like to read additional album information?",
                                        " Yes",
                                        " No"
                                    };
                                    bool repeat = true;
                                    while (repeat)
                                    {
                                        selectedMenuItem = DrawMenu(MenuItems);
                                        if ((selectedMenuItem.Contains('N')) | selectedMenuItem.Contains('Y')) // This will work as long as there's no album named "Yes" or "No"
                                            repeat = false;                                                    // It just checks if a selection has been made before breaking the loop.
                                        if (selectedMenuItem.Contains('N'))
                                            albumsLoop = false;
                                    }


                                }
                                else if (selectedMenuItem.Contains('N'))
                                {
                                    albumsLoop = false;
                                }
                            }
                            MenuItems = new List<string>
                            {
                                "Please make a new selection",
                                " Albums",
                                " Movies",
                                " Exit"
                            };
                            index = 0;
                            break;
                        }
                    case " Movies":
                        {
                            MenuItems = new List<string>();

                            selectedMenuItem = DrawMenu(MenuItems);
                            foreach (Movie m in movieList)
                            {
                                MenuItems.Add(m.Title());
                            }

                            bool yesLoop = true;
                            while (yesLoop)
                            {
                                selectedMenuItem = DrawMenu(MenuItems);
                                foreach (Movie m in movieList)
                                {
                                    if (m.Title() == selectedMenuItem)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"{m.Title()}, performed by {m.MovieDirector()}, released on {m.Date()} with a rating of {m.averageUserRating}\r\n Available now at a price of {m.price}:-");
                                        yesLoop = false;
                                    }
                                }
                            }

                            index = 0;
                            Console.WriteLine("\r\nPress any key to continue."); Console.ReadLine();
                            Console.Clear();
                            MenuItems = new List<string>
                            {
                                "Please make a new selection.",
                                " Albums",
                                " Movies",
                                " Exit"
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
                    default:
                        {
                            break;
                        }
                }
            }
            return MenuItems;




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
