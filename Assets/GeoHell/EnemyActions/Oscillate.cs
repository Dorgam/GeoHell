using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace GeoHell.EnemyActions
{
    /// <summary>
    /// An enemy task in the behavior tree that allows the enemy to oscillate between movement directions either
    /// horizontally or vertically.
    /// </summary>
    public class Oscillate : Action
    {
        public SharedBool IsHorizontal;
        public SharedBool StartPositive;
        public SharedFloat Speed;
        public SharedFloat SecondsBetweenDirectionChange;
        private IEnumerator _oscillateCoroutine;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _direction;

        public override void OnStart()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _direction = IsHorizontal.Value ? Vector2.right : Vector2.up;
            _direction = StartPositive.Value ? _direction : -_direction;
        
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
                _rigidbody2D.velocity = _direction * Speed.Value;
                yield return new WaitForSeconds(SecondsBetweenDirectionChange.Value);
                _rigidbody2D.velocity = -_direction * Speed.Value;
                yield return new WaitForSeconds(SecondsBetweenDirectionChange.Value);
            }
        }

        public override void OnEnd()
        {
            StopCoroutine(_oscillateCoroutine);
        }
    }
}
