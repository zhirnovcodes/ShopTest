using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ChangeVIPShopAction", menuName = "Configs/Change VIP Action")]
public class ChangeVIPShopAction : ShopActionBase
{
    public Operation Operation;
    public int Minutes;
    public int Seconds;

    public override void Apply(IPlayerData data)
    {
        var vip = data.GetData<VIPElementData>();
        var newTime = GetAfterChangeSec(vip.TimeRemain);
        vip.TimeRemain = TimeSpan.FromSeconds( newTime );
    }

    public override bool CanApply(IPlayerData data)
    {
        var vip = data.GetData<VIPElementData>();
        var newTimeSec= GetAfterChangeSec(vip.TimeRemain);
        return newTimeSec >= 0;
    }

    private double GetAfterChangeSec(TimeSpan current)
    {
        var time = new TimeSpan(0, Minutes, Seconds);
        switch (Operation)
        {
            case Operation.Add:
                return current.TotalSeconds + time.TotalSeconds;
            case Operation.Remove:
                return current.TotalSeconds - time.TotalSeconds;
        }
        throw new NotImplementedException();
    }
}

public enum Operation
{
    Add,
    Remove
}