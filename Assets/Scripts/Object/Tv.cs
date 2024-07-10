using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tv : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void On_Tv()
    {
        animator.SetTrigger("Tv_On");
    }
}
