using System;
using System.Collections;
using System.Collections.Generic;
using GeoHell.PlayerActions;
using GeoHell.ShootersSystem;
using UnityEngine;

namespace GeoHell.Pickups
{
    public class AddNewPlayerWeapon : MonoBehaviour
    {
        [SerializeField] private GameObject weapon;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
                return;
            
            other.GetComponent<Shoot>().AddWeapon(weapon);
            Destroy(gameObject);
        }
    }
}
