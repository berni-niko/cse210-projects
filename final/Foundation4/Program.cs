using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // List to hold different activities
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 3), 45, 15.0),
            new Swimming(new DateTime(2022, 11, 3), 60, 20)
        };

        // Iterate through each activity and print the summary
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
