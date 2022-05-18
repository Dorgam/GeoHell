using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnable
{
    public Vector2 SpawnLocation { get; }
    public string Name { get;}
}
