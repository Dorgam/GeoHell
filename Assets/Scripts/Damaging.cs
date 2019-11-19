using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaging : MonoBehaviour
{
    [SerializeField] private ParticleSystem onDeathParticleSystem;
    [SerializeField] private float inflictedDamage;
    [SerializeField] private bool shakeScreenOnDamage = true;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Damageable damageable = other.gameObject.GetComponent<Damageable>();
        
        if (damageable != null)
        {
            damageable.InflictDamage(inflictedDamage);
        }
        
        if (onDeathParticleSystem != null)
        {
            Instantiate(onDeathParticleSystem, transform.position, Quaternion.identity);
            CamShake.Shake(0.2f, 0.05f);
        }

        Destroy(gameObject);
    }
}
