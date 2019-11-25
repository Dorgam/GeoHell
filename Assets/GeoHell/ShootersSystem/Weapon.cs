using UnityEngine;

namespace GeoHell.ShootersSystem
{
    /// <summary>
    /// Every character in the game (player or enemy) has a set of weapons that they can shoot
    /// </summary>
    public class Weapon : MonoBehaviour
    {
        public string weaponName;
        [HideInInspector] public bool isShooting = false;
        [SerializeField] private Muzzle[] muzzles;

        public void Fire()
        {
            isShooting = true;
            foreach (Muzzle muzzle in muzzles)
            {
                muzzle.Fire();
            }
        }

        public void Stop()
        {
            isShooting = false;
            foreach (Muzzle muzzle in muzzles)
            {
                muzzle.Stop();
            }
        }
    }
}
