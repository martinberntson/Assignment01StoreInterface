using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment01StoreInterface
{
    class Printer
    {
        public static void AlbumPrinter(Album[] input, bool track)
        {
            if (track)
            {
                string title;
                for (int n = 0; n < input.Length; n++)
                {
                    Console.WriteLine(input[n].AlbumTitle() + ", released on " + input[n].AlbumDate());
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
                    Console.WriteLine(input[n].AlbumTitle() + ", released on " + input[n].AlbumDate());
                    Console.WriteLine("  Performed by: " + input[n].AlbumArtist());
                }
            }
        }

        public static void MoviePrinter(Movie[] input)
        {
            for (int n = 0; n < input.Length; n++)
            {
                Console.WriteLine(input[n].MovieTitle() + ", released on " + input[n].MovieDate());
                Console.WriteLine("  Directed by: " + input[n].MovieDirector());
            }
        }
    }
}
