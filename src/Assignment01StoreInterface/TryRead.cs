using System;

namespace Assignment01StoreInterface
{
    class TryRead
    {
        public static bool BoolRead()                           // Den här metoden har två referenser. De är båda i den här metoden.
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

        public static int MenuChoice()                           // Den här metoden har två referenser. De är båda i den här metoden.
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
        public static int Int()                                         // Den här metoden är menad att läsa input från användaren, och om det inte är ett heltal som
        {                                                               // får plats i en Int32 så säger den att något är fel och säger åt användaren att försöka igen.
            int i;                                                      // När väl användaren lyckas så kollapsar allt ihop och man är tillbaka i friheten.
            try
            {
                i = Convert.ToInt32(Console.ReadLine());
                if (i == 0)
                {
                    Console.WriteLine("Invalid input. Must be greater than 0. Try again.");
                    i = TryRead.Int();                                  // Kallar på sig själv ifall något är fel
                }
                return i;
                
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
                i = TryRead.Int();                                      // Kallar på sig själv ifall något är fel
            }

            return i;                                                   // Om allt funkar så skickas en integer tillbaka.
        }
    }
}
