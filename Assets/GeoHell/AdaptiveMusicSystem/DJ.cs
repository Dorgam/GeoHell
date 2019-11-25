using UnityEngine;

namespace GeoHell.AdaptiveMusicSystem
{
    /// <summary>
    /// This class changes the music active layer using Grumble Music Player based on the Tension level
    /// </summary>
    public class DJ : MonoBehaviour
    {
        [SerializeField] private int mediumLayerBulletCount;
        [SerializeField] private int heavyLayerBulletCount;
        private grumbleAMP _amp;
        private int _currentMusicLayer = 0;

        private void Start()
        {
            _amp = GetComponent<grumbleAMP>();
            _amp.PlaySong(0, 0);
        }

        private void Update()
        {
            if (_currentMusicLayer != 0 && GameParameters.Instance.Tension < mediumLayerBulletCount)
            {
                _currentMusicLayer = 0;
                Debug.Log("Light Layer");
                _amp.CrossFadeToNewLayer(0);
            }
            else if (_currentMusicLayer != 1 && GameParameters.Instance.Tension > mediumLayerBulletCount && GameParameters.Instance.Tension < heavyLayerBulletCount)
            {
                _currentMusicLayer = 1;
                Debug.Log("Medium Layer");
                _amp.CrossFadeToNewLayer(1);
            }
            else if (_currentMusicLayer != 2 && GameParameters.Instance.Tension >= heavyLayerBulletCount)
            {
                _currentMusicLayer = 2;
                Debug.Log("Heavy Layer");
                _amp.CrossFadeToNewLayer(2);
            }
        }
    }
}
