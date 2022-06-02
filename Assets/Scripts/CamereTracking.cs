using Assets.Scripts.Balls;
using Assets.Scripts.Tower;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class CamereTracking : MonoBehaviour
    {
        [SerializeField] private Vector3 _directionOffset;
        [SerializeField] private float _lenght;

        private Ball _ball;
        private Beam _beam;
        private Vector3 _camerePosition;
        private Vector3 _minimumBallPosition;

        private void Start()
        {

            _beam = FindObjectOfType<Beam>();
            _ball = FindObjectOfType<Ball>();


            _camerePosition = _ball.transform.position;
            _minimumBallPosition = _ball.transform.position;
            Track();
        }

        private void Update()
        {
            if (_ball.transform.position.y < _minimumBallPosition.y)
            {
                Track();
                _minimumBallPosition = _ball.transform.position;
            }
        }

        private void Track()
        {
            Vector3 beam = _beam.transform.position;
            beam.y = _ball.transform.position.y;

            _camerePosition = _ball.transform.position;
            var direction = (beam - _ball.transform.position).normalized + _directionOffset;
            _camerePosition -= direction * _lenght;

            transform.position = _camerePosition;
            transform.LookAt(_ball.transform);
        }
    }
}