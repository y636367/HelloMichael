using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batterys : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Battery = null;

    public int Count = 3;
    private int P_Count;

    private int Get_battery_num;
    private int Get_floor_num;

    private int P_floor = 0;
    private int P_Count_t = 2;

    private int Start_Battery_Numbering;
    void Awake()
    {
        if (OptionManager.Instance.Difficulty)
        {
            Count = 3;
            P_Count = Count;
        }
        else
        {
            Count = 5;
            P_Count = Count;
        }

        Start_Battery_Numbering = Random.Range(0,Battery.Length-1);

        StartCoroutine(Battery_Random_On());
    }
    public IEnumerator Battery_Random_On()
    {
        while (Count != 0)
        {
            for (int i = Start_Battery_Numbering; i < Battery.Length; i++)
            {
                int k = Random.Range(0, 4);
                if (Count != 0 && k == 1 && Battery[i].activeSelf != true &&
                    Get_battery_num != Battery[i].GetComponent<Battery_numbering>().numbering&&
                    Get_floor_num!= Battery[i].GetComponent<Battery_numbering>().floor)
                {
                    if (Battery[i].GetComponent<Battery_numbering>().floor != P_floor)
                    {
                        Count--;
                        Battery[i].SetActive(true);
                        P_floor = Battery[i].GetComponent<Battery_numbering>().floor;
                    }
                }
            }
            yield return null;
        }
    }
    public void Stop_Battery()
    {
        for(int i=0;i<Battery.Length;i++)
        {
            Battery[i].SetActive(false);
        }
        Count = P_Count;
        StopCoroutine(Battery_Random_On());
    }
    public void Start_Battery()
    {
        Start_Battery_Numbering = Random.Range(0, Battery.Length-1);
        StartCoroutine(Battery_Random_On());
    }
    public void Get_Battery_num(int t_num)
    {
        Get_battery_num = t_num;
    }
    public void Get_Floor_num(int t_num)
    {
        if (t_num == -2)
            first_battery();

        Get_floor_num = t_num;
    }
    private void first_battery()
    {
        if (P_Count_t != 0)
        {
            P_Count_t -= 1;
            P_Count += 1;
        }
    }
}
