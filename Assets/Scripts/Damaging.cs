using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaging : MonoBehaviour
{
    [SerializeField] private ParticleSystem onDeathParticleSystem;
    [SerializeField] private float inflictedDamage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Damageable damageable = other.gameObject.GetComponent<Damageable>();
        
        if (damageable != null)
        {
            damageable.InflictDamage(inflictedDamage);
        }

        if (onDeathParticleSystem != null)
        {
            Instantiate(onDeathParticleSystem, transform);
        }
        
        Destroy(gameObject);
    }
}
