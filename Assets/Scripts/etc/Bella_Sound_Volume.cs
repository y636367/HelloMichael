using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bella_Sound_Volume : MonoBehaviour
{
    [SerializeField]
    private Bella bella;

    [SerializeField]
    private float t_volume;

    [SerializeField]
    private float maxdistance;

    [SerializeField]
    private bool Second_Floor = false;
    [SerializeField]
    private bool Middle_Floor = false;
    private void OnTriggerEnter(Collider collider)
    {
        if (!Second_Floor)
            Set_Volume();
        else
            Set_Distance();

        if(Middle_Floor)
        {
            Set_Volume();
            Set_Distance();
        }
    }
    private void Set_Volume()
    {
        bella.GetComponent<AudioSource>().enabled=true;
        bella.GetComponent<AudioSource>().volume = t_volume;
    }
    private void Set_Distance()
    {
        bella.GetComponent<AudioSource>().enabled = true;
        bella.GetComponent<AudioSource>().maxDistance = maxdistance;
    }
}
