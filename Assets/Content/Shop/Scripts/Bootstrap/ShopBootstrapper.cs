using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopBootstrapper : MonoBehaviour
{
    public ShopConfig ShopConfig;
    public ShopBoardView View;
    public HUDView HUDView;

    private ShopConfigModel ShopModel;
    private IPurchaseController PurchaseController;
    private IPlayerDataObserver PlayerObserver;
    private ShopPreferences ShopPreferences;
    private IPlayerData PlayerData;
    private IPlayerAllData PlayerAllData;
    private ShopBoardPresenter Presenter;

    void Start()
    {
        CreateShopPrefs();
        CreateConfigModel();
        CreatePlayerData();
        CreatePurchaseController();
        CreateShopContext();
        CreateShopUI();
        CreateHUD();
    }

    private void CreateShopContext()
    {
        var go = new GameObject();
        var cont = go.AddComponent<ShopContext>();
        cont.Initialize(ShopModel, PurchaseController, PlayerObserver, ShopPreferences);
    }

    private void CreateShopPrefs()
    {
        ShopPreferences = new ShopPreferences();
    }

    private void CreateConfigModel()
    {
        ShopModel = new ShopConfigModel(ShopConfig);
    }

    private void CreatePlayerData()
    {
        PlayerData = new PlayerData();
        PlayerAllData = PlayerData as IPlayerAllData;
        PlayerObserver = PlayerData as IPlayerDataObserver;
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
        var hudPresenter = new HUDPresenter(PlayerAllData, HUDView, PlayerObserver, PlayerData);
        hudPresenter.Enable();
    }

    private void CreateShopUI()
    {
        var presenter = new ShopBoardPresenter(ShopModel, View, PurchaseController, PlayerObserver);
        presenter.Enable();
        presenter.InfoButtonClicked += HandleInfoButtonClicked;
    }

    private void HandleInfoButtonClicked(int cardIndex)
    {
        ShowCardScene(cardIndex);
    }

    private void ShowCardScene(int cardIndex)
    {
        ShopPreferences.SelectedCardIndex = cardIndex;
        _ = ShowCardSceneAsync(cardIndex);
    }

    private async Task ShowCardSceneAsync(int cardIndex)
    {
        await SceneManager.LoadSceneAsync("CardInfo", LoadSceneMode.Additive);
    }
}
