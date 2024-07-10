using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Data : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] Sounds_Off;

    private void Awake()
    {
        for (int i = 0; i < Sounds_Off.Length; i++)
        {
            Sounds_Off[i].enabled = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.player=other.GetComponent<Player>();
            GameManager.Instance.Object_list_match();
        }
    }
}
