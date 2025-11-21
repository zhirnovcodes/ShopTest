using UnityEngine;

public class ShopContext : MonoBehaviour
{
    public ShopConfigModel ShopModel;
    public IPurchaseController PurchaseController;
    public IPlayerDataObserver PlayerObserver;
    public ShopPreferences ShopPreferences;
    public ShopSceneManager SceneManager;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Initialize(ShopConfigModel shopModel,
        IPurchaseController purchaseController,
        IPlayerDataObserver playerObserver,
        ShopPreferences shopPreferences,
        ShopSceneManager sceneManager)
    {
        ShopModel = shopModel;
        PurchaseController = purchaseController;
        PlayerObserver = playerObserver;
        ShopPreferences = shopPreferences;
        SceneManager = sceneManager;
    }
}
