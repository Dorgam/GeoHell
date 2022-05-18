using System.Collections.Generic;
using System.Linq;
using GeoHell.ShootersSystem;
using UnityEngine;

namespace GeoHell.PlayerActions
{
    /// <summary>
    /// A player action that allows the player to shoot
    /// </summary>
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private Weapon currentWeapon;
        private List<Weapon> _weapons;

        private void Awake()
        {
            _weapons = new List<Weapon>(GetComponentsInChildren<Weapon>());
        }

        public void AddWeapon(GameObject weapon)
        {
            Weapon w = weapon.GetComponent<Weapon>();
        
            Weapon newWeapon;
            if (_weapons.All(x => x.weaponName != w.weaponName))
            {
                newWeapon = Instantiate(weapon, transform).GetComponent<Weapon>();
            }
            else
            {
                newWeapon = _weapons.Single(x => x.weaponName == w.weaponName);
            }

            currentWeapon.Stop();
            currentWeapon = newWeapon;
        }

        public void StartShooting(string weaponName)
        {
            currentWeapon = _weapons.Single(x => x.weaponName == weaponName);
            StartShooting();
        }
    
        public void StopShooting(string weaponName)
        {
            _weapons.Single(x => x.weaponName == weaponName).Stop();
        }

        public void StartShooting()
        {
            if (!currentWeapon.isShooting)
            {
                currentWeapon.Fire();
            }
        }

        public void StopShooting()
        {
            currentWeapon.Stop();
        }
    }
}
