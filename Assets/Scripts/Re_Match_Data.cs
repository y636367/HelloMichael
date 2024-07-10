using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Re_Match_Data : MonoBehaviour
{
    [SerializeField]
    private Flashlight flashlight;
    Camera_Scripts CS;

    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private Transform Position;

    [SerializeField]
    private Re_data data;

    Re_Start_Fade RSF;
    public void Set_Data_Flashlight()
    {
        data=FindObjectOfType<Re_data>();

        flashlight.Flash_Timer = data.t_Timer_data;
        flashlight.Battery_Count = data.t_Battery_data;
    }
    public void Set_Data_Position()
    {
        data = FindObjectOfType<Re_data>();

        Player.gameObject.SetActive(false);
        Player.transform.position = data.t_player_data_Position;

        Player.gameObject.SetActive(true);
        CS = FindObjectOfType<Camera_Scripts>();
        CS.Re_dir(data.t_player_data_2.eulerAngles.x, data.t_player_data_2.eulerAngles.y);
    }
    public void Set_Survive()
    {
        if (!GameManager.Instance.Back_Point)
        {
            GameManager.Instance.Re_Setting_Player();

            RSF = FindObjectOfType<Re_Start_Fade>();
            RSF.Start_Re();
        }
        else
        {
            Re_Back_Point JBP = FindObjectOfType<Re_Back_Point>();
            JBP.Re_();

            GameManager.Instance.Re_Back_Setting();
            RSF = FindObjectOfType<Re_Start_Fade>();
            RSF.Start_Back();
        }
    }
    public void Get_Player(Player t_player)
    {
        Player = t_player.gameObject;
    }
    public void Get_Flashlight(Flashlight t_flash)
    {
        flashlight = t_flash;
    }
}
