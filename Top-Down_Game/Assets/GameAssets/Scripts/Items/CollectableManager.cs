using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TopDown
{
    public class CollectableManager : MonoBehaviour
    {
        private List<ACollectable> _itemsList;

        private ScoreService _scoreService;
        
        private GameplayController _gameplayController;

        [Inject]
        private void Construct(ScoreService scoreService, GameplayController gameplayController)
        {
            _gameplayController = gameplayController;
            _scoreService = scoreService;
        }

        public void CollectItem(ACollectable item)
        {
            if (!_itemsList.Remove(item)) return;
            _scoreService.SetCollectedItemsCount(_itemsList.Count);

            if (_itemsList.Count == 0)
            {
                _gameplayController.GameState.Value = EGameState.GameOver;
            }
        }

        private void Start() => InitializeAllItems();

        private void InitializeAllItems()
        {
            _itemsList = new List<ACollectable>(FindObjectsOfType<ACollectable>());
            var count = _itemsList.Count;

            _scoreService.SetInitialItemsCount(count);
            _scoreService.SetCollectedItemsCount(count);
        }
    }
}