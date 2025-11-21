using System;

public class ShopBoardPresenter
{
    public event Action<int> InfoButtonClicked = (int index) => { };

    private ShopConfigModel Config;
    private ShopBoardView View;
    private IPurchaseController PurchaseController;
    private IPlayerDataObserver DataObserver;

    public ShopBoardPresenter(ShopConfigModel config, 
        ShopBoardView view, 
        IPurchaseController purchaseController,
        IPlayerDataObserver dataObserver)
    {
        Config = config;
        View = view;
        PurchaseController = purchaseController;
        DataObserver = dataObserver;
    }

    public void Enable()
    {
        View.Enable();

        AddCards();

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
        var card = View.GetCard(index);
        UpdateCardState(index, card);
    }

    private void AddCards()
    {
        for (int i = 0; i < Config.GetItemsCount(); i++)
        {
            var button = View.AddCard();

            SetupCard(i, button);
            UpdateCardState(i, button);
        }
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

        if (PurchaseController.GetPurchaseIsInProgress(index))
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
        var card = View.GetCard(index);
        PurchaseController.Purchase(index);
        UpdateCardState(index, card);
    }

    private void HandleInfoButtonClicked(int index)
    {
        InfoButtonClicked(index);
    }

    private void HandleDataChanged()
    {
        for (int i = 0; i < View.GetCardsCount(); i++)
        {
            var card = View.GetCard(i);
            UpdateCardState(i, card);
        }
    }
}
