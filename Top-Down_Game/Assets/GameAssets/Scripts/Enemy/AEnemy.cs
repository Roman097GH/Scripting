using UnityEngine;

namespace TopDown
{
    public abstract class AEnemy : MonoBehaviour
    {
        [SerializeField, HideInInspector] protected string _enemyName;
        [SerializeField, HideInInspector] protected float _lookAtRadius;
        [SerializeField, HideInInspector] protected float _followRadius;
        [SerializeField, HideInInspector] protected float _attackRadius;
        //[SerializeField, HideInInspector] protected float _speed;
        //[SerializeField, HideInInspector] protected float _health;
        

        public abstract void Initialize(SOEnemy enemyInfo, int enemyLevel);

        protected abstract void Eating();
        protected abstract void LookAt();
        protected abstract void Follow();
        protected abstract void Attack();
    }
}