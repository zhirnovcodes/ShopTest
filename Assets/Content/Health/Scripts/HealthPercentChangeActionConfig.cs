using UnityEngine;

[CreateAssetMenu(fileName = "HealthChangePercentAction", menuName = "Configs/Health Change Percent Action")]
public class HealthPercentChangeActionConfig : ShopActionBase
{
    [Range(0,100)] public float PercentValue;

    public override void Apply(IPlayerData data)
    {
        var health = data.GetData<HealthElementData>();
        health.Value = (int)(health.Value * PercentValue / 100);
    }

    public override bool CanApply(IPlayerData data)
    {
        return true;
    }
}
