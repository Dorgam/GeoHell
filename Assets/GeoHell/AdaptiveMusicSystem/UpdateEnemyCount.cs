using UnityEngine;

namespace GeoHell.AdaptiveMusicSystem
{
    /// <summary>
    /// A component that is placed on enemies gameObjects to update the count of enemies when they are created
    /// and when they are destroyed
    /// </summary>
    public class UpdateEnemyCount : MonoBehaviour
    {
        private void Awake()
        {
            GameParameters.Instance.EnemiesAlive++;
        }

        private void OnDestroy()
        {
            GameParameters.Instance.EnemiesAlive--;
        }
    }
}
