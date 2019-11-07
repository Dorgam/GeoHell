using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private bool invincible;
    private Die _die;
    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;
    private IEnumerator _flashCoroutine;

    private void Awake()
    {
        _die = GetComponent<Die>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        _originalColor = _spriteRenderer.color;
    }

    public void InflictDamage(float damage)
    {
        if(invincible) return;

        currentHealth -= damage;
        Flash();
        
        if (currentHealth > 0) return;
        
        currentHealth = 0;
        if (_die != null)
        {
            _die.StartDying();
        }
    }

    public void HealDamage(float damage)
    {
        currentHealth += damage;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
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
