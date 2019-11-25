using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GeoHell.LevelSystem
{
    /// <summary>
    /// List of all game levels
    /// </summary>
    public enum Level
    {
        Main,
        Game,
        Win,
        Lose
    }

    /// <summary>
    /// A component for loading levels on button click, useful for menus
    /// </summary>
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
}