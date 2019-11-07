using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _rigidbody2D;
    
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetRotation(Vector2 v)
    {
        if(_rigidbody2D == null)
            return;

        /*float newRotation = -Util.AngleFromVector2(v);
        
        if(Mathf.Abs(newRotation) > 10)
            _rigidbody2D.MoveRotation(newRotation);*/
        
        _rigidbody2D.MoveRotation(-Util.AngleFromVector2(v));
    }
}
