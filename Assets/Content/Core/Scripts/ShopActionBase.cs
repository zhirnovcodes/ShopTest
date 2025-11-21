using UnityEngine;

public abstract class ShopActionBase : ScriptableObject, IShopAction
{
    public abstract void Apply(IPlayerData data);
    public abstract bool CanApply(IPlayerData data);
}
