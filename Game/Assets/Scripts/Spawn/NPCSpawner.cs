using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles spawning of random NPCs givena list of customized WaveConfig
 * Author: Alexander R @ 2021-02-21
 * Updated: Payam F @ 2021-12-05
 */
public class NPCSpawner : MonoBehaviour
{

    [SerializeField] List<WaveConfig> waveConfigs;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //Payam F: removed looping because unnecessary
            yield return StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves()
    {
        // Payam F: To randomly start waves of NPCs
        while (true)
        {
            int waveIndex = Random.Range(0, waveConfigs.Count);
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnNPCsInWave(currentWave));
        }
    }

    private IEnumerator SpawnNPCsInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            var newNPC = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWayPoints()[0].transform.position, Quaternion.identity);
            newNPC.transform.SetParent(gameObject.transform);
            newNPC.GetComponent<NPCMover>().SetWaveConfig(waveConfig);
            CharacterAnimator animator = newNPC.GetComponent<CharacterAnimator>();
            animator.setSpriteType(Random.Range(1, animator.DIFFERENT_HAIR_TYPES + 1),
                Random.Range(1, animator.DIFFERENT_SKIN_TYPES + 1),
                Random.Range(1, animator.DIFFERENT_CLOTHING_TYPES + 1));
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns()*(1 + Random.Range(waveConfig.GetSpawnRandomFactor()*-1, waveConfig.GetSpawnRandomFactor())));

        }
    }
}
