using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds_Control_3D : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] Sounds;

    private void LateUpdate()
    {
        if (GameManager.Instance.Option_)
        {
            Pause();
        }
        else
            UnPause();

        if (sceneManager.Instance.Scene_ing)
            UnPause();
    }
    private void Pause()
    {
        for (int i = 0; i < Sounds.Length; i++)
        {
            Sounds[i].Pause();
        }
    }
    private void UnPause()
    {
        for (int i = 0; i < Sounds.Length; i++)
        {
            Sounds[i].UnPause();
        }
    }
}
