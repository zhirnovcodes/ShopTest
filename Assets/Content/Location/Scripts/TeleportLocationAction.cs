using UnityEngine;

[CreateAssetMenu(fileName = "TeleportLocationAction", menuName = "Configs/Teleport Location")]
public class TeleportLocationAction : ShopActionBase
{
    public Locations To;

    public override void Apply(IPlayerData data)
    {
        var loc = data.GetData<LocationElementData>();
        loc.Location = To;
    }

    public override bool CanApply(IPlayerData data)
    {
        var loc = data.GetData<LocationElementData>();
        return loc.Location != To;
    }
}
