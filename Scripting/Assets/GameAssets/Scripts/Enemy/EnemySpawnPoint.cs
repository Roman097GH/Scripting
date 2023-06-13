using UnityEngine;
using Zenject;

namespace Scripting
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [Range(1, 10)]
        [SerializeField] private int _enemyLevel;
        [SerializeField] private SOEnemy _enemy;

        [Inject]
        private void Constructor(EnemyFactoryService enemyFactoryService)
        {
            enemyFactoryService.Create(_enemy, _enemyLevel - 1, transform);
            Destroy(gameObject);
        }
    }
}