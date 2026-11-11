using UnityEngine;

public class MoveEnemy_1 : MonoBehaviour
{
    [SerializeField] EnemyWaves WaveEnemy;
    [SerializeField] float EnemySpeed;
    int pointIndex = 0;
    Transform[] getPointsWave;
    void Start()
    {
        getPointsWave = WaveEnemy.WavePoints();
    }

    // Update is called once per frame
    void Update()
    {
        PathWaves();
    }
    public void PathWaves()
    {
        Vector3 WaveTargetPositions = getPointsWave[pointIndex].position;
        transform.position = Vector2.MoveTowards(transform.position,WaveTargetPositions, EnemySpeed*Time.deltaTime);
        if(transform.position == WaveTargetPositions)
        {
            pointIndex++;
            if (pointIndex >= getPointsWave.Length)
            {
                pointIndex = 0;
            }
        }
    }
}
