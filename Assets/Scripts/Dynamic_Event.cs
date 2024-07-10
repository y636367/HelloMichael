using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic_Event : MonoBehaviour
{
    [SerializeField]
    private int num;

    Dynamic_Objects DO;

    void Awake()
    {
        DO=FindObjectOfType<Dynamic_Objects>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (this.num == 0)
            {
                Debug.Log("All_Off_Lights");
                DO.All_Lights_Off();
            }
            else if(this.num == 1)
            {
                Debug.Log("All_On_Lights");
                DO.All_Lights_On();
            }
            else if (this.num == 2)
            {
                Debug.Log("All_Doors_Open");
                DO.All_Doors_Open();
            }
            else if (this.num==3)
            {
                Debug.Log("All_Doors_Close");
                DO.All_Doors_Close();
            }
            else if(this.num==4)
            {
                Debug.Log("All_Doors_UnLock");
                DO.All_Doors_UnLock();
            }
            else if (this.num == 5)
            {
                Debug.Log("Light_UnLock");
                DO.Light_UnLock();
            }
            else if (this.num == 6)
            {
                Debug.Log("Twinkl");
                DO.this_t(this.gameObject);
                StartCoroutine(DO.twinkl_Off());
            }
            else if(this.num==7)
            {
                Debug.Log("Last_Door");
                DO.Last_Door();
            }
        }
    }
}
