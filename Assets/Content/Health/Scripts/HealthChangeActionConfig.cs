using UnityEngine;

[CreateAssetMenu(fileName = "HealthChangeAction", menuName = "Configs/Health Change Action")]
public class HealthChangeActionConfig : ShopActionBase
{
    public int Value;

    public override void Apply(IPlayerData data)
    {
        var health = data.GetData<HealthElementData>();
        health.Value += Value;
    }

    public override bool CanApply(IPlayerData data)
    {
        var health = data.GetData<HealthElementData>();
        return health.Value + Value >= 0;
    }
}
