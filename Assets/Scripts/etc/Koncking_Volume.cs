using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koncking_Volume : MonoBehaviour
{
    [SerializeField]
    private GameObject Knocking_o;
    [SerializeField]
    private AudioSource Knocking;

    [SerializeField]
    private float t_volume;

    [SerializeField]
    private float maxdistance;

    [SerializeField]
    private bool D = false;
    private void Awake()
    {
        Knocking=Knocking_o.GetComponent<AudioSource>();
    }
    private void LateUpdate()
    {
        if (GameManager.Instance.Option_)
        {
            Knocking.enabled = false;
        }
        else
        {
            Knocking.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!D)
            Set_Volume();
        else
        {
            Set_Volume();
            Set_Distance();
        }
    }
    private void Set_Volume()
    {
        Knocking.enabled = true;
        Knocking.volume=t_volume;
    }
    private void Set_Distance()
    {
        Knocking.enabled = true;
        Knocking.maxDistance = maxdistance;
    }
}
