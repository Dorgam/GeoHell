using GeoHell.Utils;
using UnityEngine;

namespace GeoHell.PlayerActions
{
    /// <summary>
    /// A component that allows player character to rotate
    /// </summary>
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

            _rigidbody2D.MoveRotation(-Util.AngleFromVector2(v));
        }
    }
}
