using UnityEngine;

namespace GeoHell.AdaptiveMusicSystem
{
    /// <summary>
    /// A component that is placed on bullets to update the total count of bullets when
    /// they are created and when they are destroyed.
    /// </summary>
    public class UpdateBulletCount : MonoBehaviour
    {
        private void Awake()
        {
            GameParameters.Instance.BulletsAlive++;
        }

        private void OnDestroy()
        {
            GameParameters.Instance.BulletsAlive--;
        }
    }
}
