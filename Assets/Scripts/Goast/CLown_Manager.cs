using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLown_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Boxes = null;
    [SerializeField]
    private GameObject[] clowns = null;

    private GameObject Now_On = null;
    private GameObject priveous = null;

    public bool Start = false;
    private bool Time_On = false;

    private float TImer = 0f;

    private float Hold_Range = 0f;

    public int Count = 1;

    private float hold_timer = 0f;
    private bool hold = false;

    private float hold_time;

    Player player;
    private void Awake()
    {
        hold_time = Random.Range(3, 8);
        player=FindObjectOfType<Player>();
    }
    public void Re_Setting()
    {
        TImer = 0f;
        Count += 1;
        priveous = Now_On;
        Time_On = false;
        hold = true;
    }
    void Update()
    {
        if (!GameManager.Instance.Option_||!player.death)
        {
            if (Start == true && !Time_On && !hold)
            {
                Boxes_Random();
            }

            if (Time_On == true)
            {
                TImer += Time.deltaTime;

                if (TImer >= Hold_Range)
                {
                    TImer = 0f;
                    Count += 1;
                    priveous = Now_On;
                    Now_On.SetActive(false);
                    Time_On = false;
                }
            }

            if (hold)
            {
                hold_timer += Time.deltaTime;

                if (hold_timer >= hold_time)
                {
                    hold = false;
                    hold_timer = 0f;
                    hold_time = Random.Range(3, 8);
                }
            }
        }
    }
    private void Boxes_Random()
    {
        while (Count != 0)
        {
            for (int i = 0; i < Boxes.Length; i++)
            {
                int k = Random.Range(0, 4);
                if (Count != 0 && k == 1 && Boxes[i].activeSelf != true)
                {
                    if (Boxes[i] != priveous)
                    {
                        Boxes[i].SetActive(true);
                        clowns[i].GetComponent<CLown_Box>().Check = true;
                        Count -= 1;
                        Hold_Range = Random.Range(20, 46);
                    }
                    Now_On = Boxes[i];
                    Time_On = true;
                }
            }
        }
    }
    public void Stop_Game()
    {
        Start = false;

        for (int i = 0; i < Boxes.Length; i++)
        {
            Boxes[i].SetActive(false);
        }
    }
}
