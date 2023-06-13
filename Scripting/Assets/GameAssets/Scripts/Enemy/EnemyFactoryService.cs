using UnityEngine;

namespace Scripting
{
    public class EnemyFactoryService
    {
        public void Create(SOEnemy enemyInfo, int enemyLevel, Transform pointTransform)
        {
            AEnemy enemyInstance = Object.Instantiate(enemyInfo.Enemy, pointTransform.position, pointTransform.rotation);
            enemyInstance.Initialize(enemyInfo, enemyLevel);
        }
    }
}