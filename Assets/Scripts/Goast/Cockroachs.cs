using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cockroachs : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    private AudioSource FootStep;
    [SerializeField]
    private AudioClip footstep;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        FootStep=GetComponent<AudioSource>();
        FootStep.clip = footstep;
    }

    public void On_Anima()
    {
        animator.SetTrigger("On");
    }

    private void OnDestroy()
    {
        Destroy(this.gameObject);
    }
    private void Sounds()
    {
        FootStep.PlayOneShot(footstep);
    }
}
