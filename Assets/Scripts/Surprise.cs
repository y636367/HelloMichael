using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surprise : MonoBehaviour
{
    Animator animator;

    Start_Play SP;

    public void Whoa(Start_Play t_sp)
    {
        animator = GetComponent<Animator>();
        animator.SetBool("On", true);
        SP = t_sp;
    }
    public void NextActive()
    {
        SP.Destory_obj();
    }
}
