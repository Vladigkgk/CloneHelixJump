using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Platforms
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlatformSegment : MonoBehaviour
    {
        public void Bounses(float force, Vector3 centre, float radius)
        {
            if (TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.isKinematic = false;
                rigidbody.AddExplosionForce(force, centre, radius);
            }
        }
    }
}