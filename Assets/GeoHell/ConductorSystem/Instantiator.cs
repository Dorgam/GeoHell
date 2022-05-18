using GeoHell.EnemyActions;
using UnityEngine;
using UnityEngine.Serialization;

namespace GeoHell.ConductorSystem
{
    /// <summary>
    /// Responsible for instantiating enemies in the scene.
    /// </summary>
    public class Instantiator : MonoBehaviour
    {
        [SerializeField] private SpawnableDictionary spawnableDictionary;
        private Transform _locationsGrid;

        private void Awake()
        {
            _locationsGrid = GameObject.FindWithTag("LocationsGrid").transform;
        }

        public GameObject InstantiateSpawnable(string spawnName, Vector2 location)
        {
            var prefab = spawnableDictionary[spawnName];
            return InstantiateSpawnable(prefab, location);
        }
    
        public GameObject InstantiateSpawnable(GameObject prefab, Vector2 location)
        {
            var spawnPos = _locationsGrid.GetChild((int) location.x - 1).GetChild((int) location.y - 1).position;
            var spawn = Instantiate(prefab, spawnPos, Quaternion.identity);
            return spawn;
        }
    }
}
