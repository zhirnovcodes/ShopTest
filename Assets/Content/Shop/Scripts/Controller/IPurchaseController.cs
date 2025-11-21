using System;

public interface IPurchaseController
{
    public event Action<int> PurchaseComplete;
    public void Purchase(int index);
    public bool GetPurchaseIsInProgress(int index);
    public bool CanPurchaseItem(int index);
}
