using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace TopDown
{
    public class GamePanel : MonoBehaviour, IInitializable
    {
        [FormerlySerializedAs("_coinCounterLabel")] [SerializeField] private TextMeshProUGUI _itemCounterLabel;
        [SerializeField] private TextMeshProUGUI _bestScoreLabel;

        private ScoreService _scoreService;

        private CompositeDisposable _disposable;

        [Inject]
        private void Construct(ScoreService scoreService)
        {
            _scoreService = scoreService;
        }
        
        public void Initialize()
        {
            _disposable = new CompositeDisposable();
            AddListeners();
        }

        private void AddListeners()
        {
            _scoreService.ItemsCount.Subscribe(_ => UpdateInfo()).AddTo(_disposable);
            _scoreService.BestScore.Subscribe(_ => UpdateInfo()).AddTo(_disposable);
        }

        private void UpdateInfo()
        {
            _itemCounterLabel.text = "Items: " + _scoreService.ItemsCount.Value;
            _bestScoreLabel.text = "Best Score: " + _scoreService.BestScore.Value;
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }
    }
}
