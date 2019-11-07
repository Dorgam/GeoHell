using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class InformOnDeath : MonoBehaviour
{
    private void OnDestroy()
    {
        GlobalVariables.Instance.SetVariableValue("EnemiesAlive", (int) GlobalVariables.Instance.GetVariable("EnemiesAlive").GetValue() - 1);
    }
}
