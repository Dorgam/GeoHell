using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace GeoHell.EnemyActions
{
    /// <summary>
    /// An enemy task in the behavior tree that allows enemies to constantly rotate around themselves.
    /// Useful to spread interesting patterns of bullets.
    /// </summary>
    public class RotateAroundSelf : Action
    {
        public SharedFloat RotationSpeed;
        private Rigidbody2D _rigidbody2D;

        public override void OnStart()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public override void OnFixedUpdate()
        {
            _rigidbody2D.MoveRotation(_rigidbody2D.rotation + RotationSpeed.Value * Time.deltaTime);
        }

        public override TaskStatus OnUpdate()
        {
            return TaskStatus.Running;
        }
    }
}
