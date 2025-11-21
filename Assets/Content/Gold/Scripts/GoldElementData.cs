public class GoldElementData : IPlayerElementData
{
    public int Value;

    public string GetName()
    {
        return "Gold";
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