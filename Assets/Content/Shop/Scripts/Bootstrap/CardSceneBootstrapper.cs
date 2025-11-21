using UnityEngine;
using UnityEngine.SceneManagement;

public class CardSceneBootstrapper : MonoBehaviour
{
    private CardScenePresenter Presenter;
    private ShopSceneManager SceneManager;

    void Start()
    {
        var shopContext = FindFirstObjectByType<ShopContext>();
        CreateCardSceneView(shopContext);

        SceneManager = shopContext.SceneManager;
    }

    private void CreateCardSceneView(ShopContext context)
    {
        var view = FindFirstObjectByType<CardSceneView>();
        Presenter = new CardScenePresenter(context.ShopModel, context.PurchaseController, view, context.ShopPreferences.SelectedCardIndex, context.PlayerObserver);
        Presenter.Enable();
        Presenter.CloseButtonClicked += CloseScene;
    }

    private void CloseScene()
    {
        Presenter.CloseButtonClicked -= CloseScene;
        Presenter.Disable();
        SceneManager.UnloadScene(gameObject.scene);
    }
}
