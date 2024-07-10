using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    [SerializeField]
    private GameObject On = null;

    public void Object_On()
    {
        this.On.SetActive(true);  
    }
}
