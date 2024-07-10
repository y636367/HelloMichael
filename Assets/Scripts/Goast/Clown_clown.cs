using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown_clown : MonoBehaviour
{
    Animator animator;

    public void Whoa()
    {
        Goast_Surprise GS=FindObjectOfType<Goast_Surprise>();
        GS.Box_S();
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
