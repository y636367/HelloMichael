using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_Eyes : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void start_a()
    {
        StartCoroutine(Start_anime());
    }
    IEnumerator Start_anime()
    {
        yield return new WaitForSeconds(2f);
        Start_();
    }
    void Start_()
    {
        animator.SetBool("Start", true);
    }
}
