using System;
using UnityEngine;
using UnityEngine.AI;

namespace TopDown
{
    public class EnemyZombieStreetman : AEnemy
    {
        [SerializeField] private SphereCollider _lookColliderRadius;
        [SerializeField, HideInInspector] private int _playerLayer;
        private EEnemyState _enemyState = EEnemyState.Eating;
        private PlayerMove _player;
        private float _distance;

        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Animator _animator;
        private static readonly int EatingAnim = Animator.StringToHash("EatingTrig");
        private static readonly int LookAtAnim = Animator.StringToHash("LookAtTrig");
        private static readonly int FollowAnim = Animator.StringToHash("FollowTrig");
        private static readonly int AttackAnim = Animator.StringToHash("AttackTrig");
        private static readonly int DeathAnim = Animator.StringToHash("DeathTrig");

        [SerializeField] private GameObject _particle;

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
                case EEnemyState.Eating:
                    Eating();
                    break;

                case EEnemyState.LookAt:
                    LookAt();
                    break;

                case EEnemyState.Follow:
                    Follow();
                    break;

                case EEnemyState.Attack:
                    Follow();
                    Attack();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected override void Eating()
        {
            _animator.SetTrigger(EatingAnim);
        }

        protected override void LookAt()
        {
            _animator.SetTrigger(LookAtAnim);
            transform.LookAt(_player.transform.position);
        }

        protected override void Follow()
        {
            _animator.SetTrigger(FollowAnim);
            _navMeshAgent.SetDestination(_player.transform.position);
        }

        protected override void Attack()
        {
            _animator.SetTrigger(AttackAnim);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != _playerLayer || !other.TryGetComponent(out PlayerMove player)) return;

            _player = player;
            _enemyState = EEnemyState.LookAt;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer != _playerLayer || !other.TryGetComponent(out PlayerMove player)) return;

            _distance = Vector3.Distance(transform.position, player.transform.position);

            if (_distance <= _attackRadius) _enemyState = EEnemyState.Attack;
            else if (_distance <= _followRadius) _enemyState = EEnemyState.Follow;
            else _enemyState = EEnemyState.LookAt;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer != _playerLayer || !other.TryGetComponent(out PlayerMove player)) return;

            _distance = 0;
            _player = null;
            _enemyState = EEnemyState.Eating;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Damage"))
            {
                _animator.SetTrigger(DeathAnim);
                _particle.gameObject.SetActive(true);
            }
        }
    }
}