using Assets.Scripts.Platforms;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Balls
{
    public class Ball : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlatformSegment platformSegment))
            {
                other.GetComponentInParent<Platform>().Break();
            }
        }
    }
}