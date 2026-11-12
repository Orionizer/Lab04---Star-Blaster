using UnityEngine;

public class MoveEnemy_1 : MonoBehaviour
{
    EnemySpawner enemySpawner;
    EnemyWaves WaveEnemy;
    int pointIndex = 0;
    Transform[] getPointsWave;
    void Start()
    {
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
        WaveEnemy = enemySpawner.GetCurrentWave();
        getPointsWave = WaveEnemy.WavePoints();
        transform.position = WaveEnemy.GetStartingWaypoint().position;
    }

    // Update is called once per frame
    void Update()
    {
        PathWaves();
    }
    public void PathWaves()
    {
        Vector3 WaveTargetPositions = getPointsWave[pointIndex].position;
        float moveDelta = WaveEnemy.GetEnemyMoveSpeed() * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position,WaveTargetPositions, moveDelta);
        if(transform.position == WaveTargetPositions)
        {
            pointIndex++;
            if (pointIndex >= getPointsWave.Length)
            {
                Destroy(gameObject);
            }
        }
    }
}
