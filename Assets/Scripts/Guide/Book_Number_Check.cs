using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Book_Number_Check : MonoBehaviour
{
    [SerializeField]
    private int Now_Open;

    [SerializeField]
    private GameObject[] Book_List;

    [SerializeField]
    private GameObject Book_Title;

    [SerializeField]
    public TMP_Text Key_Text = null;

    [SerializeField]
    private KeyCode Close_Book;

    private bool Open_Check = false;

    Player player;

    [Header("Sounds")]
    [SerializeField]
    private string Book_Close;
    private void Awake()
    {
        for(int i=0; i<Book_List.Length; i++)
        {
            Book_List[i].SetActive(false);
        }
        Book_Title.SetActive(false);

        player=FindObjectOfType<Player>();

        Close_Book = KeySetting.keys[(KeyAction)8];
        Open_Check = false;
        Key_Text.text = "[" + (Close_Book == KeyCode.Mouse0 ? "LeftMouse" :
            Close_Book == KeyCode.Mouse1 ? "RightMouse" :
            Close_Book == KeyCode.Mouse2 ? "MouseWheel" : Close_Book.ToString()) + "]";
    }
    private void Update()
    {
        if (Open_Check)
        {
            if (Input.GetKeyDown(Close_Book))
            {
                soundManager.Instance.PlaySoundEffect(Book_Close);
                Open_Check = false;
                Book_List[Now_Open].SetActive(false);
                Book_Title.SetActive(false);
                player.Move_Ok = true;
            }
        }
    }
    public void List_Num(int t_num)
    {
        Open_Check = true;

        Now_Open = t_num;

        Book_Open();
    }
    private void Book_Open()
    {
        player.Move_Ok = false;
        Book_Title.SetActive(true);
        Book_List[Now_Open].SetActive(true);
    }
    public void Set_Key()
    {
        Close_Book = KeySetting.keys[(KeyAction)8];

        try
        {
            Key_Text.text = "[" + (Close_Book == KeyCode.Mouse0 ? "LeftMouse" : 
                Close_Book == KeyCode.Mouse1 ? "RightMouse" : 
                Close_Book == KeyCode.Mouse2 ? "MouseWheel" : Close_Book.ToString()) + "]";
        }
        catch (NullReferenceException) { }
    }
}