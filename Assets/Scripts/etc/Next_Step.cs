using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next_Step : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Next;

    [SerializeField]
    private GameObject[] Destroys;

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < Next.Length; i++)
            Next[i].SetActive(true);

        for (int i=0;i< Destroys.Length; i++)
        {
            try
            {
                Destroy(Destroys[i]);
            }catch(NullReferenceException) { }
        }
    }
}
