using UniRx;
using UnityEngine;

namespace Scripting.Player
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour, IPlayer
    {
        [SerializeField, HideInInspector] private PlayerInput _playerInput;
        [SerializeField, HideInInspector] private CharacterController _characterController;
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
    }
}