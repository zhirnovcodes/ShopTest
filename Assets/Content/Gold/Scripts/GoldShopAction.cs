using UnityEngine;

[CreateAssetMenu(fileName = "GoldShopAction", menuName = "Configs/GoldShopAction")]
public class GoldShopAction : ShopActionBase
{
    public int Value;

    public override void Apply(IPlayerData data)
    {
        var gold = data.GetData<GoldElementData>();
        gold.Value += Value;
    }

    public override bool CanApply(IPlayerData data)
    {
        var gold = data.GetData<GoldElementData>();
        return gold.Value + Value >= 0;
    }
}
