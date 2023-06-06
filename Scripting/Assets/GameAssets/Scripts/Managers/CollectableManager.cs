using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripting
{
    public class CollectableManager : MonoBehaviour
    {
        private List<ACollectable> _itemsList;

        private GameStateService _gameStateService;

        [Inject]
        private void Construct(GameStateService gameStateService)
        {
            _gameStateService = gameStateService;
        }

        public void CollectItem(ACollectable item)
        {
            if (_itemsList.Remove(item)) _gameStateService.SetCollectedItemsCount(_itemsList.Count);
        }

        private void Start() => InitializeAllItems();

        private void InitializeAllItems()
        {
            _itemsList = new List<ACollectable>(FindObjectsOfType<ACollectable>());
            var count = _itemsList.Count;

            _gameStateService.SetInitialItemsCount(count);
            _gameStateService.SetCollectedItemsCount(count);
        }
    }
}