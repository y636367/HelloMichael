using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sihouette_cam : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    private GameObject Shadows = null;

    [SerializeField]
    private GameObject[] S_S = null;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void Start_anime(int t_n)
    {
        if (t_n == 0)
        {
            S_S[t_n].SetActive(true);
            animator.SetTrigger("Blue");
            GameManager.Instance.Dont_Option = false;
        }
        else if (t_n == 1)
        {
            S_S[t_n].SetActive(true);
            animator.SetTrigger("Red");
            GameManager.Instance.Dont_Option = false;
        }
        else if (t_n == 2)
        {
            S_S[t_n].SetActive(true);
            animator.SetTrigger("Yellow");
            GameManager.Instance.Dont_Option = false;
        }
        Destroy(Shadows);
    }
    private void End_anima()
    {
        GameManager.Instance.Dont_Option = true;

        for (int i=0;i < S_S.Length;i++)
        {
            Destroy(S_S[i]);
        }
    }
}
