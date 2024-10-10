using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using Random = UnityEngine.Random;

namespace Global
{
    public class EnemySpawnerManager : MonoBehaviour
    {  
        [SerializeField] private float spawnDistance = 1f;
        [SerializeField] private float spawnIntervalTime = 2f;
        [SerializeField] private int numberOfEnemiesToSpawn = 5; 
        [SerializeField] private List<EnemyData> enemies;
        
        [Space]
        [Header("References")]
        [SerializeField] private DifficultyManager difficultyManager;
        
        private bool isSpawnOnDuration = false; 
        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
            difficultyManager = GameManager.Instance.difficultyManager;
            difficultyManager.OnDifficultyLevelChanged += IncreaseDifficulty;
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

        public void SpawnObjectOutsideScreen()
        {
            for (var i = 0; i < numberOfEnemiesToSpawn; i++)
            {
                var spawnPosition = GetRandomPositionOutsideScreen();
                var enemyObject = GetRandomEnemy().enemyPrefab;
                Instantiate(enemyObject, (Vector2)spawnPosition, Quaternion.identity);
            } 
        } 
        private void IncreaseDifficulty(int obj)
        {
            spawnIntervalTime -= 0.1f;
            numberOfEnemiesToSpawn += 1;
        }

        
        private IEnumerator SpawnEnemies()
        {
            isSpawnOnDuration = true;
            SpawnObjectOutsideScreen();
            yield return new WaitForSeconds(spawnIntervalTime); 
            isSpawnOnDuration = false;
        }
        
        private EnemyData GetRandomEnemy()
        { 
            if (enemies == null || enemies.Count == 0)
            {
                throw new InvalidOperationException("No enemies available to spawn.");
            }
            var randomIndex = Random.Range(0, enemies.Count);
            return enemies[randomIndex];
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
