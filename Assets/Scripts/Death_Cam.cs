using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Cam : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    private GameObject Death_Canvas = null;

    public void Whoa()
    {
        this.gameObject.SetActive(true);
        animator = GetComponent<Animator>();
        animator.SetBool("On", true);
        GameManager.Instance.Dont_Option = false;
    }

    public void Active_False()
    {
        animator.SetBool("On", false);
        GameManager.Instance.Dont_Option = true;
        Death_Canvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
