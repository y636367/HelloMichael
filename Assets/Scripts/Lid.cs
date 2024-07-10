using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lid : MonoBehaviour
{
    Animator animator;

    [Header("Sounds")]
    [SerializeField]
    private AudioSource Box_;
    [SerializeField]
    private AudioClip Box_Open;
    void Start()
    {
        animator = GetComponent<Animator>();

        Box_ = GetComponent<AudioSource>();
        Box_.clip = Box_Open;
    }
    private void LateUpdate()
    {
        if (GameManager.Instance.Option_)
            animator.GetComponent<Animator>().speed = 0.0f;
        else
            animator.GetComponent<Animator>().speed = 1.0f;
    }
    public void Lid_animation()
    {
        this.Box_.PlayOneShot(Box_Open);
        animator.SetBool("On", true);
    }
    private void End()
    {
        this.gameObject.SetActive(false);
    }
}
