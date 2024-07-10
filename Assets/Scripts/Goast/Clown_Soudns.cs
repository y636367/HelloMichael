using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown_Soudns : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] Box_Sounds;
    [SerializeField]
    private AudioClip[] box_Clips;

    private void Awake()
    {
        for(int i=0; i<Box_Sounds.Length; i++)
        {
            Box_Sounds[i].GetComponent<AudioSource>();
            Box_Sounds[i].clip = box_Clips[i];
        }
    }

    private void Box_1()
    {
        Box_Sounds[0].PlayOneShot(box_Clips[0]);
    }
    private void Box_2()
    {
        Box_Sounds[1].PlayOneShot(box_Clips[1]);
    }
    private void Box_3()
    {
        Box_Sounds[2].PlayOneShot(box_Clips[2]);
    }
    private void Box_4()
    {
        Box_Sounds[3].PlayOneShot(box_Clips[3]);
    }
}
