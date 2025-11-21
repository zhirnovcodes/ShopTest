using UnityEngine;

[CreateAssetMenu(fileName = "HealthRemoveItem", menuName = "Configs/Health Remove Item")]
public class HealthRemoveActionConfig : ShopActionBase
{
    public int Value;

    public override void Apply(IPlayerData data)
    {
        var health = data.GetData<HealthElementData>();
        health.Value -= Value;
    }

    public override bool CanApply(IPlayerData data)
    {
        var health = data.GetData<HealthElementData>();
        return health.Value >= Value;
    }
}
