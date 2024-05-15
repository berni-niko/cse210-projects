using System;
using System.Linq.Expressions;
using AssignmentApp.Assignment;

class Program
{
    static void Main(string[] args)
    {
        
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");

        Console.WriteLine(writingAssignment.GetSummary());

        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}