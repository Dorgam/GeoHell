using UnityEngine;

namespace GeoHell.MortalSystem
{
    /// <summary>
    /// A component that allows a gameObject to die with style (spawning a particle system)
    /// </summary>
    public class Die : MonoBehaviour
    {
        [SerializeField] private ParticleSystem dyingEffect;
    
        public void StartDying()
        {
            if (dyingEffect != null)
            {
                Instantiate(dyingEffect, transform);
            }
        
            Destroy(gameObject);
        }
    }
}
