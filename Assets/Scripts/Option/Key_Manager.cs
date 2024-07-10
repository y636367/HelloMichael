using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public enum KeyAction
{
    Foward_W, Backward_w, Left_W, Right_W,
    Sprint, Sitting,
    Interect, Zoom, Pass_Script, O_action, 
    Pause, KeyCount
}
public static class KeySetting
{
    public static Dictionary<KeyAction, KeyCode> keys = new Dictionary<KeyAction, KeyCode>();
    //Dictionary 형으로 입력 키 1대1 매칭
}
public class Key_Manager : MonoBehaviour
{
    KeyCode[] defaultKeys = new KeyCode[] {KeyCode.W,KeyCode.S, KeyCode.A, KeyCode.D,
        KeyCode.LeftShift, KeyCode.LeftControl,
        KeyCode.E, KeyCode.Mouse1, KeyCode.Space, KeyCode.Mouse0,
        KeyCode.Escape
    };

    KeyCode t_KeyCode = KeyCode.None;
    int t_keyNum = 0;

    static public Key_Manager Instance;

    public bool Check = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            for (int i = 0; i < (int)KeyAction.KeyCount; i++)
            {
                KeySetting.keys.Add((KeyAction)i, defaultKeys[i]);
            }
        }
        else if (Instance != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
    private void OnGUI()
    {
        if (Check)
        {
            Event keyEvent = Event.current;
            //현재 이벤트 호출
            if (keyEvent.isKey)
            {
                KeySetting.keys[(KeyAction)key] = keyEvent.keyCode;
                t_KeyCode = keyEvent.keyCode;
                t_keyNum = key;
                if (key != -1)
                    Check_Redundant(t_KeyCode, t_keyNum);
                key = -1;
                Set_Key();
            }
            else if (keyEvent.isMouse)
            {
                if (Input.GetMouseButton(0))
                {
                    KeySetting.keys[(KeyAction)key] = KeyCode.Mouse0;
                    t_KeyCode = KeyCode.Mouse0;
                    t_keyNum = key;
                }
                else if (Input.GetMouseButton(1))
                {
                    KeySetting.keys[(KeyAction)key] = KeyCode.Mouse1;
                    t_KeyCode = KeyCode.Mouse1;
                    t_keyNum = key;
                }
                else if (Input.GetMouseButton(2))
                {
                    KeySetting.keys[(KeyAction)key] = KeyCode.Mouse2;
                    t_KeyCode = KeyCode.Mouse3;
                    t_keyNum = key;
                }
                if (key != -1)
                    Check_Redundant(t_KeyCode, t_keyNum);
                key = -1;
                Set_Key();
            }
        }
    }
    int key = -1;
    public void ChangeKey(int num)
    {
        key = num;
    }
    public void Reset_KeySetting()
    {
        for (int i = 0; i < (int)KeyAction.KeyCount; i++)
        {
            KeySetting.keys[(KeyAction)i]=defaultKeys[i];
        }
    }
    private void Check_Redundant(KeyCode t_Code, int t_num)
    {
        for (int i = 0; i < (int)KeyAction.KeyCount; i++)
        {
            if (KeySetting.keys[(KeyAction)i] == t_Code && i!=t_num)
            {
                KeySetting.keys[(KeyAction)i] = KeyCode.None;
                break;
            }
        }
    }
    private void Set_Key()
    {
        GameManager.Instance.Set_Key();
        ChatController.instance.Set_Key();

        try
        {
            Player player =GameObject.FindObjectOfType<Player>();
            player.Set_Key();
        }
        catch (NullReferenceException) { }

        try
        {
            HitRayCast hit = GameObject.FindObjectOfType<HitRayCast>();
            hit.Set_Key();
        }
        catch (NullReferenceException) { }

        try
        {
            Flashlight flashlight = GameObject.FindObjectOfType<Flashlight>();
            flashlight.Set_Key();
        }
        catch (NullReferenceException) { }

        try
        {
            Grab_Hammer hammer=GameObject.FindObjectOfType<Grab_Hammer>();
            hammer.Set_Key();
        }
        catch (NullReferenceException) { }

        try
        {
            Remote remote = GameObject.FindObjectOfType<Remote>();
            remote.Set_Key();
        }
        catch (NullReferenceException) { }

        try
        {
            Book_Number_Check Book = GameObject.FindObjectOfType<Book_Number_Check>();
            Book.Set_Key();
        }
        catch (NullReferenceException) { }
    }
}
