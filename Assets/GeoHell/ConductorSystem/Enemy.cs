using System;

namespace GeoHell.ConductorSystem
{
    /// <summary>
    /// Used to parse the JSON description of the level
    /// </summary>
    [Serializable]
    public class Enemy
    {
        public string name;
        public int[] spawnLocation;
        public int[] targetLocation;
    }
}
