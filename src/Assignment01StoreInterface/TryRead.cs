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
                    printTrack = false;
                }
            }
            catch
            {
                printTrack = false;
            }
            return printTrack;
        }
    }
}
