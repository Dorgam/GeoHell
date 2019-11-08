using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateEnemyCount : MonoBehaviour
{
    private void Awake()
    {
        GameParameters.Instance.EnemiesAlive++;
    }

    private void OnDestroy()
    {
        GameParameters.Instance.EnemiesAlive--;
    }
}
