using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVScroll : MonoBehaviour
{
    [SerializeField] private Vector2 speed;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    void LateUpdate() {
        _renderer.material.mainTextureOffset = speed * Time.time;
    }
}
