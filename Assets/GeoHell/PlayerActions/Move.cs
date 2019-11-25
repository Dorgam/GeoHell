using System;
using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;

namespace GeoHell.PlayerActions
{
    /// <summary>
    /// A component that allows the player to move his character
    /// </summary>
    public class Move : MonoBehaviour
    {
        public float speed;
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

            if (movement == "Right")
            {
                _rigidbody2D.velocity = new Vector2(speed, currentVelocity.y);
            }
            else if(movement == "Left")
            {
                _rigidbody2D.velocity = new Vector2(-speed, currentVelocity.y);
            }
            else if(movement == "Up")
            {
                _rigidbody2D.velocity = new Vector2(currentVelocity.x, speed);
            }
            else
            {
                _rigidbody2D.velocity = new Vector2(currentVelocity.x, -speed);
            }
        }

        public void StopMoving(string movement)
        {
            Vector2 currentVelocity = _rigidbody2D.velocity;

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
}