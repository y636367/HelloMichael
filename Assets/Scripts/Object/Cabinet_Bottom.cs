using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet_Bottom : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    public bool open = false;

    public bool Check = false;

    Cabinet_Bottom t_cabinet;

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

        Drawler_Open=GetComponent<AudioSource>();
        Drawler_Close=GetComponent<AudioSource>();

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
    public void CabinetAnime()
    {
        if (t_cabinet.open == false)
        {
            t_cabinet.Drawler_Open.PlayOneShot(t_cabinet.drawler_Open);
            t_cabinet.animator.SetBool("Cabinet_Event", true);
            t_cabinet.open = true;
        }
        else
        {
            t_cabinet.Drawler_Close.PlayOneShot(t_cabinet.drawler_Close);
            t_cabinet.animator.SetBool("Cabinet_Event", false);
            t_cabinet.open = false;
        }
    }
    public void this_Cabinet(RaycastHit hit)
    {
        t_cabinet = hit.collider.GetComponent<Cabinet_Bottom>();
    }
    public void t_this_Cabinet(Cabinet_Bottom t_cb)
    {
        t_cabinet = t_cb;
    }
}
