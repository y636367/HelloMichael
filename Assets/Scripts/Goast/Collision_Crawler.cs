using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Crawler : MonoBehaviour
{
    public bool Player_sound = false;

    Crawler crawler;
    Player player;
    private void Awake()
    {
        crawler = FindObjectOfType<Crawler>();
        
        player = FindObjectOfType<Player>();
    }
    private void LateUpdate()
    {
        Soudns_Check();
    }
    private void Soudns_Check()
    {
        if (player.Move_Check)
        {
            Player_sound = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Player_sound)
        {
            crawler.Change_Hold();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player_sound = false;
            crawler.Get_Player_false();
        }
    }
}
