using System;

public class ShopBoardPresenter
{
    public event Action<int> InfoButtonClicked = (int index) => { };

    private ShopConfigModel Config;
    private ShopBoardView View;
    private IPurchaseController PurchaseController;

    public ShopBoardPresenter(ShopConfigModel config, ShopBoardView view, IPurchaseController purchaseController)
    {
        Config = config;
        View = view;
        PurchaseController = purchaseController;
    }

    public void Enable()
    {
        View.Enable();

        AddCards();

        PurchaseController.PurchaseComplete += HandlePurchaseComplete;
    }

    public void Disable()
    {
        View.Disable();
        PurchaseController.PurchaseComplete -= HandlePurchaseComplete;
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
        UpdateCardState(index, card);
    }

    private void HandleInfoButtonClicked(int index)
    {
        InfoButtonClicked(index);
    }
}
