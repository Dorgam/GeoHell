using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Oscillate : Action
{
    public SharedBool isHorizontal;
    public SharedBool startPositive;
    public SharedFloat speed;
    public SharedFloat secondsBetweenDirectionChange;
    private IEnumerator _oscillateCoroutine;
    private Rigidbody2D _rigidbody2D;
    private Vector2 direction;

    public override void OnStart()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        direction = isHorizontal.Value ? Vector2.right : Vector2.up;
        direction = startPositive.Value ? direction : -direction;
        
        if (_oscillateCoroutine != null)
        {
            StopCoroutine(_oscillateCoroutine);
        }

        _oscillateCoroutine = OscillateIe();
        StartCoroutine(_oscillateCoroutine);
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.Running;
    }

    private IEnumerator OscillateIe()
    {
        while (true)
        {
            _rigidbody2D.velocity = direction * speed.Value;
            yield return new WaitForSeconds(secondsBetweenDirectionChange.Value);
            _rigidbody2D.velocity = -direction * speed.Value;
            yield return new WaitForSeconds(secondsBetweenDirectionChange.Value);
        }
    }

    public override void OnEnd()
    {
        StopCoroutine(_oscillateCoroutine);
    }
}
