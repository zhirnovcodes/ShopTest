using System.Collections.Generic;

public interface IPlayerData
{
    T GetData<T>() where T : IPlayerElementData, new();
}


public interface IPlayerAllData
{
    IEnumerator<IPlayerElementData> GetAllData();
}

