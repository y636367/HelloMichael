using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_F_Box : MonoBehaviour
{
    Animator animator;


    [Header("Sounds")]
    [SerializeField]
    private AudioSource Box_Thumb_2;
    [SerializeField]
    private AudioSource Box_Thumb_3;
    [SerializeField]
    private AudioSource Box_Thumb_4;
    [SerializeField]
    private AudioSource Box_Thumb_5;
    [SerializeField]
    private AudioSource Box_Thumb_6;
    [SerializeField]
    private AudioClip box_thumb_2;
    [SerializeField]
    private AudioClip box_thumb_3;
    [SerializeField]
    private AudioClip box_thumb_4;
    [SerializeField]
    private AudioClip box_thumb_5;
    [SerializeField]
    private AudioClip box_thumb_6;
    void Awake()
    {
        animator = GetComponent<Animator>();

        Box_Thumb_2 = GetComponent<AudioSource>();
        Box_Thumb_2.clip = box_thumb_2;

        Box_Thumb_3 = GetComponent<AudioSource>();
        Box_Thumb_3.clip = box_thumb_3;

        Box_Thumb_4 = GetComponent<AudioSource>();
        Box_Thumb_4.clip = box_thumb_4;

        Box_Thumb_5 = GetComponent<AudioSource>();
        Box_Thumb_5.clip = box_thumb_5;

        Box_Thumb_6 = GetComponent<AudioSource>();
        Box_Thumb_6.clip = box_thumb_6;
    }
    private void LateUpdate()
    {
        if (GameManager.Instance.Option_)
            animator.GetComponent<Animator>().speed = 0.0f;
        else
            animator.GetComponent<Animator>().speed = 1.0f;
    }
    public void Boxes()
    {
        animator.SetBool("On", true);
    }
    private void Box_sound_2()
    {
        Box_Thumb_2.PlayOneShot(box_thumb_2);
    }
    private void Box_sound_3()
    {
        Box_Thumb_2.PlayOneShot(box_thumb_3);
    }
    private void Box_sound_4()
    {
        Box_Thumb_2.PlayOneShot(box_thumb_4);
    }
    private void Box_sound_5()
    {
        Box_Thumb_2.PlayOneShot(box_thumb_5);
    }
    private void Box_sound_6()
    {
        Box_Thumb_2.PlayOneShot(box_thumb_6);
    }
}
