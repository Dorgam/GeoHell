using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeoHell.ConductorSystem
{
    /// <summary>
    /// Used to parse the JSON description of the level
    /// </summary>
    [Serializable]
    public class Pickup : ISpawnable
    {
        public string name;
        public string Name => name;

        public float delayBeforeSpawn;

        public int[] spawnLocation;
        public Vector2 SpawnLocation => new Vector2(spawnLocation[0], spawnLocation[1]);
    }
}
