using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Tower
{
    [RequireComponent(typeof(Rigidbody))]
    public class TowerRotator : MonoBehaviour
    {
        [SerializeField] private float _speedRotate;

        private CloneHelixJump _input;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _input = new CloneHelixJump();
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {

            _input.Enable();
        }

        private void FixedUpdate()
        {
            var rotate = _input.Player.Rotate.ReadValue<Vector2>().normalized;
            float torque = rotate.x * _speedRotate;
            _rigidbody.AddTorque(Vector3.up * torque);
        }

        private void OnDisable()
        {
            _input.Disable();
        }
    }
}