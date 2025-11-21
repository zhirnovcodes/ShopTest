public class LocationElementData : IPlayerElementData
{
    public Locations Location;

    public string GetName()
    {
        return "Location";
    }

    public string GetStringValue()
    {
        return Location.ToString();
    }

    public void TestAdd()
    {
        Location = Locations.Forest;
    }

}
