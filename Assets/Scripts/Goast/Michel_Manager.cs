using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Michel_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Michels = null;

    private GameObject Now_On = null;
    private GameObject priveous = null;

    public bool Start = false;
    private bool Time_On = false;

    private float TImer = 0f;

    public int Count = 1;

    private float hold_timer = 0f;
    private bool hold = false;

    [SerializeField]
    private float hold_time;

    private float Wait_Time;

    Player player;

    private void Awake()
    {
        Wait_Time=Random.Range(20,30);
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        if (!GameManager.Instance.Option_&&!player.death)
        {
            if (Start == true && Time_On != true && hold != true)
            {
                Michel_Random();
            }

            if (Time_On == true)
            {
                TImer += Time.deltaTime;

                if (TImer >= Wait_Time)
                {
                    TImer = 0f;
                    Count += 1;
                    priveous = Now_On;
                    Now_On.SetActive(false);
                    Time_On = false;
                    Wait_Time = Random.Range(20, 30);
                }
            }

            if (hold != false)
            {
                hold_timer += Time.deltaTime;

                if (hold_timer >= hold_time)
                {
                    hold = false;
                    hold_timer = 0f;
                }
            }
        }
    }
    public void Re_Setting()
    {
        TImer = 0f;
        Count += 1;
        priveous = Now_On;
        Time_On = false;
        hold = true;
    }
    private void Michel_Random()
    {
        while (Count != 0)
        {
            for (int i = 0; i < Michels.Length; i++)
            {
                int k = Random.Range(0, 4);
                if (Count != 0 && k == 1 && Michels[i].activeSelf != true)
                {
                    if (Michels[i] != priveous)
                    {
                        Michels[i].SetActive(true);
                        Count -= 1;
                    }
                    Now_On = Michels[i];
                    Time_On = true;
                }
            }
        }
    }
    public void Stop_Game()
    {
        Start = false;

        for (int i = 0; i < Michels.Length; i++)
        {
            Michels[i].SetActive(false);
        }
    }
}
