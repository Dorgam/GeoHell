using System;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace GeoHell.ConductorSystem
{
    /// <summary>
    /// Used to create a serializable view of EnemyDictionary in the Unity scene.
    /// </summary>
    [Serializable]
    public class SpawnableDictionary : SerializableDictionaryBase<string, GameObject>
    {
    }
}
