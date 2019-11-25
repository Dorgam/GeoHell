using GeoHell.Utils;
using UnityEngine.SceneManagement;

namespace GeoHell.LevelSystem
{
    /// <summary>
    /// Responsible for loading levels
    /// </summary>
    public class LevelManager : Singleton<LevelManager>
    {
        public void LoadLevel(Level level)
        {
            SceneManager.LoadScene(level.ToString());
        }
    }
}
