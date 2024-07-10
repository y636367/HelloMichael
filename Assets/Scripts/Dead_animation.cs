using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_animation : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Start_Motion()
    {
        animator.SetTrigger("On");
        GameManager.Instance.Dont_Option = false;
    }
    public void Fin_Game()
    {
        GameManager.Instance.Save_Point = false; 
        GameManager.Instance.Back_Point = false;
        GameManager.Instance.Dont_Option = true;
        sceneManager.Instance.Fin_Game();
    }
}
