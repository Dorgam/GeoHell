using System;

namespace GeoHell.ConductorSystem
{
    /// <summary>
    /// Used to parse the JSON description of the level
    /// </summary>
    [Serializable]
    public class Wave
    {
        public string name;
        public Spawn[] spawns;
        public Pickup[] pickups;
    }
}
