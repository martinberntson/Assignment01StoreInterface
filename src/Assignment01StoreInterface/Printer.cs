using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment01StoreInterface
{
    class Printer
    {
        public static void AlbumPrinter(Album[] input, bool track)
        {
            if (input != null)
            {
                if (track)
                {
                    string title;
                    for (int n = 0; n < input.Length; n++)
                    {
                        Console.WriteLine(input[n].Title() + ", rated average " + input[n].AlbumRating());
                        Console.WriteLine("  Performed by: " + input[n].AlbumArtist());

                        for (int i = 0; i < (input[n].AlbumTrackCount()); i++)
                        {
                            title = input[n].AlbumTrack(i);
                            Console.WriteLine("  " + title);
                        }
                    }
                }
                else
                {
                    for (int n = 0; n < input.Length; n++)
                    {
                        Console.WriteLine(input[n].Title() + ", rated average " + input[n].AlbumRating());
                        Console.WriteLine("  Performed by: " + input[n].AlbumArtist());
                    }
                }
            }
            else Console.WriteLine("Album data unavailable.");
        }

        public static void MoviePrinter(Movie[] input)
        {
            if (input != null)
            {
                for (int n = 0; n < input.Length; n++)
                {
                    Console.WriteLine(input[n].Title() + ", released on " + input[n].Date());
                    Console.WriteLine("  Directed by: " + input[n].MovieDirector());
                }
            }
            else Console.WriteLine("Movie data unavailable.");
        }
    }
}
