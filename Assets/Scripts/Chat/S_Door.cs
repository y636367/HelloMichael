using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Door : MonoBehaviour
{
    [Header("Script")]
    [SerializeField]
    private string[] Script;

    [SerializeField]
    private bool Re;

    int Count = 1;

    bool Check = false;

    ChatController CC;
    void Awake()
    {
        CC = FindObjectOfType<ChatController>();
    }

    private void Update()
    {
        if (Re == true)
        {
            Count = 1;
        }
    }
    public void Script_On()
    {
        Check= true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&Count==1)
        {
            if(Check==true)
            {
                Count--;
                CC.Get_player(other.GetComponent<Player>());
                other.GetComponent<Player>().Move_Ok = false;
                CC.GetScribt(Script);
                CC.turnOn(this.gameObject);
            }
        }
    }void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Check = false;
        }
    }
}
