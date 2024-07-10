using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_Goast : MonoBehaviour
{
    Animator animator;

    Dead_Trash DT;

    public int Count = 0;
    private void Awake()
    {
        animator = GetComponent<Animator>();     
        DT=FindObjectOfType<Dead_Trash>();
    }
    public void Start_Dead()
    {
        animator.SetTrigger("Dead");
        GameManager.Instance.Dont_Option = false;
    }
    private void Count_Up()
    {
        Count += 1;

        if (Count == 13)
        {
            soundManager.Instance.StopAllSoundEffect();
            Next_Step();
        }
    }
    private void Next_Step()
    {
        GameManager.Instance.Dont_Option = true;
        DT.Dead_Start();
    }
}
