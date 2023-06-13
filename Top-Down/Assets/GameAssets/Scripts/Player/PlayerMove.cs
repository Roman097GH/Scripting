using UnityEngine;
using UnityEngine.AI;

namespace TopDown
{
    public class PlayerMove : MonoBehaviour, IPlayer
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        [SerializeField] private Animator _animator;
        private static readonly int WalkAnim = Animator.StringToHash("RunTrig");
        private static readonly int AttackAnim = Animator.StringToHash("AttackTrig");

        public void MoveTo(Vector3 position)
        {
            _navMeshAgent.SetDestination(position);
            _animator.SetTrigger(WalkAnim);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                SetAnimation();
            }
        }

        public void SetAnimation()
        {
            _animator.SetTrigger(AttackAnim);
        }
    }
}