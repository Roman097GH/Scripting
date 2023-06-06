using UnityEngine;
using Zenject;

namespace Scripting
{
    public class Coin : ACollectable
    {
        [SerializeField, HideInInspector] private int _playerLayerMask;

        private CollectableManager _collectableManager;
        
        [Inject]
        private void Construct(CollectableManager collectableManager)
        {
            _collectableManager = collectableManager;
        }
        
        private void OnValidate()
        {
            _playerLayerMask = LayerMask.NameToLayer("Player");
        }

        protected override void Collect()
        {
            _collectableManager.CollectItem(this);
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != _playerLayerMask) return;
            Collect();
        }
    }
}
