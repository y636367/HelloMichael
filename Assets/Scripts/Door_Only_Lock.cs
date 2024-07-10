using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Only_Lock : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Doors = null;

    public void Lock_only()
    {
        for(int i=0;i<Doors.Length;i++)
        {
            Doors[i].GetComponent<Door>().Re = false;
            Doors[i].GetComponent<Door>().Count = 0;
        }
    }
    public void UnLock()
    {
        Doors[0].GetComponent<Door>().Lock = false;
    }
}
