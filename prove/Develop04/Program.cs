using System;
using System.Collections.Generic;
using System.Threading;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activities");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an activity: ");
            string choice = Console.ReadLine();
            if (choice == "4") break;
            Activity activity = null;
            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity(); // Creates a BreathingActivity object
                    break;
                case "2":
                    activity = new ReflectingActivity(); // Creates a ReflectingActivity object
                    break;
                case "3":
                    activity = new ListingActivity(); // Creates a ListingActivity object
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    Thread.Sleep(1000);
                    continue;
            }
            activity.Run(); // Calls the Run method of the selected activity
        }
    }
}