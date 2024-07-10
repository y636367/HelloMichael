using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_s : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Lighting = null;

    [SerializeField]
    private GameObject[] Cover = null;

    [SerializeField]
    public bool on_off = true;

    public bool Lock;

    public bool Lamp;

    Light_s t_light;

    [Header("Sounds")]
    [SerializeField]
    private AudioClip light_Switch_On;
    [SerializeField]
    private AudioClip light_Switch_Off;
    [SerializeField]
    private AudioSource Light_Switch_On;
    [SerializeField]
    private AudioSource Light_Switch_Off;

    void Awake()
    {
        if (!this.Lamp)
        {
            for (int i = 0; i < Cover.Length; i++)
            {
                Cover[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < Cover.Length; i++)
            {
                Cover[i].SetActive(true);
            }
        }

        Light_Switch_On=GetComponent<AudioSource>();
        Light_Switch_Off=GetComponent<AudioSource>();

        Light_Switch_On.clip = this.light_Switch_On;
        Light_Switch_Off.clip = this.light_Switch_Off;
    }
    public void LightCheck()
    {
        if (!t_light.Lock)
        {
            if (t_light.on_off == true)
            {
                t_light.Light_Switch_Off.PlayOneShot(t_light.light_Switch_Off);
                LightOff();
            }
            else
            {
                t_light.Light_Switch_On.PlayOneShot(t_light.light_Switch_On);
                LightOn();
            }
        }else
            t_light.Light_Switch_On.PlayOneShot(t_light.light_Switch_On);
    }
    private void LightOn()
    {
        for (int i = 0; i < t_light.Lighting.Length; i++)
        {
            t_light.Cover[i].SetActive(false);
            t_light.Lighting[i].SetActive(true);
        }
            t_light.on_off = true;
    }
    private void LightOff()
    {
        for (int i = 0; i < t_light.Lighting.Length; i++)
        {
            t_light.Cover[i].SetActive(true);
            t_light.Lighting[i].SetActive(false);
        }
            t_light.on_off= false;
    }
    public void this_light(RaycastHit hit)
    {
        t_light=hit.collider.GetComponent<Light_s>();
    }
    public void t_this_light(Light_s t_l)
    {
        t_light = t_l;
    }
}
