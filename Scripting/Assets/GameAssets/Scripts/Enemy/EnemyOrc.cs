using System;
using UnityEngine;

namespace Scripting
{
    public class EnemyOrc : AEnemy
    {
        [SerializeField] private SphereCollider _lookColliderRadius;

        [SerializeField, HideInInspector] private int _playerLayer;

        private EEnemyState _enemyState = EEnemyState.Idle;
        
        private Player _player;
        
        private float _distance;

        public override void Initialize(SOEnemy enemyInfo, int enemyLevel)
        {
            _playerLayer = LayerMask.NameToLayer("Player");

            EnemyLevelInfo info = enemyInfo.EnemyLevelInfos[enemyLevel];
            _enemyName = enemyInfo.name;
            _speed = info.Speed;
            _lookAtRadius = info.LookRadius;
            _followRadius = info.FollowRadius;
            _attackRadius = info.AttackRadius;

            _lookColliderRadius.radius = _lookAtRadius;

            Debug.Log(enemyInfo.name);
            Debug.Log(enemyInfo.EnemyLevelInfos[enemyLevel].AttackRadius);
            Debug.Log(transform.position);
        }

        private void Update()
        {
            switch (_enemyState)
            {
                case EEnemyState.Idle:
                    Idle();
                    break;

                case EEnemyState.LookAt:
                    LookAt();
                    break;

                case EEnemyState.Follow:
                    LookAt();
                    Follow();
                    break;

                case EEnemyState.Attack:
                    LookAt();
                    Attack();
                    break;

                case EEnemyState.Patrol:
                    Patrol();
                    break;

                case EEnemyState.GoToInitialPoint:
                    GoToInitialPoint();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected override void Idle()
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 20.0f);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        protected override void LookAt()
        {
            transform.LookAt(_player.transform.position);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        protected override void Follow()
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, Time.deltaTime * _speed);
        }

        protected override void Attack()
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }

        protected override void Patrol()
        {
        }

        protected override void GoToInitialPoint()
        {
            Idle();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != _playerLayer || !other.TryGetComponent(out Player player)) return;

            _player = player; 
            _enemyState = EEnemyState.LookAt;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer != _playerLayer || !other.TryGetComponent(out Player player)) return;

            _distance = Vector3.Distance(transform.position,player.transform.position);

            if (_distance <= _attackRadius) _enemyState = EEnemyState.Attack;
            else if (_distance <= _followRadius) _enemyState = EEnemyState.Follow;
            else _enemyState = EEnemyState.LookAt;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer != _playerLayer || !other.TryGetComponent(out Player player)) return;

            _distance = 0;
            _player = null;
            _enemyState = EEnemyState.GoToInitialPoint;
        }
    }
}