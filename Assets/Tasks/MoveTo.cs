using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class MoveTo : Action
{
    public SharedFloat _speed;
    public SharedTransform _target;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _moveDirection;
    
    public override void OnStart()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public override void OnFixedUpdate()
    {
        _moveDirection = (_target.Value.position - transform.position).normalized;
        _rigidbody2D.MovePosition(transform.position + Time.deltaTime * _speed.Value * _moveDirection);
    }

    public override TaskStatus OnUpdate()
    {
        if (Vector2.Distance(transform.position, _target.Value.position) < 0.05f)
        {
            return TaskStatus.Success;
        }
        
        return TaskStatus.Running;
    }
}
