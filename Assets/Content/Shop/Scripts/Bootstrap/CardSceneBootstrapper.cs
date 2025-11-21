using UnityEngine;
using UnityEngine.SceneManagement;

public class CardSceneBootstrapper : MonoBehaviour
{
    private CardScenePresenter Presenter;

    public void Run(ShopConfigModel shopConfigModel,
        IPurchaseController purchaseController,
        int cardIndex)
    {
        CreateCardSceneView(shopConfigModel, purchaseController, cardIndex);
    }

    private void CreateCardSceneView(ShopConfigModel shopConfigModel,
        IPurchaseController purchaseController, int cardIndex)
    {
        var view = FindFirstObjectByType<CardSceneView>();
        Presenter = new CardScenePresenter(shopConfigModel, purchaseController, view, cardIndex);
        Presenter.Enable();
        Presenter.CloseButtonClicked += CloseScene;
    }

    private void CloseScene()
    {
        Presenter.CloseButtonClicked -= CloseScene;
        Presenter.Disable();
        SceneManager.UnloadSceneAsync(gameObject.scene);
    }
}
