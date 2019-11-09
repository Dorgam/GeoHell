using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJ : MonoBehaviour
{
    [SerializeField] private int mediumLayerBulletCount;
    [SerializeField] private int heavyLayerBulletCount;
    private grumbleAMP amp;
    private int currentMusicLayer = 0;

    private void Start()
    {
        amp = GetComponent<grumbleAMP>();
        amp.PlaySong(0, 0);
    }

    private void Update()
    {
        if (currentMusicLayer != 0 && GameParameters.Instance.BulletsAlive < mediumLayerBulletCount)
        {
            currentMusicLayer = 0;
            Debug.Log("Light Layer");
            amp.CrossFadeToNewLayer(0);
        }
        else if (currentMusicLayer != 1 && GameParameters.Instance.BulletsAlive > mediumLayerBulletCount && GameParameters.Instance.BulletsAlive < heavyLayerBulletCount)
        {
            currentMusicLayer = 1;
            Debug.Log("Medium Layer");
            amp.CrossFadeToNewLayer(1);
        }
        else if (currentMusicLayer != 2 && GameParameters.Instance.BulletsAlive >= heavyLayerBulletCount)
        {
            currentMusicLayer = 2;
            Debug.Log("Heavy Layer");
            amp.CrossFadeToNewLayer(2);
        }
    }
}
