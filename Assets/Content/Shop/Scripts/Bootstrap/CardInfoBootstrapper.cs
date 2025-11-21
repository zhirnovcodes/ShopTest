using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class CardInfoBootstrapper : MonoBehaviour
{
    [Inject] private CardScenePresenter Presenter;
    /*
    [Inject]
    public void Construct(
    CardScenePresenter presenter)
    {
        Debug.Log(1);
        Presenter = presenter;
    }*/

    void Start()
    {
        Debug.Log(2);
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
