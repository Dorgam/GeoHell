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
    public SharedFloat speed;
    private Rigidbody2D _rigidbody2D;
    private GameObject _spawnedEnemy;
    private Transform _locationsGrid;
    private Vector3 _spawnTargetPos;
    private Vector3 _startTargetPos;

    public override void OnStart()
    {
        GlobalVariables.Instance.SetVariableValue("EnemiesAlive", (int) GlobalVariables.Instance.GetVariable("EnemiesAlive").GetValue() + 1);
        _locationsGrid = GameObject.FindWithTag("LocationsGrid").transform;
        _spawnTargetPos = _locationsGrid.GetChild((int) spawnTarget.Value.x - 1).GetChild((int) spawnTarget.Value.y - 1).position;
        _startTargetPos = _locationsGrid.GetChild((int) startTarget.Value.x - 1).GetChild((int) startTarget.Value.y - 1).position;
        _spawnedEnemy = GameObject.Instantiate(enemy.Value, _spawnTargetPos, Quaternion.identity);
        _rigidbody2D = _spawnedEnemy.GetComponent<Rigidbody2D>();
    }
    
    public override void OnFixedUpdate()
    {
        if(_spawnedEnemy == null)
            return;
        
        Vector3 currentPosition = _spawnedEnemy.transform.position;
        Vector2 moveDirection = (_startTargetPos - currentPosition).normalized;
        _rigidbody2D.MovePosition((Vector2) currentPosition + Time.deltaTime * speed.Value * moveDirection);
    }

    public override TaskStatus OnUpdate()
    {
        if (_spawnedEnemy == null)
            return TaskStatus.Success;
        
        if (Vector2.Distance(_spawnedEnemy.transform.position, _startTargetPos) < 0.05f)
        {
            _spawnedEnemy.GetComponent<BehaviorTree>().EnableBehavior();
            return TaskStatus.Success;
        }

        return TaskStatus.Running;
    }
}
