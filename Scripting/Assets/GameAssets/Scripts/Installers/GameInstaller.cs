using UnityEngine;
using Zenject;

namespace Scripting
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GamePanel _gamePanelObject;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GamePanel>().FromInstance(_gamePanelObject);
            Container.BindInterfacesAndSelfTo<GameStateService>().AsSingle();
            Container.Bind<CollectableManager>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
            Container.Bind<ILocalization>().To<UnityLocalization>().AsSingle().NonLazy();
            Container.Bind<EnemyFactoryService>().AsSingle();
        }
    }
}
