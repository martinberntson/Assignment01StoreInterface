using System;

public class Film
{

    private string name;
    private string creator;
    private double averageUserRating;
    private string releaseDate;
    private int runtime;
    private double price;


    public Film(string Name, string Creator, double AverageUserRating, string ReleaseDate, int Runtime, double Price)
    {
        name = Name;
        creator = Creator;
        averageUserRating = AverageUserRating;
        releaseDate = ReleaseDate;
        runtime = Runtime;
        price = Price;
    }

    public void PrintAll()
    {
        Console.WriteLine($"The movie's name is {name}, it was directed by {creator}," +
            $" it has an average user rating of {averageUserRating}, it was released on {releaseDate}, " +
            $"has a runtime of {runtime} and costs {price}:-");
    }
    


        //För filmer: Namn, Regissör, Snittbetyg från användare(0 - 10), Releasedatum, Speltid(i minuter och timmar), Pris.
        //För musikalbum: Namn, Artist, Snittbetyg från användare(0 - 10), Releasedatum, Speltid(i minuter och timmar), Antal låtar, Pris.
}

