using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Assignment01StoreInterface
{
    class Sorter
    {
        // Add two methods here - one to sort albums, and one to sort movies

        public static Album[] AlbumSort(List<Album> inputList)
        {
            Album[] outputList = new Album[inputList.Count];
            int counter = 0;
            foreach (Album a in inputList)
            { 
                outputList[counter] = a;
                counter++;
            }
            int[] bucket = new int[10];
            int[] tempBucket = new int[10];

            for (int i = 9; i >= 0; i--)
            {
                if ((i != 4) && (i != 7))
                {
                    // Outer loop, run once for each integer in a date of format YYYY-MM-
                    for (int n = 0; n < inputList.Count; n++)
                    {
                        bucket[Convert.ToInt32(inputList.ElementAt(n).AlbumDate().Substring((i), 1))] += 1;
                    }
                    // Console.WriteLine($"The raw data is        {bucket[0]}, {bucket[1]}, {bucket[2]}, {bucket[3]}, {bucket[4]}, {bucket[5]}, {bucket[6]}, {bucket[7]}, {bucket[8]}, {bucket[9]}, ");


                    tempBucket = bucket;
                    for (int n = 0; n < 9; n++)  // Calculate prefix sums
                    {
                        bucket[n + 1] += bucket[n];
                    }

                    // Console.WriteLine($"The modified bucket is {bucket[0]}, {bucket[1]}, {bucket[2]}, {bucket[3]}, {bucket[4]}, {bucket[5]}, {bucket[6]}, {bucket[7]}, {bucket[8]}, {bucket[9]}, ");

                    
                    for (int n = (inputList.Count -1); n >= 0; n--)
                    {
                        switch (Convert.ToInt32(inputList.ElementAt(n).AlbumDate().Substring(i, 1)))
                        {
                            case 0:
                                bucket[0] -= 1;
                                outputList[bucket[0]] = inputList.ElementAt(n);
                                break;
                            case 1:
                                bucket[1] -= 1;
                                outputList[bucket[1]] = inputList.ElementAt(n);
                                break;
                            case 2:
                                bucket[2] -= 1;
                                outputList[bucket[2]] = inputList.ElementAt(n);
                                break;
                            case 3:
                                bucket[3] -= 1;
                                outputList[bucket[3]] = inputList.ElementAt(n);
                                break;
                            case 4:
                                bucket[4] -= 1;
                                outputList[bucket[4]] = inputList.ElementAt(n);
                                break;
                            case 5:
                                bucket[5] -= 1;
                                outputList[bucket[5]] = inputList.ElementAt(n);
                                break;
                            case 6:
                                bucket[6] -= 1;
                                outputList[bucket[6]] = inputList.ElementAt(n);
                                break;
                            case 7:
                                bucket[7] -= 1;
                                outputList[bucket[7]] = inputList.ElementAt(n);
                                break;
                            case 8:
                                bucket[8] -= 1;
                                outputList[bucket[8]] = inputList.ElementAt(n);
                                break;
                            case 9:
                                bucket[9] -= 1;
                                outputList[bucket[9]] = inputList.ElementAt(n);
                                break;
                            default:
                                break;
                        }
                    }

                    inputList.Clear();

                    for (int n = 0; n < outputList.Length; n++)
                    {
                        inputList.Insert(n, outputList[n]);
                    }
                    // Console.WriteLine("Sorted by number " + i);
                }
                else { }

                

                // reset bucket after sort
                for (int n = 0; n < 10; n++)
                { bucket[n] = 0; }
                tempBucket = bucket;

            }
            Console.WriteLine("Albums sorted.");
            outputList.Reverse();
            return outputList;
        }

        public static Movie[] MovieSort(List<Movie> inputList)
        {
            Movie[] outputList = new Movie[inputList.Count];
            int counter = 0;
            foreach (Movie a in inputList)
            {
                outputList[counter] = a;
                counter++;
            }
            int[] bucket = new int[10];
            int[] tempBucket = new int[10];

            for (int i = 9; i >= 0; i--)
            {
                if ((i != 4) && (i != 7))
                {
                    // Outer loop, run once for each integer in a date of format YYYY-MM-
                    for (int n = 0; n < inputList.Count; n++)
                    {
                        bucket[Convert.ToInt32(inputList.ElementAt(n).MovieDate().Substring((i), 1))] += 1;
                    }
                    // Console.WriteLine($"The raw data is        {bucket[0]}, {bucket[1]}, {bucket[2]}, {bucket[3]}, {bucket[4]}, {bucket[5]}, {bucket[6]}, {bucket[7]}, {bucket[8]}, {bucket[9]}, ");


                    tempBucket = bucket;
                    for (int n = 0; n < 9; n++)  // Calculate prefix sums
                    {
                        bucket[n + 1] += bucket[n];
                    }

                    // Console.WriteLine($"The modified bucket is {bucket[0]}, {bucket[1]}, {bucket[2]}, {bucket[3]}, {bucket[4]}, {bucket[5]}, {bucket[6]}, {bucket[7]}, {bucket[8]}, {bucket[9]}, ");


                    for (int n = (inputList.Count - 1); n >= 0; n--)
                    {
                        switch (Convert.ToInt32(inputList.ElementAt(n).MovieDate().Substring(i, 1)))
                        {
                            case 0:
                                bucket[0] -= 1;
                                outputList[bucket[0]] = inputList.ElementAt(n);
                                break;
                            case 1:
                                bucket[1] -= 1;
                                outputList[bucket[1]] = inputList.ElementAt(n);
                                break;
                            case 2:
                                bucket[2] -= 1;
                                outputList[bucket[2]] = inputList.ElementAt(n);
                                break;
                            case 3:
                                bucket[3] -= 1;
                                outputList[bucket[3]] = inputList.ElementAt(n);
                                break;
                            case 4:
                                bucket[4] -= 1;
                                outputList[bucket[4]] = inputList.ElementAt(n);
                                break;
                            case 5:
                                bucket[5] -= 1;
                                outputList[bucket[5]] = inputList.ElementAt(n);
                                break;
                            case 6:
                                bucket[6] -= 1;
                                outputList[bucket[6]] = inputList.ElementAt(n);
                                break;
                            case 7:
                                bucket[7] -= 1;
                                outputList[bucket[7]] = inputList.ElementAt(n);
                                break;
                            case 8:
                                bucket[8] -= 1;
                                outputList[bucket[8]] = inputList.ElementAt(n);
                                break;
                            case 9:
                                bucket[9] -= 1;
                                outputList[bucket[9]] = inputList.ElementAt(n);
                                break;
                            default:
                                break;
                        }
                    }

                    inputList.Clear();

                    for (int n = 0; n < outputList.Length; n++)
                    {
                        inputList.Insert(n, outputList[n]);
                    }
                    // Console.WriteLine("Sorted by number " + i);
                }
                else { }



                // reset bucket after sort
                for (int n = 0; n < 10; n++)
                { bucket[n] = 0; }
                tempBucket = bucket;

            }
            outputList.Reverse();
            Console.WriteLine("Movies sorted.");
            return outputList;
        }


    }
}
