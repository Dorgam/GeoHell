using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class SpawnMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform _locationsGrid;
    private Vector3 _target;
    private Rigidbody2D _rigidbody2D;
    private bool isDone = false;

    public void StartMove(Vector2 target)
    {
        _locationsGrid = GameObject.FindWithTag("LocationsGrid").transform;
        _target = _locationsGrid.GetChild((int) target.x - 1).GetChild((int) target.y - 1).position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    public void FixedUpdate()
    {
        if(isDone)
            return;
        
        Vector3 currentPosition = transform.position;
        Vector2 moveDirection = (_target - currentPosition).normalized;
        _rigidbody2D.MovePosition((Vector2) currentPosition + Time.deltaTime * speed * moveDirection);
    }

    public void Update()
    {
        if(isDone)
            return;
        
        if (Vector2.Distance(transform.position, _target) < 0.05f)
        {
            isDone = true;
            GetComponent<BehaviorTree>().EnableBehavior();
        }
    }
}
