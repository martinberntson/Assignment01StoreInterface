using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment01StoreInterface
{
    class Menu
    {
        public void CallMenu(bool running)
        {
            while (running)
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: // Call Movie Printer
                        break;
                    case 2: // Call Album Printer
                        break;
                    case 3:
                        running = false;
                        break;

                }
            }
        }
    }
}
