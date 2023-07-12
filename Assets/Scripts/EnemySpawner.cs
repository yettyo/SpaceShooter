using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;
    void Start()
    {
        SpawnEnemies();
    }

    public WaveConfigSO getCurrentWave() {
        return currentWave;
    }
    void SpawnEnemies() {
        Instantiate(currentWave.GetEnemyPrefab(0), 
            currentWave.getStartingWaypoint().position, 
            Quaternion.identity);
    }
}
