using System;

public interface IPlayerData
{
    T GetData<T>() where T : IPlayerElementData, new();
    void Update();
}

public interface IPlayerDataObserver
{
    event Action DataChanged;
}

