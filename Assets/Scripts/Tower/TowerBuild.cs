using Assets.Scripts.Platforms;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tower
{
    public class TowerBuild : MonoBehaviour
    {
        private int _levelCount;
        [SerializeField] private float _addLocalScale;
        [SerializeField] private GameObject _beam;
        [SerializeField] private SpawnPlatform _spawnPlatform;
        [SerializeField] private Platform[] _platform;
        [SerializeField] private FinishPlatform _finishPlatform;

        private float _startAndFinishAddLocalScale = 0.5f;

        public float BeamScaleY => _levelCount / 2f + _startAndFinishAddLocalScale + _addLocalScale / 2;

        private void Awake()
        {
            _levelCount = Random.Range(5, 10);
            Build();
        }

        private void Build()
        {
            var beam = Instantiate(_beam, transform);
            beam.transform.localScale = new Vector3(1, BeamScaleY, 1);
            Vector3 spawnPosition = beam.transform.position;
            spawnPosition.y += beam.transform.localScale.y - _addLocalScale;

            SpawnPlatforms(_spawnPlatform.gameObject, ref spawnPosition, beam.transform);

            for (int i = 0; i < _levelCount; i++)
            {
                SpawnPlatforms(_platform[Random.Range(0, _platform.Length)].gameObject, ref spawnPosition, beam.transform);
            }

            SpawnPlatforms(_finishPlatform.gameObject, ref spawnPosition, beam.transform);
        }

        private void SpawnPlatforms(GameObject platform, ref Vector3 spawnPosition, Transform parent)
        {
            Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
            spawnPosition.y -= 1;
        }
    }
}

