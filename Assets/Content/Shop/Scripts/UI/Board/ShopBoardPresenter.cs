using System;

public class ShopBoardPresenter : IDisposable
{
    public event Action<int> InfoButtonClicked = (int index) => { };

    private ShopConfigModel Config;
    private ShopBoardView View;
    private IPurchaseController PurchaseController;
    private IPlayerDataChangeHandler DataObserver;

    public ShopBoardPresenter(ShopConfigModel config, 
        ShopBoardView view, 
        IPurchaseController purchaseController,
        IPlayerDataChangeHandler dataObserver)
    {
        Config = config;
        View = view;
        PurchaseController = purchaseController;
        DataObserver = dataObserver;
    }

    public void Enable()
    {
        View.Enable();

        PurchaseController.PurchaseComplete += HandlePurchaseComplete;
        DataObserver.DataChanged += HandleDataChanged;
    }

    public void Disable()
    {
        View.Disable();
        PurchaseController.PurchaseComplete -= HandlePurchaseComplete;
        DataObserver.DataChanged -= HandleDataChanged;
    }

    public void UpdateAllStates()
    {
        for (int i = 0; i < Config.GetItemsCount(); i++)
        {
            var button = View.GetCard(i);
            UpdateCardState(i, button);
        }
    }

    private void HandlePurchaseComplete(int index)
    {
        UpdateAllStates();
    }

    public void CreateCards()
    {
        for (int i = 0; i < Config.GetItemsCount(); i++)
        {
            var button = View.AddCard();

            SetupCard(i, button);
        }

        UpdateAllStates();
    }

    private void SetupCard(int index, ShopCardView card)
    {
        card.Enable();

        card.SetIndex(index);
        card.SetName(Config.GetItemName(index));

        card.ShowInfoButton();

        card.BuyButtonClicked += HandleBuyButtonClicked;
        card.InfoButtonClicked += HandleInfoButtonClicked;
    }

    private void UpdateCardState(int index, ShopCardView button)
    {
        if (PurchaseController.CanPurchaseItem(index))
        {
            button.SetBuyClickable();
        }
        else
        {
            button.SetBuyUnlickable();
        }

        if (PurchaseController.GetPurchaseIsInProgress())
        {
            button.SetWaiting();
        }
        else
        {
            button.SetBuy();
        }
    }

    private void HandleBuyButtonClicked(int index)
    {
        PurchaseController.Purchase(index);
        UpdateAllStates();
    }

    private void HandleInfoButtonClicked(int index)
    {
        InfoButtonClicked(index);
    }

    private void HandleDataChanged()
    {
        UpdateAllStates();
    }

    public void Dispose()
    {
        View.Dispose();
    }
}
