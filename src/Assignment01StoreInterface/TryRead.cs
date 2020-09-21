using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Text;

namespace Assignment01StoreInterface
{
    class TryRead
    {
        public static bool BoolRead()
        {
            bool printTracks;
            try
            {
                char input = Convert.ToChar(Console.ReadLine());
                if (input == 'y')
                {
                    printTracks = true;
                }
                else if (input == 'n')
                {
                    printTracks = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input. Try again.");
                    printTracks = BoolRead();
                }
            }
            catch
            {
                Console.WriteLine("Invalid Input. Try again.");
                printTracks = BoolRead();
            }
            return printTracks;
        }

        public static int MenuChoice()
        {
            int i;
            try
            {
                i = Convert.ToInt32(Console.ReadLine());
                if ((i <= 3) && (i >= 1))
                {
                    return i;
                }
                else
                {
                    Console.WriteLine("Invalid Input. Try again.");
                    i = MenuChoice();
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
                i = MenuChoice();
            }

            return i;
        }
    }
}
