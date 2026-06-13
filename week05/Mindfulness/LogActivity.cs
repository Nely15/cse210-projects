using System.IO;

public static class LogActivity
{

    public static int BreathingCount = 0;
    public static int ReflectionCount = 0;
    public static int ListingCount = 0;

    public static int BreathingSeconds = 0;
    public static int ReflectionSeconds = 0;
    public static int ListingSeconds = 0;

    public static void Save()
    {

        using (StreamWriter output = new StreamWriter("activitylog.txt"))
        {

            output.WriteLine(BreathingCount);
            output.WriteLine(BreathingSeconds);

            output.WriteLine(ReflectionCount);
            output.WriteLine(ReflectionSeconds);

            output.WriteLine(ListingCount);
            output.WriteLine(ListingSeconds);

        }

    }
    
    public static void Load()
    {

        if (!File.Exists("activitylog.txt"))
            return;

        string[] lines = File.ReadAllLines("activitylog.txt");

        if (lines.Length >= 6)
        {

            BreathingCount = int.Parse(lines[0]);
            BreathingSeconds = int.Parse(lines[1]);

            ReflectionCount = int.Parse(lines[2]);
            ReflectionSeconds = int.Parse(lines[3]);

            ListingCount = int.Parse(lines[4]);
            ListingSeconds = int.Parse(lines[5]);

        }   

    }

}