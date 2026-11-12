using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyWaves[] waves;
    [SerializeField] float TimeBetweenWaves = 1f;
    EnemyWaves currentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        foreach (EnemyWaves wave in waves)
        {
            currentWave = wave;
            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
                Instantiate(
                    currentWave.GetEnemyPrefab(i),
                    currentWave.GetStartingWaypoint().position,
                    Quaternion.identity,
                    transform);
                yield return new WaitForSeconds(currentWave.GetRandomEnemySpawnTime());
            }
            yield return new WaitForSeconds(TimeBetweenWaves);
        }
    }

    public EnemyWaves GetCurrentWave()
    {
        return currentWave;
    }
}
