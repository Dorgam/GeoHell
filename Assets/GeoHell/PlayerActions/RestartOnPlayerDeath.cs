using GeoHell.LevelSystem;
using GeoHell.MortalSystem;
using UnityEngine;

namespace GeoHell.PlayerActions
{
    /// <summary>
    /// Player component that restarts the game on player death
    /// </summary>
    public class RestartOnPlayerDeath : MonoBehaviour
    {
        private void OnDestroy()
        {
            Damageable damageable = GetComponent<Damageable>();
            if(damageable != null && damageable.CurrentHealth == 0) // If level is destroyed player will be destroyed, so this is a safety check
                LevelManager.Instance.LoadLevel(Level.Lose);
        }
    }
}
