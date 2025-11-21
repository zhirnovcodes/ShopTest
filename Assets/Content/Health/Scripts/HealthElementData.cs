public class HealthElementData : IPlayerElementData
{
    public int Value = 10;

    public string GetName()
    {
        return "Health";
    }

    public string GetStringValue()
    {
        return Value.ToString();
    }

    public void TestAdd()
    {
        Value++;
    }
}