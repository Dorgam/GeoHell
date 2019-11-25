using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public TextAsset json;
    public Playthrough Playthrough;
    private void Awake()
    {
        Playthrough = JsonUtility.FromJson<Playthrough>(json.text);
        Debug.Log(Playthrough.waves[0].name);
    }
}
