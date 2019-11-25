using UnityEngine;

namespace GeoHell.Utils
{
    /// <summary>
    /// Singleton design pattern, useful for manager like objects
    /// </summary>
    public class Singleton<T> : MonoBehaviour where T: Singleton<T>
    {
        public static T Instance;
    
        private void Awake() 
        {
            if(!Instance)
            {
                Instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
