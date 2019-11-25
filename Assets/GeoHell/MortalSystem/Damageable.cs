using System.Collections;
using UnityEngine;

namespace GeoHell.MortalSystem
{
    /// <summary>
    /// Any gameObject with this component becomes mortal, and can be destroyed
    /// </summary>
    public class Damageable : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private bool invincible;
        private Die _die;
        private SpriteRenderer _spriteRenderer;
        private Color _originalColor;
        private IEnumerator _flashCoroutine;

        [field: SerializeField]
        public float CurrentHealth { get; private set; }

        private void Awake()
        {
            _die = GetComponent<Die>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            CurrentHealth = maxHealth;
            _originalColor = _spriteRenderer.color;
        }

        public void InflictDamage(float damage)
        {
            if(invincible) return;

            CurrentHealth -= damage;
            Flash();
        
            if (CurrentHealth > 0) return;
        
            CurrentHealth = 0;
            if (_die != null)
            {
                _die.StartDying();
            }
        }

        public void HealDamage(float damage)
        {
            CurrentHealth += damage;
            if (CurrentHealth > maxHealth)
            {
                CurrentHealth = maxHealth;
            }
        }

        public void RestoreHealth()
        {
            HealDamage(maxHealth);
        }

        public void DiminishHealth()
        {
            InflictDamage(maxHealth);
        }

        private void Flash()
        {
            if (_flashCoroutine != null)
            {
                StopCoroutine(_flashCoroutine);
            }

            _flashCoroutine = FlashSprite();
            StartCoroutine(_flashCoroutine);
        }

        private IEnumerator FlashSprite()
        {
            _spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.05f);
            _spriteRenderer.color = _originalColor;
        }
    }
}
