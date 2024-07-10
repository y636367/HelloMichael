using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awake_Sounds : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] Sounds;
    [SerializeField]
    private AudioClip[] sounds;

    private void Awake()
    {
        for(int i=0;i<Sounds.Length; i++)
        {
            Sounds[i].PlayOneShot(sounds[i]);
        }
    }
}
