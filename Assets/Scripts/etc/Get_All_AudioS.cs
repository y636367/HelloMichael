using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_All_AudioS : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] audioSource;

    private void Awake()
    {
        Invoke("GetUP", 1.2f);
    }
    private void GetUP()
    {
        for(int i=0; i<audioSource.Length; i++)
        {
            audioSource[i].enabled = true;
        }
    }
}
