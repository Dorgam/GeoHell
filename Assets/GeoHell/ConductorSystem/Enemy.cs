﻿using System;
using UnityEngine;

namespace GeoHell.ConductorSystem
{
    /// <summary>
    /// Used to parse the JSON description of the level
    /// </summary>
    [Serializable]
    public class Enemy : ISpawnable
    {
        public int[] targetLocation;
        
        public string name;
        public string Name => name;

        public int[] spawnLocation;
        public Vector2 SpawnLocation => new Vector2(spawnLocation[0], spawnLocation[1]);
    }
}
