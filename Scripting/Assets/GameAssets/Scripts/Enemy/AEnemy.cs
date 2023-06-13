using UnityEngine;

namespace Scripting
{
    public abstract class AEnemy : MonoBehaviour
    {
        [SerializeField, HideInInspector] protected string _enemyName;
        [SerializeField, HideInInspector] protected float _lookAtRadius;
        [SerializeField, HideInInspector] protected float _followRadius;
        [SerializeField, HideInInspector] protected float _attackRadius;
        [SerializeField, HideInInspector] protected float _speed;

        public abstract void Initialize(SOEnemy enemyInfo, int enemyLevel);

        protected abstract void Idle();
        protected abstract void LookAt();
        protected abstract void Follow();
        protected abstract void Attack();
        protected abstract void Patrol();
        protected abstract void GoToInitialPoint();
    }
}