using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_Doll : MonoBehaviour
{
    [SerializeField]
    private GameObject Doll = null;

    [SerializeField]
    private GameObject FlashLight = null;

    [SerializeField]
    private GameObject Hammer = null;

    [SerializeField]
    private GameObject Fragment = null;

    [SerializeField]
    private GameObject Remote = null;

    Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();

        try
        {
            Doll.SetActive(false);
        }
        catch (NullReferenceException) { }
        try
        {
            FlashLight.SetActive(false);
        }
        catch (NullReferenceException) { }
        try
        {
            Hammer.SetActive(false);
        }
        catch (NullReferenceException) { }
        try
        {
            Fragment.SetActive(false);  
        }
        catch(NullReferenceException) { }
        try
        {
            Remote.SetActive(false);
        }
        catch (NullReferenceException) { }
    }
    void Update()
    {
        if (player.DollGet)
        {
            try
            {
                Doll.SetActive(true);
            }
            catch (NullReferenceException) { }
        }
        else
            try
            {
                Doll.SetActive(false);
            }
            catch (NullReferenceException) { }

        if (player.FlashGet)
        {
            try
            {
                FlashLight.SetActive(true);
            }
            catch (NullReferenceException) { }
        }
        else
            try
            {
                FlashLight.SetActive(false);
            }
            catch (NullReferenceException) { }

        if (player.HammerGet)
        {
            try
            {
                Hammer.SetActive(true);
            }
            catch (NullReferenceException) { }
        }
        else
            try
            {
                Hammer.SetActive(false);
            }
            catch (NullReferenceException) { }

        if (player.FragmentGet)
        {
            try
            {
                Fragment.SetActive(true);
            }
            catch (NullReferenceException) { }
        }
        else
            try
            {
                Fragment.SetActive(false);
            }
            catch (NullReferenceException) { }

        if (player.RemoteGet)
        {
            try
            {
                Remote.SetActive(true);
            }
            catch (NullReferenceException) { }
        }
        else
            try
            {
                Remote.SetActive(false);
            }
            catch (NullReferenceException) { }
    }
}
