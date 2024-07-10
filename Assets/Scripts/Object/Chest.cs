using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    public bool open = false;

    public bool Check = false;

    Chest t_chest;

    [Header("Sounds")]
    [SerializeField]
    private AudioSource Drawler_Open;
    [SerializeField]
    private AudioSource Drawler_Close;
    [SerializeField]
    private AudioClip drawler_Open;
    [SerializeField]
    private AudioClip drawler_Close;
    void Awake()
    {
        animator = GetComponent<Animator>();

        Drawler_Open = GetComponent<AudioSource>();
        Drawler_Close = GetComponent<AudioSource>();

        Drawler_Open.clip = this.drawler_Open;
        Drawler_Close.clip = this.drawler_Close;
    }
    private void LateUpdate()
    {
        if (GameManager.Instance.Option_)
            animator.GetComponent<Animator>().speed = 0.0f;
        else
            animator.GetComponent<Animator>().speed = 1.0f;
    }
    public void ChestAnime()
    {
        if (t_chest.open == false)
        {
            t_chest.Drawler_Open.PlayOneShot(t_chest.drawler_Open);
            t_chest.animator.SetBool("Chest_Event", true);
            t_chest.open = true;
        }
        else
        {
            t_chest.Drawler_Close.PlayOneShot(t_chest.drawler_Close);
            t_chest.animator.SetBool("Chest_Event", false);
            t_chest.open = false;
        }
    }
    public void this_Chest(RaycastHit hit)
    {
        t_chest = hit.collider.GetComponent<Chest>();
    }
    public void t_this_Chest(Chest t_c)
    {
        t_chest = t_c;
    }
}
