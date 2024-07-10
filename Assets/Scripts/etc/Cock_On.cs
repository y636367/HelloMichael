using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cock_On : MonoBehaviour
{
    [SerializeField]
    private Cockroachs t_Cock;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            t_Cock.On_Anima();
        }
    }
}
