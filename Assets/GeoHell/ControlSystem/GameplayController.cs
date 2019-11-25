using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameplayController : MonoBehaviour
{
    private MyPlayerActions _playerActions;
    
    [SerializeField] private Move move;
    [SerializeField] private Shoot shoot;
    [SerializeField] private Rotate rotate;

    private void Awake()
    {
        _playerActions = new MyPlayerActions();
    }

    private void Update()
    {
        CheckActionsPressed();
        CheckActionsReleased();
        SetRotation();
        SetMovement();
    }

    private void SetMovement()
    {
        move.SetMovement(_playerActions.Move.Value);
    }

    private void SetRotation()
    {
        rotate.SetRotation(_playerActions.Rotate.Value);
    }
    
    private void CheckActionsReleased()
    {
        if (_playerActions.Shoot.WasReleased)
        {
            if (shoot != null) shoot.StopShooting();
        }
    }

    private void CheckActionsPressed()
    {
        if (_playerActions.Shoot.WasPressed)
        {
            if (shoot != null) shoot.StartShooting();
        }
    }
}
