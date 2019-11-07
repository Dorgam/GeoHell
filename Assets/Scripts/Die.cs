using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
