using System;
using System.Collections.Generic;

public class PlayerData : IPlayerData, IPlayerDataEnumerator, IPlayerDataChangeHandler
{
    private Dictionary<Type, object> Data = new Dictionary<Type, object>();

    public event Action DataChanged = () => { };

    public IEnumerable<IPlayerElementData> GetAllData()
    {
        foreach (var data in Data.Values)
        {
            yield return (IPlayerElementData)data;
        }
    }

    public T GetData<T>() where T : IPlayerElementData, new()
    {
        Type type = typeof(T);

        if (Data.ContainsKey(type) == false)
        {
            Data[type] = new T();
        }

        return (T)Data[type];
    }

    public void Load()
    {
        // loads Data from JSON
    }

    public void Update()
    {
        DataChanged();
    }
}

