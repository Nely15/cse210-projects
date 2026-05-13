using System;

class Program
{
    static void Main(string[] args)
    {

        Job job1 = new Job();

        job1._jobTitle = "Game Designer";
        job1._company = "Nintendo";
        job1._startYear = 2005;
        job1._endYear = 2014;


        Job job2 = new Job();
        job2._jobTitle = "Field Service Engineer";
        job2._company = "Samsung";
        job2._startYear = 2015;
        job2._endYear = 2026;

        Resume myResume = new Resume();
        myResume._name = "Allison Rose";

        myResume._jobHistory.Add(job1);
        myResume._jobHistory.Add(job2);


        myResume.Display();

        Console.ReadLine();
    }
}