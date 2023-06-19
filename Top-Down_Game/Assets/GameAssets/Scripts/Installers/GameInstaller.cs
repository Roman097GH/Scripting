using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace TopDown
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;
        [FormerlySerializedAs("_playerMoveObject")] [SerializeField] private Player playerObject;
        [SerializeField] private GamePanel _gamePanelObject;

        public override void InstallBindings()
        {
            
            Container.Bind<IPlayer>().FromInstance(playerObject);

            Container.BindInterfacesAndSelfTo<InputHandler>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ScoreService>().AsSingle();
            
            Container.BindInterfacesTo<GamePanel>().FromInstance(_gamePanelObject);
            Container.BindInterfacesAndSelfTo<GameplayController>().AsSingle().NonLazy();
            
            Container.Bind<CollectableManager>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
            
            Container.Bind<Camera>().WithId(BaseIds.GameCameraId).FromInstance(_camera);
            
            Container.Bind<EnemyFactoryService>().AsSingle();
        }
    }
}