using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pantry : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    public bool open = false;

    public bool Check = false;

    Pantry t_pantry;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void PantryAnime()
    {
        if (open == false)
        {
            t_pantry.animator.SetBool("Pantry_Event", true);
            open = true;
        }
        else
        {
            t_pantry.animator.SetBool("Pantry_Event", false);
            open = false;
        }
    }
    public void this_Pantry(RaycastHit hit)
    {
        t_pantry = hit.collider.GetComponent<Pantry>();
    }
    public void t_this_Pantry(Pantry t_p)
    {
        t_pantry = t_p;
    }
}
