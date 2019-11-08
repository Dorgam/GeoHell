using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBulletCount : MonoBehaviour
{
    private void Awake()
    {
        GameParameters.Instance.BulletsAlive++;
    }

    private void OnDestroy()
    {
        GameParameters.Instance.BulletsAlive--;
    }
}
