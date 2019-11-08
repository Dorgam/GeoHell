using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Win : Action
{
    public override TaskStatus OnUpdate()
    {
        LevelManager.Instance.LoadLevel(Level.Win);
        return TaskStatus.Success;
    }
}
