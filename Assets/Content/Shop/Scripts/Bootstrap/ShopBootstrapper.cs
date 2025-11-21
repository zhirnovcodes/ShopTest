using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopBootstrapper : MonoBehaviour
{
    public ShopConfig ShopConfig;
    public ShopBoardView View;

    private ShopConfigModel ShopModel;
    private IPlayerData PlayerData;
    private IPurchaseController PurchaseController;

    void Start()
    {
        CreateConfigModel();
        CreatePlayerData();
        CreatePurchaseController();
        CreateHUD();
        CreateShopUI();
    }

    private void CreateConfigModel()
    {
        ShopModel = new ShopConfigModel(ShopConfig);
    }

    private void CreatePlayerData()
    {
        PlayerData = new PlayerData();
    }

    private void CreatePurchaseController()
    {
        var go = new GameObject("PurchaseController");
        var purchaseController = go.AddComponent<PurchaseController>();
        purchaseController.Initialize(ShopModel, PlayerData);
        PurchaseController = purchaseController;
    }

    private void CreateHUD()
    {
    }

    private void CreateShopUI()
    {
        var presenter = new ShopBoardPresenter(ShopModel, View, PurchaseController);
        presenter.Enable();
        presenter.InfoButtonClicked += HandleInfoButtonClicked;
    }

    private void HandleInfoButtonClicked(int cardIndex)
    {
        ShowCardScene(cardIndex);
    }

    private void ShowCardScene(int cardIndex)
    {
        SceneManager.LoadScene("CardPresent", LoadSceneMode.Additive);
        var bootstrapper = FindFirstObjectByType<CardSceneBootstrapper>();
        bootstrapper.Run(ShopModel, PurchaseController, cardIndex);
    }
}