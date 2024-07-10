using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    public bool open = false;

    [SerializeField]
    public bool Lock;

    public bool Check = false;

    [Header("Script")]
    [SerializeField]
    private string[] Script;

    [SerializeField]
    public bool Re;

    public int Count = 1;

    ChatController CC;
    Player player;
    Door t_door;

    [Header("Sounds")]
    [SerializeField]
    private AudioClip door_Open;
    [SerializeField]
    private AudioClip door_Close;
    [SerializeField]
    private AudioClip lock_Door;
    [SerializeField]
    private AudioSource Door_Open;
    [SerializeField]
    private AudioSource Door_Close;
    [SerializeField]
    private AudioSource Lock_Door;
    void Awake()
    {
        animator = GetComponent<Animator>();
        CC = FindObjectOfType<ChatController>();

        t_door = this;

        Door_Open=GetComponent<AudioSource>();
        Door_Close=GetComponent<AudioSource>();
        Lock_Door=GetComponent<AudioSource>();

        Door_Open.clip=this.door_Open;
        Door_Close.clip = this.door_Close;
        Lock_Door.clip=this.lock_Door;
    }
    private void LateUpdate()
    {
        if (t_door.Re)
        {
            t_door.Count = 1;
        }

        if (GameManager.Instance.Option_)
            animator.GetComponent<Animator>().speed = 0.0f;
        else
            animator.GetComponent<Animator>().speed = 1.0f;
    }
    public void DoorAnime()
    {
        if (!t_door.Lock)
        {
            if (t_door.open == false)
            {
                t_door.Door_Open.PlayOneShot(t_door.door_Open);
                t_door.animator.SetBool("Door_Event", true);
                t_door.open = true;
            }
            else
            {
                t_door.Door_Close.PlayOneShot(t_door.door_Close);
                t_door.animator.SetBool("Door_Event", false);
                t_door.open = false;
            }
        }
        else
        {
            t_door.Lock_Door.PlayOneShot(t_door.lock_Door);

            if (t_door.Count == 1)
            {
                t_door.Count--;
                CC.Get_player(player);
                player.Move_Ok = false;
                player.Now_Chat = true;
                CC.GetScribt(t_door.Script);
                CC.turnOn(this.gameObject);
            }
        }
    }
    public void DoorAnime_Goast()
    {
        if (!t_door.Lock)
        {
            if (t_door.open == false)
            {
                t_door.Door_Open.PlayOneShot(t_door.door_Open);
                t_door.animator.SetBool("Door_Event", true);
                t_door.open = true;
            }
        }
    }
    public void this_door(RaycastHit hit)
    {
        t_door = hit.collider.GetComponent<Door>();
        player=GameManager.Instance.player;
    }
    public void t_this_door(Door t_d)
    {
        t_door = t_d;
    }
    public void this_door_Goast(RaycastHit hit)
    {
        t_door = hit.collider.GetComponent<Door>();
    }
}
