using UnityEngine;

public class ShopContext : MonoBehaviour
{
    public ShopConfigModel ShopModel { get; private set; }
    public IPurchaseController PurchaseController { get; private set; }
    public IPlayerDataObserver PlayerObserver { get; private set; }
    public ShopPreferences ShopPreferences { get; private set; }
    public ShopSceneManager SceneManager { get; private set; }

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
