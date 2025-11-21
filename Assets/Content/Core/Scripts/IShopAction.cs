public interface IShopAction
{
    bool CanApply(IPlayerData data);
    void Apply(IPlayerData data);
}
