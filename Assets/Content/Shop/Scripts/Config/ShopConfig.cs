using UnityEngine;

[CreateAssetMenu(fileName = "ShopConfig", menuName = "Configs/Shop Config")]
public class ShopConfig : ScriptableObject
{
    public ShopItemConfig[] Bundles;
}
