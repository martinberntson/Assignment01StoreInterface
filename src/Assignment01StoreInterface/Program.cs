using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment01StoreInterface
{
    class Program
    {

        string fakturaAdress = "Unreasonable Lane 991a";
        string besoksAdress = "Oddroad 13579";


        static void Main(string[] args)
        {
            // Step the first; load the two .xml files containing all the album and movie data.
            // Todo: add a choice of either using premade data or generating data procedurally.
            List<Album> albumList = AlbumReader.Read(Directory.GetCurrentDirectory() + "/AlbumData.xml");
            List<Movie> movieList = MovieReader.Read(Directory.GetCurrentDirectory() + "/MovieData.xml");


            // Sort the album data by average user rating
            Album[] sortedAlbumList;
            sortedAlbumList = Sorter.AlbumSortRating(albumList);
            try
            {
                Array.Reverse(sortedAlbumList);
            }
            catch { }
            
            // Sort the movie data by release date
            Movie[] sortedMovieList;
            sortedMovieList = Sorter.MovieSort(movieList);
            try
            {
                Array.Reverse(sortedMovieList);
            }
            catch { }

            // Ask whether all album track titles should be printed as well since they take quite a lot of vertical space.
            // Will be obsolete once proper menus are added.
            Console.WriteLine("Would you like to print all albums' tracks? (y/n)");
            bool printTrack = TryRead.BoolRead();
            Printer.AlbumPrinter(sortedAlbumList, printTrack);
            Printer.MoviePrinter(sortedMovieList);


            /* UI Design:
             * 1. Welcome screen followed by a prompt to "press enter to continue" or somesuch. Name "Hans-Johnnys Butik", adress, stuff like that.
             * 2. Options menu; would you like to a) go with stored XML data or b) generate a dataset of user-defined size?
             * 3. Initialization, possibly with visualization of how objects are sorted.
             * 4. Store menu. Here you can make choices based on the assignment specifications. At some part of the screen, show the billing and shop adresses.
             *      a) Show a list of movie on the left, sorted by release date.
             *      b) Show a list of albums on the right, sorted by release date.
             *          Each movie and album has an associated number
             *      c) Print descriptive text telling the user what input the console is waiting for.
             *      d) Options at this screen should be "Pick a Movie" and "Pick an Album", and it takes inputs in the form of '1', '2', '3' and so on.
             *          If you pick an option, it wants you to then pick which item from the list to grab.
             *          If you pick a movie, it prints the Name, Director, Average User Rating, Release Date and Price of the movie
             *          If you pick an album, it prints the Name, Artist, Average User Rating, Release Date, Price and Track Count
             *              It then asks if you want a list of tracks in the album. If 'y', then print a list of Track Name : Runtime : Featured Artist
             *              
             *              
             * So I first want a menu choice that asks which list you want, albums, movies, adresses, or if you want to exit.
             *  Basically Console.WriteLine($"Please enter a number corresponding to this list: \r\n
             *                              1) Print Album List
             *                              2) Print Movie List
             *                              3) Print Store Information
             *                              4) Exit");
             * In the submenus for Albums/Movies, which are listed in the format of "n. albumTitle by albumArtist" or "n. movieTitle by movieDirector"
             *      the user is then promted to enter a number corresponding to the item in the list they want to view.
             *          When they choose an item the item's info gets printed on the screen in the format "albumTitle
             *                                                                                             by albumArtist
             *                                                                                             released on albumDate
             *                                                                                             Only albumPrice to buy today!"
             *                                                                                             Followed by a list of tracks contained in the album.
             *          And then they get the option to return to the list, put in an order or leave the shop.
             * 
             */
            


            /* So how to go about this the best way.
             * In order to sort the data, I'll need two sorting methods, AlbumSort() and MovieSort(), each sorting by release date.
             * I'll need some nifty way of storing all the data in memory, preferrably in an array, maybe in a list.
             * Step 1: Read data. Got this down.                                                                                                    DONE
             * Step 2: Isolate data into sets, save them as objects, and keep them grouped in a list/array. This needs work.                        DONE
             * Step 3: create one or more sorting algorithms that can sort the objects in the lists based on their release dates.                   1/? Radix done
             *          Note: Since both MovieData.xml and AlbumData.xml use the ReleaseDate attribute, a single method might cover both types?     YUP
             * Step 4: Create some UI that lets the user see all the data as presented.                                                             
             * Step 5: Going beyond what's needed, create a class with methods that generate movies and albums procedurally.                        
             * Step 6: If bubble and compare sorts are available, disable them for generated lists, since they'll run the risk of doing bad things. 
             * Step 7: Also disable listing the objects in cases where more than 1000 are made, since writing it all out takes.... Time.            
             * Step 8: ???
             * 
             */

        }

      


    }
}
