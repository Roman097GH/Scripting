using UnityEngine;
using UnityEngine.AI;

namespace TopDown
{
    public class Player : MonoBehaviour, IPlayer
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        [SerializeField] private Animator _animator;
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");
        private static readonly int AttackAnim = Animator.StringToHash("AttackTrig");

        [SerializeField] private float _onAnimanionDistance = 1.25f;
        [SerializeField] private float _distance;
        [SerializeField] private Vector3 _newPosition;

        [SerializeField] private float _timer;

        [SerializeField] private float _attackPeriod;

        public void MoveTo(Vector3 position)
        {
            _navMeshAgent.SetDestination(position);
            _newPosition = position;
        }

        private void Update()
        {
            _distance = Vector3.Distance(transform.position, _newPosition);
            _animator.SetBool(IsWalking, _distance >= _onAnimanionDistance);

            _timer += Time.unscaledDeltaTime;

            if (_timer > _attackPeriod)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    _timer = 0;
                    _animator.SetTrigger(AttackAnim);
                }
            }
        }
    }
}