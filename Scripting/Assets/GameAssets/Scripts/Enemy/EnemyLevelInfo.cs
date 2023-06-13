using System;
using UnityEngine;

namespace Scripting
{
    [Serializable]
    public class EnemyLevelInfo
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float LookRadius { get; private set; }
        [field: SerializeField] public float FollowRadius { get; private set; }
        [field: SerializeField] public float AttackRadius { get; private set; }
    }
}