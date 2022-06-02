using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Platforms
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private float _force;
        [SerializeField] private float _radius;

        public void Break()
        {
            PlatformSegment[] platformSegments = GetComponentsInChildren<PlatformSegment>();

            foreach (var platformSegment in platformSegments)
            {
                platformSegment.Bounses(_force, transform.position, _radius);
            }
        }
    }
}