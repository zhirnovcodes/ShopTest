public interface IPlayerData
{
    T GetData<T>() where T : IPlayerElementData, new();
    void Update();
}

