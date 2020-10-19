using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;


namespace Assignment01StoreInterface
{
    class AlbumReader
    {
        public static async void Read(string FilePath) // Async, så den kommer på egen tråd och kan köras parallelt med motsvarande MovieReader kod.
        {
            List<Album> albums = new List<Album>();
            List<string> trackTitles;
            List<string> trackRuntimes;
            List<string> trackFeatArtists;
            string albumTitle;
            string albumArtist;
            string albumDate;
            decimal albumAverageUserRating;
            short albumRuntime;
            byte albumPrice;
            short albumTrackCount;

            XmlDocument xDoc = new XmlDocument();

            try { xDoc.Load(FilePath); }
            catch (System.IO.FileNotFoundException) // Om filen inte hittas så genereras en lista på 25 objekt och skickas istället.
            {
                Console.WriteLine("AlbumData.xml was not found.\r\nGenerating new data...\r\nPress the any key (enter) to continue."); Console.Read();
                Task<List<Album>> task = AlbumReader.Generate(25);
                List<Album> generatedAlbums = await task;
                task.Wait();
                Program.SetAlbums(generatedAlbums);
                return;
            }

            XmlNodeList itemNodes = xDoc.SelectNodes("//Albums/Album"); // Pekar mot rätt objekttyp i XML-filen.

            foreach (XmlNode albumNode in itemNodes)                    // Går igenom alla album en efter en.
            {
                albumTitle = albumNode.Attributes["Title"].Value;
                albumArtist = albumNode.Attributes["Artist"].Value;
                albumDate = albumNode.Attributes["ReleaseDate"].Value;
                albumAverageUserRating = Convert.ToDecimal(albumNode.Attributes["AverageUserRating"].Value);
                albumRuntime = (short)Convert.ToInt32(albumNode.Attributes["Runtime"].Value);
                albumPrice = Convert.ToByte(albumNode.Attributes["Price"].Value);
                albumTrackCount = (short)Convert.ToInt32(albumNode.Attributes["Tracks"].Value);


                trackTitles = new List<string>();                       // Använder List<string> då det är okänt hur många objekt som ska läsas in.
                trackRuntimes = new List<string>();                     // Kommer konverteras till string[]-array format i konstruktorn.
                trackFeatArtists = new List<string>();                  // Featured Artist kan vara null

                foreach (XmlNode trackNode in albumNode.ChildNodes)     // Går igenom alla tracks i nuvarande album
                {
                    if (trackNode.Attributes.Count == 3)
                    {
                        trackTitles.Add(trackNode.Attributes["Title"].Value);
                        trackRuntimes.Add(trackNode.Attributes["Runtime"].Value);
                        trackFeatArtists.Add(trackNode.Attributes["FeatArtist"].Value);
                    }
                    else { }
                }
                Album newAlbum = new Album(trackTitles, trackRuntimes, 
                    trackFeatArtists, albumTitle, albumArtist, 
                    albumDate, albumAverageUserRating, albumRuntime, 
                    albumPrice, albumTrackCount);                       // Skickar in allt som lästs från XML in i Album-klassens konstruktor.
      
                albums.Add(newAlbum);                                   // Lägger till det nyskapade albumet i den List<Album> som ska skickas tillbaka.
            }
            Program.SetAlbums(albums);                                  // Använder metoden i Program som sätter den statiska listan albumList för användning i resten av programmet.
        }

        public static async Task<List<Album>> Generate(int numberToGenerate)        // Skapar ett antal Album-objekt motsvarande numberToGenerate
        {
            List<Album> albumList = new List<Album>();
            await Task.Run(() =>                                        // Jag... Är inte helt säker på hur async grejerna fungerar. 
            {                                                           // Det var mest att jag testade olika saker tills det fungerade.
                for (int i = numberToGenerate; i > 0; i--)              // Kör loopen ett antal gånger motsvarande numberToGenerate
                {                                                       // Generator-klassen har ett antal metoder för varje typ av data som ett Album-objekt behöver.
                    string s1 = Generator.AlbumTitle();
                    string s2 = Generator.Name();
                    string s3 = Generator.Date();
                    decimal d1 = Generator.Rating();
                    byte b2 = Generator.Price();
                    List<string> t1 = new List<string>();
                    List<string> t2 = new List<string>();
                    List<string> t3 = new List<string>();



                    Random rollTrackCount = new Random();               // Slumpar fram hur många tracks som ska existera i albumet.
                    int roll = rollTrackCount.Next(6);                  // Heltal fr.o.m. 1, t.o.m. 5
                    bool loop = true;

                    int trackCount = 5;
                    while (loop)
                    {
                        if (roll == 5)                                  // Hanterar det 
                        {
                            trackCount += (roll - 1);                   // Om den rullar en femma sätts inte loop till false, så den rullar igen.
                        }                                               // -1 är där då minsta som kan läggas in i nästa loop är 1, och den skulle annars skippa värden.
                        else
                        {
                            trackCount += roll;
                            loop = false;
                        }
                        roll = rollTrackCount.Next(6);                  // Chansen för högre och högre track counts sjunker drastiskt. 20% chans för en andra rullning
                    }                                                   // men bara runt 4% chans för en tredje. Sen 0.8% chans för fjärde, osv.

                    Random featArtistCheck = new Random();              // Dags att se om vi har en featured artist på spåret.
                    bool[] featArtistWeight = new bool[]
                    {
                    false, false, false, false, true
                    };                                                  // Genom att skapa denna array, och sen slumpa fram ett val ur den
                                                                        // Så har vi chansen att få en featured artist satt till 1/5, eller 20%.
                    for (int n = 0; n < trackCount; n++)
                    {
                        t1.Add(Generator.AlbumTitle());                 // Album och spår kör på samma generator för titlar.
                        t2.Add(Generator.TrackRuntime());               // Ger en string i formatet "X:XX" där X är siffror från 0-9, med vissa begränsningar.
                        bool check = featArtistWeight[(featArtistCheck.Next(1, 6) - 1)];    // Här gör vi faktiskt kollen om vi ska skapa en Featured Artist att slänga
                        if (check)                                      // Det är, som sagt, 20% chans för att check tilldelats true
                        {
                            t3.Add(Generator.Name());
                        }
                        else                                            // Och om ingen featured artist skapats så tilldelas en tom string för att undvika null exception.
                        {
                            t3.Add("");
                        }
                    }
                    int runtimeSum = 0;                                 // Dags att börja räkna på runtime för albumet.
                    foreach (string s in t2)                            // Summerar varje spårs runtime (i sekunder) för att sen konvertera till minuter för albumet
                    {
                        runtimeSum += (Convert.ToInt32(s.Substring(0, 1)) * 60 + Convert.ToInt32(s.Substring(2, 2)));
                    }
                    byte b1 = (byte)(runtimeSum / 60);                  // Och här är albumets runtime.
                    short sh1 = (short)t1.Count;                        // Samt antalet tracks för albumet.


                    albumList.Add(new Album(t1, t2, t3, s1, s2, s3, d1, b1, b2, sh1)); // Skicka in allt i konstruktorn, lägg till på listan.
                }
            });
            return albumList;                                           // Och när vi loopat igenom alla gångerna så skickas den tillbaka, klart.

        }
    }
}
