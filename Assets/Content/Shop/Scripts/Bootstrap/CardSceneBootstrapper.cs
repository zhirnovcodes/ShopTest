using UnityEngine;
using UnityEngine.SceneManagement;

public class CardSceneBootstrapper : MonoBehaviour
{
    private CardScenePresenter Presenter;

    void Start()
    {
        var shopContext = FindFirstObjectByType<ShopContext>();
        CreateCardSceneView(shopContext.ShopModel, shopContext.PurchaseController, shopContext.ShopPreferences.SelectedCardIndex, shopContext.PlayerObserver);
    }

    private void CreateCardSceneView(ShopConfigModel shopConfigModel,
        IPurchaseController purchaseController, int cardIndex, IPlayerDataObserver dataObserver)
    {
        var view = FindFirstObjectByType<CardSceneView>();
        Presenter = new CardScenePresenter(shopConfigModel, purchaseController, view, cardIndex, dataObserver);
        Presenter.Enable();
        Presenter.CloseButtonClicked += CloseScene;
    }

    private void CloseScene()
    {
        Presenter.CloseButtonClicked -= CloseScene;
        Presenter.Disable();
        _ = SceneManager.UnloadSceneAsync(gameObject.scene);
    }
}
