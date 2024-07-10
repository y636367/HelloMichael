using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Data : MonoBehaviour
{
    private float Timer_data;
    private int Battery_data;

    private Transform Player_Data_1;
    private Quaternion Player_Data_2;

    [SerializeField]
    private Flashlight flashlight;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform Head;

    Re_data re_data;

    private void Awake()
    {
        re_data = FindObjectOfType<Re_data>();
        flashlight = FindObjectOfType<Flashlight>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Get_Battery_Data() ;
            Get_Player_Data() ;

            re_data.Set_On_Battery(Timer_data, Battery_data);
            re_data.Set_On_Player(Player_Data_1,Player_Data_2);

            GameManager.Instance.Save_Point = true;
            GameManager.Instance.Back_Point = false;

            Destroy(this.gameObject);
        }
    }
    private void Get_Battery_Data()
    {
        Battery_data = flashlight.Battery_Count;
        Timer_data = flashlight.Flash_Timer;
    }
    private void Get_Player_Data()
    {
        Player_Data_1 = player.transform;
        Player_Data_2 = Head.transform.localRotation;
    }
}
