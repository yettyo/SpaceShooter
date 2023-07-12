using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    WaveConfigSO currentWave;
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO getCurrentWave() {
        return currentWave;
    }
    IEnumerator SpawnEnemyWaves() {
        foreach(WaveConfigSO wave in waveConfigs) {
            currentWave = wave;
            for(int i = 0; i < currentWave.GetEnemyCount(); i++) {
                Instantiate(currentWave.GetEnemyPrefab(i), 
                currentWave.getStartingWaypoint().position, 
                Quaternion.identity,
                transform);
                yield return new WaitForSeconds(currentWave.getRandomSpawnTime());
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
        
        
    }
}
