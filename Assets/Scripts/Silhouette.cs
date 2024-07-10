using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silhouette : MonoBehaviour
{
    [SerializeField]
    private GameObject[] silhoueets = null;

    public void On()
    {
        for(int i=0;i<silhoueets.Length;i++)
        {
            silhoueets[i].SetActive(true);
        }
    }
}
