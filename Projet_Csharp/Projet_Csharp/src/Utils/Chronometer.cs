using System;
using System.Diagnostics;

public class Chronometer
{
    private Stopwatch stopwatch;

    public Chronometer()
    {
        stopwatch = new Stopwatch();
    }

    public void Start()
    {
        stopwatch.Start();
    }

    public void Stop()
    {
        stopwatch.Stop();
    }

    public void Reset()
    {
        stopwatch.Reset();
    }

    public TimeSpan ElapsedTime()
    {
        return stopwatch.Elapsed;
    }

    public string ElapsedTimeFormatted()
    {
        return stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fff");
    }
}