using Assets.Scripts.Balls;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Platforms
{
    public class SpawnPlatform : Platform
    {
        [SerializeField] private Ball _ball;
        [SerializeField] private Transform _spawnPoint;

        private void Awake()
        {
            Instantiate(_ball, _spawnPoint.position, Quaternion.identity);
        }
    }
}