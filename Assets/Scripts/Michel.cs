using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Michel : MonoBehaviour
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
    private GameObject Fake_doll = null;

    Player player;

    private Michel t_michel;

    [Header("Sounds")]
    [SerializeField]
    private string Sound;

    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    public void Grab_michel()
    {
        try
        {
            Destroy(Fake_doll);
        }
        catch (NullReferenceException) { }

        player.Move_Ok = false;
        ChatController.instance.GetScribt(t_michel.Script);
        ChatController.instance.turnOn(t_michel.gameObject, t_michel.list_do,t_michel.list_Check);

        player.DollGet = true;

        try
        {
            soundManager.Instance.PlaySoundEffect(t_michel.Sound);
        }
        catch (NullReferenceException) { }
    }
    public void Destroy_Fakedoll()
    {
        Destroy(Fake_doll);
    }
    public void Michel_get(RaycastHit t_M)
    {
        t_michel=t_M.collider.GetComponent<Michel>();
    }
}
