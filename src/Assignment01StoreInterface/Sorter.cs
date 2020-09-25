using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment01StoreInterface
{
    class Sorter
    {
        public static Album[] AlbumSortRating(List<Album> inputList)        // En Radix-sort speciellt byggd för att sortera objekt efter string-objekt av formatet "X:XX"
        {                                                                   // Där 'X' är siffror, och ':' ignoreras
            if (inputList != null)                                          // Om listan är null så returneras null direkt
            {
                Album[] outputList = new Album[inputList.Count];            // Skapar en array av samma storlek som listan som kommer in.
                int counter = 0;
                foreach (Album a in inputList)                              // Fyller arrayen med objekt från listan
                {
                    outputList[counter] = a;
                    counter++;
                }
                int[] bucket = new int[10];                                 // Skapar två int[]-arrayer för att lagra summor i.
                int[] tempBucket = new int[10];                             // Den första är för att räkna med, den andra är jag osäker på om den används...
                /*
                 * Radix sort gör så att den först går igenom den minst värdefulla positionen först, så om alla objekt har formatet ABCD så kollar den D först.
                 * Den räknar hur många av varje siffra som finns där (det fungerar även med andra baser än 10, men jag har bas 10, så siffror 0-9) och sparar det i arrayen.
                 * Sen skapar den en prefix-summa genom att ta arrayens värde i n+1 och lägga till n på den. Så om man har bas 4 (0-3) så har man en array som kan se ut
                 * {7, 3, 4, 4}. När man kalkylerar prefix summan tar man index 1 och lägger till index 0, så då har vi 3+=7; sen blir index 2 += index 1, och index 3 += index 2.
                 * Det ger oss ett prefix resultat av { 7, 10, 14, 18 }
                 * Sen går den igenom listan igen, och använder prefix-summan för att se var i output-listan den ska placera varje värde.
                 * När den först räknar går den vänster-till-höger, men när den kollar med prefix-summan (som representerar position i output-arrayen) så går den höger-till-vänster
                 * eller motsatt ordning.
                 * I vårat fall har vi en array med prefix-summan {7, 10, 14, 18}, som motsvarar siffrorna 0, 1, 2, 3. Så man går från höger, kollar vad relevanta siffran är.
                 * Säg att vi har 0123, då ser den trean. Prefix-summan på plats 3 är 18. Först subtraheras ett från den, sen placeras 0123 i output på plats motsvarande vad som
                 * nu är i arrayen, vilket är position 17 i output.
                 * Efter att man gått igenom alla objekt så ersätter man input listan med output listan och fortsätter tills man gått igenom alla positioner.
                 * 
                 * I mitt fall har jag tider i formatet "X,X", så först kollar jag decimalen, sen skippar kommat och kollar heltal istället.
                 * I andra sorteringsmetoden, den som används för filmer, så har jag strängar av formatet "YYYY-MM-DD". Loopen tar extra steg, och skippar bindessträcken
                 * men fungerar annars exakt likadant.
                 */
                for (int i = 2; i >= 0; i--)
                {
                    if (i != 1)
                    {

                        for (int n = 0; n < inputList.Count; n++)
                        {
                            bucket[Convert.ToInt32(inputList.ElementAt(n).AlbumRating().Substring((i), 1))] += 1;   // Kortfattat: öka värdet i bucket[j]
                        }                                                                                           // Där 'j' motsvarar siffran i relevanta positionen

                        for (int n = 0; n < 9; n++)                                                                 // Här fixar vi prefix-summan
                        {                                                                                           // bucket[1] += bucket[0], bucket[2] += bucket[1] osv.
                            bucket[n + 1] += bucket[n];
                        }

                        for (int n = (inputList.Count - 1); n >= 0; n--)                                            // Den här loopen tar prefix-summan, kollar värderna, och
                        {                                                                                           // kopierar från inputlistan till output listan
                            switch (Convert.ToInt32(inputList.ElementAt(n).AlbumRating().Substring(i, 1)))
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

                        inputList.Clear();                                                      // Tömmer input listan

                        for (int n = 0; n < outputList.Length; n++)                             // Och fyller den sedan med data från output som är lite mer sorterad.
                        {
                            inputList.Insert(n, outputList[n]);
                        }
                    }
                    else { }                                                                    // Om i = 1 ska inget göras

                    for (int n = 0; n < 10; n++)                                                // Loop som nollställer bucket[]
                    { bucket[n] = 0; }

                }

                outputList.Reverse();                                                           // Vänder på output-listan då min metod sorterar den i omvänd förväntad ordning.
                return outputList;                                                              // Och skickar sen tillbaka den.
            }
            else
            {
                return null;                                                                    // Om input är null så är den så sorterad som den kan vara och null skickas tillbaka.
            }
        }




        public static Movie[] MovieSort(List<Movie> inputList)                                  // Precis samma idé som AlbumSortRating(), fast fler tecken i strängen.s
        {
            if (inputList != null)
            {
                Movie[] outputList = new Movie[inputList.Count];
                int counter = 0;
                foreach (Movie a in inputList)
                {
                    outputList[counter] = a;
                    counter++;
                }
                int[] bucket = new int[10];

                for (int i = 9; i >= 0; i--)
                {
                    if ((i != 4) && (i != 7))
                    {
                        for (int n = 0; n < inputList.Count; n++)
                        {
                            bucket[Convert.ToInt32(inputList.ElementAt(n).Date().Substring((i), 1))] += 1;
                        }

                        for (int n = 0; n < 9; n++)
                        {
                            bucket[n + 1] += bucket[n];
                        }

                        for (int n = (inputList.Count - 1); n >= 0; n--)
                        {
                            switch (Convert.ToInt32(inputList.ElementAt(n).Date().Substring(i, 1)))
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
                    }
                    else { }

                    for (int n = 0; n < 10; n++)
                    { bucket[n] = 0; }

                }
                outputList.Reverse();

                return outputList;
            }
            else
            {
                return null;
            }
        }
    }
}
