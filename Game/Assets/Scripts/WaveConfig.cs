using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.2f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveEnemySpeed = 2f;


    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }
    public List<Transform> GetWayPoints()
    {
        var waveWavepoint = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWavepoint.Add(child);
        }
        return waveWavepoint;
    }
    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }
    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }
    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }
    public float GetMoveEnemySpeed()
    {
        return moveEnemySpeed;
    }
}
