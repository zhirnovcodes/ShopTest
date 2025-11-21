using UnityEngine;
using Zenject;

public class ShopParentInstaller : MonoInstaller
{
    [SerializeField] private ShopConfig ShopConfig;

    public override void InstallBindings()
    {
        Container.Bind<ShopConfigModel>()
            .AsSingle()
            .WithArguments(ShopConfig);

        Container.Bind<PlayerData>()
            .AsSingle()
            .NonLazy();

        Container.Bind<IPlayerData>()
            .To<PlayerData>()
            .FromResolve();

        Container.Bind<IPlayerAllData>()
            .To<PlayerData>()
            .FromResolve();

        Container.Bind<IPlayerDataObserver>()
            .To<PlayerData>()
            .FromResolve();

        Container.Bind<ShopPreferences>()
            .AsSingle();

        Container.Bind<IPurchaseController>()
            .To<PurchaseController>()
            .FromNewComponentOnNewGameObject()
            .WithGameObjectName("PurchaseController")
            .AsSingle()
            .NonLazy();
    }
}
