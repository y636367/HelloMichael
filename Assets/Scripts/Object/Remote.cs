using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remote : MonoBehaviour
{
    Player player;

    [SerializeField]
    private KeyCode KeyCodeClick;

    [SerializeField]
    private GameObject Tv_Screen;

    bool Plug = false;
    private void Awake()
    {
        player=FindObjectOfType<Player>();
        try
        {
            Tv_Screen.SetActive(false);

        }catch(NullReferenceException) { }

        KeyCodeClick = KeySetting.keys[(KeyAction)9];
    }

    private void Update()
    {
        if (player.RemoteGet)
        {
            if (Input.GetKeyDown(KeyCodeClick))
            {
                if (!Plug)
                {
                    Tv_Screen.SetActive(true);
                    Plug = true;
                }
                else
                {
                    Tv_Screen.SetActive(false);
                    Plug = false;
                }
            }
        }
    }
    public void Set_Key()
    {
        KeyCodeClick = KeySetting.keys[(KeyAction)9];
    }
}
