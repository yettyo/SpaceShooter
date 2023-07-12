using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")] 
public class WaveConfigSO : ScriptableObject
{   
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0.5f;
    [SerializeField] float minSpawnTime = 0.2f;
    
    public int GetEnemyCount() {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index) {
        return enemyPrefabs[index];
    }

    public Transform getStartingWaypoint() {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints() {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab) {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMovementSpeed() {
        return movementSpeed;
    }

    public float getRandomSpawnTime() {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance, timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
    }
}
