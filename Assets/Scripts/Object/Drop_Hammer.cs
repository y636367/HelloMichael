using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Hammer : MonoBehaviour
{
    [SerializeField]
    private AudioSource Hammer;

    [SerializeField]
    private AudioClip Thumb_4;

    private void Awake()
    {
        Hammer = GetComponent<AudioSource>();
        Hammer.clip = Thumb_4; ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Hammer.PlayOneShot(Thumb_4);
    }
}
