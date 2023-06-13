using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TopDown
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private static readonly int AttackAnim = Animator.StringToHash("AttackTrig");
        public void SetAnimation()
        {
            throw new System.NotImplementedException();
        }
    }
}
