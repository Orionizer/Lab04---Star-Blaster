using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaves", menuName = "New EnemyWaves")]
public class EnemyWaves : ScriptableObject
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Transform myEnemyWave;
    [SerializeField] float EnemySpeed;
    [SerializeField] float TimeBetweenEnemySpawns;
    [SerializeField] float enemySpawnVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0f;

    public int GetEnemyCount()
    {
        return enemyPrefabs.Length;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }
    public Transform GetStartingWaypoint()
    {
        return myEnemyWave.GetChild(0);
    }
    public float GetEnemyMoveSpeed()
    {
        return EnemySpeed;
    }
    public Transform[] WavePoints()
    {
        Transform[] WaveMovePoints = new Transform[myEnemyWave.childCount];
        for (int i = 0; i < myEnemyWave.childCount; i++)
        {
            WaveMovePoints[i] = myEnemyWave.GetChild(i);
        }
        return WaveMovePoints;
    }

    public float GetRandomEnemySpawnTime()
    {
        float spawnTime = Random.Range(TimeBetweenEnemySpawns - enemySpawnVariance, TimeBetweenEnemySpawns + enemySpawnVariance);

        spawnTime = Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);

        return spawnTime;
    }
}