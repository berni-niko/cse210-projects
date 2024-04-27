using System;
using System.Collections.Generic;

public class Resume
{
    public string _name { get; set; }
    public List<Job> Jobs { get; set; } = new List<Job>();

    public Resume(string name)
    {
        _name = name;
    }

    public void AddJob(Job job)
    {
        Jobs.Add(job);
    }

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in Jobs)
        {
            job.Display();
        }
    }
}
