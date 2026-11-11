using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaves", menuName = "New EnemyWaves")]
public class EnemyWaves : ScriptableObject
{
    [SerializeField] Transform myEnemyWave;
    [SerializeField] float EnemySpeed;
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
}