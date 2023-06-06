using UniRx;
using UnityEngine;

namespace Scripting.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public readonly ReactiveProperty<Vector3> OnMove = new();

        private void Update()
        {
            OnMove.SetValueAndForceNotify(new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")));
        }
    }
}