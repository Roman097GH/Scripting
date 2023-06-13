using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using Zenject;

namespace TopDown
{
    [UsedImplicitly]
    public class GameplayController : IInitializable
    {
        private readonly IPlayer _player;
        private readonly InputHandler _inputHandler;

        public readonly ReactiveProperty<EGameState> GameState = new(EGameState.GameActive);

        public GameplayController(IPlayer player, InputHandler inputHandler)
        {
            _player = player;
            _inputHandler = inputHandler;
        }

        public void Initialize()
        {
            _inputHandler.OnClicked.Subscribe(OnClicked);
        }

        private void OnClicked(Vector3 position)
        {
            _player.MoveTo(position);
        }
    }
}