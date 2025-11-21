using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseController : MonoBehaviour, IPurchaseController
{
    public event Action<int> PurchaseComplete = (int index) => { };

    private ShopConfigModel Config;
    private IPlayerData Data;

    private bool IsRunningPurchases;

    public void Initialize(ShopConfigModel config, IPlayerData data)
    {
        Config = config;
        Data = data;
    }

    public bool GetPurchaseIsInProgress()
    {
        return IsRunningPurchases;
    }

    public void Purchase(int index)
    {
        StartCoroutine(PurchaseCoroutine(index));
    }

    public IEnumerator PurchaseCoroutine(int index)
    {
        IsRunningPurchases = true;

        yield return new WaitForSeconds(3);

        Config.BuyItem(index, Data);

        IsRunningPurchases = false;

        PurchaseComplete(index);
    }

    public bool CanPurchaseItem(int index)
    {
        return Config.CanBuyItem(index, Data);
    }
}
