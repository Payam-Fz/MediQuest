using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<WaveConfig> waveConfigs;
    //[SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);

    }

    private IEnumerator SpawnAllWaves()
    {
        // New: To randomly start waves of NPCs
        while (true)
        {
            int waveIndex = Random.Range(0, waveConfigs.Count);
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    
        // Old
        /*for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
        */
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWayPoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<NPCMover>().SetWaveConfig(waveConfig);
            CharacterAnimator animator = newEnemy.GetComponent<CharacterAnimator>();
            animator.setSpriteType(Random.Range(1, animator.DIFFERENT_HAIR_TYPES + 1),
                Random.Range(1, animator.DIFFERENT_SKIN_TYPES + 1),
                Random.Range(1, animator.DIFFERENT_CLOTHING_TYPES + 1));
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns()*(1 + Random.Range(waveConfig.GetSpawnRandomFactor()*-1, waveConfig.GetSpawnRandomFactor())));

        }
    }
}
