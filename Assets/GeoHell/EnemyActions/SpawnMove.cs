using BehaviorDesigner.Runtime;
using UnityEngine;

namespace GeoHell.EnemyActions
{
    /// <summary>
    /// A special movement behavior for enemies that allows to move between the spawn point, and the point where
    /// the enemies will start shooting.
    /// </summary>
    public class SpawnMove : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Transform _locationsGrid;
        private Vector3 _target;
        private Rigidbody2D _rigidbody2D;
        private bool _isDone = false;

        public void StartMove(Vector2 target)
        {
            _locationsGrid = GameObject.FindWithTag("LocationsGrid").transform;
            _target = _locationsGrid.GetChild((int) target.x - 1).GetChild((int) target.y - 1).position;
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
    
        public void FixedUpdate()
        {
            if(_isDone)
                return;
        
            Vector3 currentPosition = transform.position;
            Vector2 moveDirection = (_target - currentPosition).normalized;
            _rigidbody2D.MovePosition((Vector2) currentPosition + Time.deltaTime * speed * moveDirection);
        }

        public void Update()
        {
            if(_isDone)
                return;
        
            if (Vector2.Distance(transform.position, _target) < 0.05f)
            {
                _isDone = true;
                GetComponent<BehaviorTree>().EnableBehavior();
            }
        }
    }
}
