using System.Collections;
using UnityEngine;

namespace GeoHell.Utils
{
    /// <summary>
    /// Shake the camera view
    /// </summary>
    public class CamShake : MonoBehaviour
    {
        private static CamShake _instance;
        private Vector3 _originalPos;
        private float _timeAtCurrentFrame;
        private float _timeAtLastFrame;
        private float _fakeDelta;
        private static bool _isShaking = false;

        private void Awake()
        {
            _instance = this;
        }

        private void Update() {
            // Calculate a fake delta time, so we can Shake while game is paused.
            _timeAtCurrentFrame = Time.realtimeSinceStartup;
            _fakeDelta = _timeAtCurrentFrame - _timeAtLastFrame;
            _timeAtLastFrame = _timeAtCurrentFrame; 
        }

        public static void Shake (float duration, float amount)
        {
            if(_isShaking) return;
            _isShaking = true;
            _instance._originalPos = _instance.gameObject.transform.localPosition;
            _instance.StopAllCoroutines();
            _instance.StartCoroutine(_instance.CShake(duration, amount));
        }

        private IEnumerator CShake (float duration, float amount) {
            var endTime = Time.time + duration;

            while (duration > 0) {
                transform.localPosition = _originalPos + Random.insideUnitSphere * amount;

                duration -= _fakeDelta;

                yield return null;
            }

            transform.localPosition = _originalPos;
            _isShaking = false;
        }
    }
}
