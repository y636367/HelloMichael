using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Michel_Surprise : MonoBehaviour
{
    Surprise_Cam SPCam;
    Animator animator;
    Player player;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        player=FindObjectOfType<Player>();
    }
    private void LateUpdate()
    {
        if (GameManager.Instance.Option_ || player.death)
            animator.GetComponent<Animator>().speed = 0.0f;
        else
            animator.GetComponent<Animator>().speed = 1.0f;
    }
    public void Start_Cam()
    {
        Player t_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(t_player.Life(1700))
            SPCam.Whoa();
    }
    public void Set_Cam()
    {
        GameObject t_player = GameObject.FindGameObjectWithTag("Player");
        GameObject Head = t_player.transform.Find("Head").gameObject;
        GameObject Main = Head.transform.Find("Main Camera").gameObject;

        SPCam = Main.transform.Find("Surprise_cam").gameObject.GetComponent<Surprise_Cam>();
    }
}
