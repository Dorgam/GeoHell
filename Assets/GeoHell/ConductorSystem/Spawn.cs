using System;

namespace GeoHell.ConductorSystem
{
    /// <summary>
    /// Used to parse the JSON description of the level
    /// </summary>
    [Serializable]
    public class Spawn
    {
        public int delayBeforeSpawn;
        public Enemy[] enemies;
    }
}
