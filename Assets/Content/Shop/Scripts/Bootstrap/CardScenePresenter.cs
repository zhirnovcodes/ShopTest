using System;

public class CardScenePresenter
{
    public event Action CloseButtonClicked = () => { };

    private readonly IPurchaseController PurchaseController;
    private readonly CardSceneView View;
    private readonly int ItemIndex;
    private ShopCardView Card;

    public CardScenePresenter(
        ShopConfigModel shopConfigModel,
        IPurchaseController purchaseController,
        CardSceneView view,
        int itemIndex)
    {
        PurchaseController = purchaseController;
        View = view;
        ItemIndex = itemIndex;

        PurchaseController.PurchaseComplete += HandlePurchaseComplete;
        CreateCard(shopConfigModel, itemIndex);
    }

    private void CreateCard(ShopConfigModel shopConfigModel, int itemIndex)
    {
        Card = View.GetCard();
        Card.SetName(shopConfigModel.GetItemName(itemIndex));
        Card.SetIndex(itemIndex);
        Card.HideInfoButton();

        ChangeCardState();

        Card.BuyButtonClicked += HandleBuyClicked;
    }

    public void Enable()
    {
        View.Enable();

        View.CloseClicked += HandleCloseClicked;
    }

    public void Disable()
    {
        PurchaseController.PurchaseComplete -= HandlePurchaseComplete;
        Card.BuyButtonClicked -= HandleBuyClicked;
        View.Disable();

        View.CloseClicked -= HandleCloseClicked;
    }

    private void ChangeCardState()
    {
        if (PurchaseController.GetPurchaseIsInProgress(ItemIndex))
        {
            Card.SetWaiting();
        }
        else
        {
            Card.SetBuy();
        }

        if (PurchaseController.CanPurchaseItem(ItemIndex))
        {
            Card.SetBuyClickable();
        }
        else
        {
            Card.SetBuyUnlickable();
        }
    }

    private void HandlePurchaseComplete(int index)
    {
        ChangeCardState();
    }

    private void HandleBuyClicked(int index)
    {
        PurchaseController.Purchase(index);
        ChangeCardState();
    }

    private void HandleCloseClicked()
    {
        CloseButtonClicked();
    }
}
