using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class GameParameters : Singleton<GameParameters>
{
    [SerializeField] private int bulletsAlive;
    [SerializeField] private int enemiesAlive;

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

    public int BulletsAlive
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
}
