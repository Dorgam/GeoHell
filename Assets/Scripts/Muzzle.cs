using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float secondsBetweenBullets;
    private IEnumerator _fireCoroutine;
    private Transform _transform;
    private float _muzzleRotation;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _muzzleRotation = _transform.rotation.eulerAngles.z;
    }

    private IEnumerator ShootBullets()
    {
        while (true)
        {
            _muzzleRotation = _transform.rotation.eulerAngles.z;
            GameObject temp = Instantiate(bullet, _transform.position, Quaternion.Euler(0,0, _muzzleRotation));
            Vector2 direction = Util.DegreeToVector2(_muzzleRotation + 90);
            temp.GetComponent<Rigidbody2D>().velocity = bulletSpeed * direction;
            yield return new WaitForSeconds(secondsBetweenBullets);
        }
    }

    public void Fire()
    {
        if (_fireCoroutine != null)
        {
            StopCoroutine(_fireCoroutine);
        }

        _fireCoroutine = ShootBullets();
        StartCoroutine(_fireCoroutine);
    }

    public void Stop()
    {
        if (_fireCoroutine != null)
        {
            StopCoroutine(_fireCoroutine);
        }
    }
}
