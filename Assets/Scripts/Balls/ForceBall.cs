using Assets.Scripts.Platforms;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Balls
{
    [RequireComponent(typeof(Rigidbody))]
    public class ForceBall : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out PlatformSegment platformSegment))
            {
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }
    }
}