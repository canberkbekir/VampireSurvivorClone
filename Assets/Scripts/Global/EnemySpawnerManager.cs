using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

namespace Global
{
    public class EnemySpawnerManager : MonoBehaviour
    { 
        [SerializeField] private GameObject objectToSpawn;
        [SerializeField] private float spawnDistance = 1f;
        [SerializeField] private float spawnIntervalTime = 2f;
        [SerializeField] private int numberOfEnemiesToSpawn = 5;  
        
        private bool isSpawnOnDuration = false;

        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main; 
        }

        private void Update()
        {
            if (!isSpawnOnDuration)
            {
                StartSpawning();
            }
        }

        public void StartSpawning()
        {
            StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            isSpawnOnDuration = true;
            SpawnObjectOutsideScreen();
            yield return new WaitForSeconds(spawnIntervalTime); 
            isSpawnOnDuration = false;
        }

        public void SpawnObjectOutsideScreen()
        {
            for (var i = 0; i < numberOfEnemiesToSpawn; i++)
            {
                Vector3 spawnPosition = GetRandomPositionOutsideScreen();
                Instantiate(objectToSpawn, (Vector2)spawnPosition, Quaternion.identity);
            } 
        }

        private Vector3 GetRandomPositionOutsideScreen()
        {
            var screenPosition = Vector3.zero;
            var side = Random.Range(0, 4);

            screenPosition = side switch
            {
                0 => // Top
                    new Vector3(Random.Range(0, Screen.width), Screen.height + spawnDistance, mainCamera.nearClipPlane),
                1 => // Bottom
                    new Vector3(Random.Range(0, Screen.width), -spawnDistance, mainCamera.nearClipPlane),
                2 => // Left
                    new Vector3(-spawnDistance, Random.Range(0, Screen.height), mainCamera.nearClipPlane),
                3 => // Right
                    new Vector3(Screen.width + spawnDistance, Random.Range(0, Screen.height), mainCamera.nearClipPlane),
                _ => screenPosition
            };
            return mainCamera.ScreenToWorldPoint(screenPosition);
        }
    }
}
