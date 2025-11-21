using System;
using System.Collections.Generic;

public interface IPlayerData
{
    T GetData<T>() where T : IPlayerElementData, new();
    void Update();
}


public interface IPlayerAllData
{
    IEnumerable<IPlayerElementData> GetAllData();
}

public interface IPlayerDataObserver
{
    event Action DataChanged;
}

