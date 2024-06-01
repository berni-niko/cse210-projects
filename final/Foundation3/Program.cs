class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Elm St", "New York City", "NY", "USA");
        Address address2 = new Address("123 Elm St", "New York City", "NY", "USA");
        Address address3 = new Address("246 Oak Circle", "London", "England", "UK");

        Event lecture = new Lecture("Object Oriented Programming", "inheritance", new DateTime(2023, 1, 1, 9, 0, 0), new TimeSpan(9, 0, 0), address1, "Bob the Builder", 100);
        Event reception = new Reception("Graduation", "MSD 321 Graduation Party", new DateTime(2023, 6, 1, 19, 0, 0), new TimeSpan(19, 0, 0), address2, "grad@msd321.com");
        Event outdoorGathering = new OutdoorGathering("Bridge Tour", "Tour the London Bridge", new DateTime(2023, 8, 15, 12, 0, 0), new TimeSpan(12, 0, 0), address3, "Chance of Rain");

        PrintEventDetails(lecture);
        Console.WriteLine("==============================");
        PrintEventDetails(reception);
        Console.WriteLine("==============================");
        PrintEventDetails(outdoorGathering);
    }

    static void PrintEventDetails(Event ev)
    {
        Console.WriteLine(ev.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(ev.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(ev.GetShortDescription());
        Console.WriteLine();
    }
}
