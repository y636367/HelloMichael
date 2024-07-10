using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic_Objects : MonoBehaviour
{
    [SerializeField]
    private Door[] doors = null;

    [SerializeField]
    private Door Last_door = null;

    [SerializeField]
    private Chest[] chests = null;

    [SerializeField]
    private Pantry[] pantrys = null;

    [SerializeField]
    private Cabinet_Bottom[] cabinets = null;

    [SerializeField]
    private Light_s[] lights = null;

    [SerializeField]
    private GameObject t_d = null;

    [SerializeField]
    private GameObject Darker;
    [SerializeField]
    private GameObject Lighter;

    public int Count = 0;
    public void All_Doors_Open() //2
    {
        for(int i=0;i<doors.Length;i++)
        {
            if (!doors[i].open)
            {
                doors[i].t_this_door(doors[i]);
                doors[i].DoorAnime();
            }
        }
    }
    public void All_Doors_Close() //3
    {
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].open)
            {
                doors[i].t_this_door(doors[i]);
                doors[i].DoorAnime();
                doors[i].Lock = true;
            }
        }
    }
    public void All_Doors_UnLock() //4
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].t_this_door(doors[i]);
            if (doors[i] != Last_door)
                doors[i].Lock = false;
        }
    }
    public void Last_Door() //7
    {
        Last_door.Lock= false;

        if (!Last_door.open)
        {
            Last_door.DoorAnime();
        }
    }
    public void All_Pantry_Close()
    {
        for (int i = 0; i < pantrys.Length; i++)
        {
            if (pantrys[i].open)
            {
                pantrys[i].t_this_Pantry(pantrys[i]);
                pantrys[i].PantryAnime();
            }
        }
    }
    public void All_Chest_Close()
    {
        for (int i = 0; i < chests.Length; i++)
        {
            if (chests[i].open)
            {
                chests[i].t_this_Chest(chests[i]);
                chests[i].ChestAnime();
            }
        }
    }
    public void All_Cabinet_Close()
    {
        for (int i = 0; i < cabinets.Length; i++)
        {
            if (cabinets[i].open)
            {
                cabinets[i].t_this_Cabinet(cabinets[i]);
                cabinets[i].CabinetAnime();
            }
        }
    }
    public void All_Lights_On() //1
    {
        for(int i=0;i<lights.Length;i++)
        {
            if (!lights[i].on_off)
            {
                lights[i].t_this_light(lights[i]);
                lights[i].Lock = false;
                if (!lights[i].Lamp)
                    lights[i].LightCheck();
            }
        }
        Lighter_ON();
    }
    public void All_Lights_Off() //0
    {
        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i].on_off)
            {
                lights[i].t_this_light(lights[i]);
                lights[i].LightCheck();
            }
                lights[i].Lock = true;
        }
        Darker_ON();
    }
    public void Light_UnLock() //5
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].t_this_light(lights[i]);
            lights[i].Lock = false;
        }
    }
    public IEnumerator twinkl_Off() //6
    {
        yield return new WaitForSeconds(0.1f);

        All_Lights_Off();

        Count += 1;

        if (Count == 3)
        {
            Count = 0;
            All_Lights_On();
            StopCoroutine(twinkl_Off());
            t_d.SetActive(false);
        }
        else
            StartCoroutine(twinkl_On());
    }
    IEnumerator twinkl_On()
    {
        yield return new WaitForSeconds(0.2f);

        All_Lights_On();

        StartCoroutine(twinkl_Off());
    }
    public void Darker_ON()
    {
        Darker.SetActive(true);
        Lighter.SetActive(false);
    }
    public void Lighter_ON()
    {
        Darker.SetActive(false);
        Lighter.SetActive(true);
    }
    public void this_t(GameObject t_this)
    {
        t_d=t_this;
    }
}
