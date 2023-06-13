using UniRx;
using UnityEngine;

namespace Scripting
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour, IPlayer
    {
        [SerializeField, HideInInspector] private CharacterController _characterController;
        [SerializeField, HideInInspector] private PlayerInput _playerInput;
        [SerializeField] private float _speed = 5.0f;
        private Vector3 _movement;

        private void OnValidate()
        {
            _playerInput = GetComponent<PlayerInput>();
            _characterController = GetComponent<CharacterController>();
        }

        private void OnEnable()
        {
            _playerInput.OnMove.Subscribe(Move);
        }

        private void Update()
        {
            _characterController.Move(_movement);
        }

        public void Move(Vector3 moveVector)
        {
            _movement = Vector3.ClampMagnitude(moveVector, 1.0f) * Time.deltaTime * _speed;
        }

        public Vector3 GetCurrentPosition() => transform.position;
    }
}