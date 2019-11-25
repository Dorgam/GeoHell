using UnityEngine;

namespace GeoHell.Utils
{
    /// <summary>
    /// A collection of util methods
    /// </summary>
    public class Util : MonoBehaviour
    {
        public static Vector2 RadianToVector2(float radian)
        {
            return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
        }
  
        public static Vector2 DegreeToVector2(float degree)
        {
            return RadianToVector2(degree * Mathf.Deg2Rad);
        }
    
        public static float AngleFromVector2(Vector2 pVector2)
        {
            if (pVector2.x < 0)
            {
                return 360 - (Mathf.Atan2(pVector2.x, pVector2.y) * Mathf.Rad2Deg * -1);
            }
            else
            {
                return Mathf.Atan2(pVector2.x, pVector2.y) * Mathf.Rad2Deg;
            }
        }
    
        public static float Map (float value, float from1, float to1, float from2, float to2) 
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }
    }
}
