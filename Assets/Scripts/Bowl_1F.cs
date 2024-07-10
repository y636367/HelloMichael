using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl_1F : MonoBehaviour
{
    Animator animator;


    [Header("Sounds")]
    [SerializeField]
    private AudioSource Bowl_Sound;
    [SerializeField]
    private AudioClip bowl_sound;
    void Awake()
    {
        animator = GetComponent<Animator>();

        Bowl_Sound=GetComponent<AudioSource>();
        Bowl_Sound.clip = bowl_sound;
    }
    private void LateUpdate()
    {
        if (GameManager.Instance.Option_)
            animator.GetComponent<Animator>().speed = 0.0f;
        else
            animator.GetComponent<Animator>().speed = 1.0f;
    }
    public void Bowl()
    {
        animator.SetBool("On", true);
    }
    private void sound()
    {
        Bowl_Sound.PlayOneShot(bowl_sound);
        Debug.Log("Bowl");
    }
}
