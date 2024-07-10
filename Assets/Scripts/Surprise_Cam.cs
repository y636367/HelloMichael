using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Surprise_Cam : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Whoa()
    {
        Goast_Surprise GS=FindObjectOfType<Goast_Surprise>();
        GS.Micheal_S();
        this.gameObject.SetActive(true);
        animator = GetComponent<Animator>();
        animator.SetBool("On", true);
        GameManager.Instance.Dont_Option = false;
    }

    public void Active_False()
    {
        animator.SetBool("On", false);
        GameManager.Instance.Dont_Option = true;
        this.gameObject.SetActive(false);
    }
}
