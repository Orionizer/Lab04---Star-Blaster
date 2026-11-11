using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaves", menuName = "Scriptable Objects/EnemyWaves")]
public class EnemyWaves : ScriptableObject
{
    [SerializeField] Transform myEnemyWave;
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