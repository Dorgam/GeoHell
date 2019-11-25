using GeoHell.EnemyActions;
using UnityEngine;

namespace GeoHell.ConductorSystem
{
    /// <summary>
    /// Responsible for instantiating enemies in the scene.
    /// </summary>
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
            var prefab = enemyDictionary[enemyName];
            return InstantiateEnemy(prefab, spawn, target);
        }
    
        public GameObject InstantiateEnemy(GameObject prefab, Vector2 spawn, Vector2 target)
        {
            var spawnPos = _locationsGrid.GetChild((int) spawn.x - 1).GetChild((int) spawn.y - 1).position;
            var spawnedEnemy = GameObject.Instantiate(prefab, spawnPos, Quaternion.identity);
            spawnedEnemy.GetComponent<SpawnMove>().StartMove(target);
            return spawnedEnemy;
        }
    }
}
