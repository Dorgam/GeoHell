using System.Collections;
using BehaviorDesigner.Runtime;
using GeoHell.MortalSystem;
using GeoHell.Utils;
using UnityEngine;

namespace GeoHell.AdaptiveMusicSystem
{
    /// <summary>
    /// This class collects game data to create accessible API for tension calculation.
    /// </summary>
    public class GameParameters : MonoBehaviour
    {
        [SerializeField] private float enemyWeight;
        [SerializeField] private float playerHealthWeight;
        [SerializeField] private float bulletsWeight;
        private int _enemiesAlive;

        private Damageable _playerDamageable;

        public int EnemiesAlive
        {
            get => _enemiesAlive;
            set
            {
                _enemiesAlive = value;
                GlobalVariables.Instance.SetVariableValue("EnemiesAlive", _enemiesAlive);
            }
        }

        public float BulletsAlive { get; set; }
        
        public static GameParameters Instance;
    
        private void Awake() 
        {
            if(!Instance)
            {
                Instance = this;
            }
        }

        public float PlayerHealth
        {
            get
            {
                if (_playerDamageable == null)
                {
                    _playerDamageable = GameObject.FindGameObjectWithTag("Player").GetComponent<Damageable>();
                }

                return _playerDamageable.CurrentHealth;
            }
        }

        public float Tension => _enemiesAlive * enemyWeight + PlayerHealth * playerHealthWeight + BulletsAlive * bulletsWeight;

        private void Start()
        {
            DebugGUI.SetGraphProperties("tension", "Tension", 0, 1500, 0, new Color(1, 1, 0), true);
            StartCoroutine(ReportTension());
        }

        private IEnumerator ReportTension()
        {
            yield return new WaitForSeconds(5);
            while (true)
            {
                DebugGUI.Graph("tension", Tension);
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
