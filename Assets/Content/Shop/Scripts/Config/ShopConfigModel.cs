public class ShopConfigModel
{
    private ShopConfig Config;

    public ShopConfigModel(ShopConfig config)
    {
        Config = config;
    }

    public int GetItemsCount()
    {
        return Config.Bundles.Length;
    }

    public string GetItemName(int index)
    {
        return Config.Bundles[index].Name;
    }

    public bool CanBuyItem(int index, IPlayerData data)
    {
        var result = false;

        foreach (var action in Config.Bundles[index].Actions)
        {
            result = result & action.CanApply(data);
        }

        return result;
    }

    public void BuyItem(int index, IPlayerData data)
    {
        foreach (var action in Config.Bundles[index].Actions)
        {
            action.Apply(data);
        }
    }
}