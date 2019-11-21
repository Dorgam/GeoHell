using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiator : MonoBehaviour
{
    [SerializeField] private EnemyDictionary enemyDictionary;
    private Transform _locationsGrid;

    private void Awake()
    {
        _locationsGrid = GameObject.FindWithTag("LocationsGrid").transform;
    }

    public GameObject InstantiateEnemy(string enemyName, Vector2 spawn, Vector2 target)
    {
        GameObject prefab = enemyDictionary[enemyName];
        return InstantiateEnemy(prefab, spawn, target);
    }
    
    public GameObject InstantiateEnemy(GameObject prefab, Vector2 spawn, Vector2 target)
    {
        Vector3 spawnPos = _locationsGrid.GetChild((int) spawn.x - 1).GetChild((int) spawn.y - 1).position;
        GameObject spawnedEnemy = GameObject.Instantiate(prefab, spawnPos, Quaternion.identity);
        spawnedEnemy.GetComponent<SpawnMove>().StartMove(target);
        return spawnedEnemy;
    }
}
