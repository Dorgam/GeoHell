using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartOnPlayerDeath : MonoBehaviour
{
    private void OnDestroy()
    {
        if(GetComponent<Damageable>().CurrentHealth == 0) // If level is destroyed player will be destroyed, so this is a safety check
            LevelManager.Instance.LoadLevel(Level.Lose);
    }
}
