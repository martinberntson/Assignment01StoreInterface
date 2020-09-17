using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.Xml;
using System.Xml.Linq;

namespace Assignment01StoreInterface
{
    class Program
    {

        string fakturaAdress = "Unreasonable Lane 991a";
        string besoksAdress = "Oddroad 13579";


        static void Main(string[] args)
        {
            string filePath = Directory.GetCurrentDirectory();
            Console.WriteLine(filePath);

            List<Album> albumList = AlbumReader.Read(filePath + "/AlbumData.xml");
            List<Movie> movieList = MovieReader.Read(filePath + "/MovieData.xml");



            Album[] sortedAlbumList;
            sortedAlbumList = Sorter.AlbumSort(albumList);

            Movie[] sortedMovieList;
            sortedMovieList = Sorter.MovieSort(movieList);


            Console.WriteLine("Would you like to print all albums' tracks? (y/n)");
            bool printTrack = TryRead.BoolRead();
            Printer.AlbumPrinter(sortedAlbumList, printTrack);
            Printer.MoviePrinter(sortedMovieList);

            


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
