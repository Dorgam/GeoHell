using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class SpawnEnemy : Action
{
    public SharedGameObject enemy;
    public SharedVector2 spawnTarget;
    public SharedVector2 startTarget;
    private EnemyInstantiator _instantiator;

    public override void OnStart()
    {
        GlobalVariables.Instance.SetVariableValue("EnemiesAlive", (int) GlobalVariables.Instance.GetVariable("EnemiesAlive").GetValue() + 1);
        _instantiator = GetComponent<EnemyInstantiator>();
    }
    
    public override TaskStatus OnUpdate()
    {
        _instantiator.InstantiateEnemy(enemy.Value, spawnTarget.Value, startTarget.Value);
        return TaskStatus.Success;
    }
}
