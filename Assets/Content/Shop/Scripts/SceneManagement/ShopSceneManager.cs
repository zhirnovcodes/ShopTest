using System;
using UnityEngine.SceneManagement;

public class ShopSceneManager
{
    public event Action SceneChanged = () => { };

    public void OpenSceneOnTop(SceneNames name)
    {
        SceneManager.LoadScene(name.ToString(), LoadSceneMode.Additive);
        SceneChanged();
    }

    public void UnloadScene(Scene scene)
    {
        _ = SceneManager.UnloadSceneAsync(scene);
        SceneChanged();
    }
}
