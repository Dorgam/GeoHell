using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
