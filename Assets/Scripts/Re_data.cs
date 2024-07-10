using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Re_data : MonoBehaviour
{
    public float t_Timer_data;
    public int t_Battery_data;

    public Transform t_player_data_1;
    public Quaternion t_player_data_2;

    public Vector3 t_player_data_Position;

    [SerializeField]
    public GameObject Position = null;

    public void Set_On_Battery(float time, int count)
    {
        t_Timer_data = time;
        t_Battery_data = count;
    }
    public void Set_On_Player(Transform t_1,Quaternion t_2)
    {
        t_player_data_1=t_1;
        t_player_data_2=t_2;

        t_player_data_Position = t_player_data_1.transform.position;

        Position.transform.localPosition = t_player_data_Position;
        Position.transform.localRotation = t_player_data_2;
    }
    public void Set_Position_Object()
    {
        Position = GameObject.FindGameObjectWithTag("Re_Position");
    }
}
