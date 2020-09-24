using System;

namespace Assignment01StoreInterface
{
    class Generator
    {
        private static string[] internals = new string[] { "up", "a", "an", "without", "nor", "but", "yet", "so", "with",
            "at", "around", "by", "after", "along", "for", "from", "of", "to", "of the", "in", "on", "the", };
        private static string[] movieTitleWords = new string[] { "Empire", "Half", "Show", "Basic", "Poetic", "Kids", "Dead", "The", "Pump", "Man",
            "Fear", "Life", "Space", "Happy", "Never", "Boy", "Ten", "Nine", "Twelve", "Mortal",
            "Sister", "City", "Birdcage", "Raise", "Lantern", "House", "Party", "Rumble", "Bronx", "Army",
            "Darkness", "Element", "Sleepless", "Wedding", "Funeral", "Men", "Women", "White", "Black", "Gray",
            "Red", "Blue", "Green", "Yellow", "Purple", "Diamond", "Gold", "Silver", "Platinum", "Steel",
            "Stone", "Plastic", "Good", "Austin", "Powers", "International", "Mystery", "Murder", "Romance", "Comedy",
            "Action", "Farce", "Demolition", "Crow", "Thin", "Line", "Run", "History", "Documentary", "King",
            "Queen", "Prince", "Dusk", "Dawn", "Midday", "Midnight", "Lunch", "Breakfast", "Dinner", "Nightmare",
            "Dream", "Christmas", "Hanukka", "New Year's", "Midsummer", "Winter", "Solstice", "Pi", "Lock", "Stock",
            "Smoking", "Barrel", "World", "Moon", "Sun", "Dollhouse", "Welcome", "Farewell", "Dazed", "Confused",
            "Piano", "Color", "Colors", "Something", "About", "Brave", "Cowardly", "Coward", "Unfazed", "Sight",
            "Blind", "Touch",  "Scent", "Over", "Under", "Inside", "Outside",
            "Oracle", "Pantheon", "Culture", "Science", "Dog", "Dogs", "Cat", "Cats", "Bird", "Prey",
            "Predator", "Hunter", "Hunted", "Horror", "Thriller", "Thunder", "Everybody", "Nobody", "Jump", "Fall",
            "Leap", "Sprint", "Danger", "Safety", "Safe", "Sage", "Prophet", "Philosopher", "Wonder", "World",
            "Moon", "Mars", "Martian", "Invasion", "Assault", "Battery", "Satellite", "Dish", "Food", "Thought",
            "Spaghetti", "Pizza", "Vegan", "Apple", "Pear", "Lemon", "Orange", "Typical", "Unliving", "Eternal",
            "Ephemeral", "Void", "Blank", "Toward", "Sing", "Silence", "Stars", "Star", "Starring", "Ground" };
        private static string[] albumWords = new string[]
        {
            "Stone","Rock","Metal","Hard","Leather","Scent","Sweat","Tears","Blood","Demon",
            "Life","Love","Live","Pop","Blues","Country","Road","Hurt","Find","Fear",
            "Legend","Myth","Master","Monster","Thriller","Dark","Side","Moon","Bat","Out",
            "Hell","Number","Ones","We","Champion","What","Morning","Noon","Midnight","Afternoon",
            "Lunch","Dinner","Egg","Sandwich","Bacon","Butter","Curtain","Call","Sound","Music",
            "Definitely","Maybe","Greatest","Hits","Very","Best","Mac","Time","Flies","AM",
            "PM","Immaculate","Collection","Nevermind","South","Pacific","Atlantic","Oceanic","Indian","Ocean",
            "Lonely","Ultimate","Riff","Hour","Minute","Second","Seconds","Minutes","Face","Value",
            "Whatever","People","Say","That","Way","I","Want","Tubular","Bell","Bells",
            "Toll","Tolling","Appetite","Destruction","Creation","Subjection","Transmission","Space","Oddity","Ood",
            "Stardust","Space","Man","Woman","Child","Boy","Girl","Plastic","Solid","Liquid",
            "Solidus","Steel","Heavy","Light","Berlin","Stockholm","Tour","Tear","Amber","Aqua",
            "Aven","Babylon","Crime","Fighter","Danger","Zone","Ether","Everlasting","Four","Grand",
            "Golem","Garden","Gin","Harp","Halo","Horizon","Hand","Interject","Internet","Impossible",
            "Imperative","Job","Joker","Jar","Kill","Kind","Kindling","Lard","Living","Leftover",
            "Left","My","Move","Made","Master","Mister","Monday","Nothing","Nimble","Nutcase",
            "Overflow","Over","Open","Ochre","Product","Prime","Pincers","Powerful","Quirk","Quick",
            "Quandary","Quiet","Race","Role","Riveting","Ranger","Robot","Super","Sonic","Summer",
            "Singe","Tremble","Treble","Time","Tower","Town","Tender","Under","Unlike","Until",
            "Vibrant","Variant","Vector","Vile","Vindicate","Wander","Winter","Wonderland","Will","Wake",
            "Xylophone","Year","Yearn","Yard","Zero","Zen"};

        private static string[] FirstNames = new string[] {
            "James", "John", "Michael", "William", "David", "Richard", "Joseph", "Thomas", "Charles", "Robert",
            "Mary", "Patricia", "Jennifer", "Linda", "Elizabeth", "Barbara", "Susan", "Jessica", "Sarah", "Karen",
            "Christopher", "Daniel", "Matthew", "Anthony", "DonaldDuck", "Mark", "Paul", "Steven", "Andrew", "Kenneth",
            "Nancy", "Lisa", "Margaret", "Betty", "Sandra", "Ashley", "Dorothy", "Kimberly", "Emily", "Donna",
            "Kenneth", "Joshua", "Kevin", "Brian", "George", "Edward", "Ronald", "Timothy", "Jason", "Jeffrey",
            "Michelle", "Carol", "Amanda", "Melissa", "Deborah", "Stephanie", "Rebecca", "Laura", "Sharon", "Cynthia",
            "Mohammed", "Ahmed", "Beshoi", "Kirollos", "Habib", "Fatima", "Meriem", "Nadia", "Omar", "Aya",
            "Alya", "Santiago", "Juan", "Mateo", "Pedro", "Santino", "Dylan", "Kevin", "José", "Noah",
            "Liam", "Alexis", "Alexandra", "Luis", "Joaquín", "Gabriella", "Sofía", "Lucía", "Emilia", "Olivia",
            "Alice", "Mariana", "Cheng", "Liang", "Ning", "Lian", "Shu", "Xian", "Yun", "Kim",
            "Sô", "Minato", "Itsuki", "Asahi", "Sakura", "Aoi", "Rin", "Kaede", "Min-Jun", "Seo-yeon" };

        private static string[] FamilyNames = new string[] {
            "Ali", "Mohamed", "Johannes", "Ndong", "Ivanova", "Wang", "Satô", "Kim", "Chen", "De La Cruz",
            "Devi", "Jónsdóttir", "Hansen", "Andersson", "Korhonen", "Jensen", "De Jong", "Martin", "Müller", "Smith",
            "Murphy", "Peeters", "Schmit", "Garcia", "Silva", "Rossi", "Borg", "Papadopoulus", "Popa", "Nowak",
            "Gruber", "Melnik", "Hernandez", "Lopez", "Rodriguez", "Williams", "Harris", "John", "Devi", "Zhang",
            "Johnson", "Brown", "Jones", "Miller", "Davis", "Wilson", "Taylor"};
        public static string MovieTitle()
        {
            string s;
            Random roll = new Random();
            int rollValue = roll.Next(1, 9);
            int[] weight = new int[] { 1, 2, 2, 2, 2, 3, 3, 3, 3 };
            int wordcount = weight[rollValue - 1];

            switch (wordcount)
            {
                case 1:
                    s = movieTitleWords[roll.Next(0, (movieTitleWords.Length - 1))];
                    break;
                case 2:
                    s = (movieTitleWords[roll.Next(0, (movieTitleWords.Length - 1))] + " " + movieTitleWords[roll.Next(0, (movieTitleWords.Length - 1))]);
                    break;
                case 3:
                    s = (movieTitleWords[roll.Next(0, (movieTitleWords.Length - 1))] + " " + internals[roll.Next(0, (internals.Length - 1))]  + " " + movieTitleWords[roll.Next(0, (movieTitleWords.Length - 1))]);
                    break;
                default:
                    s = "";
                    break;
            }

            return s;
        }

        public static string AlbumTitle() // Används för både album och tracks.
        {
            string s;
            Random roll = new Random();
            int rollValue = roll.Next(1, 12);
            int[] weight = new int[] { 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 5 };
            int wordcount = weight[rollValue - 1];

            switch (wordcount)
            {
                case 1:
                    s = albumWords[roll.Next(0, (albumWords.Length - 1))];
                    break;
                case 2:
                    s = (albumWords[roll.Next(0, (albumWords.Length - 1))] + " " + albumWords[roll.Next(0, (albumWords.Length - 1))]);
                    break;
                case 3:
                    s = (albumWords[roll.Next(0, (albumWords.Length - 1))] + " " + internals[roll.Next(0, (internals.Length - 1))] + " " + albumWords[roll.Next(0, (albumWords.Length - 1))]);
                    break;
                case 4:
                    if (roll.Next(0,1) == 0)
                        s = (albumWords[roll.Next(0, (albumWords.Length - 1))] + " " + albumWords[roll.Next(0, (albumWords.Length - 1))] + " " + internals[roll.Next(0, (internals.Length - 1))] + " " + albumWords[roll.Next(0, (albumWords.Length - 1))]);
                    else
                        s = (albumWords[roll.Next(0, (albumWords.Length - 1))] + " " + internals[roll.Next(0, (internals.Length - 1))] + " " + albumWords[roll.Next(0, (albumWords.Length - 1))] + " " + albumWords[roll.Next(0, (albumWords.Length - 1))]);
                    break;
                case 5:
                    s = (albumWords[roll.Next(0, (albumWords.Length - 1))] + " " + albumWords[roll.Next(0, (albumWords.Length - 1))] + " " + internals[roll.Next(0, (internals.Length - 1))] + " " + albumWords[roll.Next(0, (albumWords.Length - 1))] + " " + albumWords[roll.Next(0, (albumWords.Length - 1))]);
                    break;
                default:
                    s = "";
                    break;
            }

            return s;
        }

        public static string Name()
        {
            string s = "";
            Random roll = new Random();
            s = (FirstNames[roll.Next(0, (FirstNames.Length - 1))] + " " + FamilyNames[roll.Next(0, (FamilyNames.Length - 1))]);
            return s;
        }

        public static string Date()
        {
            Random roll = new Random();
            string s = (Convert.ToString(roll.Next(1920, 2020)) + "-0" + Convert.ToString(roll.Next(1, 9)) + "-" + Convert.ToString(roll.Next(0,2)) + Convert.ToString(roll.Next(1, 9)));
            return s;
        }

        public static decimal Rating()
        {
            Random roll = new Random();
            double d = roll.NextDouble();
            decimal d1 = Convert.ToDecimal(d*roll.Next(1,10));
            d1 = Math.Round(d1, 1);
            return d1;
        }

        public static byte MovieRuntime()
        {
            Random roll = new Random();
            byte b = (byte)roll.Next(55, 255);
            return b;
        }

        public static byte Price()
        {
            Random roll = new Random();
            int rollValue = roll.Next(1, 12);
            int[] weight = new int[] { 49, 59, 79, 99, 129, 139, 139, 149, 149, 159, 199, 249 };
            byte b = (byte)weight[rollValue - 1];
            return b;
        }

        public static string TrackRuntime()
        {
            string s;
            Random roll = new Random();
            s = Convert.ToString(roll.Next(1, 9) + ":" + Convert.ToString(roll.Next(1, 9)) + Convert.ToString(roll.Next(1, 9)));
            return s;
        }
    }
}
