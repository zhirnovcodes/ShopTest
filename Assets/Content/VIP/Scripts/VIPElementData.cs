using System;

public class VIPElementData : IPlayerElementData
{
    public TimeSpan TimeRemain;

    public string GetName()
    {
        return "VIP";
    }

    public string GetStringValue()
    {
        return TimeRemain.TotalSeconds.ToString() + " sec"; 
    }

    public void TestAdd()
    {
        TimeRemain = TimeRemain.Add(TimeSpan.FromMinutes(1));
    }
}