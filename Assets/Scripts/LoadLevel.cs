using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Level
{
    Main,
    Game,
    Win,
    Lose
}

public class LoadLevel : MonoBehaviour
{
    public Level level;
    
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            LevelManager.Instance.LoadLevel(level);
        });
    }
}
