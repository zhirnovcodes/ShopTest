using UnityEngine;
using UnityEngine.SceneManagement;

public class CardSceneBootstrapper : MonoBehaviour
{
    private CardScenePresenter Presenter;

    public void Run(ShopConfigModel shopConfigModel,
        IPurchaseController purchaseController,
        int cardIndex,
        IPlayerDataObserver dataObserver)
    {
        CreateCardSceneView(shopConfigModel, purchaseController, cardIndex, dataObserver);
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
