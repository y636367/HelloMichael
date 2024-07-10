using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_Child : MonoBehaviour
{
    [SerializeField]
    private GameObject Parent;

    public void Seperate()
    {
        this.gameObject.transform.SetParent(null);
    }
    public void Join()
    {
        this.transform.parent = Parent.transform;
    }
}
