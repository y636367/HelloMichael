using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Change : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Option_Moving()
    {
        animator.SetTrigger("Option");
    }
    public void Start_Moving()
    {
        animator.SetTrigger("Start");
    }
}
