using UnityEngine;

namespace GeoHell.Utils
{
    /// <summary>
    /// When an item escapes screen view, it is destroyed (useful for bullets)
    /// </summary>
    public class DestroyWhenNotVisible : MonoBehaviour
    {
        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
