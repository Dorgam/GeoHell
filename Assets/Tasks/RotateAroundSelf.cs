using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class RotateAroundSelf : Action
{
    public SharedFloat _rotationSpeed;
    private Rigidbody2D _rigidbody2D;

    public override void OnStart()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public override void OnFixedUpdate()
    {
        _rigidbody2D.MoveRotation(_rigidbody2D.rotation + _rotationSpeed.Value * Time.deltaTime);
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.Running;
    }
}
