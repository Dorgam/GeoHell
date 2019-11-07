using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public enum CharacterType
{
    Right,
    Left
}

public class Move : MonoBehaviour
{
    public float speed;
    public CharacterType characterType;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetMovement(Vector2 v)
    {
        if(_rigidbody2D == null)
            return;
        
        _rigidbody2D.velocity = v * speed;
    }

    public void StartMoving(string movement)
    {
        Vector2 currentVelocity = _rigidbody2D.velocity;
        float directionMod = characterType == CharacterType.Right ? 1 : -1;
        
        if (movement == "Right")
        {
            _rigidbody2D.velocity = new Vector2(directionMod * speed, currentVelocity.y);
        }
        else if(movement == "Left")
        {
            _rigidbody2D.velocity = new Vector2(directionMod * -speed, currentVelocity.y);
        }
        else if(movement == "Up")
        {
            _rigidbody2D.velocity = new Vector2(currentVelocity.x, directionMod * speed);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(currentVelocity.x, directionMod * -speed);
        }
    }

    public void StopMoving(string movement)
    {
        Vector2 currentVelocity = _rigidbody2D.velocity;
        float directionMod = characterType == CharacterType.Right ? 1 : -1;
        
        if (movement == "Right" || movement == "Left")
        {
            _rigidbody2D.velocity = new Vector2(0, currentVelocity.y);
        }
        else if(movement == "Up" || movement == "Down")
        {
            _rigidbody2D.velocity = new Vector2(currentVelocity.x, 0);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(currentVelocity.x, 0);
        }
    }
}
