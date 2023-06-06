using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Scripting
{
    public class GamePanel : MonoBehaviour, IInitializable
    {
        [SerializeField] private TextMeshProUGUI _coinCounterLabel;
        //[SerializeField] private TextMeshProUGUI _bestScoreLabel;

        private GameStateService _gameStateService;
        private ILocalization _localization;

        private CompositeDisposable _disposable;

        [Inject]
        private void Construct(GameStateService gameStateService, ILocalization localization)
        {
            _gameStateService = gameStateService;
        }
        
        public void Initialize()
        {
            _disposable = new CompositeDisposable();
            AddListeners();
        }

        private void AddListeners()
        {
            _gameStateService.ItemsCount.Subscribe(_ => UpdateInfo()).AddTo(_disposable);
            //_gameStateService.BestScore.Subscribe(value => _bestScoreLabel.text = "Best score " + value);
        }

        private void UpdateInfo()
        {
            _coinCounterLabel.text = _localization.Translate( "coin.count", _gameStateService.ItemsCount.Value);
            _disposable.Dispose();
        }
    }
}
