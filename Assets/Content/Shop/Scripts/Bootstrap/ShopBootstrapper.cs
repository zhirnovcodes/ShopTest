using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopBootstrapper : MonoBehaviour
{
    public ShopConfig ShopConfig;
    public ShopBoardView View;
    public HUDView HUDView;

    private ShopSceneManager Scenes;
    private ShopConfigModel ShopModel;
    private IPurchaseController PurchaseController;
    private IPlayerDataObserver PlayerObserver;
    private ShopPreferences ShopPreferences;
    private IPlayerData PlayerData;
    private IPlayerAllData PlayerAllData;
    private ShopBoardPresenter Presenter;

    void Start()
    {
        CreateSceneManager();
        CreateShopPrefs();
        CreateConfigModel();
        CreatePlayerData();
        CreatePurchaseController();
        CreateShopContext();
        CreateShopUI();
        CreateHUD();

        ShowUI();
        SubscribeOnSceneEvents();
    }

    private void CreateSceneManager()
    {
        Scenes = new ShopSceneManager();
    }

    private void CreateShopContext()
    {
        var go = new GameObject();
        var cont = go.AddComponent<ShopContext>();
        cont.Initialize(ShopModel, PurchaseController, PlayerObserver, ShopPreferences, Scenes);
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
        Presenter = new ShopBoardPresenter(ShopModel, View, PurchaseController, PlayerObserver);
        Presenter.CreateCards();
        Presenter.InfoButtonClicked += HandleInfoButtonClicked;
    }

    private void HandleInfoButtonClicked(int cardIndex)
    {
        ShowCardScene(cardIndex);
    }

    private void ShowCardScene(int cardIndex)
    {
        ShopPreferences.SelectedCardIndex = cardIndex;
        Scenes.OpenSceneOnTop(SceneNames.CardInfo);
    }

    private void ShowUI()
    {
        Presenter.Enable();
    }

    private void SubscribeOnSceneEvents()
    {
        Scenes.SceneChanged += HandleSceneChanged;
    }

    private void HandleSceneChanged()
    {
        Presenter.UpdateAllStates();
    }
}
