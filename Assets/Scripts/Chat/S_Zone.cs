using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class S_Zone : MonoBehaviour
{
    [Header("Script")]
    [SerializeField]
    private string[] Script;

    [Header("List?")]
    [SerializeField]
    private string[] list_do;
    [SerializeField]
    private bool list_Check;
    [SerializeField]
    private bool Re;
    [SerializeField]
    private int list_num;

    [SerializeField]
    private bool Scene_ = false;

    [SerializeField]
    private bool Goal_Clear_Check = false;

    [SerializeField]
    private int turnOff_list;

    [SerializeField]
    private bool List_Update = false;

    [SerializeField]
    int Count = 1;

    [SerializeField]
    private bool SoundON = false;
    [SerializeField]
    Script_Box_Audio[] SBA;

    ChatController CC;
    HitRayCast hit;
    void Awake()
    {
        CC=FindObjectOfType<ChatController>();
        hit=FindObjectOfType<HitRayCast>();
    }
    private void Update()
    {
        if (this.Re == true)
        {
            this.Count = 1;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&this.Count==1)
        {
            if (this.Scene_)
            {
                Debug.Log("Story");
                CC.Scene_ = this.Scene_;
            }

            this.Count--;
            CC.Get_player(other.GetComponent<Player>());
            other.GetComponent<Player>().Move_Ok = false;
            other.GetComponent<Player>().Now_Chat = true;
            CC.GetScribt(this.Script);
            CC.turnOn(this.gameObject, this.list_do, this.list_Check);

            GameManager.Instance.list_num = this.list_num;

            if (this.Goal_Clear_Check)
            {
                GameManager.Instance.Check_Update();
            }

            if (this.list_num == 2)
            {
                GameManager.Instance.Stack=this.turnOff_list;
                ChatController.instance.t_num = this.list_num;
                hit.Clear = true;
            }
            if (SoundON)
            {
                for (int i = 0; i < SBA.Length; i++)
                {
                    SBA[i].Sound_On();
                }
            }
        }
    }
    public void Count_Back()
    {
        this.Count=1;
    }
}
