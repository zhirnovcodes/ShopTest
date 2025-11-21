using System;

public interface IPurchaseController
{
    public event Action<int> PurchaseComplete;
    public void Purchase(int index);
    public bool GetPurchaseIsInProgress();
    public bool CanPurchaseItem(int index);
}
