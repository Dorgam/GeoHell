using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    [SerializeField] private TextAsset playthroughJson;
    private Playthrough _playthrough;
    private int _currentWaveNumber;
    private EnemyInstantiator _instantiator;

    private void Awake()
    {
        _playthrough = JsonUtility.FromJson<Playthrough>(playthroughJson.text);
        _instantiator = GetComponent<EnemyInstantiator>();
    }

    private void Start()
    {
        StartCoroutine(StartPlaythrough(_playthrough));
    }

    private IEnumerator StartPlaythrough(Playthrough playthrough)
    {
        for (int i = 0; i < playthrough.waves.Length; i++)
        {
            _currentWaveNumber = i;
            StartWave(playthrough.waves[i]);
            yield return new WaitForSeconds(1);
            while (!IsWaveDone(i))
            {
                yield return null;
            }
            Debug.Log("Wave is Done!");
        }
        LevelManager.Instance.LoadLevel(Level.Win);
    }

    private bool IsWaveDone(int waveIndex)
    {
        return GameParameters.Instance.EnemiesAlive == 0;
    }

    private void StartWave(Wave wave)
    {
        for (int i=0; i < wave.spawns.Length; i++)
        {
            StartCoroutine(StartSpawn(wave.spawns[i]));
        }
    }

    private IEnumerator StartSpawn(Spawn spawn)
    {
        yield return new WaitForSeconds(spawn.delayBeforeSpawn);
        for (int i = 0; i < spawn.enemies.Length; i++)
        {
            SpawnEnemy(spawn.enemies[i]);
        }
    }

    private GameObject SpawnEnemy(Enemy enemy)
    {
        return _instantiator.InstantiateEnemy(enemy.name, new Vector2(enemy.spawnLocation[0], enemy.spawnLocation[1]),
            new Vector2(enemy.targetLocation[0], enemy.targetLocation[1]));
    }
}
