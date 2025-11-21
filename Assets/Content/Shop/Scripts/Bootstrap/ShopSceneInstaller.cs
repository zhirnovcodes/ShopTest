using UnityEngine;
using Zenject;

public class ShopSceneInstaller : MonoInstaller
{
    [SerializeField] private ShopBoardView ShopBoardView;
    [SerializeField] private HUDView HUDView;

    public override void InstallBindings()
    {
        Container.Bind<ShopBoardView>()
            .FromInstance(ShopBoardView)
            .AsSingle();

        Container.Bind<HUDView>()
            .FromInstance(HUDView)
            .AsSingle();

        Container.Bind<ShopBoardPresenter>()
            .AsSingle()
            .NonLazy();

        Container.Bind<HUDPresenter>()
            .AsSingle()
            .NonLazy();
    }
}
