using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break_Doll : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Pieces = null;

    void Awake()
    {
        for(int i=0;i<Pieces.Length; i++)
        {
            Pieces[i].GetComponent<Rigidbody>().useGravity = false;
        }
    }
    public void OnCrash()
    {
        for (int i = 0; i < Pieces.Length; i++)
        {
            Pieces[i].GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
