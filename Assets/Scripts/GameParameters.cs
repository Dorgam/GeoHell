using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class GameParameters : Singleton<GameParameters>
{
    [SerializeField] private float enemyWeight;
    [SerializeField] private float playerHealthWeight;
    [SerializeField] private float bulletsWeight;
    private float bulletsAlive;
    private int enemiesAlive;

    private Damageable _playerDamageable;

    public int EnemiesAlive
    {
        get => enemiesAlive;
        set
        {
            enemiesAlive = value;
            GlobalVariables.Instance.SetVariableValue("EnemiesAlive", enemiesAlive);
        }
    }

    public float BulletsAlive
    {
        get => bulletsAlive;
        set => bulletsAlive = value;
    }

    public float PlayerHealth
    {
        get
        {
            if (_playerDamageable == null)
            {
                _playerDamageable = GameObject.FindGameObjectWithTag("Player").GetComponent<Damageable>();
            }

            return _playerDamageable.CurrentHealth;
        }
    }

    public float Tension => enemiesAlive * enemyWeight + PlayerHealth * playerHealthWeight + bulletsAlive * bulletsWeight;

    private void Start()
    {
        DebugGUI.SetGraphProperties("tension", "Tension", 0, 1500, 0, new Color(1, 1, 0), true);
        StartCoroutine(ReportTension());
    }

    private IEnumerator ReportTension()
    {
        yield return new WaitForSeconds(5);
        while (true)
        {
            DebugGUI.Graph("tension", Tension);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
