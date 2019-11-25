using UnityEngine;

namespace GeoHell.Utils
{
    /// <summary>
    /// Creates the scrolling effect of backgrounds (change texture offset value)
    /// </summary>
    public class UVScroll : MonoBehaviour
    {
        [SerializeField] private Vector2 speed;
        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void LateUpdate() {
            _renderer.material.mainTextureOffset = speed * Time.time;
        }
    }
}
