using System;
using System.ComponentModel.DataAnnotations;

public class Job
{
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_jobTitle}) {_startYear}-{_endYear}");
    }
}