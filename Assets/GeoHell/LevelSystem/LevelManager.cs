using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public void LoadLevel(Level level)
    {
        SceneManager.LoadScene(level.ToString());
    }
}
