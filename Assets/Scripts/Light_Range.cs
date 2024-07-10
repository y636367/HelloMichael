using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Light_Range : MonoBehaviour
{
    private Light light;
    private float distance = 0;

    void Awake()
    {
        light = GetComponent<Light>();
    }
    void Update()
    {
        Range_set(distance);
    }

    private void Range_set(float t_d)
    {
        float real_distance = 0;

        real_distance = t_d;

        if (t_d <= 1 && t_d > 0)
        {
            real_distance = 1f;
        }
        else if (t_d <= 0)
        {
            real_distance = 5f;
        }

        light.intensity = real_distance;
    }
    public void light_Range(float t_d)
    {
        distance= t_d;
    }
}
