using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoundManager : MonoBehaviour
{
    [System.Serializable]
    public class EnemySpawnData {
        public GameObject enemyPrefab;
        public EnemyType type;
        public int weight; // Higher = more likely to spawn

        public float baseHealth = 5f;
        public float baseSpeed = 5f;

        [HideInInspector] public float scaledHealth;
        [HideInInspector] public float scaledSpeed;
    }

    public List<EnemySpawnData> enemies;
    public Transform[] spawnPoints; // Drag spawn locations here
    public int enemiesPerRound = 10;

    public int currentRound = 1;
    private List<Enemy> activeEnemies = new List<Enemy>();

    public void StartRound() {
        ScaleEnemyData(); // Apply scaling based on currentRound
        StartCoroutine(SpawnEnemies());
        currentRound++;
        enemiesPerRound += 2;
    }

    void ScaleEnemyData() {
        foreach (var enemy in enemies) {
            if (enemy.type == EnemyType.Lead || enemy.type == EnemyType.Shielded) {
                enemy.weight += Mathf.FloorToInt(currentRound / 2f);
            }

            // Scale stats
            if (enemy.baseHealth + currentRound * 1.5f < enemy.baseHealth + 10) {
                enemy.scaledHealth = enemy.baseHealth + currentRound * 1.5f;
            }
            if (enemy.baseSpeed + currentRound * 0.2f < enemy.baseSpeed + 2f) {
                enemy.scaledSpeed = enemy.baseSpeed + currentRound * 0.2f;
            }
        }
    }

    IEnumerator SpawnEnemies() {
        List<EnemySpawnData> spawnPool = BuildWeightedPool();

        for (int i = 0; i < enemiesPerRound; i++) {
            EnemySpawnData data = spawnPool[Random.Range(0, spawnPool.Count)];
            int lane = Random.Range(0, spawnPoints.Length);

            GameObject enemyGO = Instantiate(data.enemyPrefab, spawnPoints[lane].position, Quaternion.Euler(0,-90,0));
            Enemy enemyScript = enemyGO.GetComponent<Enemy>();

            enemyScript.health = data.scaledHealth;
            enemyScript.speed = data.scaledSpeed;

            yield return new WaitForSeconds(1f); // Delay between spawns
        }

        currentRound++;
        enemiesPerRound += 2; // increase each round
    }

    List<EnemySpawnData> BuildWeightedPool() {
        List<EnemySpawnData> pool = new List<EnemySpawnData>();

        foreach ( var data in enemies) {
            for (int i = 0; i < data.weight; i++) {
                pool.Add(data);
            }
        }

        return pool;
    }
}
