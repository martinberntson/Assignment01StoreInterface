using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment01StoreInterface
{
    class TryRead
    {
        public static bool BoolRead()
        {
            bool printTrack;
            try
            {
                if (Convert.ToChar(Console.ReadLine()) == 'y')
                {
                    printTrack = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input. Try again.");
                    printTrack = BoolRead();
                }
            }
            catch
            {
                Console.WriteLine("Invalid Input. Try again.");
                printTrack = BoolRead();
            }
            return printTrack;
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
