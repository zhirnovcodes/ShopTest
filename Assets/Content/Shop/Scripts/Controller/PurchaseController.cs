using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseController : MonoBehaviour, IPurchaseController
{
    public event Action<int> PurchaseComplete = (int index) => { };

    private ShopConfigModel Config;
    private IPlayerData Data;

    private HashSet<int> RunningPurchases = new HashSet<int>();

    public void Initialize(ShopConfigModel config, IPlayerData data)
    {
        Config = config;
        Data = data;
    }

    public bool GetPurchaseIsInProgress(int index)
    {
        return RunningPurchases.Contains(index);
    }

    public void Purchase(int index)
    {
        StartCoroutine(PurchaseCoroutine(index));
    }

    public IEnumerator PurchaseCoroutine(int index)
    {
        RunningPurchases.Add(index);

        yield return new WaitForSeconds(3);

        Config.BuyItem(index, Data);

        RunningPurchases.Remove(index);

        PurchaseComplete(index);
    }

    public bool CanPurchaseItem(int index)
    {
        return Config.CanBuyItem(index, Data);
    }
}
