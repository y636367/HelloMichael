using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler_A_Collider : MonoBehaviour
{
    public bool Attack_Check;

    Crawler_Cam crawler_Cam;
    Crawler crawler;

    private void Start()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        Attack_Check = false;
    }

    private void Update()
    {
        if (Attack_Check)

            Collider_On();
        else
            Collider_Off();
    }
    private void Collider_On()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    private void Collider_Off()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        Set_Cam();
        if (other.CompareTag("Player"))
        {
            Start_Cam();
            crawler.Change_Attack();
        }
    }
    public void Set_Cam()
    {
        GameObject t_player = GameObject.FindGameObjectWithTag("Player");
        GameObject Head = t_player.transform.Find("Head").gameObject;
        GameObject Main = Head.transform.Find("Main Camera").gameObject;

        crawler_Cam = Main.transform.Find("Crawler_Cam").gameObject.GetComponent<Crawler_Cam>();

        crawler = FindObjectOfType<Crawler>();
    }
    private void Start_Cam()
    {
        Player t_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(t_player.Life(4250))
            crawler_Cam.Whoa();
    }
}
